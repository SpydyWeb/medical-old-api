using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FINANCIAL_AGENTS")]
	public class SstFinancialAgents : BaseModel
	{
		[Column("FIN_TRN_DET_ID")]
		public long FinTrnDetId { get; set; }

		[Column("AGENT_ID")]
		public long AgentId { get; set; }

		[Column("AGENT_ROLE_ID")]
		public long AgentRoleId { get; set; }

		[Column("COMM_PERCENTAGE")]
		public decimal CommPercentage { get; set; }

		[Column("COMM_AMOUNT")]
		public decimal CommAmount { get; set; }

		[ForeignKey("FinTrnDetId")]
		[InverseProperty("SstFinancialAgents")]
		public virtual SstFinancialDetails FinTrnDet { get; set; }
	}
}
