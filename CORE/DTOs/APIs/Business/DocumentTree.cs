using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Business
{
	public class DocumentTree : Results
	{
		public List<Policy> Policies { get; set; }

		public List<Policy> Quotations { get; set; }

		public List<Policy> LatestTransactions { get; set; }

		public List<Policy> LatestNotPayed { get; set; }

		public DocumentTree()
		{
			Policies = new List<Policy>();
			Quotations = new List<Policy>();
			LatestTransactions = new List<Policy>();
			LatestNotPayed = new List<Policy>();
		}
	}
}
