using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Business
{
	public class ApprovalHistDeclaration : Results
	{
		public List<MemberDeclare> memberDeclares { get; set; }

		public ApprovalHistDeclaration()
		{
			memberDeclares = new List<MemberDeclare>();
		}
	}
}
