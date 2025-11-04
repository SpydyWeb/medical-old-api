using CORE.DTOs.Business;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Process.Approvals
{
	public class approvalhistlist
	{
		public ApprovalHistDetails approvalHistDetails { get; set; }

		public Production Production { get; set; }

		public approvalhistlist()
		{
			Production = new Production();
			approvalHistDetails = new ApprovalHistDetails();
		}
	}
}
