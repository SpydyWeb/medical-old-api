using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace InsuranceAPIs.Extension
{
	public class ReCaptcha
	{
		private readonly HttpClient captchaClient;

		public ReCaptcha(HttpClient captchaClient)
		{
			this.captchaClient = captchaClient;
		}

		public async Task<bool> IsValid(string captcha)
		{
			try
			{
				JObject resultObject = JObject.Parse(await (await captchaClient.PostAsync("?secret=SECRET_KEY&response=" + captcha, new StringContent(""))).Content.ReadAsStringAsync());
				dynamic success = resultObject["success"];
				return (bool)success;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
