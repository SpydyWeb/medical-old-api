using System;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class AgentsOutput
	{
		public long ID { get; set; }

		public int CompanyId { get; set; }

		public long CustomerId { get; set; }

		public string CUSTOMER_NAME { get; set; }

		public long AgentId { get; set; }

		public string AGENT_NAME { get; set; }

		public DateTime CreationDate { get; set; }

		public string CreatedBy { get; set; }

		public int Status { get; set; }

		public int[] RoleIDs { get; set; }
	}
}
