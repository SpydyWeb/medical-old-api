namespace CORE.DTOs.Authentications
{
	public class UserInfo
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string CompanyName { get; set; }

		public int RoleId { get; set; }

		public string Region { get; set; }

		public int EskaID { get; set; }

		public int IsActive { get; set; }

		public string? MacAddress { get; set; }

		public int TypeId { get; set; }
	}
}
