using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Business
{
	public class CancellationReasonOutput : Results
	{
		public List<CancellationReason> cancellationReasons { get; set; }

		public CancellationReasonOutput()
		{
			cancellationReasons = new List<CancellationReason>();
		}
	}
}
