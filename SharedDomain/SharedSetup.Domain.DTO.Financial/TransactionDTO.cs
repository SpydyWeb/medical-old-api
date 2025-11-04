using System;
using System.Collections.Generic;

namespace SharedSetup.Domain.DTO.Financial
{
	public class TransactionDTO
	{
		public long Id { get; set; }

		public DateTime? JournalDate { get; set; }

		public string Source { get; set; }

		public decimal? TotalAmount { get; set; }

		public int IsReverse { get; set; }

		public int IsPosted { get; set; }

		public int IsPrinted { get; set; }

		public int IsDeleted { get; set; }

		public string CreatedBy { get; set; }

		public DateTime CreationDate { get; set; }

		public string ModifiedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }

		public string TransactionCode { get; set; }

		public string FiscalYear { get; set; }

		public string Month { get; set; }

		public long CompanyId { get; set; }

		public long? BranchId { get; set; }

		public string InvoiceType { get; set; }

		public string AppRefId { get; set; }

		public long? _TrnId { get; set; }

		public List<TransDetailDTO> Trans_Details { get; set; }

		public InsuranceData InsuranceData { get; set; }

		public int? JournalNo { get; set; }

		public string SegmentCode { get; set; }

		public string Notes { get; set; }

		public string Notes2 { get; set; }

		public int? CashierId { get; set; }

		public long? CustomerId { get; set; }

		public int? FCS_CTR_ID { get; set; }

		public int? FCR_COL_CODE { get; set; }

		public string Doc_Path { get; set; }

		public long? FGL_STY_ID { get; set; }

		public string ExtraAttribute { get; set; }

		public string FromJournalDate { get; set; }

		public string ToJournalDate { get; set; }

		public int? ChartOfAccountId { get; set; }

		public string FromSegmentCode { get; set; }

		public string ToSegmentCode { get; set; }

		public string Currency { get; set; }

		public string ReferenceNo { get; set; }

		public string IDs { get; set; }

		public long IdTranOrg { get; set; }
	}
}
