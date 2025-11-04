using System.Collections.Generic;

namespace Domain.Models.SearchCriteria
{
	public class AccountSearchCriteria
	{
		public long CompanyID { get; set; }

		public long? SystemID { get; set; }

		public long InsuranceClassID { get; set; }

		public long? PolicyTypeID { get; set; }

		public List<byte> buisnessTypeIDs { get; set; }

		public List<long> feeTierIDs { get; set; }

		public List<long> policyDiscountIDs { get; set; }

		public List<long> policyCoverIDs { get; set; }

		public long? fromBranch { get; set; }

		public long? toBranch { get; set; }

		public long? transactionId { get; set; }

		public string currencyCode { get; set; }

		public long? glAccount { get; set; }

		public long? refundGlAccount { get; set; }

		public long? costcenterId { get; set; }

		public string ModuleCode { get; set; }

		public AccountSearchCriteria()
		{
			buisnessTypeIDs = new List<byte>();
			feeTierIDs = new List<long>();
			policyDiscountIDs = new List<long>();
			policyCoverIDs = new List<long>();
			currencyCode = string.Empty;
		}
	}
}
