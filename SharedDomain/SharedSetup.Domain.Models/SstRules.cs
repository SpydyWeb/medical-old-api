using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_RULES")]
	public class SstRules : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("RULE_TYPE")]
		public byte? RuleType { get; set; }

		[Column("RULE_TARGET")]
		public long? RuleTarget { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[Column("PRODUCT_ID")]
		public long? ProductId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstRules")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Rule")]
		public virtual ICollection<SstActions> SstActions { get; set; }

		[InverseProperty("Rule")]
		public virtual ICollection<SstConditions> SstConditions { get; set; }

		[InverseProperty("Rule")]
		public virtual ICollection<SstProcessStepsPages> SstProcessStepsPages { get; set; }

		public SstRules()
		{
			SstActions = new HashSet<SstActions>();
			SstConditions = new HashSet<SstConditions>();
			SstProcessStepsPages = new HashSet<SstProcessStepsPages>();
		}
	}
}
