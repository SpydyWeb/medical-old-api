using System;

namespace Domain.Models.SearchCriteria
{
	public class AgentCustomersSearchCriteria
	{
		public long SystemId { get; set; }

		public long ClassId { get; set; }

		public long PolicyType { get; set; }

		public short BusinessType { get; set; }

		public short AgentType { get; set; }

		public short ApplyOn { get; set; }

		public string RoleIds { get; set; }

		public long CustomerId { get; set; }

		public long? BrmId { get; set; }

		public long? AgentId { get; set; }

		public long? FinAgentId { get; set; }

		public long? LinkedAgentId { get; set; }

		public DateTime EffectiveDate { get; set; }

		public string query { get; set; }
	}
}
