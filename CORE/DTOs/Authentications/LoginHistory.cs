using System;

namespace CORE.DTOs.Authentications
{
	public class LoginHistory
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public DateTime? LastLoginDate { get; set; }

		public int FailureAttemp { get; set; }

		public string? LoginIp { get; set; }
	}
}
