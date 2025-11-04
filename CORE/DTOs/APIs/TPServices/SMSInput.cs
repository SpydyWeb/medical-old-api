using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.TPServices
{
	public class SMSInput : Results
	{
		public string Mobile { get; set; }

		public string MessageBody { get; set; }

		public string? CustomerName { get; set; }
	}

	public class SMSRequestTaqnyat
	{
        public List<long> recipients { get; set; }
        public string body { get; set; }
		public string sender { get; set; } = "AJT";
		public string scheduledDatetime { get; set; } = DateTime.Now.ToString();
    }
}
