using System;

namespace CORE.DTOs.APIs.Process.Payments
{
	public class UpdateFinancialPayment
	{
		public DateTime EffectiveDate { get; set; }

		public string EskaId { get; set; }

		public string VAT { get; set; }
        public string IBAN { get; set; }
        public string BankNameEn { get; set; }
        public string BankNameAr { get; set; }
    }
}
