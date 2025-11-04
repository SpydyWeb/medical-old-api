using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Core
{
	public class CountriesDTO
	{
		public int? cOUNTRY_NO { get; set; }

		public string cODE { get; set; }

		public string nAME { get; set; }

		public string nAME2 { get; set; }

		public string nATIONALITY { get; set; }

		public string nATIONALITY2 { get; set; }

		public int pHONE_CODE { get; set; }

		public string cRG_CUR_CODE { get; set; }

		public int? iD { get; set; }

		[JsonProperty("_COUNTRY_NO")]
		private int? _COUNTRY_NO
		{
			set
			{
				cOUNTRY_NO = value;
			}
		}

		[JsonProperty("_CODE")]
		private string _CODE
		{
			set
			{
				cODE = value;
			}
		}

		[JsonProperty("_NAME")]
		private string _NAME
		{
			set
			{
				nAME = value;
			}
		}

		[JsonProperty("_NAME2")]
		private string _NAME2
		{
			set
			{
				nAME2 = value;
			}
		}

		[JsonProperty("_NATIONALITY")]
		private string _NATIONALITY
		{
			set
			{
				nATIONALITY = value;
			}
		}

		[JsonProperty("_NATIONALITY2")]
		private string _NATIONALITY2
		{
			set
			{
				nATIONALITY2 = value;
			}
		}

		[JsonProperty("_PHONE_CODE")]
		private int _PHONE_CODE
		{
			set
			{
				pHONE_CODE = value;
			}
		}

		[JsonProperty("_CRG_CUR_CODE")]
		private string _CRG_CUR_CODE
		{
			set
			{
				cRG_CUR_CODE = value;
			}
		}

		[JsonProperty("_ID")]
		private int? _ID
		{
			set
			{
				iD = value;
			}
		}
	}
}
