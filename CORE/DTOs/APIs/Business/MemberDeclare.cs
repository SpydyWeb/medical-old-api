using System.Collections.Generic;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class MemberDeclare
	{
		public ApprovalHistory ApprovalHistory { get; set; }

		public MembersDeclarations HealthDeclarations { get; set; }

		public Subjects Subjects { get; set; }

		public List<DeclarationsAnswers> declarationsAnswers { get; set; }

		public MemberDeclare()
		{
			ApprovalHistory = new ApprovalHistory();
			HealthDeclarations = new MembersDeclarations();
			Subjects = new Subjects();
			declarationsAnswers = new List<DeclarationsAnswers>();
		}
	}
}
