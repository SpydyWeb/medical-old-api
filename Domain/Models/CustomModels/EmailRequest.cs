using System.Collections.Generic;

namespace Domain.Models.CustomModels
{
	public class EmailRequest
	{
		public List<string> To { get; set; }

		public string body { get; set; }

		public string Subject { get; set; }

		public string ErrorDetails { get; set; }

		public string PolicyNumber { get; set; }

		public string SponsorNumber { get; set; }

		public string PlanName { get; set; }

		public string MemberID { get; set; }

		public bool IsCCHIDown { get; set; }

		public string CCHIDown { get; set; } = " CCHI uploading is down from CCHI side";

	}
}
