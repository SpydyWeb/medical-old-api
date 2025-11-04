using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CONTAINERS")]
	public class SstContainers : BaseModel
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
		[InverseProperty("SstContainers")]
		public virtual SstComponents Component { get; set; }

		[InverseProperty("Container")]
		public virtual ICollection<SstFormControls> SstFormControls { get; set; }

		public SstContainers()
		{
			SstFormControls = new HashSet<SstFormControls>();
		}
	}
}
