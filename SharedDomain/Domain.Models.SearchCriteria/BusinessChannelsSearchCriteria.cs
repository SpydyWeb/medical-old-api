namespace Domain.Models.SearchCriteria
{
	public class BusinessChannelsSearchCriteria
	{
		public string Name { get; set; }

		public string Name2 { get; set; }

		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public string UserName { get; set; }

		public string RolesId { get; set; }

		public bool? IsDirect { get; set; }
	}
}
