using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Process.Approvals
{
	public class LoadHistoryDetails : Results
	{
		public List<approvalhistlist> LoadApprovalHistDetails { get; set; }

		public LoadHistoryDetails()
		{
			LoadApprovalHistDetails = new List<approvalhistlist>();
		}
	}
}
