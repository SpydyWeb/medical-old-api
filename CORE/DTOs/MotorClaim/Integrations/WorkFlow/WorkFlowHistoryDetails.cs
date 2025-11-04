using System;

namespace CORE.DTOs.MotorClaim.WorkFlow
{
	public class WorkFlowHistoryDetails
	{
		public int Id { get; set; }

		public string Email { get; set; }

		public string ApproverName { get; set; }

		public int ApprovalLevel { get; set; }

		public int ApprovalType { get; set; }

		public int Status { get; set; }

		public string Comments { get; set; }

		public bool Reassigned { get; set; }

		public int WorkFlowHistoryId { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? CompletionDate { get; set; }

		public string CreatedBy { get; set; }

		public string ModifiedBy { get; set; }
	}
}
