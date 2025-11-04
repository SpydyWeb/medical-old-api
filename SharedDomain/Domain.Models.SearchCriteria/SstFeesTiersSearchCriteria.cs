namespace Domain.Models.SearchCriteria
{
	public class SstFeesTiersSearchCriteria
	{
		public long CompanyId { get; set; }

		public long FeeId { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? BusinessType { get; set; }

		public long? CoverType { get; set; }

		public long? TPA { get; set; }

		public string UserName { get; set; }
	}
}
