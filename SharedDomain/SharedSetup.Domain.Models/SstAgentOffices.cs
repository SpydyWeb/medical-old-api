using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_AGENT_OFFICES")]
	public class SstAgentOffices : BaseModel
	{
		[NotMapped]
		public string AgentName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string BusinessTypeName { get; set; }

		[NotMapped]
		public string OfficeName { get; set; }

		[Column("OFFICE_ID")]
		public long OfficeId { get; set; }

		[Column("AGENT_ID")]
		public long AgentId { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime? EffectiveDate { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("BUSINESS_TYPE")]
		public short? BusinessType { get; set; }

		[ForeignKey("AgentId")]
		[InverseProperty("SstAgentOffices")]
		public virtual SstAgents Agent { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstAgentOffices")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("OfficeId")]
		[InverseProperty("SstAgentOffices")]
		public virtual SstOffices Office { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstAgentOffices")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
