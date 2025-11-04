using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class LoadPolicyBusiness : Results
	{
		public List<Production> Headers { get; set; }

		public List<Subjects> Subjects { get; set; }
	}
}
