using System;
using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Core
{
	public class ReportDTO
	{
		public bool rEPORT_BUILDER_SOURCE { get; set; }

		public object rEPORT_BUILDER_FILE_NAME { get; set; }

		public string cODE { get; set; }

		public string rEPORT_NAME { get; set; }

		public string rEPORT_NAME2 { get; set; }

		public int rEPORT_ORDER { get; set; }

		public int cAM_RMU_ID { get; set; }

		public string dESCRIPTION { get; set; }

		public object iS_ATTACHMENT { get; set; }

		public object aTTACHMENT_NAME { get; set; }

		public object dEFAULT_PRINTER { get; set; }

		public int iS_WRITABLE_REPORT { get; set; }

		public object cAM_APP_ID { get; set; }

		public DateTime cREATIONDATE { get; set; }

		public object created_By { get; set; }

		public DateTime modification_Date { get; set; }

		public object modify_By { get; set; }

		public int aPP_ID { get; set; }

		public int cOM_ID { get; set; }

		public int oLD_COM_ID { get; set; }

		public object sYS_ID { get; set; }

		public object cAM_SYS_ID { get; set; }

		public int rEP_ID { get; set; }

		[JsonProperty("reporT_TYPE")]
		private int reporT_TYPE
		{
			set
			{
				rEP_ID = value;
			}
		}

		public object countries { get; set; }

		public int rEPORT_TYPE { get; set; }

		public string rEPORT_TYPE_DESC { get; set; }
	}
}
