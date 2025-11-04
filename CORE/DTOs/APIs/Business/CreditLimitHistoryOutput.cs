using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Business;

namespace CORE.DTOs.APIs.Business
{
	public class CreditLimitHistoryOutput : Results
	{
		public List<CreditLimitHistory> creditLimitHistories { get; set; }

		public CreditLimitHistoryOutput()
		{
			creditLimitHistories = new List<CreditLimitHistory>();
		}
	}
}
