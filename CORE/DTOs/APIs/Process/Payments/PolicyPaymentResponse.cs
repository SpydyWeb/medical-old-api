using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Process.Payments
{
	public class PolicyPaymentResponse : Results
	{
		public decimal Premium { get; set; }

		public decimal Vat { get; set; }

		public decimal Total { get; set; }

		public int MembersCount { get; set; }
	}
}
