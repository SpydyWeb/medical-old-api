using System.Collections.Generic;
using Domain.Models.CustomModels;
using Domain.Models.DTOs;

namespace Domain.Common
{
	public class SharedSettings
	{
		public static string CoreApiUrl { get; set; }

		public static string SharedSetupUrl { get; set; }

		public static string ReInsuranceApiUrl { get; set; }

		public static string MySqlConnectionString { get; set; }

		public static string OracleConnectionString { get; set; }

		public static string ReportManagerApiUrl { get; set; }

		public static string NotificationLogPath { get; set; }

		public static string NotificationAttachmentPath { get; set; }

		public static string ErrorLogRecepients { get; set; }

		public static string SchemaName { get; set; }

		public static string AttachmentsPath { get; set; }

		public static string DMSApiURL { get; set; }

		public static int DatabaseType { get; set; }

		public static bool EnableDMSIntegration { get; set; }

		public static int PageSize { get; set; }

		public static string OldMedicalUrl { get; set; }

		public static string UnderwritingEmailAddress { get; set; }

		public static int MedicalCCHICompanyId { get; set; }

		public static string ProviderServiceURL { get; set; }

		public static APIsSchedulersConfig aPIsSchedulersConfig { get; set; }

		public static string AccessKeyCCHI { get; set; }

		public static CchiGovernmentIntegration GovernmentIntegrationSection { get; set; }

		public static CchiGovernmentIntegration CCHIGovernmentIntegration { get; set; }

		public static APIsSchedulersConfig APIsSchedulersConfig { get; set; }

		public static EmailConfiguration EmailConfiguration { get; set; }

		public static List<string> Emails { get; set; }

		public static Keys Keys { get; set; }

		public static CCHIPatchTimeConfig CCHIPatchTimeConfig { get; set; }

		public static CCHIBenefitConfig CCHIBenefitConfig { get; set; }

        //public static YakeenAPIConfig YakeenAPIConfig { get; set; }
    }
}
