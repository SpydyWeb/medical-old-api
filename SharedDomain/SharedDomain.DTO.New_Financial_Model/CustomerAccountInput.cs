namespace SharedDomain.DTO.New_Financial_Model
{
	public class CustomerAccountInput
	{
		public long CustomerId { get; set; }

		public string RoleId { get; set; }

		public int CompanyId { get; set; }

		public bool? OnlyOne { get; set; }

		public string Name { get; set; }
	}
}
