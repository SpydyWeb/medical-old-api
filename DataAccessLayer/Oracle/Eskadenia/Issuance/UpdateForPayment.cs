using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Issuance
{
	public class UpdateForPayment
	{
		public static bool UpdatePayment(long PolicyId, DateTime Effective, string Vat, string Connection)
		{
			using OracleConnection objConn = new OracleConnection(Connection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.DBP_SME_PAYT_UPDATE_PROCESS";
				objCmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = PolicyId;
				objCmd.Parameters.Add("P_EFFECTIVE", OracleDbType.Date).Value = Effective;
				objCmd.Parameters.Add("P_VAT", OracleDbType.NVarchar2).Value = Vat;
				objConn.Open();
				objCmd.ExecuteNonQuery();
				objConn.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

      
    }
}
