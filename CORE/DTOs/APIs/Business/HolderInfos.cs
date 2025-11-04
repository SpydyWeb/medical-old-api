using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Business;

namespace CORE.DTOs.APIs.Business
{
	public class HolderInfos : Results
	{
		public CRDetails CRDetails { get; set; }

		public HolderInfos()
		{
			CRDetails = new CRDetails();
		}
	}
}
