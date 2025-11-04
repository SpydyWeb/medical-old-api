namespace Domain.Models.SearchCriteria
{
	public class AgentInfoSearchCriteria
	{
		public short ClassId { get; set; }

		public long PolicyTypeId { get; set; }

		public long FinAgentId { get; set; }

		public long SystemId { get; set; }

		public long ChannelType { get; set; }

		public short AgentType { get; set; }
	}
}
