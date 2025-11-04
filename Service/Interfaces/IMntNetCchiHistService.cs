using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Models;

namespace Service.Interfaces
{
	public interface IMntNetCchiHistService : IService<MntNetCchiHist>
	{
		Task<ResponseResult<List<MntNetCchiHist>>> GetByNetId(long netId);
	}
}
