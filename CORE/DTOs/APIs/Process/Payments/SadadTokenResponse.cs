using System;

namespace CORE.DTOs.APIs.Process.Payments
{
	public class SadadTokenResponse
	{
		public string access_token { get; set; }

		public string token_type { get; set; }

		public int expires_in { get; set; }

		public string UserName { get; set; }

		public string BillerId { get; set; }

		public DateTime issued { get; set; }

		public string expires { get; set; }

		public string? error { get; set; }

		public string? error_description { get; set; }
	}
}
