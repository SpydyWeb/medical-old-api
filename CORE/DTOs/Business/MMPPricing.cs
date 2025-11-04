namespace CORE.DTOs.Business
{
	public class MMPPricing
	{
		public int Id { get; set; }

		public int Idemnity { get; set; }

		public int Aggregator { get; set; }

		public string? Proffision { get; set; }

		public string? Category { get; set; }

		public decimal? Gross { get; set; }
	}
}
