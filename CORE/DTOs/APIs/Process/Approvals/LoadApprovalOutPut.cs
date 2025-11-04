using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Process.Approvals
{
	public class LoadApprovalOutPut : Results
	{
		public List<ApprovalSet> approvalSets { get; set; }

		public LoadApprovalOutPut()
		{
			approvalSets = new List<ApprovalSet>();
		}
	}
}
