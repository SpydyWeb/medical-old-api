using System;

namespace CORE.DTOs.MotorClaim.Productions
{
	public class Drivers
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string NationalId { get; set; }

		public DateTime DateOfBirth { get; set; }

		public int VehicleId { get; set; }
	}
}
