using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Shared;
using Domain.Models;

namespace Service.Interfaces
{
	public interface IMpdMembersCchiHistService : IService<MpdMembersCchiHist>
	{
		Task<IResponseResult<IEnumerable<MpdMembersCchiHist>>> GetHistByMpdMemCchiId(long MpdPlcMemId);
	}
}
