namespace CORE.DTOs.APIs.Business
{
	public class Princible
	{
		public string NationalId { get; set; }

		public string? Sponsor { get; set; }

		public string? Error { get; set; }

		public bool IsSuccess { get; set; }

		public string DateOfBirth { get; set; }
	}
}
