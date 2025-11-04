using System;

namespace CORE.DTOs.APIs.Process.Approvals
{
	public class LoadApprovalsInput
	{
		public int? UserId { get; set; }

		public bool? AllApprovals { get; set; }

		public int? ActionStatus { get; set; }

		public DateTime? Fromdate { get; set; }

		public int? NoOfApprovals { get; set; }

		public string? CROrAppNo { get; set; }

		public string? PolicyNo { get; set; }
	}
}
