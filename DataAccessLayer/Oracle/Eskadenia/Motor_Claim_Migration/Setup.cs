using System;
using System.Collections.Generic;
using System.Data;
using CORE.DTOs.APIs.Setups.MMP;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Motor_Claim_Migration
{
	public static class Setup
	{
		public static List<DDL> LoadDomains(string connection, int Domain)
		{
			List<DDL> ls = new List<DDL>();
			using (OracleConnection objConn = new OracleConnection(connection))
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.GET_APIDOMAIN_VALUES";
				objCmd.Parameters.Add("P_CAM_ID", OracleDbType.Int32).Value = Domain;
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader adapter = objCmd.ExecuteReader();
				while (adapter.Read())
				{
					DDL dDL = new DDL();
					dDL.NameArabic = ((adapter["NAME2"] != DBNull.Value) ? adapter["NAME2"].ToString() : "");
					dDL.NameEnglish = adapter["NAME"].ToString();
					dDL.Id = Convert.ToInt32(adapter["VALUE"].ToString());
					ls.Add(dDL);
				}
				objConn.Close();
			}
			return ls;
		}

		public static List<DDL> LoadSubjectType(string connection, string PolicyType)
		{
			List<DDL> ls = new List<DDL>();
			using (OracleConnection objConn = new OracleConnection(connection))
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.GET_APISUBJECT_TYPE";
				objCmd.Parameters.Add("P_PLT_CODE", OracleDbType.NVarchar2).Value = PolicyType;
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader adapter = objCmd.ExecuteReader();
				while (adapter.Read())
				{
					DDL dDL = new DDL();
					dDL.NameArabic = ((adapter["NAME2"] != DBNull.Value) ? adapter["NAME2"].ToString() : "");
					dDL.NameEnglish = adapter["NAME"].ToString();
					dDL.Id = Convert.ToInt32(adapter["ID"].ToString());
					ls.Add(dDL);
				}
				objConn.Close();
			}
			return ls;
		}

		public static List<DDL> LoadLoability(string connection, string PolicyType)
		{
			List<DDL> ls = new List<DDL>();
			using (OracleConnection objConn = new OracleConnection(connection))
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.GET_APILIABILITY_STRUCT";
				objCmd.Parameters.Add("P_PLT_CODE", OracleDbType.NVarchar2).Value = PolicyType;
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader adapter = objCmd.ExecuteReader();
				while (adapter.Read())
				{
					DDL dDL = new DDL();
					dDL.NameArabic = ((adapter["NAME"] != DBNull.Value) ? adapter["NAME"].ToString() : "");
					dDL.NameEnglish = adapter["NAME"].ToString();
					dDL.LiabilityLimit = adapter["LIABILITY_LIMIT"].ToString();
					dDL.AggregateLimit = adapter["AGGREGATE_LIMIT"].ToString();
					dDL.Id = Convert.ToInt32(adapter["ID"].ToString());
					ls.Add(dDL);
				}
				objConn.Close();
			}
			return ls;
		}
	}
}
