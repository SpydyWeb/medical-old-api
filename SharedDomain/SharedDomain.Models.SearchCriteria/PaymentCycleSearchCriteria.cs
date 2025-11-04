namespace SharedDomain.Models.SearchCriteria
{
	public class PaymentCycleSearchCriteria
	{
		public string name { get; set; }

		public long? systemId { get; set; }

		public long companyId { get; set; }

		public long? paymentCycleId { get; set; }
	}
}
