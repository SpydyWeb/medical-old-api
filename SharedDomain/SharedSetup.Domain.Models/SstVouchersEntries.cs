using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_VOUCHERS_ENTRIES")]
	public class SstVouchersEntries : BaseModel
	{
		[Column("SERIAL")]
		public byte Serial { get; set; }

		[Column("ENTRY_NAME")]
		public string EntryName { get; set; }

		[Column("DEBIT_CREDIT")]
		public byte DebitCredit { get; set; }

		[Column("CUSTOMER")]
		public long? Customer { get; set; }

		[Column("CURRENCY")]
		public long? Currency { get; set; }

		[Column("EXRATE")]
		public long? Exrate { get; set; }

		[Column("ACCOUNT")]
		public long? Account { get; set; }

		[Column("COST_CENTER")]
		public long? CostCenter { get; set; }

		[Column("AMOUNT")]
		public long? Amount { get; set; }

		[Column("AMOUNT_LC")]
		public long? AmountLc { get; set; }

		[Column("AGENT")]
		public long? Agent { get; set; }

		[Column("REFERENCE_NO")]
		public long? ReferenceNo { get; set; }

		[Column("DETAIL_TYPE")]
		public long? DetailType { get; set; }

		[Column("EXTRA_ATTRIBUTE")]
		public long? ExtraAttribute { get; set; }

		[Column("INVOICE_START_DATE")]
		public long? InvoiceStartDate { get; set; }

		[Column("PAYMENT_METHOD")]
		public long? PaymentMethod { get; set; }

		[Column("NOTES")]
		public long? Notes { get; set; }

		[Column("NOTES2")]
		public long? Notes2 { get; set; }

		[Column("VOUCHER_TYPE")]
		public byte VoucherType { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("VOUCHER_SERIAL")]
		public byte VoucherSerial { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[ForeignKey("Serial")]
		[InverseProperty("SstVouchersEntriesVoucherSerialNavigation")]
		public virtual SstVouchersTypes VoucherSerialNavigation { get; set; }

		[ForeignKey("VoucherType")]
		[InverseProperty("SstVouchersEntriesVoucherTypeNavigation")]
		public virtual SstVouchersTypes VoucherTypeNavigation { get; set; }
	}
}
