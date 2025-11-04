namespace CORE.DTOs.MotorClaim.WorkFlow
{
	public class WorkFlowStages
	{
		public int Id { get; set; }

		public string StageName { get; set; }

		public int Order { get; set; }

		public string Description { get; set; }

		public string EmailSubjectTemplate { get; set; }

		public string EmailBodyTemplate { get; set; }

		public bool IsActive { get; set; }

		public string Query { get; set; }

		public int PolicyType { get; set; }

		public int OutComeType { get; set; }

		public string Operator { get; set; }

		public string ComparingValue { get; set; }

		public string? CreatedBy { get; set; }

		public string? ModifiedBy { get; set; }
	}
}
