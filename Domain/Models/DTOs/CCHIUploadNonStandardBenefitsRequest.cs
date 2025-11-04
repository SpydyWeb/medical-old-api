using System.Collections.Generic;

namespace Domain.Models.DTOs
{
	public class CCHIUploadNonStandardBenefitsRequest
	{
		public string POLICYNUMBER { get; set; }

		public int COMPANYNUMBER { get; set; }

		public string COMPANYCLASSID { get; set; }

		public int UPDATEREASON { get; set; }

		public List<BENEFITS> BENEFITS { get; set; }
	}
}
