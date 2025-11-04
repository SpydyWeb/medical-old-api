using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;

namespace Service.Interfaces
{
	public interface IMpdMembersCchiService : IService<MpdMembersCchi>
	{
		IResponseResult<string> OnHoldMembers(long PolicyId, string MemberIds, long Flag, string CreationUser);

		Task<IResponseResult<IEnumerable<MpdMembersCchi>>> GetMembersSuggest(MpdMembersCchiSearchCriteria search);

		Task<IResponseResult<IEnumerable<MpdMembersCchi>>> GetByCriteria(MpdMembersCchiSearchCriteria search);
	}
}
