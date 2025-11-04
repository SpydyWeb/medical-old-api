using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FINANCIAL_TRANSACTIONS")]
	public class SstFinancialTransactions : BaseModel
	{
		[NotMapped]
		public string SegmentCode { get; set; }

		[NotMapped]
		public int IsPosted { get; set; }

		[NotMapped]
		public string PaymentMethodName { get; set; }

		[Column("TRANS_ID")]
		public long? TransId { get; set; }

		[Column("JOURNAL_DATE")]
		public DateTime JournalDate { get; set; }

		[Required]
		[Column("SOURCE")]
		public string Source { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("REFERENCE_NO")]
		public string ReferenceNo { get; set; }

		[Column("TOTAL_AMOUNT")]
		public decimal TotalAmount { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("BRANCH_ID")]
		public long BranchId { get; set; }

		[Column("CUSTOMER_ID")]
		public long? CustomerId { get; set; }

		[Required]
		[Column("CURRENCY")]
		public string Currency { get; set; }

		[Column("EXRATE")]
		public decimal Exrate { get; set; }

		[Column("APP_REF_ID")]
		public string AppRefId { get; set; }

		[Column("ENDORSEMENT_NO")]
		public long? EndorsementNo { get; set; }

		[Column("FIN_POL_ID")]
		public long FinPolId { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("VOUCHER_TYPE")]
		public string VoucherType { get; set; }

		[Column("BRANCH_NAME")]
		public string BranchName { get; set; }

		[Column("CUSTOMER_NAME")]
		public string CustomerName { get; set; }

		[Column("CUSTOMER_ROLE")]
		public string CustomerRole { get; set; }

		[Column("PAYMENT_METHOD")]
		public short? PaymentMethod { get; set; }

		[Column("TRANS_CODE")]
		public short? TransCode { get; set; }

		[ForeignKey("FinPolId")]
		[InverseProperty("SstFinancialTransactions")]
		public virtual SstFinancialPolicies FinPol { get; set; }

		[InverseProperty("FinTrn")]
		public virtual ICollection<SstFinancialClaims> SstFinancialClaims { get; set; }

		[InverseProperty("Trans")]
		public virtual ICollection<SstFinancialDetails> SstFinancialDetails { get; set; }

		public SstFinancialTransactions()
		{
			SstFinancialClaims = new HashSet<SstFinancialClaims>();
			SstFinancialDetails = new HashSet<SstFinancialDetails>();
		}
	}
}
