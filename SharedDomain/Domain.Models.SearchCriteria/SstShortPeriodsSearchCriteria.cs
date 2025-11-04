namespace Domain.Models.SearchCriteria
{
	public class SstShortPeriodsSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? ApplyOnEvent { get; set; }

		public string UserName { get; set; }
	}
}
