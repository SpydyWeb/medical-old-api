using System.Collections.Generic;
using Domain.Interfaces.Shared;
using Domain.Models;

namespace Service.Interfaces
{
	public interface IMpdBenefitsCchiService : IService<MpdBenefitsCchi>
	{
		IResponseResult<List<MpdBenefitsCchi>> GetBenefitsList(int classID);
	}
}
