using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Core
{
	public class RepParamsDTO
	{
		public int iD { get; set; }

		public string cOLUMN_NAME { get; set; }

		public int cOLUMN_TYPE { get; set; }

		public string cOLUMN_TYPE_NAME { get; set; }

		public int pARAM_ORDER { get; set; }

		public string pARAM_FROM { get; set; }

		public object pARAM_TO { get; set; }

		public string lABEL1 { get; set; }

		public object lABEL2 { get; set; }

		public string p1_QUERY { get; set; }

		public object p2_QUERY { get; set; }

		public object dEFAULT_FROM { get; set; }

		public object dEFAULT_TO { get; set; }

		public int p1_MANDATORY { get; set; }

		public int p2_MANDATORY { get; set; }

		public object cAM_RPM_ID { get; set; }

		public string cAM_RPT_CODE { get; set; }

		public object pARAM_NAME { get; set; }

		public int cRG_COM_ID { get; set; }

		public string MODIFICATION_DATE { get; set; }

		[JsonProperty("COLUMN_NAME")]
		private string COLUMN_NAME
		{
			set
			{
				cOLUMN_NAME = value;
			}
		}

		[JsonProperty("PARAM_FROM")]
		private string PARAM_FROM
		{
			set
			{
				pARAM_FROM = value;
			}
		}

		[JsonProperty("PARAM_TO")]
		private string PARAM_TO
		{
			set
			{
				pARAM_TO = value;
			}
		}

		[JsonProperty("P1_QUERY")]
		private string P1_QUERY
		{
			set
			{
				p1_QUERY = value;
			}
		}

		[JsonProperty("P2_QUERY")]
		private string P2_QUERY
		{
			set
			{
				p2_QUERY = value;
			}
		}

		[JsonProperty("DEFAULT_FROM")]
		private string DEFAULT_FROM
		{
			set
			{
				dEFAULT_FROM = value;
			}
		}

		[JsonProperty("DEFAULT_TO")]
		private string DEFAULT_TO
		{
			set
			{
				dEFAULT_TO = value;
			}
		}

		[JsonProperty("CAM_RPT_CODE")]
		private string CAM_RPT_CODE
		{
			set
			{
				cAM_RPT_CODE = value;
			}
		}

		[JsonProperty("COLUMN_TYPE")]
		private string COLUMN_TYPE
		{
			set
			{
				cOLUMN_TYPE_NAME = value;
			}
		}

		[JsonProperty("COLUMN_TYPE_ID")]
		private int COLUMN_TYPE_ID
		{
			set
			{
				cOLUMN_TYPE = value;
			}
		}

		[JsonProperty("PARAM_ORDER")]
		private int PARAM_ORDER
		{
			set
			{
				pARAM_ORDER = value;
			}
		}

		[JsonProperty("P1_MANDATORY")]
		private int P1_MANDATORY
		{
			set
			{
				p1_MANDATORY = value;
			}
		}

		[JsonProperty("P2_MANDATORY")]
		private int P2_MANDATORY
		{
			set
			{
				p2_MANDATORY = value;
			}
		}

		[JsonProperty("LABEL2")]
		private object LABEL2
		{
			set
			{
				lABEL2 = value;
			}
		}

		[JsonProperty("LABEL1")]
		private string LABEL1
		{
			set
			{
				lABEL1 = value;
			}
		}

		[JsonProperty("PARAMFROM")]
		private string PARAMFROM
		{
			set
			{
				pARAM_FROM = value;
			}
		}

		[JsonProperty("ID")]
		private int ID
		{
			set
			{
				iD = value;
			}
		}
	}
}
