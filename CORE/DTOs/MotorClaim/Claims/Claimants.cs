using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class Claimants
	{
		public int Id { get; set; }

		public long ClaimId { get; set; }

		public int Serial { get; set; }

		public int? ClaimantType { get; set; }

		public int? DamageType { get; set; }

		public int? NatureofLoss { get; set; }

		public string? ClaimantName { get; set; }

		public bool? IsCustomer { get; set; }

		public bool? IsSurveyRequired { get; set; }

		public int? BeneficiaryType { get; set; }

		public string? NationalId { get; set; }

		public int? Responsipility { get; set; }

		public int? OurPercent { get; set; }

		public string? OwnerName { get; set; }

		public string? OwnerNationalId { get; set; }

		public decimal? ReserveAmount { get; set; }

		public string? CreatedBy { get; set; }

		public string? MobileNo { get; set; }

		public string? DriverAge { get; set; }

		public string? InsurancePolicyNumber { get; set; }

		public string? InsuranceCompanyName { get; set; }

		public int? ClaimantStatus { get; set; }

		public string? StatusReason { get; set; }

		public DateTime? DriverLicenseExpiryDate { get; set; }

		public string? DriverName { get; set; }

		public string? DriverNationalId { get; set; }

		public DateTime? DriverBirthDate { get; set; }

		public string? BenefecieryName { get; set; }

		public string? ChassisNo { get; set; }

		public string? SequenceNo { get; set; }

		public string? CustomNo { get; set; }

		public string? PlateNo { get; set; }

		public int? ColorId { get; set; }

		public int? Manifacturing { get; set; }

		public int? MakeId { get; set; }

		public int? ModelId { get; set; }

		public string? ColorDesc { get; set; }

		public string? MakeDesc { get; set; }

		public string? ModelDesc { get; set; }

		public string? Iban { get; set; }

		public string? BankName { get; set; }
	}
}
