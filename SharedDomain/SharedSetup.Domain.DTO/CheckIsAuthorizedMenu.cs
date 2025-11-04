namespace SharedSetup.Domain.DTO
{
	public class CheckIsAuthorizedMenu
	{
		public string UserName { get; set; }

		public int? CompanyId { get; set; }

		public string URL { get; set; }

		public int? SystemId { get; set; }
	}
}
