using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using SharedSetup.Domain.Common;

namespace SharedDomain.Common
{
	public class AESEncryption
	{
		public static string DecryptStringAES(string cipherText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(SharedSettings.Secret);
			byte[] bytes2 = Encoding.UTF8.GetBytes(SharedSettings.Secret);
			byte[] cipherText2 = Convert.FromBase64String(cipherText);
			string format = DecryptStringFromBytes(cipherText2, bytes, bytes2);
			return string.Format(format);
		}

		public static string EncryptString(string cipherText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(SharedSettings.Secret);
			byte[] bytes2 = Encoding.UTF8.GetBytes(SharedSettings.Secret);
			return Encrypt(cipherText, bytes, bytes2);
		}

		private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
		{
			if (cipherText == null || cipherText.Length == 0)
			{
				throw new ArgumentNullException("cipherText");
			}
			if (key == null || key.Length == 0)
			{
				throw new ArgumentNullException("key");
			}
			if (iv == null || iv.Length == 0)
			{
				throw new ArgumentNullException("key");
			}
			string result = null;
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.Mode = CipherMode.CBC;
				rijndaelManaged.Padding = PaddingMode.PKCS7;
				rijndaelManaged.FeedbackSize = 128;
				rijndaelManaged.FeedbackSize = 128;
				rijndaelManaged.Key = key;
				rijndaelManaged.IV = iv;
				ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				try
				{
					using MemoryStream stream = new MemoryStream(cipherText);
					using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
					using StreamReader streamReader = new StreamReader(stream2);
					result = streamReader.ReadToEnd();
				}
				catch
				{
					result = "keyError";
				}
			}
			return result;
		}

		private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
		{
			if (plainText == null || plainText.Length <= 0)
			{
				throw new ArgumentNullException("plainText");
			}
			if (key == null || key.Length == 0)
			{
				throw new ArgumentNullException("key");
			}
			if (iv == null || iv.Length == 0)
			{
				throw new ArgumentNullException("key");
			}
			using RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			rijndaelManaged.FeedbackSize = 128;
			rijndaelManaged.Key = key;
			rijndaelManaged.IV = iv;
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using MemoryStream memoryStream = new MemoryStream();
			using CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			using (StreamWriter streamWriter = new StreamWriter(stream))
			{
				streamWriter.Write(plainText);
			}
			return memoryStream.ToArray();
		}

		public static string Encrypt(string strPlainText, byte[] key, byte[] iv)
		{
			byte[] bytes = new UTF8Encoding().GetBytes(strPlainText);
			using RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			rijndaelManaged.FeedbackSize = 128;
			rijndaelManaged.FeedbackSize = 128;
			rijndaelManaged.Key = key;
			rijndaelManaged.IV = iv;
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor();
			byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
			return Convert.ToBase64String(inArray);
		}
	}
}
