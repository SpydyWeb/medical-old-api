namespace CORE.DTOs.MotorClaim.Claims
{
	public class ClaimSubmissionDocuments
	{
		public int Id { get; set; }

		public int eClaimId { get; set; }

		public string? DA { get; set; }

		public string? IBAN { get; set; }

		public string? Others { get; set; }

		public string? AcciedentReport { get; set; }

		public string? LicenseCopy { get; set; }

		public string? IstimaraCopy { get; set; }
	}
}
