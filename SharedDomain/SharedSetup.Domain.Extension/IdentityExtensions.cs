using System.Security.Claims;
using System.Security.Principal;
using Newtonsoft.Json;
using SharedSetup.Domain.DTO;
using SharedSetup.Domain.Enums;

namespace SharedSetup.Domain.Extension
{
	public static class IdentityExtensions
	{
		private static LoginDTO GetUserInfo(IIdentity identity)
		{
			Claim claim = ((ClaimsIdentity)identity).FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata");
			LoginDTO result = new LoginDTO();
			if (claim != null)
			{
				string value = claim.Value;
				result = JsonConvert.DeserializeObject<LoginDTO>(value);
			}
			return result;
		}

		public static string GetUserName(this IIdentity identity)
		{
			string empty = string.Empty;
			LoginDTO userInfo = GetUserInfo(identity);
			return userInfo.userName;
		}

		public static int GetCompanyId(this IIdentity identity)
		{
			LoginDTO userInfo = GetUserInfo(identity);
			return userInfo.companyId.GetValueOrDefault();
		}

		public static string GetCoreToken(this IIdentity identity)
		{
			Claim claim = ((ClaimsIdentity)identity).FindFirst(ClaimIdentityKeys.CoreToken.ToString());
			string result = string.Empty;
			if (claim != null)
			{
				result = claim.Value;
			}
			return result;
		}

		public static string GetLanguage(this IIdentity identity)
		{
			Claim claim = ((ClaimsIdentity)identity).FindFirst("Language");
			return (claim != null) ? claim.Value : string.Empty;
		}
	}
}
