using System;

namespace CORE.DTOs.MotorClaim.Productions
{
	public class VehileCovers
	{
		public int Id { get; set; }

		public int PolicyId { get; set; }

		public int VehicleId { get; set; }

		public string CoverName { get; set; }

		public DateTime? CoverEffectiveDate { get; set; }

		public DateTime TransferDate { get; set; }
	}
}
