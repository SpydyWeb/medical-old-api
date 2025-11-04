using System;
using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Core
{
	public class UserDTO
	{
		[JsonProperty(PropertyName = "company")]
		public CompaniesDTO company { get; set; }

		public object iTotalRecords { get; set; }

		public object iTotalDisplayRecords { get; set; }

		public string uSERNAME { get; set; }

		public object nAME { get; set; }

		public object nAME2 { get; set; }

		public object sHORT_NAME { get; set; }

		public DateTime eFFECTIVE_DATE { get; set; }

		public DateTime eXPIRY_DATE { get; set; }

		public int sTATUS { get; set; }

		public DateTime sTATUS_DATE { get; set; }

		public object iP_ADDRESS { get; set; }

		public object pASSWORD { get; set; }

		public object pATH { get; set; }

		public object dEFAULT_IP_ADDRESS { get; set; }

		public int cRG_COM_ID { get; set; }

		public object eMAIL { get; set; }

		public int fAILED_LOGIN_ATTEMPTS { get; set; }

		public object bIRTH_DATE { get; set; }

		public object pICTURE { get; set; }

		public int uI_THEME { get; set; }

		public int dEFAULT_LANGUAGE { get; set; }

		[JsonProperty("LANGUAGE_ID")]
		private int LanguageId
		{
			set
			{
				dEFAULT_LANGUAGE = value;
			}
		}

		public object dESCRIPTION { get; set; }

		public int cRG_BRN_ID { get; set; }

		public object mOBILE { get; set; }

		public object resetPassword { get; set; }

		public object lOGIN_USER { get; set; }

		public object mAX_NO_OF_SESSION { get; set; }

		public object uSER_TYPE { get; set; }

		public int iS_DEFAULT_LANDING { get; set; }

		public object fORGOT_EMAIL_BODY { get; set; }

		public object fORGOT_EMAIL_SENDER { get; set; }

		public object fORGOT_EMAIL_SUBJECT { get; set; }

		public int pROF_ID { get; set; }

		public object cHANNEL { get; set; }

		public object lOCKED_UNTIL { get; set; }

		public int iS_EXTERNAL_USER { get; set; }

		public object cREDIT_USER_LIMIT { get; set; }

		public object dEBIT_USER_LIMIT { get; set; }

		public int sIGNATURE { get; set; }

		public object rESET_LOCKOUT { get; set; }

		public DateTime cREATION_DATE { get; set; }

		public DateTime mODIFICATION_DATE { get; set; }

		public object cREATED_BY { get; set; }

		public object body { get; set; }

		public int gROUP_TYPE { get; set; }

		public object mODIFIED_BY { get; set; }

		public object iSADMINCLOUD { get; set; }

		public object iSCLOUDUSER { get; set; }

		public int iS_PORTAL { get; set; }

		public object cAM_APP_ID { get; set; }

		public int dO_SYTEM_TOUR { get; set; }

		public object dEFAULT_PAGE_SMU_ID { get; set; }

		public object dEFAULT_PAGE_APP_ID { get; set; }

		public object lAST_LOGIN_SUCC { get; set; }

		public object lAST_LOGIN_FAIL { get; set; }

		public object path_Page { get; set; }
	}
}
