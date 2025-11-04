using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_CONTROL_VALUES")]
	public class SpdControlValues : BaseModel
	{
		[Column("STEP_ID")]
		public long StepId { get; set; }

		[Column("PRODUCT_ID")]
		public long ProductId { get; set; }

		[Column("COMPONENT_ID")]
		public long ComponentId { get; set; }

		[Column("CONTROL_ID")]
		public long? ControlId { get; set; }

		[Column("CONTROL_KEY")]
		public string ControlKey { get; set; }

		[Column("CONTROL_VALUE")]
		public byte[] ControlValue { get; set; }

		[Column("USER_PROPERTY_ID")]
		public long? UserPropertyId { get; set; }

		[ForeignKey("ComponentId")]
		[InverseProperty("SpdControlValues")]
		public virtual SpdComponents Component { get; set; }

		[ForeignKey("ControlId")]
		[InverseProperty("SpdControlValues")]
		public virtual SpdFormControls Control { get; set; }

		[ForeignKey("ProductId")]
		[InverseProperty("SpdControlValues")]
		public virtual SpdProducts Product { get; set; }

		[ForeignKey("StepId")]
		[InverseProperty("SpdControlValues")]
		public virtual SpdProductsSteps Step { get; set; }

		[ForeignKey("UserPropertyId")]
		[InverseProperty("SpdControlValues")]
		public virtual CpUserProperties UserProperty { get; set; }
	}
}
