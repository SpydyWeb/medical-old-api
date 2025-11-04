namespace CORE.DTOs.APIs.APIs_Scheduler
{
	public class APIsSchedulersConfig
	{
		public bool IsEnabled { get; set; }

		public int WorksEveryMnt { get; set; }

		public int ReportEveryMnt { get; set; }

		public bool IsReportEnable { get; set; }

		public bool IsPolicyRunning { get; set; } = false;


		public bool IsMembersRunning { get; set; } = false;


		public bool IsGetClassInfoRunning { get; set; } = false;


		public bool IsUploadBenefitsRunning { get; set; } = false;


		public bool IsUploadNonStandardBenefitsRunning { get; set; } = false;

	}
}
