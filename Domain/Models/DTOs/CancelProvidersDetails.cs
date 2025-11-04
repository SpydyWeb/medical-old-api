using System.Collections.Generic;

namespace Domain.Models.DTOs
{
	public class CancelProvidersDetails
	{
		public string CchiAccessKey { get; set; }

		public int CompanyId { get; set; }

		public List<Provider> dtProviders { get; set; }

		public string UserName { get; set; }
	}
}
