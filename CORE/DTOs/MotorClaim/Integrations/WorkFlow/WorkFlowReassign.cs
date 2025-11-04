using System;

namespace CORE.DTOs.MotorClaim.WorkFlow
{
	public class WorkFlowReassign
	{
		public int Id { get; set; }

		public int WorkFlowHistoryDetailId { get; set; }

		public string AssignFrom { get; set; }

		public string AssignTo { get; set; }

		public DateTime AssignDate { get; set; }

		public string AssignedBy { get; set; }

		public string ModifiedBy { get; set; }
	}
}
