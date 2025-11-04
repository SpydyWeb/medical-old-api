using System;
using System.Data;
using CORE.DTOs.Setups;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Setups
{
	public class GETCRClaim
	{
		public static CRClaims ValidateRenewal(string CRNumber, string Connection)
		{
			CRClaims claim = new CRClaims();
			try
			{
				using OracleConnection objConn = new OracleConnection(Connection);
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.MPD_SME_RENEWAL_ONLINE";
				objCmd.Parameters.Add("P_CR_NUMBER", OracleDbType.Varchar2).Value = CRNumber;
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						claim.EXPIRY = reader["EXPIRY"].ToString();
						claim.CLAIMS = reader["CLAIMS"].ToString();
						claim.ENDORS = reader["ENDORS"].ToString();
						claim.TOTAL = reader["TOTAL"].ToString();
					}
				}
				objConn.Close();
			}
			catch (Exception)
			{
			}
			return claim;
		}
	}
}
