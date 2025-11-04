namespace CORE.DTOs.APIs.Business
{
	public class NationalityMapping
	{
		public int Id { get; set; }

		public string? NationalityNameEn { get; set; }

		public string? NationalityNameAr { get; set; }

		public string? EskaCode { get; set; }

		public string? EskaNameEn { get; set; }

		public string? EskaNameAr { get; set; }

		public int? ClassId { get; set; }
	}
}
