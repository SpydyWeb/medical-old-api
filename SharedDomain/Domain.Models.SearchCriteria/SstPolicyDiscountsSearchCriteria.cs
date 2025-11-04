using System;

namespace Domain.Models.SearchCriteria
{
	public class SstPolicyDiscountsSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? DiscountId { get; set; }

		public long? ClassId { get; set; }

		public long? BusinessType { get; set; }

		public long? PolicyType { get; set; }

		public string UserName { get; set; }

		public DateTime? EffectiveDate { get; set; }

		public DateTime? ExpiryDate { get; set; }
	}
}
