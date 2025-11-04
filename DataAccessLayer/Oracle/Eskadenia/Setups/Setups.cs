using System;
using System.Collections.Generic;
using System.Data;
using CORE.DTOs.Setups;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Setups
{
	public static class Setups
	{
		public static List<Occupations> loadOccupations(string EskaConnection, string Occupation)
		{
			List<Occupations> lsOccupation = new List<Occupations>();
			try
			{
				using OracleConnection objConn = new OracleConnection(EskaConnection);
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "igeneral.DBP_MST_CODES_BY_MAJOR_CODE";
				objCmd.Parameters.Add("P_MAJOR_CODE", OracleDbType.Int32).Value = 13;
				objCmd.Parameters.Add("P_MINOR_CODE", OracleDbType.NVarchar2).Value = Occupation;
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Occupations occupation = new Occupations();
						occupation.Id = Convert.ToInt64(reader["ID"].ToString());
						occupation.name = reader["NAME"].ToString();
						lsOccupation.Add(occupation);
					}
				}
				objConn.Close();
			}
			catch (Exception)
			{
			}
			return lsOccupation;
		}
	}
}
