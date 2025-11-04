using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Business;

namespace CORE.DTOs.APIs.Business
{
	public class LoadCreditLimitOutput : Results
	{
		public List<CreditLimits> lcreditLimits { get; set; }

		public LoadCreditLimitOutput()
		{
			lcreditLimits = new List<CreditLimits>();
		}
	}
}
