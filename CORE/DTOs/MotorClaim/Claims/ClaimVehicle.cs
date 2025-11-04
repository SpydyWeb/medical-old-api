namespace CORE.DTOs.MotorClaim.Claims
{
	public class ClaimVehicle
	{
		public long Id { get; set; }

		public long ClaimId { get; set; }

		public long PolicyId { get; set; }

		public int RiskId { get; set; }
	}
}
