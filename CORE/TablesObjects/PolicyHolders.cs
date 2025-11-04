using System;

namespace CORE.TablesObjects
{
	public class PolicyHolders
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string CommercialNo { get; set; }

		public DateTime LicenseExpiryDate { get; set; }

		public string? VatNumber { get; set; }

		public int? BankId { get; set; }

		public string? IBAN { get; set; }

		public string Email { get; set; }

		public string MobileNo { get; set; }

		public long? EskaId { get; set; }

		public DateTime CreationDate { get; set; }

		public int CreatedBy { get; set; }

		public string? InsuranceHR { get; set; }

		public string? InsuranceHRMobile { get; set; }

		public DateTime? HRDOB { get; set; }
		public bool? isBlocked { get; set; }
        public string? BankNameEn { get; set; }
        public string? BankNameAr { get; set; }
    }
}
