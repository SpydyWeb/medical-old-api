namespace SharedDomain.Models.SearchCriteria
{
	public class SstPreferencesSearchCriteria
	{
		public long SystemId { get; set; }

		public long CompanyId { get; set; }

		public short? Type { get; set; }

		public string Code { get; set; }

		public string Name { get; set; }

		public string Value { get; set; }

		public string Page { get; set; }
	}
}
