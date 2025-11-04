using System;

namespace CORE.TablesObjects
{
	public class Production
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public string? CreatedBy { get; set; }

		public DateTime CreationDate { get; set; }

		public int DocumentType { get; set; }

		public int EndtSerial { get; set; }

		public int UWYear { get; set; }

		public string? SeqmentCode { get; set; }

		public DateTime IssueDate { get; set; }

		public DateTime EffectiveDate { get; set; }

		public DateTime ExpiryDate { get; set; }

		public string? InsuredName { get; set; }

		public int AccountedFor { get; set; }

		public decimal GrossAmount { get; set; }

		public decimal TotalFees { get; set; }

		public decimal CommissionAmount { get; set; }

		public decimal VAT { get; set; }

		public decimal? DiscountAmount { get; set; }

		public decimal? LoadingAmount { get; set; }

		public decimal NetPremium { get; set; }

		public long? PolicyId { get; set; }

		public int? QuotationId { get; set; }

		public int? CustomerId { get; set; }

		public int PaymentMethod { get; set; }

		public int OfficeId { get; set; }

		public int? Validity { get; set; }

		public bool IsPaid { get; set; }

		public int ChartOfAccount { get; set; }

		public int? PlanId { get; set; }

		public string? CCHIPolicyNo { get; set; }

		public int? Status { get; set; }

		public int? OrginalPolicy { get; set; }

		public string? UniqueGuid { get; set; }

		public int? PushToEska { get; set; }

		public decimal? TpaShare { get; set; }

		public int? TPAId { get; set; }

		public long? EskaId { get; set; }

		public int? PushToYakeen { get; set; }

		public string? EskaSegment { get; set; }

		public int? EndosmentType { get; set; }

		public int? CancellationReason { get; set; }
		public string? NationalId { get; set; }
    }
}
