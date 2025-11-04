namespace Domain.Models.DTOs
{
	public class CCHIBenefitConfig
	{
		public string BenefitApiUrl { get; set; }

		public string GetClassInformationsUrl { get; set; }

		public string UploadCCHITableOfBenefitsUrl { get; set; }

		public string UploadCustoomTableOfBenefitsUrl { get; set; }

		public string UserKey { get; set; }

		public string Authorization { get; set; }

		public bool UseSSL { get; set; }
	}
}
