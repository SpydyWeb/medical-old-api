using System.Threading.Tasks;
using Domain.Common;
using Domain.Models;

namespace Service.Interfaces
{
	public interface IMntNetCchiService : IService<MntNetCchi>
	{
		Task<ResponseResult<string>> getReferenceNumber(long netId);

		Task<ResponseResult<string>> getStatus(long netId);

		Task<ResponseResult<MntNetCchi>> GetByNetId(long netId);

		Task<ResponseResult<MntNetCchi>> GetDataByNetId(long netId);
	}
}
