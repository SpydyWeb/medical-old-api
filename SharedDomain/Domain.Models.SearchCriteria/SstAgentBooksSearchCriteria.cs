namespace Domain.Models.SearchCriteria
{
	public class SstAgentBooksSearchCriteria
	{
		public long SystemId { get; set; }

		public long? BusinessShare { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? AgentId { get; set; }

		public string BookNo { get; set; }

		public long? CertificateType { get; set; }

		public long? DocumentType { get; set; }

		public long? AgentBookStatus { get; set; }

		public long CompanyId { get; set; }

		public string Name { get; set; }

		public string Query { get; set; }
	}
}
