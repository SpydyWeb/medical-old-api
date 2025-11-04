namespace Domain.Models.SearchCriteria
{
	public class DataSecuritySearchCriteria
	{
		public long CompanyId { get; set; }

		public long? InsuranceClassId { get; set; }

		public long? InsuranceSystemId { get; set; }

		public long? PolicyTypeId { get; set; }

		public long? ProductId { get; set; }

		public long? GroupId { get; set; }

		public string UserName { get; set; }
	}
}
