namespace CORE.DTOs.Authentications
{
	public class InsertUser
	{
		public string Username { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public int Mobile { get; set; }

		public int RoleId { get; set; }

		public int EskaId { get; set; }

		public bool? status { get; set; } = null;


		public bool? IsAllow { get; set; } = null;


		public int Type { get; set; }

		public int? FailledAttemp { get; set; }

		public int? TeamLeader { get; set; }
	}
}
