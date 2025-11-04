namespace Domain.Models.SearchCriteria
{
	public class DocumentGroupsSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? DocumentParentType { get; set; }

		public string GroupName { get; set; }

		public string Username { get; set; }
	}
}
