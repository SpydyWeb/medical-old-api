using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Newtonsoft.Json;

namespace Service.Services
{
	public class BaseTPService
	{
		protected readonly HttpClient client;

		public BaseTPService(HttpClient client)
		{
			this.client = client;
			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Add("Accept", "application/json;profile=PascalCase;charset=utf-8");
			this.client.DefaultRequestHeaders.TransferEncodingChunked = false;
		}

		public async Task<IEnumerable<T>> GetListFrom<T>(string baseAddress, string url, string authToken = null)
		{
			string request = baseAddress + url;
			WriteLog(request + " : start");
			List<T> list = new List<T>();
			try
			{
				if (!string.IsNullOrEmpty(authToken))
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
				}
				Uri urirequest = new Uri(request);
				WriteLog(request + " : start using ");
				try
				{
					WriteLog("start url" + request);
					using HttpResponseMessage response = await client.GetAsync(urirequest);
					WriteLog("END url" + request);
					if (response.IsSuccessStatusCode)
					{
						WriteLog(request + " : Begin Result");
						using HttpContent content = response.Content;
						list = JsonConvert.DeserializeObject<List<T>>(await content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
						WriteLog(request + " : result");
					}
				}
				catch (Exception ex2)
				{
					WriteLog(request + "  " + ex2.Message);
				}
			}
			catch (Exception ex3)
			{
				Exception ex = ex3;
				WriteLog(request + "  " + ex.Message);
			}
			WriteLog(request + " : END");
			return list;
		}

		public async Task<T> GetFrom<T>(string baseAddress, string url, string authToken = null)
		{
			string request = baseAddress + url;
			object obj = Activator.CreateInstance(typeof(T));
			try
			{
				WriteLog(request + " : start");
				if (!string.IsNullOrEmpty(authToken))
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
				}
				Uri urirequest = new Uri(request);
				try
				{
					WriteLog("start url" + request);
					using HttpResponseMessage response = await client.GetAsync(urirequest).ConfigureAwait(continueOnCapturedContext: false);
					WriteLog("END url" + request);
					if (response.IsSuccessStatusCode)
					{
						WriteLog(request + " : Begin Result");
						using HttpContent content = response.Content;
						obj = JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
						WriteLog(request + " : End Result");
					}
				}
				catch (Exception ex2)
				{
					WriteLog(request + "  " + ex2.Message);
				}
			}
			catch (Exception ex3)
			{
				Exception ex = ex3;
				WriteLog(request + "  " + ex.Message);
			}
			WriteLog(request + " : END");
			return (T)obj;
		}

