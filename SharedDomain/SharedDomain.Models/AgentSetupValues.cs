namespace SharedDomain.Models
{
	public class AgentSetupValues
	{
		public long AgentFinId { get; set; }

		public long? AgentSetupId { get; set; }

		public string AgentName { get; set; }

		public decimal AgentCommAmount { get; set; }

		public decimal AgentCommPer { get; set; }

		public long? TierId { get; set; }

		public bool CoverLevel { get; set; }
	}
}
