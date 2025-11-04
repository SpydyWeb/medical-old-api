namespace SharedSetup.Domain.DTO.Financial
{
	public class CustomerAccountDTO
	{
		public int ID { get; set; }

		public int CustomerId { get; set; }

		public int? CustomerType { get; set; }

		public int DR_Account { get; set; }

		public int CR_Account { get; set; }

		public int RoleId { get; set; }

		public ExtendCustomerAccountDTO Extend { get; set; }
	}
}
