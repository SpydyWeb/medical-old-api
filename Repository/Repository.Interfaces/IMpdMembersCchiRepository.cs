using System.Collections.Generic;
using Domain.Interfaces.Shared;
using Domain.Models;

namespace Repository.Interfaces
{
	public interface IMpdMembersCchiRepository : IRepository<MpdMembersCchi>
	{
		IResponseResult<string> OnHoldMembers(long PolicyId, string MemberIds, long flag, string CreationUser);

		List<MpdMembersCchi> LoadMembers(int PolicyCchiId);

		long LoadCodeById(long Id);

		IResponseResult<string> UpdateMembersStatusDB(long MpdPlcCchiId, string MpdMbrSegmentCode, string Status, string StatusDesc, string TransactionType, string CreationUser);

		int CheckMemberActionType(long MpdPlmId);
	}
}
