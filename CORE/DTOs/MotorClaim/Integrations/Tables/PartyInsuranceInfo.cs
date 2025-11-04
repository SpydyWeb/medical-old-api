namespace CORE.DTOs.MotorClaim.Integrations.Tables
{
	public class PartyInsuranceInfo
	{
		public long Id { get; set; }

		public long PartyId { get; set; }

		public int? insuranceCompanyID { get; set; }

		public string? ICArabicName { get; set; }

		public string? ICEnglishName { get; set; }

		public string? policyNumber { get; set; }

		public string? policyExpiryDate { get; set; }

		public string? insurancePlate { get; set; }

		public string? chassisNo { get; set; }

		public long? vehicleID { get; set; }

		public string caseNumber { get; set; }
	}
}
