using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FORM_GRID")]
	public class SstFormGrid : BaseModel
	{
		[Column("FORM_ID")]
		public long FormId { get; set; }

		[Required]
		[Column("GRID_FIELD")]
		public string GridField { get; set; }

		[Required]
		[Column("GRID_HEADER")]
		public string GridHeader { get; set; }

		[Column("FIELD_ORDER")]
		public int FieldOrder { get; set; }

		[Column("LANGUAGE")]
		public int Language { get; set; }

		[ForeignKey("FormId")]
		[InverseProperty("SstFormGrid")]
		public virtual SstForms Form { get; set; }
	}
}
