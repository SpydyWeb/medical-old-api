using Newtonsoft.Json;

namespace Domain.Models.DTOs
{
	public class CCHIGetClassInfoResponse
	{
		[JsonProperty("CLASSID")]
		public string CLASSID { get; set; }

		[JsonProperty("CLASSNAME")]
		public string CLASSNAME { get; set; }

		[JsonProperty("CCHICLASSID")]
		public string CCHICLASSID { get; set; }

		[JsonProperty("ISBENEFIT")]
		public string ISBENEFIT { get; set; }
	}
}
