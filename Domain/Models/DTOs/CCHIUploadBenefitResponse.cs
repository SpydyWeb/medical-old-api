using Newtonsoft.Json;

namespace Domain.Models.DTOs
{
	public class CCHIUploadBenefitResponse
	{
		[JsonProperty("REFRENCENUMBER")]
		public string REFRENCENUMBER { get; set; }

		[JsonProperty("STATUS")]
		public string STATUS { get; set; }
	}
}
