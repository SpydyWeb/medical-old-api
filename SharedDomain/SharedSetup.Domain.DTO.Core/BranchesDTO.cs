using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Core
{
	public class BranchesDTO
	{
		public int iD { get; set; }

		public string nAME { get; set; }

		public string nAME2 { get; set; }

		public string pHONE { get; set; }

		public string fAX { get; set; }

		public string eMAIL { get; set; }

		public string aDDRESS { get; set; }

		public string aDDRESS2 { get; set; }

		public int cRG_COM_ID { get; set; }

		public int cRG_ARA_CODE { get; set; }

		public int cRG_CTY_CODE { get; set; }

		public string cRG_CNT_CODE { get; set; }

		public string aPPREVIATION { get; set; }

		[JsonProperty("ABBREVIATION")]
		private string ABBREVIATION
		{
			set
			{
				aPPREVIATION = value;
			}
		}

		public object cRG_BRN_ID { get; set; }

		public string cRG_CUR_CODE { get; set; }

		public CompaniesDTO company { get; set; }

		public object parentBranch { get; set; }

		public CurrenciesDTO currency { get; set; }
	}
}
