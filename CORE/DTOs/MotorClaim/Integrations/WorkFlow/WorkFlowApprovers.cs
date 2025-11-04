namespace CORE.DTOs.MotorClaim.WorkFlow
{
	public class WorkFlowApprovers
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public int ApprovalLevel { get; set; }

		public int ApprovalType { get; set; }

		public int StageId { get; set; }

		public string? CreatedBy { get; set; }

		public string? ModifiedBy { get; set; }
	}
}
