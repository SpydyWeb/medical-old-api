using System;

namespace SharedDomain.Models.SearchCriteria
{
	public class SstAgentsSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public long? AgentType { get; set; }

		public long? ChannelType { get; set; }

		public long? FinAgentId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? BrmId { get; set; }

		public long? AgentId { get; set; }

		public DateTime? InceptionDate { get; set; }

		public long? BranchId { get; set; }
	}
}
