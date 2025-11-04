using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class LoadDocsBusiness : Results
	{
		public List<Production> productions { get; set; }

		public LoadDocsBusiness()
		{
			productions = new List<Production>();
		}
	}
}
