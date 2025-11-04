namespace SharedSetup.Domain.DTO.Financial
{
	public class RolesInput
	{
		public int? ID { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public string Notes { get; set; }

		public int? ApplicationId { get; set; }

		public int? ChartOfAccountId { get; set; }
	}
}
