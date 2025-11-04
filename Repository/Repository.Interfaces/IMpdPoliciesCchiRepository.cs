using System.Collections.Generic;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;

namespace Repository.Interfaces
{
	public interface IMpdPoliciesCchiRepository : IRepository<MpdPoliciesCchi>
	{
		IResponseResult<IEnumerable<MpdPoliciesCchi>> GetByCriteria(MpdPoliciesSearchCriteria searchCriteria);

		IResponseResult<string> ChangePlcPriority(long PolicyId, long Priority, string CreationUser);

		IResponseResult<string> UpdatePoliciesStatus(long CchiPlcId, string CchiId, string Status, string StatusDesc, string TransactionType, string CreationUser, long? SeqNo);

		List<MpdPoliciesCchi> LoadPolicies();

		List<MpdPoliciesCchi> LoadTransactionsForCCHI();

		List<MpdPoliciesCchi> CollectClassesInfo(int Flag);
	}
}
