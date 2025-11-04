namespace SharedDomain.DTO.New_Financial_Model
{
	public class AccountOutput
	{
		public long ID { get; set; }

		public string ChartOfAccountNo { get; set; }

		public string Name { get; set; }

		public long MainAccountId { get; set; }

		public int Status { get; set; }

		public int CompanyId { get; set; }

		public int AccountNature { get; set; }

		public AccountOutputExtend Extend { get; set; }
	}
}
