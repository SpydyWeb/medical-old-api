using System.Security.Claims;
using System.Security.Principal;
using Domain.Enums;
using Newtonsoft.Json;

namespace Domain.Extension
{
	public static class IdentityExtensions
	{
		private static LoginDTO GetUserInfo(IIdentity identity)
		{
			Claim claim = ((ClaimsIdentity)identity).FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata");
			LoginDTO loginDTO = new LoginDTO();
			if (claim != null)
			{
				string userInfo = claim.Value;
				loginDTO = JsonConvert.DeserializeObject<LoginDTO>(userInfo);
			}
			return loginDTO;
		}

		public static string GetUserName(this IIdentity identity)
		{
			string userName = string.Empty;
			LoginDTO loginDTO = GetUserInfo(identity);
			return loginDTO.userName;
		}

		public static int GetCompanyId(this IIdentity identity)
		{
			LoginDTO loginDTO = GetUserInfo(identity);
			return loginDTO.companyId.GetValueOrDefault();
		}

		public static string GetCoreToken(this IIdentity identity)
		{
			Claim claim = ((ClaimsIdentity)identity).FindFirst(ClaimIdentityKeys.CoreToken.ToString());
			string coreToken = string.Empty;
			if (claim != null)
			{
				coreToken = claim.Value;
			}
			return coreToken;
		}

		public static string GetLanguage(this IIdentity identity)
		{
			LoginDTO loginDTO = GetUserInfo(identity);
			return string.IsNullOrEmpty(loginDTO.language) ? Language.English : loginDTO.language;
		}
	}
}
