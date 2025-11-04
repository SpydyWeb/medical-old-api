using System.Collections.Generic;

namespace SharedSetup.Domain.DTO.Core
{
	public class AddOpportunity
	{
		public string OpportunityTitle { get; set; }

		public string OpportunityDate { get; set; }

		public string Currency { get; set; }

		public string OpportunityDetails { get; set; }

		public int LeadId { get; set; }

		public string CreatedBy { get; set; }

		public int CompanyId { get; set; }

		public int BranchId { get; set; }

		public List<Product> Products { get; set; }
	}
}
