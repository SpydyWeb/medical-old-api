using System;
using System.Collections.Generic;

namespace SharedDomain.Models
{
	public class FeesSearchCriteria
	{
		public long? SystemId { get; set; }

		public string DocumentType { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public string Currency { get; set; }

		public string UserName { get; set; }

		public long? FeeName { get; set; }

		public long CompanyId { get; set; }

		public long? ApplicableTo { get; set; }

		public long? CalculatedFrom { get; set; }

		public long? FeeCategory { get; set; }

		public List<byte?> ClaimTransactionType { get; set; }

		public byte? FeeType { get; set; }

		public string Name { get; set; }

		public DateTime? FeeDate { get; set; }

		public long? sumInsured { get; set; }

		public List<byte?> ReinsuranceTransactionType { get; set; }
	}
}
