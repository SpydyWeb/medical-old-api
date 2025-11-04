using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Setups
{
	public class PlanSetups
	{
		public static int MaxPlanAge(int PlanId, string Connection)
		{
			try
			{
				using OracleConnection objConn = new OracleConnection(Connection);
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.GET_MAX_AGE_PLAN";
				objCmd.Parameters.Add("P_PLAN_Id", OracleDbType.Int32).Value = PlanId;
				objCmd.Parameters.Add("P_AGE", OracleDbType.Int32).Direction = ParameterDirection.Output;
				objConn.Open();
				objCmd.ExecuteNonQuery();
				int Age = Convert.ToInt32(objCmd.Parameters["P_AGE"].Value.ToString());
				objConn.Close();
				return Age;
			}
			catch (Exception)
			{
				return -1;
			}
		}
	}
}
