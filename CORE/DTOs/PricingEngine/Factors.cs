namespace CORE.DTOs.PricingEngine
{
	public class Factors
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public int LOB { get; set; }

		public int ChannelId { get; set; }

		public int FactorType { get; set; }

		public int FactorInput { get; set; }

		public string Name { get; set; }

		public bool status { get; set; }

		public bool IsDiscount { get; set; }

		public bool IsFixedPrice { get; set; }
	}
}
