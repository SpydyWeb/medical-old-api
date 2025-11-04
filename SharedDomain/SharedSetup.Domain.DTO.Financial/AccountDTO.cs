namespace SharedSetup.Domain.DTO.Financial
{
	public class AccountDTO
	{
		public int ID { get; set; }

		public int SERIAL_NO { get; set; }

		public string ACCOUNT_NO { get; set; }

		public string NAME { get; set; }

		public bool STATUS { get; set; }

		public string DESCRIPTION { get; set; }

		public int ACCOUNT_NATURE { get; set; }

		public string ACCOUNT_NATURE_NAME { get; set; }

		public string REFERENCE_NO { get; set; }

		public int ACCOUNT_TYPE { get; set; }

		public int ENTITY_ID { get; set; }

		public int MAIN_ID { get; set; }

		public int MAIN_ID_L1 { get; set; }

		public string MAIN_NAME_L1 { get; set; }

		public int MAIN_LEVEL_L1 { get; set; }

		public int MAIN_ID_L2 { get; set; }

		public string MAIN_NAME_L2 { get; set; }

		public int MAIN_LEVEL_L2 { get; set; }

		public int MAIN_ID_L3 { get; set; }

		public string MAIN_NAME_L3 { get; set; }

		public int MAIN_LEVEL_L3 { get; set; }
	}
}
