using System;
using Newtonsoft.Json;
using SharedSetup.Domain.DTO.Core;

namespace SharedSetup.Domain.DTO
{
	public class CompaniesDTO
	{
		public CurrenciesDTO currencies { get; set; }

		public CountriesDTO countries { get; set; }

		public int cOM_ID { get; set; }

		public int iD { get; set; }

		public string nAME { get; set; }

		public string nAME2 { get; set; }

		public string pHONE { get; set; }

		public string mOBILE { get; set; }

		public string fAX { get; set; }

		public string eMAIL { get; set; }

		public string wEBSITE { get; set; }

		public string aDDRESS { get; set; }

		public string aDDRESS2 { get; set; }

		public string cONTACT_PERSON { get; set; }

		public DateTime? dATE_FORMAT { get; set; }

		public string aCCOUNT_NO { get; set; }

		public string tAX_NO { get; set; }

		public string sOCIAL_SECURITY { get; set; }

		public string sYMBOL { get; set; }

		public string cRG_CUR_CODE { get; set; }

		public int? cRG_COM_ID { get; set; }

		public string cRG_CNT_CODE { get; set; }

		public int cRG_CTY_CODE { get; set; }

		public int cRG_ARA_CODE { get; set; }

		public object pASSWORD_MIN_LENGHT { get; set; }

		public object pASSWORD_MIN_UPPER { get; set; }

		public object pASSWORD_MIN_LOWER { get; set; }

		public object pASSWORD_MIN_DIGITS { get; set; }

		public object pASSWORD_MIN_SPECIAL { get; set; }

		public int pASSWORD_EXPIRY_PERIOD { get; set; }

		public object pASSWORD_LOGIN_ATTEMPTS { get; set; }

		public object pASSWORD_REPEAT { get; set; }

		public long? mAX_NUM_USERS { get; set; }

		public long? iMS_CUSTOMER_ID { get; set; }

		public string eRR_MSG { get; set; }

		public object fORGOT_EMAIL_SENDER { get; set; }

		public long? cSR_POLICY_ID { get; set; }

		public int dO_CONTROLS_SCAN { get; set; }

		public int? iS_DEFAULT_LANDING { get; set; }

		public object cREATED_BY { get; set; }

		public DateTime? cREATION_DATE { get; set; }

		public object mODIFIED_BY { get; set; }

		public DateTime? mODIFICATION_DATE { get; set; }

		public object uRL { get; set; }

		public object cAM_FRM_CODE { get; set; }

		public object uSER_NAME { get; set; }

		public object fORGET_EMAIL_SUBJECT { get; set; }

		[JsonProperty("FORGOT_EMAIL_SUBJECT")]
		private object FORGOT_EMAIL_SUBJECT
		{
			set
			{
				fORGET_EMAIL_SUBJECT = value;
			}
		}

		public int menuID { get; set; }

		public int appID { get; set; }

		public int sAVE_USER_LOG { get; set; }

		public int iS_DETAILED_MENU { get; set; }

		public int? dNS_ACTIVATION { get; set; }

		public DateTime? eXPIRY_DATE { get; set; }
	}
}
