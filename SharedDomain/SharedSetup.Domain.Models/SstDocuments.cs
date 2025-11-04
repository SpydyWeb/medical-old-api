using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DOCUMENTS")]
	public class SstDocuments : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("GROUP_ID")]
		public long GroupId { get; set; }

		[Column("IS_REQUIRED")]
		public byte? IsRequired { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("IS_AUTO")]
		public bool? IsAuto { get; set; }

		[ForeignKey("GroupId")]
		[InverseProperty("SstDocuments")]
		public virtual SstDocumentGroups Group { get; set; }
	}
}
