using System;
using System.Collections.Generic;
using System.Data;
using CORE.DTOs.APIs.Business;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Setups
{
	public class CancellationReasons
	{
		public static List<CancellationReason> loadCancellation(string EskaConnection)
		{
			List<CancellationReason> lscancellation = new List<CancellationReason>();
			try
			{
				using OracleConnection objConn = new OracleConnection(EskaConnection);
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "igeneral.DBP_CODES_BY_MAJOR_CODE_NEW";
				objCmd.Parameters.Add("P_MAJOR_CODE", OracleDbType.Int32).Value = 28;
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						CancellationReason cancellation = new CancellationReason();
						cancellation.Id = Convert.ToInt32(reader["ID"].ToString());
						cancellation.Name = reader["NAME"].ToString();
						lscancellation.Add(cancellation);
					}
				}
				objConn.Close();
			}
			catch (Exception)
			{
			}
			return lscancellation;
		}
	}
}
