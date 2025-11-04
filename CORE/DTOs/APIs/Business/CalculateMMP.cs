namespace CORE.DTOs.APIs.Business
{
	public class CalculateMMP
	{
		public int Id { get; set; }

		public int LiabilityId { get; set; }

		public int ProffessionId { get; set; }

		public int CategoryId { get; set; }

		public int PolicyPeriod { get; set; }

		public string NationalId { get; set; }
	}
}
