using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_EPAYMENT_DETAILS")]
	public class SstEpaymentDetails : BaseModel
	{
		[Column("CURRENCY")]
		public string Currency { get; set; }

		[Column("MERCHANT_ID")]
		public long? MerchantId { get; set; }

		[Column("MERCHANT_REFERENCE")]
		public string MerchantReference { get; set; }

		[Column("API_ID")]
		public long? ApiId { get; set; }

		[Column("TRANSACTION_ID")]
		public long? TransactionId { get; set; }

		[Column("TRANSACTION_PASSWORD")]
		public string TransactionPassword { get; set; }

		[Column("AUTHENTICATION_TYPE")]
		public byte? AuthenticationType { get; set; }

		[Column("PAYMENT_ID")]
		public long PaymentId { get; set; }

		[Column("REGISTRATION")]
		public string Registration { get; set; }

		[Column("CUSTOMER")]
		public string Customer { get; set; }

		[Column("ADDRESS")]
		public string Address { get; set; }

		[Column("CERTIFICATE_PATH")]
		public string CertificatePath { get; set; }

		[Column("CERTIFICATE_PASS")]
		public string CertificatePass { get; set; }

		[Column("PORT")]
		public long? Port { get; set; }

		[Column("TIMEOUT")]
		public long? Timeout { get; set; }

		[Column("IS_SECURE")]
		public byte? IsSecure { get; set; }

		[Column("CHANNEL")]
		public string Channel { get; set; }

		[Column("LANGUAGE")]
		public string Language { get; set; }

		[Column("AMOUNT")]
		public decimal? Amount { get; set; }

		[Column("STORE")]
		public string Store { get; set; }

		[Column("TERMINAL")]
		public string Terminal { get; set; }

		[Column("ORDER_INFO")]
		public string OrderInfo { get; set; }

		[Column("ORDER_DESCRIPTION")]
		public string OrderDescription { get; set; }

		[Column("RETURN_PATH")]
		public string ReturnPath { get; set; }

		[Column("ACCESS_CODE")]
		public string AccessCode { get; set; }

		[Column("COMMAND")]
		public string Command { get; set; }

		[Column("CUSTOMER_EMAIL")]
		public string CustomerEmail { get; set; }

		[Column("PAYMENT_OPTION")]
		public string PaymentOption { get; set; }

		[ForeignKey("PaymentId")]
		[InverseProperty("SstEpaymentDetails")]
		public virtual SstEpaymentMethods Payment { get; set; }
	}
}
