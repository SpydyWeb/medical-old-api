using System.Collections.Generic;

namespace Domain.Interfaces.Shared
{
	public interface IMntOldMIProvidersResponse<T>
	{
		List<T> dtNetworkProviders { get; set; }

		long? PageCount { get; set; }

		long? NetworkID { get; set; }

		string ReferenceNumber { get; set; }
	}
}
