namespace SharedDomain.Models
{
	public class BindWithBRM
	{
		public long BrmAgentId { get; set; }

		public long? BrmPosition { get; set; }

		public string AgentIds { get; set; }

		public decimal CommPer { get; set; }

		public decimal CommAmount { get; set; }

		public long? IsEditable { get; set; }

		public long? SameAgentCommission { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyTypeId { get; set; }

		public long? BusinessType { get; set; }
	}
}
