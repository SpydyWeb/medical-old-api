using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("CP_EPAYMENT_TRANSACTIONS")]
	public class CpEpaymentTransactions : BaseModel
	{
		[Column("AMOUNT")]
		public decimal Amount { get; set; }

		[Column("CUSTOMER_TYPE")]
		public int CustomerType { get; set; }

		[Column("CUSTOMER_ID")]
		public long? CustomerId { get; set; }

		[Column("REQUEST_DATE")]
		public DateTime? RequestDate { get; set; }

		[Column("RESPONSE_DATE")]
		public DateTime? ResponseDate { get; set; }

		[Column("STATUS")]
		public int? Status { get; set; }

		[Column("STATUS_MESSAGE")]
		public string StatusMessage { get; set; }

		[Column("CONFIRMATION_ID")]
		public long? ConfirmationId { get; set; }

		[Column("VERSION")]
		public string Version { get; set; }

		[Column("AUTO_LOG_ID")]
		public long? AutoLogId { get; set; }

		[Column("LOG_ID")]
		public long? LogId { get; set; }

		[Column("ACQUIRER_ID")]
		public long? AcquirerId { get; set; }

		[Column("ORDER_ID")]
		public long? OrderId { get; set; }

		[Column("PAYMENT_STORE")]
		public int? PaymentStore { get; set; }

		[Column("SOURCE")]
		public int? Source { get; set; }

		[Column("RESPONSE_ID")]
		public long? ResponseId { get; set; }

		[Column("NOTE")]
		public string Note { get; set; }
	}
}
