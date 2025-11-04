using System;

namespace Domain.Models.SearchCriteria
{
	public class CommissionTypesSearch
	{
		public int? SystemId { get; set; }

		public int CompanyId { get; set; }

		public long? CommissionType { get; set; }

		public string Name { get; set; }

		public long? BusinessChannel { get; set; }

		public long? Position { get; set; }

		public long? Broker { get; set; }

		public long? Branch { get; set; }

		public long? InsuranceClass { get; set; }

		public long? PolicyType { get; set; }

		public DateTime? ValidFrom { get; set; }

		public DateTime? ValidTo { get; set; }

		public string UserName { get; set; }
	}
}
