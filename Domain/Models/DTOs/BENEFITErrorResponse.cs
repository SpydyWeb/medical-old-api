using Newtonsoft.Json;

namespace Domain.Models.DTOs
{
	public class BENEFITErrorResponse
	{
		[JsonProperty("BenefitID")]
		public long BenefitID { get; set; }

		[JsonProperty("Message")]
		public string Message { get; set; }

		[JsonProperty("ErrorCode")]
		public string ErrorCode { get; set; }
	}
}
