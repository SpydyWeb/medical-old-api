using CORE.DTOs.APIs.TPServices;
using CORE.TablesObjects;

namespace InsuranceAPIs.Models.ExternalAPIs
{
	public class PolicyData
	{
		public Production policiesInfo { get; set; }

		public YakeenMemberList lsYakeen { get; set; }
	}
}
