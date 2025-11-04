using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using SharedSetup.Domain.Common;

namespace SharedDomain.Extension
{
	public static class DataBaseExtensions
	{
		public static DbConnection GetConnection()
		{
			return BaseConnection.DatabaseType switch
			{
				1 => new MySqlConnection(BaseConnection.MySqlConnectionString), 
				2 => new OracleConnection(BaseConnection.OracleConnectionString), 
				3 => new SqlConnection(BaseConnection.MsSqlServerConnectionString), 
				_ => null, 
			};
		}

		public static object GetDbParameter(string parameterName, int type, int? size, object obj, ParameterDirection direction)
		{
			switch (BaseConnection.DatabaseType)
			{
			case 1:
			{
				MySqlParameter mySqlParameter = new MySqlParameter();
				mySqlParameter.ParameterName = parameterName;
				mySqlParameter.MySqlDbType = (MySqlDbType)Enum.ToObject(typeof(MySqlDbType), GetDbDataType(type));
				if (size.HasValue)
				{
					mySqlParameter.Size = size.Value;
				}
				mySqlParameter.Direction = direction;
				mySqlParameter.Value = obj;
				return mySqlParameter;
			}
			case 2:
			{
				OracleParameter oracleParameter = new OracleParameter();
				oracleParameter.ParameterName = parameterName;
				oracleParameter.OracleDbType = (OracleDbType)Enum.ToObject(typeof(OracleDbType), GetDbDataType(type));
				if (size.HasValue)
				{
					oracleParameter.Size = size.Value;
				}
				oracleParameter.Direction = direction;
				oracleParameter.Value = obj;
				return oracleParameter;
			}
			case 3:
			{
				SqlParameter sqlParameter = new SqlParameter();
				sqlParameter.ParameterName = parameterName;
				sqlParameter.SqlDbType = (SqlDbType)Enum.ToObject(typeof(SqlDbType), GetDbDataType(type));
				sqlParameter.Size = (size.HasValue ? size.Value : 800);
				sqlParameter.Direction = direction;
				sqlParameter.Value = obj ?? DBNull.Value;
				return sqlParameter;
			}
			default:
				return null;
			}
		}

		public static int GetDbDataType(int type)
		{
			int result = 0;
			switch (type)
			{
			case 10:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 16;
					break;
				case 2:
					result = 134;
					break;
				case 3:
					result = 2;
					break;
				}
				break;
			case 4:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 2;
					break;
				case 2:
					result = 111;
					break;
				case 3:
					result = 16;
					break;
				}
				break;
			case 3:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 3;
					break;
				case 2:
					result = 112;
					break;
				case 3:
					result = 16;
					break;
				}
				break;
			case 2:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 8;
					break;
				case 2:
					result = 113;
					break;
				case 3:
					result = 0;
					break;
				}
				break;
			case 1:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 253;
					break;
				case 2:
					result = 126;
					break;
				case 3:
					result = 22;
					break;
				}
				break;
			case 7:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 12;
					break;
				case 2:
					result = 106;
					break;
				case 3:
					result = 4;
					break;
				}
				break;
			case 6:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 10;
					break;
				case 2:
					result = 106;
					break;
				case 3:
					result = 31;
					break;
				}
				break;
			case 8:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 0;
					break;
				case 2:
					result = 107;
					break;
				case 3:
					result = 5;
					break;
				}
				break;
			case 11:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 5;
					break;
				case 2:
					result = 108;
					break;
				case 3:
					result = 0;
					break;
				}
				break;
			case 9:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 8;
					break;
				case 2:
					result = 109;
					break;
				case 3:
					result = 0;
					break;
				}
				break;
			case 5:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 248;
					break;
				case 2:
					result = 121;
					break;
				case 3:
					result = 29;
					break;
				}
				break;
			case 12:
				switch (BaseConnection.DatabaseType)
				{
				case 1:
					result = 751;
					break;
				case 2:
					result = 105;
					break;
				case 3:
					result = 22;
					break;
				}
				break;
			default:
				return 1;
			}
			return result;
		}

		public static bool IsNullOrEmptyParameters(object value)
		{
			return value == DBNull.Value || value.ToString() == "null";
		}

		public static string GetDbCommandText(string procuderName)
		{
			string result = string.Empty;
			switch (BaseConnection.DatabaseType)
			{
			case 1:
				result = procuderName.Replace('.', '_');
				break;
			case 2:
				result = procuderName;
				break;
			case 3:
				result = "[" + procuderName + "]";
				break;
			}
			return result;
		}
	}
}
