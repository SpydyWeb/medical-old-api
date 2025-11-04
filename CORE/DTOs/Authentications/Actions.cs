namespace CORE.DTOs.Authentications
{
	public class Actions
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool? isMapped { get; set; }

		public int PageId { get; set; }

		public string UpperActionName { get; set; }

		public string ActionName { get; set; }

		public string ControllerName { get; set; }

		public string? CreatedBy { get; set; }
	}
}
