namespace CORE.DTOs.MotorClaim.Claims
{
	public class LookupTable
	{
		public int Id { get; set; }

		public string? NameEnglish { get; set; }

		public string? NameArabic { get; set; }

		public int? MajorCode { get; set; }

		public int? MinorCode { get; set; }

		public string? Code { get; set; }

		public int? ParentId { get; set; }
	}
}
