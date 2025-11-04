using CORE.DTOs.APIs.Business;

namespace CORE.DTOs.APIs.Process.Approvals
{
	public class AddToApprovals
	{
		public ApprovalHistory approvalHistory { get; set; }

		public AddToApprovals()
		{
			approvalHistory = new ApprovalHistory();
		}
	}
}
