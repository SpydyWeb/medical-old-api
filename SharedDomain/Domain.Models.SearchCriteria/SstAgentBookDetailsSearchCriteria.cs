namespace Domain.Models.SearchCriteria
{
	public class SstAgentBookDetailsSearchCriteria
	{
		public long? ParentAgentBook { get; set; }

		public long CompanyId { get; set; }

		public long? PageStatus { get; set; }

		public string Name { get; set; }
	}
}
