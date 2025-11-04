using System.Collections.Generic;
using InsuranceAPIs.Models.Authentications;

namespace InsuranceAPIs.Models.ExternalAPIs
{
	public class PolicyIssuance
	{
		public List<MemberBulkInfo> lsMembers { get; set; }

		public int BusinessType { get; set; }

		public long PolicyHolderId { get; set; }

		public string PolicyHolderCR { get; set; }

		public string PolicyHolderName { get; set; }

		public UserAuth userAuth { get; set; }
	}
}
