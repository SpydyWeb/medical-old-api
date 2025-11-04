namespace SharedDomain.Models.SearchCriteria
{
	public class SstCodesSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public long? MajorCode { get; set; }

		public string ModuleCode { get; set; }

		public long? MinorCode { get; set; }

		public long? ParentMajorCode { get; set; }

		public long? ParentMinorCode { get; set; }
	}
}
