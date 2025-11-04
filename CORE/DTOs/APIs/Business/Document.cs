using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class Document : Results
	{
		public List<Production> Headers { get; set; }

		public Document()
		{
			Headers = new List<Production>();
		}
	}
}
