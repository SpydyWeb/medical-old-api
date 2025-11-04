namespace CORE.DTOs.APIs.Process.Payments
{
	public class Company
	{
		public string? NameAr { get; set; }

		public string? NameEn { get; set; }

		public string? RegistrationNo { get; set; }

		public string? CommissionerName { get; set; }

		public string? CommissionerMobileNo { get; set; }

		public string? CommissionerNationalId { get; set; }

		public string CommissionerEmail { get; set; }

		public string? CustomerRefNumber { get; set; }

		public string? PreferedLanguage { get; set; }

		public bool CanSendSMS { get; set; }
	}
}
