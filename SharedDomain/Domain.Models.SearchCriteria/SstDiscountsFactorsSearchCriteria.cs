namespace Domain.Models.SearchCriteria
{
	public class SstDiscountsFactorsSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public int? LOB { get; set; }

		public long? PolicyDiscountId { get; set; }

		public short? FactorType { get; set; }
	}
}
