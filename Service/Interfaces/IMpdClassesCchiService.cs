using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;

namespace Service.Interfaces
{
	public interface IMpdClassesCchiService : IService<MpdClassesCchi>
	{
		Task<IResponseResult<IEnumerable<MpdClassesCchi>>> GetClassesSuggest(MpdClassesCchiSearchCriteria search);

		Task<IResponseResult<IEnumerable<MpdClassesCchi>>> GetByCriteria(MpdClassesCchiSearchCriteria search);
	}
}
