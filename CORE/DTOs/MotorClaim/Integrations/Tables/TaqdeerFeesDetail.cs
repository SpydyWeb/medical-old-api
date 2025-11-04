namespace CORE.DTOs.MotorClaim.Integrations.Tables
{
	public class TaqdeerFeesDetail
	{
		public string DACaseNumber { get; set; }

		public long Id { get; set; }

		public string? PolicyNumber { get; set; }

		public int InsuranceCompanyId { get; set; }

		public string? InsuranceCompanyName { get; set; }

		public string? PaymentBy { get; set; }

		public string? PaymentMethod { get; set; }

		public decimal? Fees { get; set; }

		public decimal? VAT { get; set; }

		public decimal? VATAmount { get; set; }

		public decimal? TotalFees { get; set; }
	}
}
