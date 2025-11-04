using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FORM_CONTROLS")]
	public class SstFormControls : BaseModel
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
		[InverseProperty("SstFormControls")]
		public virtual SstContainers Container { get; set; }

		[ForeignKey("RefControlId")]
		[InverseProperty("InverseRefControl")]
		public virtual SstFormControls RefControl { get; set; }

		[InverseProperty("RefControl")]
		public virtual ICollection<SstFormControls> InverseRefControl { get; set; }

		public SstFormControls()
		{
			InverseRefControl = new HashSet<SstFormControls>();
		}
	}
}
