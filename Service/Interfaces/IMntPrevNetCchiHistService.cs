using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Shared;
using Domain.Models;

namespace Service.Interfaces
{
	public interface IMntPrevNetCchiHistService : IService<MntPrvNetCchiHist>
	{
		Task<IResponseResult<List<MntPrvNetCchiHist>>> GetByNetId(long netId);
	}
}
