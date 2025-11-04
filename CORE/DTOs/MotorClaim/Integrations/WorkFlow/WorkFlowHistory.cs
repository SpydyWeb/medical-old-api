using System;

namespace CORE.DTOs.MotorClaim.WorkFlow
{
	public class WorkFlowHistory
	{
		public int Id { get; set; }

		public DateTime CreationDate { get; set; }

		public int Status { get; set; }

		public string TriggerValue { get; set; }

		public string CreatedBy { get; set; }

		public int ClaimId { get; set; }

		public int WorkflowStageId { get; set; }

		public string ModifiedBy { get; set; }
	}
}
