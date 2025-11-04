namespace Domain.Models.DTOs
{
	public class CchiGovernmentIntegration
	{
		public string ServiceURL { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string TimerPeriod { get; set; }

		public string TimerDue { get; set; }

		public string DocumentTypes { get; set; }

		public string EndorsementTypes { get; set; }

		public string BusinessTypes { get; set; }

		public string IssueDateStart { get; set; }

		public string EffectiveDateStart { get; set; }

		public string PolicyType { get; set; }

		public string CreatedDateStart { get; set; }

		public int UserCompanyID { get; set; }

		public string AccessKey { get; set; }

		public string LiveAccessKey { get; set; }

		public bool EnableSponsorsCheck { get; set; }
	}
}
