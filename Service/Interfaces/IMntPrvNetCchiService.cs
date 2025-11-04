using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;

namespace Service.Interfaces
{
	public interface IMntPrvNetCchiService : IService<MntPrvNetCchi>
	{
		Task<IResponseResult<IEnumerable<MntPrvNetCchi>>> GetPrvByNetId(long Id);

		Task<IResponseResult<string>> getStatus(long NetCchiId, long ProvNetId);

		IMntOldMIProvidersResponse<MntPrvNetOldMedical> GetNetworksProviders(MntPrvNetSearchCriteria searchCriteria);
	}
}
