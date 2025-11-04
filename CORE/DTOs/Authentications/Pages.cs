namespace CORE.DTOs.Authentications
{
	public class Pages
	{
		public int Id { get; set; }

		public string PageName { get; set; }

		public string? Description { get; set; }

		public int PageOrder { get; set; }

		public bool IsGroup { get; set; }

		public int? PageId { get; set; }

		public string? ActionName { get; set; }

		public string? ControllerName { get; set; }

		public bool IsActive { get; set; }

		public bool? isMapped { get; set; }
	}
}
