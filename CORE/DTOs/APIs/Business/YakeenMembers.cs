using System.Collections.Generic;

namespace CORE.DTOs.APIs.Business
{
	public class YakeenMembers
	{
		public YakeenLogsMember Members { get; set; }

		public List<YakeenLogsMember> Dependent { get; set; }

		public YakeenMembers()
		{
			Members = new YakeenLogsMember();
			Dependent = new List<YakeenLogsMember>();
		}
	}
}
