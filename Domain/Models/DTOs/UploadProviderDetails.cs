using System.Collections.Generic;

namespace Domain.Models.DTOs
{
	public class UploadProviderDetails
	{
		public int CompanyId { get; set; }

		public List<Provider> dtProviders { get; set; }

		public string CchiRefNo { get; set; }

		public long NetworkID { get; set; }

		public string username { get; set; }
	}
}
