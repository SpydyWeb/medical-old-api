using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.TPServices
{
	public class YakeenMemberList : Results
	{
		public List<YakeenErrorLst?> yakeenErrorLsts = new List<YakeenErrorLst>();

		public List<PolicyMembers?> policyMembers = new List<PolicyMembers>();
	}
}
