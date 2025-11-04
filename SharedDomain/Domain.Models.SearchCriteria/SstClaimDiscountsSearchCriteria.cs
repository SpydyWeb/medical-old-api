namespace Domain.Models.SearchCriteria
{
	public class SstClaimDiscountsSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public decimal? Amount { get; set; }

		public decimal? Percent { get; set; }

		public decimal? AfterClaimPercent { get; set; }

		public short? ClaimYearsFrom { get; set; }

		public short? ClaimYearsTo { get; set; }

		public long? DiscountId { get; set; }

		public string UserName { get; set; }
	}
}
