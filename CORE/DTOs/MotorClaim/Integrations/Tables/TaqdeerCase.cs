using System;

namespace CORE.DTOs.MotorClaim.Integrations.Tables
{
	public class TaqdeerCase
	{
		public string DACaseNumber { get; set; }

		public DateTime DARegistrationTime { get; set; }

		public DateTime DACompletionDate { get; set; }

		public string? AcciedentNo { get; set; }

		public string? PolicyNumber { get; set; }

		public string? OwnerName { get; set; }

		public string? OwnerId { get; set; }

		public string? MobileNumber { get; set; }

		public string? ChasisNumber { get; set; }

		public string? VehicleManufacturer { get; set; }

		public string? PlateNo { get; set; }

		public string? Model { get; set; }

		public string? Color { get; set; }

		public string? Year { get; set; }

		public DateTime FinalAssessmentTime { get; set; }

		public string? EstimatedBy { get; set; }

		public decimal EstimationCost { get; set; }

		public string? SCRejectReason { get; set; }

		public decimal? BeforeDamageVehicleCost { get; set; }

		public decimal? AfterDamageVehicleCost { get; set; }

		public bool IsHighCost { get; set; }

		public string? SCVehicleType { get; set; }

		public string? ShowroomChiefComment { get; set; }

		public string? HighCostByUser { get; set; }

		public string? HighCostByUserCompanyName { get; set; }

		public DateTime? HighCostRejectDateTime { get; set; }

		public string? SCAssessmentCity { get; set; }

		public string? AreaName { get; set; }

		public decimal TaqdeerTotalFees { get; set; }

		public decimal? SCEstimationFees { get; set; }

		public decimal? SCVATAmount { get; set; }

		public decimal? SCTotalFees { get; set; }

		public string? AttendedBy { get; set; }

		public string? CaseType { get; set; }

		public string? SubCaseType { get; set; }

		public decimal TotalCost { get; set; }
	}
}
