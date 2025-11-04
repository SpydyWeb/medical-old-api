using System.Collections.Generic;
using SharedSetup.Domain.DTO.Core;

namespace SharedDomain.DTO.Core
{
	public class ReportParamDTO
	{
		public ICollection<RepParamsDTO> cAM_REP_PARAMS { get; set; }

		public ReportParamDTO()
		{
			cAM_REP_PARAMS = new HashSet<RepParamsDTO>();
		}
	}
}
