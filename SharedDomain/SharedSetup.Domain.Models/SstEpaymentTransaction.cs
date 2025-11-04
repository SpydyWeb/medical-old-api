using System.ComponentModel.DataAnnotations.Schema;

namespace SharedSetup.Domain.Models
{
	[Table("SST_EPAYMENT_TRANSACTION")]
	public class SstEpaymentTransaction
	{
		[Column("ID")]
		public int Id { get; set; }

		[Column("AMOUNT")]
		public decimal Amount { get; set; }

		[Column("CUSTOMER_ID")]
		public long? CustomerId { get; set; }

		[Column("REQUEST_DATE")]
		public string RequestDate { get; set; }

		[Column("RESPONSE_DATE")]
		public string ResponseDate { get; set; }

		[Column("TRANSACTION_STATUS")]
		public string TransactionStatus { get; set; }

		[Column("TRANSACTION_STATUS_MESSAGE")]
		public string TransactionStatusMessage { get; set; }

		[Column("CONFIRMATION_ID")]
		public long? ConfirmationId { get; set; }

		[Column("VERSION")]
		public string Version { get; set; }

		[Column("AUTO_NOTIFY_LOG_ID")]
		public long? AutoNotifyLogId { get; set; }

		[Column("TRANSACTION_LOG_ID")]
		public long? TransactionLogId { get; set; }

		[Column("ACQUIRER_ID")]
		public long? AcquirerId { get; set; }

		[Column("ORDER_ID")]
		public long? OrderId { get; set; }

		[Column("LANGUAGE_ID")]
		public long? LanguageId { get; set; }

		[Column("PORTAL_ID")]
		public long? PortalId { get; set; }

		[Column("PAYMENT_STORE")]
		public int? PaymentStore { get; set; }

		[Column("NOTE")]
		public string Note { get; set; }

		[Column("SOURCE_OF_THE_TRANSACTION")]
		public int? SourceOfTheTransaction { get; set; }

		[Column("RETURNED_TRANSACTION_ID")]
		public long? ReturnedTransactionId { get; set; }
	}
}
