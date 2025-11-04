using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;

namespace Service.Interfaces
{
	public interface IMpdPoliciesCchiService : IService<MpdPoliciesCchi>
	{
		IResponseResult<IEnumerable<MpdPoliciesCchi>> GetByCriteria(MpdPoliciesSearchCriteria searchCriteria);

		IResponseResult<string> ChangePlcPriority(long PolicyId, long Priority, string CreationUser);

		Task<IResponseResult<IEnumerable<MpdPoliciesCchi>>> GetPolicySuggest(MpdPoliciesSearchCriteria searchCriteria);

		IResponseResult<MpdPoliciesCchi> ReUpload(MpdPoliciesCchi entity);

		IResponseResult<IEnumerable<MpdPoliciesCchi>> GetPolicyData(MpdPoliciesSearchCriteria searchCriteria);
	}
}
