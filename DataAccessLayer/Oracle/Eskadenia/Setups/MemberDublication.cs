using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Setups
{
	public class MemberDublication
	{
		public bool CheckExistsMember(string nationalId, string Connection)
		{
			bool isValid = true;
			try
			{
				using OracleConnection objConn = new OracleConnection(Connection);
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IMEDICAL.DBP_MEMBER_Existing";
				objCmd.Parameters.Add("P_NATIONAL_ID", OracleDbType.Varchar2).Value = nationalId;
				objCmd.Parameters.Add("P_IS_EXIST", OracleDbType.Int32).Direction = ParameterDirection.Output;
				objConn.Open();
				objCmd.ExecuteNonQuery();
				string isExists = objCmd.Parameters["P_IS_EXIST"].ToString();
				isValid = ((!(isExists == "1")) ? true : false);
				objConn.Close();
				return isValid;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
