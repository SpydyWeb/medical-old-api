using System.Collections.Generic;

namespace CORE.DTOs.APIs.MotorClaim
{
	public class ClaimSearchResult
	{
		public List<Production> Productions { get; set; }

		public ClaimSearchResult()
		{
			Productions = new List<Production>();
		}
	}
}
