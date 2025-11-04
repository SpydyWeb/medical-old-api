using SharedSetup.Domain.Models;

namespace SharedDomain.Models.SearchCriteria
{
	public class AcccountEntry
	{
		public long classId { get; set; }

		public long policyType { get; set; }

		public long systemId { get; set; }

		public SstAccounts[] accounts { get; set; }
	}
}
