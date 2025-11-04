using System;

namespace SharedSetup.Domain.DTO.Financial
{
	public class AgentsDTO
	{
		public int ID { get; set; }

		public int CompanyId { get; set; }

		public int CustomerId { get; set; }

		public int AgentId { get; set; }

		public string CreatedBy { get; set; }

		public DateTime CreationDate { get; set; }

		public int Status { get; set; }

		public string CUSTOMER_NAME { get; set; }

		public string AGENT_NAME { get; set; }
	}
}
