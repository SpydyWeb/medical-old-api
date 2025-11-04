using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Process.Reports
{
	public class ReportOut : Results
	{
		public int HistoryId { get; set; }

		public string Path { get; set; }
	}
}
