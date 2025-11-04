using System;

namespace SharedSetup.Domain.DTO.Financial
{
	public class TransDetailDTO
	{
		public int Serial { get; set; }

		public byte? DebitCreditId { get; set; }

		public decimal? Amount { get; set; }

		public decimal? AmountLC { get; set; }

		public byte IsDeleted { get; set; }

		public string CreatedBy { get; set; }

		public DateTime CreationDate { get; set; }

		public long? ChartOfAccountId { get; set; }

		public string Currency { get; set; }

		public decimal? Exrate { get; set; }

		public long? CustomerId { get; set; }

		public int TransactionId { get; set; }

		public DateTime? ModificationDate { get; set; }

		public string ModifiedBy { get; set; }

		public string Notes { get; set; }

		public int? FGL_CEL_ID { get; set; }

		public int? PaymentMethod { get; set; }

		public int? FGL_CRCD_CODE { get; set; }

		public string CreditCardNo { get; set; }

		public string Payee { get; set; }

		public string BankRef { get; set; }

		public DateTime? BankDate { get; set; }

		public long? EFT_NO { get; set; }

		public int? CurrencyId { get; set; }

		public long? CostCenterId { get; set; }

		public int? VAT { get; set; }

		public int? ChequeId { get; set; }

		public long? AgentId { get; set; }

		public string ReferenceNo { get; set; }

		public int? FGL_TRD_SERIAL { get; set; }

		public string ExtraAttribute { get; set; }

		public decimal? TaxPercentage { get; set; }

		public int? Data_MIG { get; set; }

		public int? FGL_DET_TYPE { get; set; }

		public decimal? SalesTaxPercentage { get; set; }

		public int? TOLERANCE_FGL_TRD_SERIAL { get; set; }

		public int? ExportPayment { get; set; }

		public int? ON_OUR_BEHALF { get; set; }

		public int? CashierId { get; set; }

		public int? FGL_CARD_HOL_BNK { get; set; }

		public DateTime? DepositDate { get; set; }

		public int? TaxCode { get; set; }

		public int? BankCode { get; set; }

		public int? BranchCode { get; set; }

		public string IBAN_NO { get; set; }

		public DateTime? InvoiceDueDate { get; set; }
	}
}
