using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FINANCIAL_INSTALLMENTS")]
	public class SstFinancialInstallments : BaseModel
	{
		[Column("INSTALLMENT_ID")]
		public long InstallmentId { get; set; }

		[Required]
		[Column("INSTALLMENT_SERIAL")]
		public string InstallmentSerial { get; set; }

		[Column("FIN_TRN_DET_ID")]
		public long FinTrnDetId { get; set; }

		[Column("DOCUMENT_ID")]
		public long DocumentId { get; set; }

		[Column("AMOUNT")]
		public decimal Amount { get; set; }

		[Column("DUE_DATE")]
		public DateTime DueDate { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[ForeignKey("FinTrnDetId")]
		[InverseProperty("SstFinancialInstallments")]
		public virtual SstFinancialDetails FinTrnDet { get; set; }
	}
}
