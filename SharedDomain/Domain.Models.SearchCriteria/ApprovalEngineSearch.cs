namespace Domain.Models.SearchCriteria
{
	public class ApprovalEngineSearch
	{
		public long SystemId { get; set; }

		public string ModuleCode { get; set; }

		public long PageId { get; set; }

		public string ControlKey { get; set; }

		public string Username { get; set; }

		public int CompanyId { get; set; }

		public string SessionKey { get; set; }

		public long? tokenId { get; set; }
	}
}
