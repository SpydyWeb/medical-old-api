namespace Domain.Models.DTOs
{
	public class APIsSchedulersConfig
	{
		public bool IsEnabled { get; set; }

		public bool IsScheduled { get; set; }

		public bool IsScheduledYakeen { get; set; }

		public int WorksEveryMnt { get; set; }

		public int ReportEveryMnt { get; set; }

		public int insuranceCompanyID { get; set; }

		public bool IsReportEnable { get; set; }

		public bool IsPolicyRunning { get; set; } = false;


		public bool IsYakeenRunning { get; set; } = false;


		public bool IsMembersRunning { get; set; } = false;


		public bool IsGetClassInfoRunning { get; set; } = false;


		public bool IsUploadBenefitsRunning { get; set; } = false;


		public bool IsUploadNonStandardBenefitsRunning { get; set; } = false;


		public string WebsiteConnection { get; set; }

		public string NajmConnection { get; set; }
	}
}
