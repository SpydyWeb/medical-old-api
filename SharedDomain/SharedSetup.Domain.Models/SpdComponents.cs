using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_COMPONENTS")]
	public class SpdComponents : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("ICON")]
		public string Icon { get; set; }

		[Column("FORM_TYPE")]
		public byte? FormType { get; set; }

		[Column("LAYOUT_TYPE")]
		public byte? LayoutType { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("STEP_ID")]
		public long? StepId { get; set; }

		[Column("REF_COMPONENT_ID")]
		public long? RefComponentId { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("StepId")]
		[InverseProperty("SpdComponents")]
		public virtual SpdProductsSteps Step { get; set; }

		[InverseProperty("Component")]
		public virtual ICollection<SpdContainers> SpdContainers { get; set; }

		[InverseProperty("Component")]
		public virtual ICollection<SpdControlValues> SpdControlValues { get; set; }

		public SpdComponents()
		{
			SpdContainers = new HashSet<SpdContainers>();
			SpdControlValues = new HashSet<SpdControlValues>();
		}
	}
}
