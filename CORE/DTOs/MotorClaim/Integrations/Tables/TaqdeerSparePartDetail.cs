namespace CORE.DTOs.MotorClaim.Integrations.Tables
{
	public class TaqdeerSparePartDetail
	{
		public long Id { get; set; }

		public string? DACaseNumber { get; set; }

		public int IdSpareInfo { get; set; }

		public string? SparePartName { get; set; }

		public bool IsOriginal { get; set; }

		public int Quantity { get; set; }

		public decimal Price { get; set; }

		public decimal Discount { get; set; }

		public decimal AfterDiscount { get; set; }
	}
}
