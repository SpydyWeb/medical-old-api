using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class Claims
	{
		public long Id { get; set; }

		public DateTime DateOfLoss { get; set; }

		public DateTime NotificationDate { get; set; }

		public DateTime RegistrationDate { get; set; }

		public string? PlateNo { get; set; }

		public string? VehicleName { get; set; }

		public int? ProductionYear { get; set; }

		public string? ChassisNo { get; set; }

		public string? Owner { get; set; }

		public int? LossResultId { get; set; }

		public int? BranchId { get; set; }

		public string? Beneficiery { get; set; }

		public string? InsuredId { get; set; }

		public int? PolicyId { get; set; }

		public string? PolicyNo { get; set; }

		public int? EventId { get; set; }

		public DateTime? PolicyEffectiveDate { get; set; }

		public DateTime? PolicyExpiryDate { get; set; }

		public int? BusinessType { get; set; }

		public int? PolicyUWYear { get; set; }

		public int? PolicySI { get; set; }

		public decimal? OsPremium { get; set; }

		public string? ClaimNo { get; set; }

		public int? ClaimUWYear { get; set; }

		public int? GeagraphicalArea { get; set; }

		public int? CityId { get; set; }

		public int? CauseOfLoss { get; set; }

		public int? ClaimCount { get; set; }

		public string? Notes { get; set; }

		public int? ClaimStatus { get; set; }

		public string? StatusReason { get; set; }

		public string? AccidentNo { get; set; }

		public string? CreatedBy { get; set; }

		public DateTime? CreationDate { get; set; }

		public string? ModifiedBy { get; set; }

		public DateTime? ModificationDate { get; set; }

		public int? ClaimType { get; set; }

		public int? SurveyCity { get; set; }

		public int FraudScore { get; set; }

		public string FraudIndicator { get; set; }

		public int ClaimReportType { get; set; }

		public string? City { get; set; }

		public string? TaqdeerNo { get; set; }

		public string? AccidentPlace { get; set; }

		public string? BasherNo { get; set; }

		public string? InsuredName { get; set; }

		public string? BusinessType_desc { get; set; }

		public string? Branch { get; set; }

		public int? AssignTo { get; set; }
	}
}
