using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.TP_Services
{
	public class APIsLists : Results
	{
		public List<ServicesLink> services { get; set; }
	}
}
