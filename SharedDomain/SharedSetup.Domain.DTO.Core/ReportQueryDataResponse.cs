using System.Collections.Generic;

namespace SharedSetup.Domain.DTO.Core
{
	public class ReportQueryDataResponse
	{
		public string p1_QUERY { get; set; }

		public List<ResultHook> result { get; set; }
	}
}
