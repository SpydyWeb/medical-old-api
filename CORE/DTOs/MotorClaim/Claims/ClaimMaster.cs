using System.Collections.Generic;
using CORE.DTOs.MotorClaim.Productions;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class ClaimMaster
	{
		public Claims claims { get; set; }

		public List<Claimants> claimants { get; set; }

		public ProductionInfo productionInfo { get; set; }

		public VehiclesInfo vehiclesInfo { get; set; }

		public ReserveBalance reserveBalance { get; set; }

		public ClaimMaster()
		{
			claims = new Claims();
			claimants = new List<Claimants>();
			productionInfo = new ProductionInfo();
			vehiclesInfo = new VehiclesInfo();
			reserveBalance = new ReserveBalance();
		}
	}
}
