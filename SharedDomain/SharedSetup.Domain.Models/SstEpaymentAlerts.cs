using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_EPAYMENT_ALERTS")]
	public class SstEpaymentAlerts : BaseModel
	{
		[Column("PAYMENT_SUCCESS")]
		public byte? PaymentSuccess { get; set; }

		[Column("PAYMENT_RECURRING")]
		public byte? PaymentRecurring { get; set; }

		[Column("PAYMENT_EXPIRY")]
		public byte? PaymentExpiry { get; set; }

		[Column("CARD_PRE_EXPIRY")]
		public byte? CardPreExpiry { get; set; }

		[Column("CARD_EXPIRY")]
		public byte? CardExpiry { get; set; }

		[Column("PAYMENT_RENEWAL")]
		public byte? PaymentRenewal { get; set; }

		[Column("PAYMENT_FAILURE")]
		public byte? PaymentFailure { get; set; }

		[Column("PAYMENT_ID")]
		public long PaymentId { get; set; }

		[ForeignKey("PaymentId")]
		[InverseProperty("SstEpaymentAlerts")]
		public virtual SstEpaymentMethods Payment { get; set; }
	}
}
