using System;

namespace SharedDomain.Models.SearchCriteria
{
	public class SstRatingMatrixSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyType { get; set; }

		public long? CoverType { get; set; }

		public string Name { get; set; }

		public bool? Status { get; set; }

		public DateTime? StatusDate { get; set; }

		public long? FinCustomerRole { get; set; }

		public long? FinCustomerId { get; set; }

		public string UserName { get; set; }
	}
}
