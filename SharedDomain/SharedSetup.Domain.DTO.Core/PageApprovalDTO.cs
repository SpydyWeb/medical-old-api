using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Core
{
	public class PageApprovalDTO
	{
		public long iD { get; set; }

		public string name { get; set; }

		public string name2 { get; set; }

		public int menuOrder { get; set; }

		public int menuType { get; set; }

		public string url { get; set; }

		public int subSystemID { get; set; }

		public int applicationID { get; set; }

		public string systemCode { get; set; }

		public string moduleCode { get; set; }

		public IEnumerable<ControlApprovalDTO> controls { get; set; }

		[JsonProperty("Order")]
		private int Order
		{
			set
			{
				menuOrder = value;
			}
		}

		[JsonProperty("CAM_APP_ID")]
		private int CAM_APP_ID
		{
			set
			{
				applicationID = value;
			}
		}

		[JsonProperty("CAM_SYS_CODE")]
		private string CAM_SYS_CODE
		{
			set
			{
				systemCode = value;
			}
		}

		[JsonProperty("CAM_MOD_CODE")]
		private string CAM_MOD_CODE
		{
			set
			{
				moduleCode = value;
			}
		}
	}
}
