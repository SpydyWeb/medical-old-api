using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DOMAINS")]
	public class SstDomains : BaseModel
	{
		[Column("CODE")]
		public long Code { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("DEFAULT_VALUE")]
		public long DefaultValue { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstDomains")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Domain")]
		public virtual ICollection<SstDomainValues> SstDomainValues { get; set; }

		[InverseProperty("StageDomainNavigation")]
		public virtual ICollection<SstStatusRelation> SstStatusRelationStageDomainNavigation { get; set; }

		[InverseProperty("StatusDomainNavigation")]
		public virtual ICollection<SstStatusRelation> SstStatusRelationStatusDomainNavigation { get; set; }

		public SstDomains()
		{
			SstDomainValues = new HashSet<SstDomainValues>();
			SstStatusRelationStageDomainNavigation = new HashSet<SstStatusRelation>();
			SstStatusRelationStatusDomainNavigation = new HashSet<SstStatusRelation>();
		}
	}
}
