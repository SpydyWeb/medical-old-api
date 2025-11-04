using System.Collections.Generic;

namespace Domain.Models.SearchCriteria
{
	public class SstAgentCommissionTiersSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? AgentId { get; set; }

		public long? LinkedAgentId { get; set; }

		public short? ClassId { get; set; }

		public long? BusinessType { get; set; }

		public short? ApplyOn { get; set; }

		public long? PolicyTypeId { get; set; }

		public string UserName { get; set; }

		public List<long> AgentIds { get; set; }
	}
}
