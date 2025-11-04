using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Endorsments
{
	public static class EndorsementPending
	{
		public static List<long> PendingEndorments(long policyId, string EskaConnection)
		{
			using OracleConnection objConn = new OracleConnection(EskaConnection);
			try
			{
				List<long> ints = new List<long>();
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.DPB_GET_END_UNPOSTED";
				objCmd.Parameters.Add("P_MPD_PLC_ID", OracleDbType.Int64).Value = policyId;
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader Readers = objCmd.ExecuteReader();
				while (Readers.Read())
				{
					ints.Add(Readers.GetInt64(0));
				}
				objConn.Close();
				return ints;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
