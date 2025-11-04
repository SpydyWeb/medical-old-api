namespace CORE.DTOs.MotorClaim.Frauds
{
	public class FraudIndicators
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int Score { get; set; }

		public string Query { get; set; }

		public int PolicyType { get; set; }

		public int OutComeType { get; set; }

		public string Operator { get; set; }

		public string ComparingValue { get; set; }

		public string? CreatedBy { get; set; }

		public string? ModifiedBy { get; set; }

		public bool IsActive { get; set; }
	}
}
