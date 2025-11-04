namespace CORE.DTOs.APIs.Business
{
	public class CalculateMMPResponse
	{
		public decimal? GrossPremium { get; set; }

		public string Name { get; set; }

		public string NationalId { get; set; }

		public int LiabilityId { get; set; }

		public int ProffessionId { get; set; }

		public int CategoryId { get; set; }

		public int PolicyPeriod { get; set; }
	}
}
