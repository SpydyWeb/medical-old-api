namespace CORE.DTOs.MotorClaim.Integrations.Tables
{
	public class TaqdeerCaseResponse
	{
		public long Id { get; set; }

		public string DACaseNumber { get; set; }

		public int Status { get; set; }

		public int DARefNumber { get; set; }

		public string ErrorCode { get; set; }

		public string ErrorMessage { get; set; }
	}
}
