using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;

namespace Service.Interfaces
{
	public interface IMpdSponsorsCchiService : IService<MpdSponsorsCchi>
	{
		Task<IResponseResult<IEnumerable<MpdSponsorsCchi>>> GetByCriteria(MpdSponsorsCchiSearchCriteria search);
	}
}
