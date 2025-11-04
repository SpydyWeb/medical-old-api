using System.Collections.Generic;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class MembersList
	{
		public Subjects Member { get; set; }

		public List<Subjects> Dependent { get; set; }
	}
}
