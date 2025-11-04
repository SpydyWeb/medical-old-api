namespace CORE.DTOs.MotorClaim.Integrations.APIs
{
	public class Involvedperson
	{
		public string nationalId { get; set; }

		public string firstName { get; set; }

		public string fatherName { get; set; }

		public string grandFatherName { get; set; }

		public string familyName { get; set; }

		public Gender gender { get; set; }

		public string nationality { get; set; }

		public string involvementType { get; set; }

		public int responsibilityPercentage { get; set; }

		public string mobileNumber { get; set; }

		public string healthStatus { get; set; }

		public string hospitalName { get; set; }

		public bool objected { get; set; }

		public int involvementSequence { get; set; }

		public string birthDate { get; set; }

		public object drivingLicenseType { get; set; }

		public object licenseExpiryDate { get; set; }

		public string relatedVehicle { get; set; }

		public object[] imagesTokens { get; set; }
	}
}
