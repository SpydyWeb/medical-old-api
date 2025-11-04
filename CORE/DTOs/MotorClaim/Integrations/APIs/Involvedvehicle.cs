namespace CORE.DTOs.MotorClaim.Integrations.APIs
{
	public class Involvedvehicle
	{
		public string make { get; set; }

		public string model { get; set; }

		public string modelYear { get; set; }

		public string bodyType { get; set; }

		public string color { get; set; }

		public string oldPlateNumber { get; set; }

		public string plate { get; set; }

		public string registrationType { get; set; }

		public string chassisNumber { get; set; }

		public int licenseExpiryDate { get; set; }

		public string insuranceCompany { get; set; }

		public int sequenceNumber { get; set; }

		public int numberOfPreviousOwners { get; set; }

		public int involvementSequence { get; set; }

		public string insurancePolicyNumber { get; set; }

		public int insuranceExpiryDate { get; set; }

		public string ownerId { get; set; }

		public string ownerName { get; set; }

		public string drivingDirection { get; set; }

		public string damageStatus { get; set; }

		public string damagePoint { get; set; }

		public string damageDescription { get; set; }

		public int numberOfPassengers { get; set; }

		public string[] imagesTokens { get; set; }
	}
}
