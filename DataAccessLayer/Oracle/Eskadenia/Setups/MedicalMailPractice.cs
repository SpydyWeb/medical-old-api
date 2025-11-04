using System;
using System.Collections.Generic;
using System.Data;
using CORE.DTOs.APIs.Setups.MMP;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Setups
{
	public class MedicalMailPractice
	{
		public static List<DDL> LoadSpecialization(string Connection)
		{
			List<DDL> ListDDL = new List<DDL>();
			try
			{
				using OracleConnection objConn = new OracleConnection(Connection);
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.Get_MMP_Specialization";
				objCmd.Parameters.Add("P_Cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				while (reader.Read())
				{
					DDL dDL = new DDL();
					dDL.Id = reader.GetInt32(0);
					dDL.NameEnglish = reader.GetString(1);
					dDL.NameArabic = reader.GetString(2);
					ListDDL.Add(dDL);
				}
				objConn.Close();
				return ListDDL;
			}
			catch (Exception)
			{
				return ListDDL;
			}
		}

		public static List<DDL> LoadLiabilityStructure(string Connection)
		{
			List<DDL> ListDDL = new List<DDL>();
			try
			{
				using OracleConnection objConn = new OracleConnection(Connection);
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.Get_MMP_Liability";
				objCmd.Parameters.Add("P_Cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				while (reader.Read())
				{
					DDL dDL = new DDL();
					dDL.Id = reader.GetInt32(0);
					dDL.NameEnglish = reader.GetString(1);
					dDL.NameArabic = reader.GetString(2);
					ListDDL.Add(dDL);
				}
				objConn.Close();
				return ListDDL;
			}
			catch (Exception)
			{
				return ListDDL;
			}
		}
	}
}
