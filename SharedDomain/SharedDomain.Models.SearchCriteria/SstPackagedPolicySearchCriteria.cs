using System;

namespace SharedDomain.Models.SearchCriteria
{
	public class SstPackagedPolicySearchCriteria
	{
		public long CompanyID { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public string ShortName { get; set; }

		public string Name { get; set; }

		public long? Status { get; set; }

		public DateTime? EffectiveDate { get; set; }

		public DateTime? ExpiryDate { get; set; }

		public string UserName { get; set; }
	}
}
