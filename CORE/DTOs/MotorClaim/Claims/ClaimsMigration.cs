using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class ClaimsMigration
	{
		public int Id { get; set; }

		public int InsuranceType { get; set; }

		public int InsuranceSurveyed { get; set; }

		public int RecoveryType { get; set; }

		public string AccidentReport { get; set; }

		public string OwnerNationalID { get; set; }

		public string SequenceNumber { get; set; }

		public string? TaqdeerNumber { get; set; }

		public string? IBANNo { get; set; }

		public DateTime? LicenseExpiryDate { get; set; }

		public DateTime CreationDate { get; set; }

		public string? Reference { get; set; }

		public DateTime? TransfereDate { get; set; }

		public int? Status { get; set; }
	}
}
