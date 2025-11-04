namespace Domain.Models.SearchCriteria
{
	public class ApprovalMappingSearchCriteria
	{
		public long SystemId { get; set; }

		public long? ProccesId { get; set; }

		public long? WorkFlowId { get; set; }

		public string SessionKey { get; set; }

		public string SessionValue { get; set; }

		public string SystemCode { get; set; }

		public string ModuleCode { get; set; }

		public long? PageId { get; set; }

		public long? CompanyId { get; set; }

		public string UserName { get; set; }
	}
}
