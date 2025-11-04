namespace CORE.DTOs.MotorClaim.Integrations.Tables
{
	public class TaqdeerSparePartsInfo
	{
		public long Id { get; set; }

		public string? DACaseNumber { get; set; }

		public string? SparePartDealer { get; set; }

		public decimal SparePartCost { get; set; }

		public decimal SparePartDiscountPercent { get; set; }

		public decimal SparePartFinalCost { get; set; }
	}
}
