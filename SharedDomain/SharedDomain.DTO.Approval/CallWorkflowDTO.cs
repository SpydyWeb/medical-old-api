namespace SharedDomain.DTO.Approval
{
	public class CallWorkflowDTO
	{
		public string Username { get; set; }

		public long ProcessCode { get; set; }

		public long? CompanyId { get; set; }

		public object Variables { get; set; }
	}
}
