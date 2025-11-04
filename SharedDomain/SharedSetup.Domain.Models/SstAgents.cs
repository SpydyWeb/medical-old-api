using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_AGENTS")]
	public class SstAgents : BaseModel
	{
		[NotMapped]
		public string AgentTypeName { get; set; }

		[NotMapped]
		public string ChannelTypeName { get; set; }

		[NotMapped]
		public string CommissionTypeName { get; set; }

		[NotMapped]
		public string CalculationBasisName { get; set; }

		[NotMapped]
		public string DirectManagerName { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("AGENT_TYPE")]
		public short AgentType { get; set; }

		[Column("CHANNEL_TYPE")]
		public long ChannelType { get; set; }

		[Column("COMM_STRUCTURE_ID")]
		public long? CommStructureId { get; set; }

		[Column("FIN_AGENT_ID")]
		public long? FinAgentId { get; set; }

		[Column("FIN_AGENT_NAME")]
		public string FinAgentName { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime? EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime? ExpiryDate { get; set; }

		[Column("BRANCH_ID")]
		public long? BranchId { get; set; }

		[Column("CALCULATION_BASE")]
		public short CalculationBase { get; set; }

		[Column("POSITION")]
		public long? Position { get; set; }

		[Column("ACHIEVEMENT_TYPE")]
		public short? AchievementType { get; set; }

		[Column("TARGET")]
		public string Target { get; set; }

		[Column("TARGET_INCLUSION")]
		public short? TargetInclusion { get; set; }

		[Column("TERM_BASIS")]
		public short? TermBasis { get; set; }

		[Column("REGULAR_PAYEMNT_TERM")]
		public short RegularPayemntTerm { get; set; }

		[Column("DATA_ACCORDANCE")]
		public short DataAccordance { get; set; }

		[Column("FIN_DIRECT_MNGR")]
		public long? FinDirectMngr { get; set; }

		[Column("FIN_DIRECT_MNGR_NAME")]
		public string FinDirectMngrName { get; set; }

		[Column("STATUS")]
		public bool? Status { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("ChannelType")]
		[InverseProperty("SstAgents")]
		public virtual SstBusinessChannels ChannelTypeNavigation { get; set; }

		[ForeignKey("CommStructureId")]
		[InverseProperty("SstAgents")]
		public virtual SstCommissionStructure CommStructure { get; set; }

		[ForeignKey("Position")]
		[InverseProperty("SstAgents")]
		public virtual SstAgentStructures PositionNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstAgents")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Agent")]
		public virtual ICollection<SstAgentCommissionTiers> SstAgentCommissionTiersAgent { get; set; }

		[InverseProperty("LinkedAgent")]
		public virtual ICollection<SstAgentCommissionTiers> SstAgentCommissionTiersLinkedAgent { get; set; }

		[InverseProperty("Agent")]
		public virtual ICollection<SstAgentOffices> SstAgentOffices { get; set; }

		public SstAgents()
		{
			SstAgentCommissionTiersAgent = new HashSet<SstAgentCommissionTiers>();
			SstAgentCommissionTiersLinkedAgent = new HashSet<SstAgentCommissionTiers>();
			SstAgentOffices = new HashSet<SstAgentOffices>();
		}
	}
}
