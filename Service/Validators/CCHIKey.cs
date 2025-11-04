using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Service.Validators
{
	public static class CCHIKey
	{
		public static string GenerateKey()
		{
			return Encrypt(string.Format("Company=CCHI;Service=CCHIService;AccessToken={0}.{1}.{2}.{3}.{4}.{5}", DateTime.Now.Year.ToString(), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString()), useHashing: true);
		}

		public static string Encrypt(string toEncrypt, bool useHashing)
		{
			byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
			AppSettingsReader settingsReader = new AppSettingsReader();
			string key = Params._EncryptionKey;
			byte[] keyArray;
			if (useHashing)
			{
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
				hashmd5.Clear();
			}
			else
			{
				keyArray = Encoding.UTF8.GetBytes(key);
			}
			TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
			tdes.Key = keyArray;
			tdes.Mode = CipherMode.ECB;
			tdes.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = tdes.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
			tdes.Clear();
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}
	}
}
