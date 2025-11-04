namespace SharedSetup.Domain.Common
{
	public class SharedSettings
	{
		public static string WebUrl { get; set; }

		public static string ApiUrl { get; set; }

		public static string CoreApiUrl { get; set; }

		public static string GenerateReportsApiUrl { get; set; }

		public static string FinancialApiUrl { get; set; }

		public static string ApprovalApiUrl { get; set; }

		public static string LogPath { get; set; }

		public static string AttachmentPath { get; set; }

		public static string GeneratedReportPath { get; set; }

		public static int DatabaseType { get; set; }

		public static int CoreApiVersion { get; set; }

		public static int JwtExpireDays { get; set; }

		public static string Secret { get; set; }

		public static string OracleConnectionString { get; set; }

		public static string CRM_ApiUrl { get; set; }

		public static string EnResPath { get; set; }

		public static string FrResPath { get; set; }

		public static string ArResPath { get; set; }

		public static string SchemaName { get; set; }

		public static int PageSize { get; set; }
	}
}
