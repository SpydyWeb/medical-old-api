using System;

namespace CORE.DTOs.MIGRATION.Motor
{
	public class PolicyMigrationObj
	{
		public int UWYear { get; set; }

		public string SegmentCode { get; set; }

		public DateTime IssueDate { get; set; }

		public DateTime EffectiveDate { get; set; }

		public DateTime ExpiryDate { get; set; }

		public string InsuredName { get; set; }

		public int AccountedFor { get; set; }

		public decimal GrossAmount { get; set; }

		public decimal TotalFees { get; set; }

		public decimal? CommissionAmount { get; set; }

		public decimal VAT { get; set; }

		public decimal NetPremium { get; set; }

		public decimal PolicyId { get; set; }

		public decimal CustomerId { get; set; }

		public decimal ChartOfAccount { get; set; }
	}
}
