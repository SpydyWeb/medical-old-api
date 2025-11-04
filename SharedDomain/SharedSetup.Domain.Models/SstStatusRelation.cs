using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_STATUS_RELATION")]
	public class SstStatusRelation : BaseModel
	{
		[Column("RELATION_TYPE")]
		public byte RelationType { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("STATUS_DOMAIN")]
		public long StatusDomain { get; set; }

		[Required]
		[Column("STATUS_VALUE")]
		public string StatusValue { get; set; }

		[Column("STAGE_DOMAIN")]
		public long StageDomain { get; set; }

		[Required]
		[Column("STAGE_VALUE")]
		public string StageValue { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstStatusRelation")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstStatusRelation")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("StageDomain")]
		[InverseProperty("SstStatusRelationStageDomainNavigation")]
		public virtual SstDomains StageDomainNavigation { get; set; }

		[ForeignKey("StatusDomain")]
		[InverseProperty("SstStatusRelationStatusDomainNavigation")]
		public virtual SstDomains StatusDomainNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstStatusRelation")]
		public virtual SstSystems System { get; set; }
	}
}
