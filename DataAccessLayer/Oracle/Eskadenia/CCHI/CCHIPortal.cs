using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using CORE.DTOs.CCHI;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.CCHI
{
	public static class CCHIPortal
	{
		public static List<MpdNetworkProviders> LoadProvidersByNetworkId(int NetworkId, string Connection)
		{
			using DbConnection connection = new OracleConnection(Connection);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "IMEDICAL.DBPKG_CCHI_ESKA_QUERY.DBP_GET_NETWORK_PROVIDERS";
			command.Parameters.Add(new OracleParameter("P_NetworkId", OracleDbType.Int32, NetworkId, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				List<MpdNetworkProviders> mpdNetworkProviders = new List<MpdNetworkProviders>();
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							mpdNetworkProviders.Add(new MpdNetworkProviders
							{
								Id = Convert.ToInt32(reader["ID"].ToString()),
								MntPrvNetCategoryId = Convert.ToInt32(reader["CategoryId"].ToString()),
								MntPrvNetCategoryName = reader["CtegoryName"].ToString(),
								MntNetId = NetworkId,
								MntPrvNetId = Convert.ToInt32(reader["ProviderId"].ToString()),
								MntPrvNetName = reader["NAME"].ToString(),
								Status = reader["Status"].ToString()
							});
						}
					}
				}
				return mpdNetworkProviders;
			}
			catch (Exception)
			{
				return new List<MpdNetworkProviders>();
			}
		}
	}
}
