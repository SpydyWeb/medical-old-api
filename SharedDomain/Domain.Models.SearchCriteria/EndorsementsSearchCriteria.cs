namespace Domain.Models.SearchCriteria
{
	public class EndorsementsSearchCriteria
	{
		public int companyId { get; set; }

		public long? insuranceSystemId { get; set; }

		public long? insuranceClassId { get; set; }

		public long? policyTypeId { get; set; }
	}
}
