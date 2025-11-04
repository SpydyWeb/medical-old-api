using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class LoadMemberBusiness : Results
	{
		public Production Production { get; set; }

		public List<Subjects> Subjects { get; set; }
	}
}
