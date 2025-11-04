namespace SharedSetup.Domain.DTO.CRM
{
	public class LeadSearchCriteria
	{
		public int? ACCOUNT_ID { get; set; }

		public string NATIONAL_ID { get; set; }

		public string COMMERCIAL_REG { get; set; }

		public string Name { get; set; }

		public int? PageNumber { get; set; }

		public int? PageSize { get; set; }
	}
}
