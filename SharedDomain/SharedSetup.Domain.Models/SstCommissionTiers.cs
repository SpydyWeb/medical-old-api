using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_COMMISSION_TIERS")]
	public class SstCommissionTiers : BaseModel
	{
		[NotMapped]
		public string BrokerName { get; set; }

		[Column("LAP_DURATION_FROM")]
		public byte LapDurationFrom { get; set; }

		[Column("LAP_DURATION_TO")]
		public byte LapDurationTo { get; set; }

		[Column("POL_DURATION_FROM")]
		public byte PolDurationFrom { get; set; }

		[Column("POL_DURATION_TO")]
		public byte PolDurationTo { get; set; }

		[Column("AMOUNT_FROM")]
		public decimal AmountFrom { get; set; }

		[Column("AMOUNT_TO")]
		public decimal AmountTo { get; set; }

		[Column("COMM_PERCENT")]
		public decimal? CommPercent { get; set; }

		[Column("COMM_AMOUNT")]
		public decimal? CommAmount { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("CUSTOMER_ID")]
		public long? CustomerId { get; set; }

		[Column("COMMISSION_DTL_ID")]
		public long CommissionDtlId { get; set; }

		[ForeignKey("CommissionDtlId")]
		[InverseProperty("SstCommissionTiers")]
		public virtual SstCommissionDetails CommissionDtl { get; set; }
	}
}
