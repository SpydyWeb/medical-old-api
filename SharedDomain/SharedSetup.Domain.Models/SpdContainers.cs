using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_CONTAINERS")]
	public class SpdContainers : BaseModel
	{
		[Column("KEY")]
		public string Key { get; set; }

		[Column("TYPE")]
		public byte? Type { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("COMPONENT_ID")]
		public long? ComponentId { get; set; }

		[Column("REF_CONTAINER_ID")]
		public long? RefContainerId { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[ForeignKey("ComponentId")]
		[InverseProperty("SpdContainers")]
		public virtual SpdComponents Component { get; set; }

		[ForeignKey("RefContainerId")]
		[InverseProperty("InverseRefContainer")]
		public virtual SpdContainers RefContainer { get; set; }

		[InverseProperty("RefContainer")]
		public virtual ICollection<SpdContainers> InverseRefContainer { get; set; }

		[InverseProperty("Container")]
		public virtual ICollection<SpdFormControls> SpdFormControls { get; set; }

		public SpdContainers()
		{
			InverseRefContainer = new HashSet<SpdContainers>();
			SpdFormControls = new HashSet<SpdFormControls>();
		}
	}
}
