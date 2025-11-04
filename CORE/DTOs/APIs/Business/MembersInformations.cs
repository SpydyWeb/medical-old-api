using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Business
{
	public class MembersInformations : Results
	{
		public List<MembersList> Members { get; set; }
	}
}
