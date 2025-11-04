namespace Domain.Models.SearchCriteria
{
	public class CommissionTiersSearch
	{
		public long CompanyId { get; set; }

		public long? CommissionDetailId { get; set; }

		public int? CommissionType { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? BrokerId { get; set; }
	}
}
