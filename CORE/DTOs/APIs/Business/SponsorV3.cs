using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Business
{
	public class SponsorV3 : Results
	{
		public int RequiredMain { get; set; }

		public int RequiredDependent { get; set; }

		public int RemainingMain { get; set; }

		public int RemainingDependent { get; set; }
	}
}
