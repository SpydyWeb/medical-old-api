using System.Collections.Generic;
using Domain.Interfaces.Shared;

namespace Domain.Common
{
	public class MntOldMIProvidersResponse<T> : IMntOldMIProvidersResponse<T>
	{
		public List<T> dtNetworkProviders { get; set; }

		public long? PageCount { get; set; }

		public long? NetworkID { get; set; }

		public string ReferenceNumber { get; set; }

		public List<string> Errors { get; set; }
	}
}
