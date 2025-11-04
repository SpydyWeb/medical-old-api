using System;

namespace Domain.Models.SearchCriteria
{
	public class SstCoreQuestionnairesSearchCriteria
	{
		public long CompanyId { get; set; }

		public long SystemId { get; set; }

		public long? ClassId { get; set; }

		public long? PolicyTypeId { get; set; }

		public long? BusinessType { get; set; }

		public long? Status { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public string UserName { get; set; }

		public DateTime? StatsDate { get; set; }
	}
}
