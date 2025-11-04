namespace SharedDomain.Models.SearchCriteria
{
	public class SstClassesSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public int? LobCode { get; set; }

		public long? BusinessChannel { get; set; }

		public string Username { get; set; }
	}
}
