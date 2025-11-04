using CORE.DTOs.Authentications;

namespace InsuranceAPIs.Models.Authentications
{
	public class UserAuth
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string CompanyName { get; set; }

		public Roles Role { get; set; }

		public string Region { get; set; }

		public int EskaID { get; set; }

		public int IsActive { get; set; }

		public string? MacAddress { get; set; }

		public UserTypes Type { get; set; }
	}
}
