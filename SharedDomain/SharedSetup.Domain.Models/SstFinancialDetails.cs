using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FINANCIAL_DETAILS")]
	public class SstFinancialDetails : BaseModel
	{
		[NotMapped]
		public string PaymentMethodName { get; set; }

		[Column("SERIAL_NO")]
		public long SerialNo { get; set; }

		[Column("DEBIT_CREDIT_ID")]
		public long? DebitCreditId { get; set; }

		[Column("AMOUNT")]
		public decimal Amount { get; set; }

		[Column("AMOUNT_LC")]
		public decimal AmountLc { get; set; }

		[Column("CURRENCY")]
		public string Currency { get; set; }

		[Column("EXRATE")]
		public decimal Exrate { get; set; }

		[Column("CUSTOMER_ID")]
		public long? CustomerId { get; set; }

		[Column("ACCOUNT_ID")]
		public long? AccountId { get; set; }

		[Column("COST_CENTER_ID")]
		public long? CostCenterId { get; set; }

		[Column("ITEM_ID")]
		public long? ItemId { get; set; }

		[Column("ITEM_PRICE")]
		public decimal? ItemPrice { get; set; }

		[Column("ITEM_QUANTITY")]
		public int? ItemQuantity { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("PAYMENT_METHOD")]
		public int? PaymentMethod { get; set; }

		[Column("BANK_CODE")]
		public long? BankCode { get; set; }

		[Column("BANK_REF")]
		public string BankRef { get; set; }

		[Column("BANK_DATE")]
		public DateTime? BankDate { get; set; }

		[Column("FILE_NAME")]
		public string FileName { get; set; }

		[Column("COMPANY_ID")]
		public long? CompanyId { get; set; }

		[Column("BRANCH_ID")]
		public long? BranchId { get; set; }

		[Column("TRANS_ID")]
		public long? TransId { get; set; }

		[Column("VOUCHER_DATE")]
		public DateTime VoucherDate { get; set; }

		[Column("REFERENCE_NO")]
		public string ReferenceNo { get; set; }

		[Column("ACCOUNT_NAME")]
		public string AccountName { get; set; }

		[Column("COST_CENTER_NAME")]
		public string CostCenterName { get; set; }

		[Column("CUSTOMER_NAME")]
		public string CustomerName { get; set; }

		[Column("AGENT_ID")]
		public long? AgentId { get; set; }

		[Column("AGENT_NAME")]
		public string AgentName { get; set; }

		[Column("BUSINESS_CHANNEL")]
		public long? BusinessChannel { get; set; }

		[ForeignKey("TransId")]
		[InverseProperty("SstFinancialDetails")]
		public virtual SstFinancialTransactions Trans { get; set; }

		[InverseProperty("FinTrnDet")]
		public virtual ICollection<SstFinancialAgents> SstFinancialAgents { get; set; }

		[InverseProperty("FinTrnDet")]
		public virtual ICollection<SstFinancialInstallments> SstFinancialInstallments { get; set; }

		public SstFinancialDetails()
		{
			SstFinancialAgents = new HashSet<SstFinancialAgents>();
			SstFinancialInstallments = new HashSet<SstFinancialInstallments>();
		}
	}
}
