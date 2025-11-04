namespace SharedDomain.DTO.New_Financial_Model
{
	public class AccountInput
	{
		public long? ID { get; set; }

		public string IDs { get; set; }

		public string ChartOfAccountNo { get; set; }

		public string Name { get; set; }

		public int CompanyId { get; set; }

		public int? Classification { get; set; }

		public int? Type { get; set; }

		public int? DetailType { get; set; }

		public int? PageNumber { get; set; }

		public int? RowsSizePerPage { get; set; }
	}
}
