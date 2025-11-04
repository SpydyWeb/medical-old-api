namespace SharedDomain.DTO.New_Financial_Model
{
	public class AgentsInput
	{
		public long CompanyId { get; set; }

		public long CustomerId { get; set; }

		public string RoleIDs { get; set; }

		public bool IsBounded { get; set; }

		public string ExcludingCustomerId { get; set; }
	}
}
