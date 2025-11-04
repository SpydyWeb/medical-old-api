namespace Domain.Models.SearchCriteria
{
	public class SerialListsSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? BranchId { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public byte? SerialType { get; set; }

		public long? BusinessChannel { get; set; }

		public byte? BusinessType { get; set; }

		public byte? Automatic { get; set; }
	}
}
