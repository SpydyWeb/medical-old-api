namespace CORE.DTOs.APIs.TPServices
{
	public class CustomerDetailsResponse
	{
		public string? SegmentCode { get; set; }

		public string? Name { get; set; }

		public string? CommercialName { get; set; }

		public string? NationalID { get; set; }

		public string? BirthDate { get; set; }

		public WatheqStatus Status { get; set; }
	}
}
