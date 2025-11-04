using System;

namespace CORE.DTOs.APIs.Business
{
	public class MMPSummery
	{
		public string Name { get; set; }

		public string NationalId { get; set; }

		public string PolicyNo { get; set; }

		public long PolicyId { get; set; }

		public string Proffession { get; set; }

		public string Liability { get; set; }

		public DateTime EffectiveDate { get; set; }

		public DateTime ExpiryDate { get; set; }

		public int PolicyPeriod { get; set; }

		public decimal GrossPremium { get; set; }

		public decimal Vat { get; set; }

		public decimal Fees { get; set; }
	}
}
