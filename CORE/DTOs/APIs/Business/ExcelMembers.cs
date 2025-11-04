using System.Collections.Generic;

namespace CORE.DTOs.APIs.Business
{
	public class ExcelMembers
	{
		public MainMemberInfo memberInfo { get; set; }

		public List<MainMemberInfo> dependent { get; set; }

		public bool YakeenPolicyLevel { get; set; }

		public ExcelMembers()
		{
			dependent = new List<MainMemberInfo>();
			memberInfo = new MainMemberInfo();
		}
	}
}
