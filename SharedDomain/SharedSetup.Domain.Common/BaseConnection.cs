namespace SharedSetup.Domain.Common
{
	public class BaseConnection
	{
		public static string MySqlConnectionString { get; set; }

		public static string OracleConnectionString { get; set; }

		public static string MsSqlServerConnectionString { get; set; }

		public static int DatabaseType { get; set; }
	}
}
