namespace SharedDomain.Models.SearchCriteria
{
	public class SstAgentOfficesSearchCriteria
	{
		public long? OfficeId { get; set; }

		public long CompanyId { get; set; }

		public long[] AgentId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? BusinessType { get; set; }

		public int PageNo { get; set; }

		public int? PageSize { get; set; }

		public string Query { get; set; }
	}
}
