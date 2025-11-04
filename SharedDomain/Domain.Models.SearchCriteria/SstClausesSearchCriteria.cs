namespace Domain.Models.SearchCriteria
{
	public class SstClausesSearchCriteria
	{
		public long InsuranceSystem { get; set; }

		public long? InsuranceClassId { get; set; }

		public long? PolicyTypeId { get; set; }

		public string ClausesName { get; set; }

		public long? ClausesType { get; set; }

		public long? Criterion { get; set; }

		public string Description { get; set; }

		public int CompanyId { get; set; }

		public string UserName { get; set; }
	}
}
