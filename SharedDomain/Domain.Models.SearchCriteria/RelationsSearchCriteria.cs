namespace Domain.Models.SearchCriteria
{
	public class RelationsSearchCriteria
	{
		public int companyId { get; set; }

		public long? insuranceSystemId { get; set; }

		public long? insuranceClassId { get; set; }

		public long? policyTypeId { get; set; }

		public long? businessType { get; set; }

		public string currency { get; set; }

		public long? paymentCycleId { get; set; }

		public int? policyRelation { get; set; }

		public long[] PolicyTypeList { get; set; }

		public string userName { get; set; }
	}
}
