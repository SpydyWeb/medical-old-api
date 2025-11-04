using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Models.DTOs
{
	public class CCHIBenefitResponseInvalid
	{
		[JsonProperty("REFRENCENUMBER")]
		public string REFRENCENUMBER { get; set; }

		[JsonProperty("ERRORS")]
		public List<BENEFITErrorResponse> Errors { get; set; }

		[JsonProperty("STATUS")]
		public string STATUS { get; set; }
	}
}
