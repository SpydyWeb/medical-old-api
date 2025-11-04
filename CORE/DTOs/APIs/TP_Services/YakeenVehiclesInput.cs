using System.Collections.Generic;

namespace CORE.DTOs.APIs.TP_Services
{
	public class YakeenVehiclesInput
	{
		public List<VehicleInfo> lstVehicleInfo { get; set; }

		public YakeenVehiclesInput()
		{
			lstVehicleInfo = new List<VehicleInfo>();
		}
	}
}
