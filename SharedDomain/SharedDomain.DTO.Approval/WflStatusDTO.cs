using System.Collections.Generic;

namespace SharedDomain.DTO.Approval
{
	public class WflStatusDTO
	{
		public string WflStatus { get; set; }

		public string PendingWith { get; set; }

		public List<Action> Action { get; set; }

		public List<History> History { get; set; }
	}
}
