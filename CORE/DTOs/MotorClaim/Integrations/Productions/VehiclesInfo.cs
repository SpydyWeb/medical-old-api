using System;

namespace CORE.DTOs.MotorClaim.Productions
{
	public class VehiclesInfo
	{
		public int Id { get; set; }

		public int PolicyId { get; set; }

		public int RiskId { get; set; }

		public string SequanceNo { get; set; }

		public string CustomNo { get; set; }

		public string ChassisNo { get; set; }

		public int ManufactureYear { get; set; }

		public int? NoOfSeats { get; set; }

		public string PlateNo { get; set; }

		public int? DeductibleAmount { get; set; }

		public string Color { get; set; }

		public string Make { get; set; }

		public string Model { get; set; }

		public string VehicleBody { get; set; }

		public int? NoOfCoveredPassegers { get; set; }

		public DateTime TransferDate { get; set; }

		public DateTime VehicleEffectiveDate { get; set; }

		public DateTime VehicleExpiryDate { get; set; }

		public int SumInsured { get; set; }

		public string? MakeDesc { get; set; }

		public string? ModelDesc { get; set; }

		public string? BodyDesc { get; set; }

		public string? usageDesc { get; set; }

		public string? colorDesc { get; set; }

		public int? RepairCondition { get; set; }

		public string? RepairDesc { get; set; }

		public string? Name { get; set; }
	}
}
