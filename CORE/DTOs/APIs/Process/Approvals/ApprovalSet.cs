using CORE.DTOs.APIs.Business;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Process.Approvals
{
	public class ApprovalSet
	{
		public ApprovalHistory approvalHistory { get; set; }

		public Production Production { get; set; }

		public ApprovalSet()
		{
			approvalHistory = new ApprovalHistory();
			Production = new Production();
		}
	}
}
