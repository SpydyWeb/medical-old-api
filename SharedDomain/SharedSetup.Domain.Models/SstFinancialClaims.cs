using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FINANCIAL_CLAIMS")]
	public class SstFinancialClaims : BaseModel
	{
		[Column("FIN_TRN_ID")]
		public long FinTrnId { get; set; }

		[Column("CLAIM_NO")]
		public long ClaimNo { get; set; }

		[Column("CLAIMANT_NAME")]
		public string ClaimantName { get; set; }

		[Required]
		[Column("PAYMENT_METHOD")]
		public string PaymentMethod { get; set; }

		[Column("BANK_ID")]
		public long BankId { get; set; }

		[Required]
		[Column("IBAN")]
		public string Iban { get; set; }

		[ForeignKey("FinTrnId")]
		[InverseProperty("SstFinancialClaims")]
		public virtual SstFinancialTransactions FinTrn { get; set; }
	}
}
