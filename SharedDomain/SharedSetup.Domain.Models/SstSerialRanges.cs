using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SERIAL_RANGES")]
	public class SstSerialRanges : BaseModel
	{
		[NotMapped]
		public string SerialTermName { get; set; }

		[Column("SERIAL_ID")]
		public long? SerialId { get; set; }

		[Column("SERIAL_FROM")]
		public long? SerialFrom { get; set; }

		[Column("SERIAL_TO")]
		public long? SerialTo { get; set; }

		[Column("SERIAL_CURRENT")]
		public long? SerialCurrent { get; set; }

		[Column("SERIAL_INCREMENT")]
		public byte? SerialIncrement { get; set; }

		[Column("SERIAL_DATE")]
		public DateTime? SerialDate { get; set; }

		[ForeignKey("SerialId")]
		[InverseProperty("SstSerialRanges")]
		public virtual SstSerialLists Serial { get; set; }
	}
}
