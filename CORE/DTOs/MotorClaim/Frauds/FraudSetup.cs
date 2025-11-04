namespace CORE.DTOs.MotorClaim.Frauds
{
	public class FraudSetup
	{
		public int Id { get; set; }

		public int ScoreFrom { get; set; }

		public int ScoreTo { get; set; }

		public int FraudResult { get; set; }

		public string Color { get; set; }

		public string CreatedBy { get; set; }

		public string? ModifiedBy { get; set; }
	}
}
