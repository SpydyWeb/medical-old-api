namespace Domain.Models.SearchCriteria
{
	public class SstPolicyBusinessSearchCriteria
	{
		public long CompanyId { get; set; }

		public long SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? BusinessType { get; set; }

		public long? Category { get; set; }

		public string ReportCode { get; set; }

		public string UserName { get; set; }
	}
}
