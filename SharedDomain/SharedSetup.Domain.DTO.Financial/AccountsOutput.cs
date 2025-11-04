namespace SharedSetup.Domain.DTO.Financial
{
	public class AccountsOutput
	{
		public int ID { get; set; }

		public string ChartOfAccountNo { get; set; }

		public string NAME { get; set; }

		public int MainAccountId { get; set; }

		public int CompanyId { get; set; }

		public int AccountNature { get; set; }

		public bool Status { get; set; }
	}
}
