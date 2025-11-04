namespace SharedDomain.DTO.New_Financial_Model
{
	public class RolesOutput
	{
		public long ID { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public string Notes { get; set; }

		public long ApplicationId { get; set; }

		public long ChartOfAccountId { get; set; }

		public RolesOutputExtend Extend { get; set; }
	}
}
