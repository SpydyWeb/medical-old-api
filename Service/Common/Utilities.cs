using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Service.Common
{
	public class Utilities
	{
		public static byte[] ConvertIFormFileToByte(ICollection<IFormFile> uploadedFiles)
		{
			byte[] bytes = null;
			foreach (IFormFile file in uploadedFiles)
			{
				using StreamReader reader = new StreamReader(file.OpenReadStream());
				using MemoryStream memstream = new MemoryStream();
				reader.BaseStream.CopyTo(memstream);
				bytes = memstream.ToArray();
			}
			return bytes;
		}

		public static async Task<List<string>> UploadAttachment(ICollection<IFormFile> fileCollection)
		{
			try
			{
				List<string> result = new List<string>();
				string strFolderPath = SharedSettings.AttachmentsPath;
				if (!Directory.Exists(strFolderPath))
				{
					Directory.CreateDirectory(strFolderPath);
				}
				foreach (IFormFile file in fileCollection)
				{
					string filePath = Path.Combine(strFolderPath, file.FileName);
					Task<string> task = Task.Run(delegate
					{
						using (FileStream target = new FileStream(filePath, FileMode.Create))
						{
							file.CopyTo(target);
						}
						return file.FileName;
					});
					await task;
					result.Add(Path.Combine(strFolderPath, task.Result.ToString()));
				}
				return result;
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				_ = ex.Message;
				return null;
			}
		}

		public static bool TryParse<T>(string value, out T result)
		{
			try
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
				if (converter != null && converter.IsValid(value))
				{
					result = (T)converter.ConvertFromString(value);
					return true;
				}
				result = default(T);
				return false;
			}
			catch
			{
				result = default(T);
				return false;
			}
		}

		public static string GetBodyUnderWrintingTemplate(dynamic obj)
		{
			try
			{
				string emailTemplate = string.Empty;
				emailTemplate = File.ReadAllText(Directory.GetCurrentDirectory() + "\\templates\\UnderwriterEmailTemplate.html");
				emailTemplate = emailTemplate.Replace("||RiskSerial||", obj.RiskSerial);
				emailTemplate = emailTemplate.Replace("||PlateNo||", obj.PlateNo);
				emailTemplate = emailTemplate.Replace("||ChassisNo||", obj.ChassisNo);
				emailTemplate = emailTemplate.Replace("||PolicyNo||", obj.PolicyNo);
				return emailTemplate.Replace("||EffectiveDate||", obj.EffectiveDate);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static string SendWebRequest(ref int StatusCode, string webURL, HttpMethodType methodType, ILogger _Logger, object dataObj = null, string[] header = null, string auth = null, string LogType = null, bool encodeAuth = true, string contentType = "application/json", bool UseSSL = false)
		{
			string requestData = string.Empty;
			string responseData = string.Empty;
			string webErrorResponse = string.Empty;
			try
			{
				if (UseSSL)
				{
					ServicePointManager.Expect100Continue = true;
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				}
				HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(webURL);
				webRequest.Method = methodType.ToString("f");
				webRequest.Accept = contentType;
				if (!string.IsNullOrEmpty(auth))
				{
					webRequest.Headers.Add("Authorization", auth);
					webRequest.PreAuthenticate = true;
				}
				switch (methodType)
				{
				case HttpMethodType.POST:
				case HttpMethodType.PUT:
				{
					requestData = (contentType.Equals("application/json") ? JsonConvert.SerializeObject(dataObj) : dataObj.ToString());
					webRequest.ContentType = contentType;
					using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
					{
						streamWriter.Write(requestData);
						streamWriter.Flush();
						streamWriter.Close();
					}
					break;
				}
				}
				using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
				{
					if ((methodType == HttpMethodType.POST || methodType == HttpMethodType.GET || methodType == HttpMethodType.DELETE) && response.StatusCode == HttpStatusCode.OK)
					{
						StatusCode = 200;
						goto IL_01cf;
					}
					if (methodType == HttpMethodType.PUT && response.StatusCode == HttpStatusCode.Created)
					{
						StatusCode = 201;
						goto IL_01cf;
					}
					if (methodType != HttpMethodType.DELETE || (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent))
					{
						StatusCode = 400;
						goto IL_01cf;
					}
					responseData = response.StatusCode.GetHashCode().ToString();
					goto end_IL_011d;
					IL_01cf:
					using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
					{
						responseData = streamReader.ReadToEnd();
					}
					goto IL_0206;
					end_IL_011d:;
				}
				goto end_IL_0013;
				IL_0206:
				_Logger.LogInformation("URL: " + webURL + Environment.NewLine + "Auth: " + auth + Environment.NewLine + "Request Data: " + requestData + Environment.NewLine + "Response Data: " + webErrorResponse + Environment.NewLine);
				end_IL_0013:;
			}
			catch (WebException ex2)
			{
				if (ex2.Response != null)
				{
					using HttpWebResponse errorResponse = (HttpWebResponse)ex2.Response;
					using StreamReader reader = new StreamReader(errorResponse.GetResponseStream());
					webErrorResponse = reader.ReadToEnd();
				}
				_Logger.LogInformation("URL: " + webURL + Environment.NewLine + "Auth: " + auth + Environment.NewLine + "Request Data: " + requestData + Environment.NewLine + "Response Data: " + webErrorResponse + Environment.NewLine + ex2.Message + Environment.NewLine + ex2.StackTrace + Environment.NewLine);
				responseData = webErrorResponse;
			}
			catch (Exception ex)
			{
				_Logger.LogInformation("URL: " + webURL + Environment.NewLine + "Auth: " + auth + Environment.NewLine + "Request Data: " + requestData + Environment.NewLine + "Response Data: " + responseData + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
			}
			return responseData;
		}

		private static byte[] ConvertToBase64(string FilePath)
		{
			using FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
			byte[] bytes = File.ReadAllBytes(FilePath);
			fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
			fs.Close();
			return bytes;
		}

		public static string YAKEENPWD()
		{
			return "y4s@798";
		}

		public static string YAKEENUSERNAME()
		{
			return "SOLIDARITY_PROD";
		}

		public static string YAKEENPROD()
		{
			return "PROD";
		}

		public static int AgeCalculation(DateTime DOB)
		{
			int Age = 0;
			if (DOB.Month > DateTime.Today.Month)
			{
				Age = DateTime.Now.Year - DOB.Year;
			}
			if (DOB.Month == DateTime.Now.Month && DOB.Day > DateTime.Now.Day)
			{
				Age = DateTime.Now.Year - DOB.Year - 1;
			}
			if (DOB.Month == DateTime.Now.Month && DOB.Day <= DateTime.Now.Day)
			{
				Age = DateTime.Now.Year - DOB.Year;
			}
			if (DOB.Month < DateTime.Now.Month)
			{
				Age = DateTime.Now.Year - DOB.Year - 1;
			}
			return Age;
		}

		public static string Decryption(string hashed)
		{
			byte[] bytesToBeDecrypted = Convert.FromBase64String(hashed.Replace("-", "+"));
			byte[] passwordBytesdecrypt = Encoding.UTF8.GetBytes("XBM##@@" + DateTime.Today.Year + "$$");
			byte[] passwordBytes = Encoding.UTF8.GetBytes("XBM##@@" + DateTime.Today.Year + "$$");
			passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
			passwordBytesdecrypt = SHA256.Create().ComputeHash(passwordBytesdecrypt);
			byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
			return Encoding.UTF8.GetString(bytesDecrypted);
		}

		public static string EskaConnection()
		{
			return "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 10.0.12.152)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = sstcdbtest)));User ID=Imedical;Password=imedical;";
		}

		public static int DecryptionNo(int num)
		{
			return DateTime.Now.Year - num;
		}

		public static int EncryptNo(int num)
		{
			return DateTime.Now.Year + num;
		}

		public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
		{
			byte[] encryptedBytes = null;
			byte[] saltBytes = new byte[8] { 2, 1, 7, 3, 6, 4, 8, 5 };
			using (MemoryStream ms = new MemoryStream())
			{
				using RijndaelManaged AES = new RijndaelManaged();
				AES.KeySize = 256;
				AES.BlockSize = 128;
				Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
				AES.Key = key.GetBytes(AES.KeySize / 8);
				AES.IV = key.GetBytes(AES.BlockSize / 8);
				AES.Mode = CipherMode.CBC;
				using (CryptoStream cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
				{
					cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
					cs.Close();
				}
				encryptedBytes = ms.ToArray();
			}
			return encryptedBytes;
		}

		public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
		{
			byte[] decryptedBytes = null;
			byte[] saltBytes = new byte[8] { 2, 1, 7, 3, 6, 4, 8, 5 };
			using (MemoryStream ms = new MemoryStream())
			{
				using RijndaelManaged AES = new RijndaelManaged();
				AES.KeySize = 256;
				AES.BlockSize = 128;
				Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
				AES.Key = key.GetBytes(AES.KeySize / 8);
				AES.IV = key.GetBytes(AES.BlockSize / 8);
				AES.Mode = CipherMode.CBC;
				using (CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
				{
					cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
					cs.Close();
				}
				decryptedBytes = ms.ToArray();
			}
			return decryptedBytes;
		}

		public static string Encrypt(string phrase)
		{
			byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(phrase);
			byte[] passwordBytes = Encoding.UTF8.GetBytes("XBM##@@" + DateTime.Today.Year + "$$");
			passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
			byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
			return Convert.ToBase64String(bytesEncrypted);
		}

		public static DateTime ConvertDate(string dr)
		{
			try
			{
				try
				{
					return DateTime.ParseExact(dr, "dd-MM-yyyy", CultureInfo.InvariantCulture);
				}
				catch (Exception)
				{
					try
					{
						return Convert.ToDateTime(dr);
					}
					catch (Exception)
					{
						try
						{
							return DateTime.ParseExact(dr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
						}
						catch
						{
							return DateTime.ParseExact(dr, "MM/dd/yyyy", CultureInfo.InvariantCulture);
						}
					}
				}
			}
			catch (Exception)
			{
				try
				{
					return DateTime.ParseExact(dr, "dd-MM-yyyy", CultureInfo.InvariantCulture);
				}
				catch (Exception)
				{
					return DateTime.ParseExact(dr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
				}
			}
		}
	}
}
