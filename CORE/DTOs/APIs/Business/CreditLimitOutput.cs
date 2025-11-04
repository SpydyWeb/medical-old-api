using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Business;

namespace CORE.DTOs.APIs.Business
{
	public class CreditLimitOutput : Results
	{
		public CreditLimits creditLimits { get; set; }

		public CreditLimitOutput()
		{
			creditLimits = new CreditLimits();
		}
	}
}
