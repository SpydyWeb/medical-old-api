using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_COMPONENTS")]
	public class SstComponents : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ICON")]
		public string Icon { get; set; }

		[Column("GLOBAL")]
		public byte? Global { get; set; }

		[Column("FORM_TYPE")]
		public byte? FormType { get; set; }

		[Column("LAYOUT_TYPE")]
		public byte? LayoutType { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[InverseProperty("Component")]
		public virtual ICollection<SstContainers> SstContainers { get; set; }

		public SstComponents()
		{
			SstContainers = new HashSet<SstContainers>();
		}
	}
}
