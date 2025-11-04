using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Shared;
using Domain.Models;

namespace Service.Interfaces
{
	public interface IMpdPoliciesCchiHistService : IService<MpdPoliciesCchiHist>
	{
		Task<IResponseResult<IEnumerable<MpdPoliciesCchiHist>>> GetHistByMpdPlcCchiId(long MpdPlcCchiId);
	}
}