		public async Task<T> GetFromResponseResult<T>(string baseAddress, string url, string authToken = null)
		{
			string request = baseAddress + url;
			object obj = Activator.CreateInstance(typeof(T));
			try
			{
				if (!string.IsNullOrEmpty(authToken))
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
				}
				WriteLog(request + " : start");
				Uri urirequest = new Uri(request);
				try
				{
					WriteLog("start url" + request);
					using HttpResponseMessage response = await client.GetAsync(urirequest).ConfigureAwait(continueOnCapturedContext: false);
					WriteLog("END url" + request);
					if (response.IsSuccessStatusCode)
					{
						WriteLog(request + " : Begin Result");
						using HttpContent content = response.Content;
						obj = JsonConvert.DeserializeObject<ResponseResult<T>>(await content.ReadAsStringAsync()).Data;
						WriteLog(request + " : End Result");
					}
				}
				catch (Exception ex2)
				{
					WriteLog(request + "  " + ex2.Message);
				}
			}
			catch (Exception ex3)
			{
				Exception ex = ex3;
				WriteLog(request + "  " + ex.Message);
			}
			WriteLog(request + " : END");
			return (T)obj;
		}

		public async Task<IEnumerable<T>> PostListFrom<T>(string baseAddress, string url, HttpContent content)
		{
			List<T> list = null;
			string request = baseAddress + url;
			WriteLog(request + " : start");
			try
			{
				Uri urirequest = new Uri(request);
				WriteLog("start url" + request);
				HttpResponseMessage response = await client.PostAsync(urirequest, content).ConfigureAwait(continueOnCapturedContext: false);
				WriteLog("END url" + request);
				if (response.IsSuccessStatusCode)
				{
					WriteLog(request + " : Begin Result");
					list = JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync());
					WriteLog(request + " : End Result");
				}
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				WriteLog(request + "  " + ex.Message);
			}
			return list;
		}

		public async Task<T> PostFrom<T>(string baseAddress, string url, string requestbody, string authToken = null)
		{
			object obj = Activator.CreateInstance(typeof(T));
			string request = baseAddress + url;
			WriteLog(request + " : start");
			try
			{
				if (!string.IsNullOrEmpty(authToken))
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
				}
				Uri urirequest = new Uri(request);
				StringContent stringContent = new StringContent(requestbody, Encoding.UTF8, "application/json");
				WriteLog("start url" + request);
				using (HttpResponseMessage response = await client.PostAsync(urirequest, stringContent).ConfigureAwait(continueOnCapturedContext: false))
				{
					using HttpContent content = response.Content;
					string json = content.ReadAsStringAsync().Result;
					WriteLog(json + " : Begin Result");
					if (response.IsSuccessStatusCode)
					{
						obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
						WriteLog(request + " : End Result");
					}
				}
				WriteLog("END url" + request);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				WriteLog(request + "  " + ex.Message);
			}
			return (T)obj;
		}

		public async Task<T> PostFromResponseResult<T>(string baseAddress, string url, string requestbody, string authToken = null)
		{
			object obj = Activator.CreateInstance(typeof(T));
			string request = baseAddress + url;
			WriteLog(request + " : start");
			try
			{
				if (!string.IsNullOrEmpty(authToken))
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
				}
				Uri urirequest = new Uri(request);
				StringContent stringContent = new StringContent(requestbody, Encoding.UTF8, "application/json");
				WriteLog("start url" + request);
				using (HttpResponseMessage response = await client.PostAsync(urirequest, stringContent).ConfigureAwait(continueOnCapturedContext: false))
				{
					using HttpContent content = response.Content;
					string json = content.ReadAsStringAsync().Result;
					WriteLog(json + " : Begin Result");
					if (response.IsSuccessStatusCode)
					{
						obj = JsonConvert.DeserializeObject<ResponseResult<T>>(await response.Content.ReadAsStringAsync()).Data;
						WriteLog(request + " : End Result");
					}
				}
				WriteLog("END url" + request);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				WriteLog(request + "  " + ex.Message);
			}
			return (T)obj;
		}

		public async Task<T> PutFrom<T>(string baseAddress, string url, string requestbody)
		{
			object obj = Activator.CreateInstance(typeof(T));
			string request = baseAddress + url;
			WriteLog(request + " : start");
			try
			{
				Uri urirequest = new Uri(request);
				StringContent stringContent = new StringContent(requestbody, Encoding.UTF8, "application/json");
				WriteLog("start url" + request);
				using (HttpResponseMessage response = await client.PutAsync(urirequest, stringContent).ConfigureAwait(continueOnCapturedContext: false))
				{
					using HttpContent content = response.Content;
					string json = content.ReadAsStringAsync().Result;
					WriteLog(json + " : Begin Result");
					if (response.IsSuccessStatusCode)
					{
						obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
						WriteLog(request + " : End Result");
					}
				}
				WriteLog("END url" + request);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				WriteLog(request + "  " + ex.Message);
			}
			return (T)obj;
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void WriteLog(params string[] strLogs)
		{
			try
			{
				string strPath = SharedSettings.ErrorLogRecepients;
				if (strLogs[0].Contains("[SUBFOLDER]"))
				{
					strPath += strLogs[0].Replace("[SUBFOLDER]", "");
				}
				string[] arrPaths = new string[1] { strPath };
				int[][] FileCount = null;
				FileCount = new int[1][];
				for (int j = 0; j < 1; j++)
				{
					FileCount[j] = new int[1];
				}
				int Index = 0;
				int RegionIndex = 0;
				StringBuilder Bldr = new StringBuilder();
				int _index = 0;
				if (strLogs[0].Contains("[SUBFOLDER]"))
				{
					_index = 1;
				}
				for (int i = _index; i < strLogs.Length; i++)
				{
					Bldr.Append(strLogs[i]);
				}
				string strLog = Bldr.ToString();
				string RegionPath = arrPaths[Index];
				string fname = DateTime.Now.ToString("yyyy-MM-dd");
				if (!Directory.Exists(arrPaths[Index]))
				{
					Directory.CreateDirectory(arrPaths[Index]);
				}
				if (!Directory.Exists(RegionPath))
				{
					Directory.CreateDirectory(RegionPath);
				}
				if (!File.Exists(RegionPath + fname + "_000.log"))
				{
					FileCount[RegionIndex][Index] = 0;
				}
				string fileName = RegionPath + fname + "_" + FileCount[RegionIndex][Index].ToString("000") + ".log";
				FileInfo info = new FileInfo(fileName);
				while (info.Exists && info.Length > 2097152)
				{
					FileCount[RegionIndex][Index]++;
					fileName = RegionPath + fname + "_" + FileCount[RegionIndex][Index].ToString("000") + ".log";
					info = new FileInfo(fileName);
				}
				using StreamWriter sw = new StreamWriter(fileName, append: true);
				sw.WriteLine(">>" + DateTime.Now.ToLongTimeString() + "\t:" + strLog);
				sw.Flush();
				sw.Close();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message;
			}
		}

		public async Task<T> PostToDMS<T>(string url, string requestbody, byte[] postedFile, string fileName)
		{
			string baseAddress = SharedSettings.DMSApiURL;
			object obj = Activator.CreateInstance(typeof(T));
			string request = baseAddress + url;
			WriteLog(request + " : start");
			try
			{
				Uri urirequest = new Uri(request);
				WriteLog("start url" + request);
				MultipartFormDataContent formContent = new MultipartFormDataContent();
				HttpContent bodyContent = new StringContent(requestbody);
				HttpContent bytesContent = new ByteArrayContent(postedFile);
				formContent.Add(bytesContent, "File", fileName);
				formContent.Add(bodyContent, "DMS_VALUES");
				using (HttpResponseMessage response = await client.PostAsync(urirequest, formContent).ConfigureAwait(continueOnCapturedContext: false))
				{
					using HttpContent content = response.Content;
					string json = content.ReadAsStringAsync().Result;
					WriteLog(json + " : Begin Result");
					if (response.IsSuccessStatusCode)
					{
						obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
						WriteLog(request + " : End Result");
					}
				}
				WriteLog("END url" + request);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				WriteLog(request + "  " + ex.Message);
			}
			return (T)obj;
		}

		public async Task<T> RemoveFromDMS<T>(string url, string requestbody)
		{
			object obj = Activator.CreateInstance(typeof(T));
			string request = SharedSettings.DMSApiURL + url;
			WriteLog(request + " : start");
			try
			{
				Uri urirequest = new Uri(request);
				FormUrlEncodedContent formContent = new FormUrlEncodedContent(new KeyValuePair<string, string>[1]
				{
					new KeyValuePair<string, string>("DMS_VALUES", requestbody)
				});
				WriteLog("start url" + request);
				using (HttpResponseMessage response = await client.PostAsync(urirequest, formContent).ConfigureAwait(continueOnCapturedContext: false))
				{
					using HttpContent content = response.Content;
					string json = content.ReadAsStringAsync().Result;
					WriteLog(json + " : Begin Result");
					if (response.IsSuccessStatusCode)
					{
						obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
						WriteLog(request + " : End Result");
					}
				}
				WriteLog("END url" + request);
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				WriteLog(request + "  " + ex.Message);
			}
			return (T)obj;
		}
	}
}
