namespace Domain.Models.SearchCriteria
{
	public class SstClosingPeriodsSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public string Module { get; set; }

		public long? BranchId { get; set; }

		public string UserName { get; set; }
	}
}
