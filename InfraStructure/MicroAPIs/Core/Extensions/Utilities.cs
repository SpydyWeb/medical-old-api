using Org.BouncyCastle.Crypto.Modes;
using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace MicroAPIs.Core.Extensions
{
	public static class Utilities
	{
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
			//return DateTime.Now.Year - DOB.Year;
            return (int)((DateTime.Now - DOB).TotalDays / 365.242199);
        }

		public static string Decryption(string hashed, string bcKey, string bcIV)
		{
            // old logic
            //byte[] bytesToBeDecrypted = Convert.FromBase64String(hashed.Replace("-", "+"));
            //byte[] passwordBytesdecrypt = Encoding.UTF8.GetBytes("XBM##@@" + DateTime.Today.Year + "$$");
            //byte[] passwordBytes = Encoding.UTF8.GetBytes("XBM##@@" + DateTime.Today.Year + "$$");
            //passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            //passwordBytesdecrypt = SHA256.Create().ComputeHash(passwordBytesdecrypt);
            //byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            //return Encoding.UTF8.GetString(bytesDecrypted);

            // New logic

            byte[] ciphertext = Convert.FromBase64String(hashed.Replace("-", "+"));
            byte[] key = Encoding.UTF8.GetBytes(bcKey);
            byte[] iv = Encoding.UTF8.GetBytes(bcIV);

            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(key), 128, iv);
            cipher.Init(false, parameters);

            byte[] output = new byte[cipher.GetOutputSize(ciphertext.Length)];
            int len = cipher.ProcessBytes(ciphertext, 0, ciphertext.Length, output, 0);
            cipher.DoFinal(output, len);
            return Encoding.UTF8.GetString(output).TrimEnd('\0');
        }

		public static string EskaConnection()
		{
			return "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 10.0.12.154)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = ESKAUAT1)));User ID=Imedical;Password=imedical;";
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

		public static string Encrypt(string phrase, string bcKey, string bcIV)
		{
			//old Logic
            //byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(phrase);
            //byte[] passwordBytes = Encoding.UTF8.GetBytes("XBM##@@" + DateTime.Today.Year + "$$");
            //passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            //byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
            //return Convert.ToBase64String(bytesEncrypted);

			//New logic
            byte[] key = Encoding.UTF8.GetBytes(bcKey);
            byte[] iv = Encoding.UTF8.GetBytes(bcIV);

            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(key), 128, iv);
            cipher.Init(true, parameters);

            byte[] input = Encoding.UTF8.GetBytes(phrase);
            byte[] output = new byte[cipher.GetOutputSize(input.Length)];
            int len = cipher.ProcessBytes(input, 0, input.Length, output, 0);
            cipher.DoFinal(output, len);
            return Convert.ToBase64String(output);
        }
	}
}
