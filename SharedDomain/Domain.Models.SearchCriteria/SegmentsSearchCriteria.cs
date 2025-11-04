namespace Domain.Models.SearchCriteria
{
	public class SegmentsSearchCriteria
	{
		public long? CompanyId { get; set; }

		public long? BranchId { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public int? SegmentType { get; set; }

		public int? BusinessChannel { get; set; }

		public int? BusinessType { get; set; }
	}
}
