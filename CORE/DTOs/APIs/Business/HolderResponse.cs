using CORE.DTOs.APIs.Unified_Response;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class HolderResponse : Results
	{
		public PolicyHolders PolicyHolders { get; set; }

		public HolderResponse()
		{
			PolicyHolders = new PolicyHolders();
		}
	}
}
