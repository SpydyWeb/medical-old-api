namespace SharedDomain.DTO.New_Financial_Model
{
	public class CustomerAccountOutput
	{
		public long ID { get; set; }

		public long CustomerId { get; set; }

		public int CustomerType { get; set; }

		public int DR_Account { get; set; }

		public int CR_Account { get; set; }

		public string DR_Account_Name { get; set; }

		public string CR_Account_Name { get; set; }

		public long RoleId { get; set; }

		public CustomerAccountOutputExtend Extend { get; set; }
	}
}
