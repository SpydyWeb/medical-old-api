namespace Domain.Models
{
	public class LoginDTO
	{
		public string username { get; set; }

		public string password { get; set; }

		public int? companyID { get; set; }

		public int? branchID { get; set; }

		public string SessionId { get; set; }

		public int Timeout { get; set; }

		public string Token { get; set; }
	}
}
