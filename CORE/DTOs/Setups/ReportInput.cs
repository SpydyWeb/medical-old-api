using CORE.Extensions;

namespace CORE.DTOs.Setups
{
	public class ReportInput
	{
		public long EskaId { get; set; }

		public ReportType reportType { get; set; }

		public ReportParams reportParams { get; set; }

		public string Path { get; set; }

		public string FileName { get; set; }
	}
}
