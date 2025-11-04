using System;
using System.Data;
using System.Data.Common;
using Domain.Common;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Extension
{
	public static class DataBaseExtensions
	{
		public static DbConnection GetConnection()
		{
			return new OracleConnection(SharedSettings.OracleConnectionString);
		}

		public static object GetDbParameter(string parameterName, int type, int? size, object obj, ParameterDirection direction)
		{
			OracleParameter oracle = new OracleParameter();
			oracle.ParameterName = parameterName;
			oracle.OracleDbType = (OracleDbType)Enum.ToObject(typeof(OracleDbType), GetDbDataType(type));
			if (size.HasValue)
			{
				oracle.Size = size.Value;
			}
			oracle.Direction = direction;
			oracle.Value = obj;
			return oracle;
		}

		public static int GetDbDataType(int type)
		{
			int dbType = 0;
			switch (type)
			{
			case 10:
				dbType = 134;
				break;
			case 4:
				dbType = 111;
				break;
			case 3:
				dbType = 112;
				break;
			case 2:
				dbType = 113;
				break;
			case 1:
				dbType = 126;
				break;
			case 7:
				dbType = 106;
				break;
			case 6:
				dbType = 106;
				break;
			case 8:
				dbType = 107;
				break;
			case 11:
				dbType = 108;
				break;
			case 9:
				dbType = 109;
				break;
			case 5:
				dbType = 121;
				break;
			case 12:
				dbType = 105;
				break;
			default:
				return 1;
			}
			return dbType;
		}

		public static bool IsNullOrEmptyParameters(object value)
		{
			return value == DBNull.Value || value.ToString() == "null";
		}

		public static string GetDbCommandText(string procuderName)
		{
			string commandText = string.Empty;
			return procuderName;
		}

		public static bool HasColumn(this DbDataReader dataReader, string columnName)
		{
			try
			{
				return dataReader.GetOrdinal(columnName) >= 0;
			}
			catch (IndexOutOfRangeException)
			{
				return false;
			}
		}
	}
}
