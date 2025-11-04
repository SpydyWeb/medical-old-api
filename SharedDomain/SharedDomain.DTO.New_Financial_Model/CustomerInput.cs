namespace SharedDomain.DTO.New_Financial_Model
{
	public class CustomerInput
	{
		public int CompanyId { get; set; }

		public long? ID { get; set; }

		public string IDs { get; set; }

		public int? CustomerStatus { get; set; }

		public int? BranchId { get; set; }

		public int? CustomerType { get; set; }

		public string NationalId { get; set; }

		public string CommercialName { get; set; }

		public string CustomerNo { get; set; }

		public string Name { get; set; }

		public string Mobile { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

		public int? PageNumber { get; set; }

		public int? RowsSizePerPage { get; set; }

		public int? LastSync { get; set; }

		public bool? OnlyOne { get; set; }

		public int? IsCustomer { get; set; }

		public string RoleIDs { get; set; }

		public long? ParentId { get; set; }

		public bool? MasterCustomer { get; set; }
	}
}
