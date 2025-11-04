namespace CORE.DTOs.PricingEngine
{
	public class FactorElements
	{
		public int Id { get; set; }

		public int FactorId { get; set; }

		public decimal? RangeFrom { get; set; }

		public decimal? RangeTo { get; set; }

		public decimal? FixedValue { get; set; }

		public decimal? Percentage { get; set; }

		public decimal? Premium { get; set; }

		public string ElementName { get; set; }
	}
}
