using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.TP_Services
{
	public class YakeenCarResponse : Results
	{
		public List<YkeenCars> lsYkeen { get; set; }

		public YakeenCarResponse()
		{
			lsYkeen = new List<YkeenCars>();
		}
	}
}
