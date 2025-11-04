using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SEGMENTS_STRUCTURES")]
	public class SstSegmentsStructures : BaseModel
	{
		[NotMapped]
		public string ElementName { get; set; }

		[Column("ELEMENT_ORDER")]
		public byte? ElementOrder { get; set; }

		[Column("ELEMENT_TYPE")]
		public byte? ElementType { get; set; }

		[Column("CONSTANT_VALUE")]
		public string ConstantValue { get; set; }

		[Column("ELEMENT_LENGTH")]
		public int? ElementLength { get; set; }

		[Column("PADDING_STRING")]
		public string PaddingString { get; set; }

		[Column("ELEMENT_SEPARATOR")]
		public string ElementSeparator { get; set; }

		[Column("SEGMENT_ID")]
		public long? SegmentId { get; set; }

		[ForeignKey("SegmentId")]
		[InverseProperty("SstSegmentsStructures")]
		public virtual SstSegments Segment { get; set; }
	}
}
