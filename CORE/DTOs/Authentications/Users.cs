using System;

namespace CORE.DTOs.Authentications
{
	public class Users
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string Mobile { get; set; }

		public string Password { get; set; }

		public bool IsActive { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime LastPasswordChange { get; set; }

		public bool IsOneTimePassword { get; set; }

		public int? FailedAttempt { get; set; }

		public long? EskaId { get; set; }

		public int? ManagerId { get; set; }

		public bool? IsCurrentLogedIn { get; set; }

		public string? AccessKey { get; set; }

		public bool? AllowCredit { get; set; }
	}
}
