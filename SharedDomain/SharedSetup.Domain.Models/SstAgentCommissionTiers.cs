using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_AGENT_COMMISSION_TIERS")]
	public class SstAgentCommissionTiers : BaseModel
	{
		[NotMapped]
		public string LinkedAgentName { get; set; }

		[NotMapped]
		public string AgentName { get; set; }

		[NotMapped]
		public string BusinessTypeName { get; set; }

		[NotMapped]
		public string ClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string CoverTypeName { get; set; }

		[NotMapped]
		public string ProductName { get; set; }

		[NotMapped]
		public string BranchName { get; set; }

		[NotMapped]
		public long? AccountId { get; set; }

		[NotMapped]
		public bool CoverLevel { get; set; }

		[Column("AGENT_ID")]
		public long AgentId { get; set; }

		[Column("FIN_AGENT_ID")]
		public long? FinAgentId { get; set; }

		[Column("FIN_AGENT_NAME")]
		public string FinAgentName { get; set; }

		[Column("LINKED_AGENT_ID")]
		public long? LinkedAgentId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("PRODUCT_TYPE")]
		public long? ProductType { get; set; }

		[Column("COMM_PER")]
		public decimal CommPer { get; set; }

		[Column("COMM_AMOUNT")]
		public decimal CommAmount { get; set; }

		[Column("APPLY_ON")]
		public short ApplyOn { get; set; }

		[Column("LAP_DURATION_FROM")]
		public short? LapDurationFrom { get; set; }

		[Column("LAP_DURATION_TO")]
		public short? LapDurationTo { get; set; }

		[Column("POL_DURATION_FROM")]
		public short? PolDurationFrom { get; set; }

		[Column("POL_DURATION_TO")]
		public short? PolDurationTo { get; set; }

		[Column("SI_FROM")]
		public decimal? SiFrom { get; set; }

		[Column("SI_TO")]
		public decimal? SiTo { get; set; }

		[Column("POSITION")]
		public long? Position { get; set; }

		[Column("IS_EDITABLE")]
		public bool? IsEditable { get; set; }

		[Column("COVER_TYPE")]
		public long? CoverType { get; set; }

		[Column("BRANCH")]
		public long? Branch { get; set; }

		[Column("BUSINESS_TYPE")]
		public short BusinessType { get; set; }

		[ForeignKey("AgentId")]
		[InverseProperty("SstAgentCommissionTiersAgent")]
		public virtual SstAgents Agent { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstAgentCommissionTiers")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("CoverType")]
		[InverseProperty("SstAgentCommissionTiers")]
		public virtual SstCoverTypes CoverTypeNavigation { get; set; }

		[ForeignKey("LinkedAgentId")]
		[InverseProperty("SstAgentCommissionTiersLinkedAgent")]
		public virtual SstAgents LinkedAgent { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstAgentCommissionTiers")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
