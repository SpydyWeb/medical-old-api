using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_FORM_CONTROLS")]
	public class SpdFormControls : BaseModel
	{
		[Column("KEY")]
		public string Key { get; set; }

		[Column("TYPE")]
		public byte? Type { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("VALUE")]
		public byte? Value { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("ICON")]
		public string Icon { get; set; }

		[Column("WIDTH")]
		public byte? Width { get; set; }

		[Column("REQUIRED")]
		public byte? Required { get; set; }

		[Column("DISABLED")]
		public byte? Disabled { get; set; }

		[Column("OPTIONS")]
		public string Options { get; set; }

		[Column("HAS_SUBFORM_CONTROLS")]
		public byte? HasSubformControls { get; set; }

		[Column("CONTAINER_ID")]
		public long? ContainerId { get; set; }

		[Column("REF_CONTROL_ID")]
		public long? RefControlId { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[ForeignKey("ContainerId")]
		[InverseProperty("SpdFormControls")]
		public virtual SpdContainers Container { get; set; }

		[ForeignKey("RefControlId")]
		[InverseProperty("InverseRefControl")]
		public virtual SpdFormControls RefControl { get; set; }

		[InverseProperty("RefControl")]
		public virtual ICollection<SpdFormControls> InverseRefControl { get; set; }

		[InverseProperty("Control")]
		public virtual ICollection<SpdControlValues> SpdControlValues { get; set; }

		public SpdFormControls()
		{
			InverseRefControl = new HashSet<SpdFormControls>();
			SpdControlValues = new HashSet<SpdControlValues>();
		}
	}
}
