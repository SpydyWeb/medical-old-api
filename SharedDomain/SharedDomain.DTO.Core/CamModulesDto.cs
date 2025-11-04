using System;
using Newtonsoft.Json;

namespace SharedDomain.DTO.Core
{
	public class CamModulesDto
	{
		public string cODE { get; set; }

		public string nAME { get; set; }

		public string nAME2 { get; set; }

		public string cAM_SYS_CODE { get; set; }

		public int? mOD_ORDER { get; set; }

		public string cREATED_BY { get; set; }

		public DateTime cREATION_DATE { get; set; }

		public string mODIFIED_BY { get; set; }

		public DateTime? mODIFICATION_DATE { get; set; }

		public byte iS_FONT_AWESOME { get; set; }

		public string iCON { get; set; }

		[JsonProperty("caM_MOD_CODE")]
		private string caM_MOD_CODE
		{
			set
			{
				cODE = value;
			}
		}

		[JsonProperty("IS_FONT_AWESOME")]
		private bool IS_FONT_AWESOME
		{
			set
			{
				iS_FONT_AWESOME = (byte)(value ? 1u : 0u);
			}
		}
	}
}
