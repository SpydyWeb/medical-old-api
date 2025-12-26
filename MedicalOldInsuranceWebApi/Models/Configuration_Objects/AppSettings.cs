using CORE.DTOs.APIs.APIs_Scheduler;
using CORE.DTOs.MotorClaim.Integrations.APIs;

namespace InsuranceAPIs.Models.Configuration_Objects
{
    public class AppSettings
    {
        public Apis apis { get; set; }

        public string Connection { get; set; }

        public string EskaConnection { get; set; }
        public string EskaIGeneralConnection { get; set; }

        public string EskaFinancialConnection { get; set; }

        public string KeyToCypher { get; set; }

        public string KeyToUserSession { get; set; }

        public string SalesUser { get; set; }

        public string SmsAPI { get; set; }

        public string SMSPassword { get; set; }

        public string SMSACC { get; set; }

        public string access_code { get; set; }

        public string language { get; set; }

        public string merchant_identifier { get; set; }

        public string sha_request { get; set; }

        public string sha_response { get; set; }

        public string sandbox { get; set; }

        public string sha_type { get; set; }

        public string Envrionment { get; set; }

        public string ApiUrlPayFort { get; set; }

        public string fort_response_cp { get; set; }

        public string YakeenHTTPS { get; set; }

        public string CCHIKey { get; set; }

        public string PlanCode { get; set; }

        public string ClassCBasic { get; set; }

        public string ClassCMena { get; set; }

        public string ClassC { get; set; }

        public string LastDiscountDate { get; set; }

        public string Discount { get; set; }

        public string WebsiteConnection { get; set; }

        public string fort_response_cp_end { get; set; }

        public string WathqKey { get; set; }

        public string WathqBaseURL { get; set; }

        public string CRNumReUse { get; set; }

        public string CRNumReUseDays { get; set; }

        public string LossRatioValue { get; set; }

        public string AbsherOTPclientId { get; set; }

        public string AbsherOTPclientAuthorization { get; set; }

        public string AbsherOTPotpType { get; set; }

        public string AbsherOTPotpTypeCustom { get; set; }

        public string AbsherOTPTemplateId { get; set; }

        public string company_email { get; set; }

        public string company_email_password { get; set; }

        public string policyLevelDiscount { get; set; }

        public string DiscountAgeExcecluded { get; set; }

        public string ReturnUrlCustomer { get; set; }

        public string ReturnToPost { get; set; }

        public string LossRatio { get; set; }

        public string RenewalDays { get; set; }

        public string SalesDiscount { get; set; }

        public string CPlusDiscountFemale { get; set; }

        public string CPlusDiscountMale { get; set; }

        public string CDiscountFemale { get; set; }

        public string CDiscountMale { get; set; }

        public string DisLevel { get; set; }

        public string TokenKey { get; set; }

        public string SAUDIOCCUPATION { get; set; }

        public string SAUDINATIONALITY { get; set; }

        public string IsAddedPremiumOnNet { get; set; }

        public static APIsSchedulersConfig CCHIPatchTimeConfig { get; set; }

        public BasherSetup BasherSetup { get; set; }

        public string RolesForCheck { get; set; }

        public string ReportAPIBase { get; set; }

        public bool DeletePendingEnd { get; set; }

        public string ESKAEndorsement { get; set; }

        public string ESKAPolicies { get; set; }

        public string ESKAProduction { get; set; }
        public YakeenAPIConfig YakeenAPIConfig { get; set; }
        public SMEAPIConfig SMEAPIConfig { get; set; }
        public string BCKey { get; set; }

        public string BCIV { get; set; }

        public string SmsAPITaqnyat { get; set; }
        public string SMSAuthorizationTaqnyat { get; set; }
        public string PayfortWebhookurl { get; set; }


        public Pentadetails pentadetails { get; set; }

        public AppSettings()
        {
            BasherSetup = new BasherSetup();
            //YakeenAPIConfig = new YakeenAPIConfig();
        }

        public class Pentadetails
        {
            public string pentaApiUrl { get; set; }
            public string lookupUrl { get; set; }
            public string PentaTokenUrl { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string endorsmentUrl { get; set; }

        }

    }


}
