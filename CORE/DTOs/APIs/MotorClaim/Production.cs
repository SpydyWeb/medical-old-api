using System.Collections.Generic;
using CORE.DTOs.MotorClaim;

namespace CORE.DTOs.APIs.MotorClaim
{
	public class Production
	{
		public ProductionInfo policy { get; set; }

		public List<VehicleInfos> Vehicles { get; set; }

		public Production()
		{
			policy = new ProductionInfo();
			Vehicles = new List<VehicleInfos>();
		}
	}
}
