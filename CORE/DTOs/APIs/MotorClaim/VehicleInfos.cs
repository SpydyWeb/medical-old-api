using System.Collections.Generic;
using CORE.DTOs.MotorClaim.Claims;
using CORE.DTOs.MotorClaim.Productions;

namespace CORE.DTOs.APIs.MotorClaim
{
	public class VehicleInfos
	{
		public VehiclesInfo Vehicle { get; set; }

		public List<Drivers> drivers { get; set; }

		public List<Claims> lsClaims { get; set; }

		public List<Attachments> lattachments { get; set; }

		public List<VehileCovers> VehicleCovers { get; set; }

		public VehicleInfos()
		{
			Vehicle = new VehiclesInfo();
			lattachments = new List<Attachments>();
			VehicleCovers = new List<VehileCovers>();
			drivers = new List<Drivers>();
			lsClaims = new List<Claims>();
		}
	}
}
