using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PAYMENT_DETAILS")]
	public class SstPaymentDetails : BaseModel
	{
		[Column("SHARE_")]
		public decimal? Share { get; set; }

		[Column("UNIT")]
		public byte Unit { get; set; }

		[Column("PERIOD")]
		public int Period { get; set; }

		[Column("METHOD")]
		public byte Method { get; set; }

		[Column("CYCLE_ID")]
		public long CycleId { get; set; }

		[ForeignKey("CycleId")]
		[InverseProperty("SstPaymentDetails")]
		public virtual SstPaymentCycles Cycle { get; set; }
	}
}
