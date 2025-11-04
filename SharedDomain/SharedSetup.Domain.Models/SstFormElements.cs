using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FORM_ELEMENTS")]
	public class SstFormElements : BaseModel
	{
		[Column("FORM_ID")]
		public long FormId { get; set; }

		[Required]
		[Column("ELEMENT_LABEL")]
		public string ElementLabel { get; set; }

		[Required]
		[Column("ELEMENT_CONTROLNAME")]
		public string ElementControlname { get; set; }

		[Required]
		[Column("ELEMENT_TYPE")]
		public string ElementType { get; set; }

		[Column("ELEMENT_OPTION")]
		public string ElementOption { get; set; }

		[Column("ELEMENT_SOURCE")]
		public string ElementSource { get; set; }

		[Column("ELEMENT_ORDER")]
		public int ElementOrder { get; set; }

		[Column("ELEMENT_ISDISABLE")]
		public byte ElementIsdisable { get; set; }

		[Column("ELEMENT_ISREQUEIRED")]
		public byte ElementIsrequeired { get; set; }

		[Column("LANGUAGE")]
		public int Language { get; set; }

		[ForeignKey("FormId")]
		[InverseProperty("SstFormElements")]
		public virtual SstForms Form { get; set; }
	}
}
