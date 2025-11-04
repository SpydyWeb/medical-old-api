using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.TPServices
{
	public class CRDetailsResponse : Results
	{
		public string? crName { get; set; }

		public string? crNumber { get; set; }

		public string? crEntityNumber { get; set; }

		public string? issueDate { get; set; }

		public string? expiryDate { get; set; }

		public string? crMainNumber { get; set; }

		public businessType? businessType { get; set; }

		public fiscalYear? fiscalYear { get; set; }

		public new status? status { get; set; }

		public location? location { get; set; }

		public activities? activities { get; set; }

		public cancellation? cancellation { get; set; }

		public company? company { get; set; }

		public WatheqStatus RequestStatus { get; set; }
	}
}
