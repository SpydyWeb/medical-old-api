using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Issuance
{
	public static class Productions
	{
		public static bool InsertMembers(long P_MPD_PLC_ID, decimal? P_DISCOUNT_PER, decimal? P_LOADING_PREM, string P_NATIONAL_ID, string P_NAME, int P_OCCUPATION, int P_MARITAL_STATUS, int P_GENDER, string P_NATIONALITY, int P_RELATION, DateTime P_IDENTITY_EXPIRY_DATE, DateTime P_IDENTITY_ISSUE_DATE, DateTime P_BIRTH_DATE, string P_SPONSER_NO, string P_SPONSER_NAME, int P_AGE, long? P_MPD_MBR_ID_RELATION, long P_MPD_PCL_ID, long P_FCS_CST_ID, string Connection, long plan)
		{
			if (P_MPD_PCL_ID == 1 && plan == 7828)
			{
				P_MPD_PCL_ID = 9186;
			}
			if (P_MPD_PCL_ID == 2 && plan == 7828)
			{
				P_MPD_PCL_ID = 9187;
			}
			if (P_MPD_PCL_ID == 3 && plan == 7828)
			{
				P_MPD_PCL_ID = 9188;
			}
			if (P_MPD_PCL_ID == 1 && plan == 7648)
			{
				P_MPD_PCL_ID = 8946;
			}
			if (P_MPD_PCL_ID == 2 && plan == 7648)
			{
				P_MPD_PCL_ID = 8947;
			}
			if (P_MPD_PCL_ID == 3 && plan == 7648)
			{
				P_MPD_PCL_ID = 8948;
			}
			using OracleConnection objConn = new OracleConnection(Connection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.DBP_INSERT_MEMBERS";
				objCmd.Parameters.Add("P_MEMBER_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
				objCmd.Parameters.Add("P_PLM_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
				objCmd.Parameters.Add("P_MPD_PLC_ID", OracleDbType.Int64).Value = P_MPD_PLC_ID;
				objCmd.Parameters.Add("P_DISCOUNT_PER", OracleDbType.Decimal).Value = P_DISCOUNT_PER;
				objCmd.Parameters.Add("P_LOADING_PREM", OracleDbType.Decimal).Value = P_LOADING_PREM;
				objCmd.Parameters.Add("P_NATIONAL_ID", OracleDbType.Varchar2).Value = P_NATIONAL_ID;
				objCmd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = P_NAME;
				objCmd.Parameters.Add("P_OCCUPATION", OracleDbType.Int32).Value = P_OCCUPATION;
				objCmd.Parameters.Add("P_MARITAL_STATUS", OracleDbType.Int32).Value = P_MARITAL_STATUS;
				objCmd.Parameters.Add("P_GENDER", OracleDbType.Int32).Value = P_GENDER;
				objCmd.Parameters.Add("P_NATIONALITY", OracleDbType.Varchar2).Value = P_NATIONALITY;
				objCmd.Parameters.Add("P_RELATION", OracleDbType.Int32).Value = P_RELATION;
				objCmd.Parameters.Add("P_IDENTITY_EXPIRY_DATE", OracleDbType.Date).Value = P_IDENTITY_EXPIRY_DATE;
				objCmd.Parameters.Add("P_IDENTITY_ISSUE_DATE", OracleDbType.Date).Value = P_IDENTITY_ISSUE_DATE;
				objCmd.Parameters.Add("P_BIRTH_DATE", OracleDbType.Date).Value = P_BIRTH_DATE;
				objCmd.Parameters.Add("P_SPONSER_NO", OracleDbType.Varchar2).Value = P_SPONSER_NO;
				objCmd.Parameters.Add("P_SPONSER_NAME", OracleDbType.Varchar2).Value = P_SPONSER_NAME;
				objCmd.Parameters.Add("P_AGE", OracleDbType.Int32).Value = P_AGE;
				objCmd.Parameters.Add("P_MPD_MBR_ID_RELATION", OracleDbType.Int64).Value = (P_MPD_MBR_ID_RELATION.HasValue ? ((object)P_MPD_MBR_ID_RELATION) : DBNull.Value);
				objCmd.Parameters.Add("P_MPD_PCL_ID", OracleDbType.Int32).Value = P_MPD_PCL_ID;
				objCmd.Parameters.Add("P_FCS_CST_ID", OracleDbType.Int32).Value = P_FCS_CST_ID;
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

		public static long InsertEndoresement(long PolicyNo, long Endo, string border, string nationalid, string connectionString)
		{
			try
			{
				using OracleConnection objConn = new OracleConnection();
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.INSERT_CORRECTION_MEMBERS";
				objCmd.Parameters.Add("P_POLICY_ID", OracleDbType.Int64).Value = PolicyNo;
				objCmd.Parameters.Add("P_END_ID", OracleDbType.Int64).Value = Endo;
				objCmd.Parameters.Add("P_BORDER", OracleDbType.NVarchar2).Value = border;
				objCmd.Parameters.Add("P_NATIONAL_ID", OracleDbType.NVarchar2).Value = nationalid;
				objCmd.Parameters.Add("P_ID", OracleDbType.Int64).Direction = ParameterDirection.Output;
				objConn.Open();
				objCmd.ExecuteNonQuery();
				objConn.Close();
				return Convert.ToInt64(objCmd.Parameters["P_ID"].Value.ToString());
			}
			catch (Exception)
			{
				return 0L;
			}
		}

		public static long? LoadMemberRelation(string Sponsor,string connectionString)
		{
			long? id = null;
			using OracleConnection objConn = new OracleConnection(connectionString);
			OracleCommand objCmd = new OracleCommand();
			objCmd.Connection = objConn;
			objCmd.CommandType = CommandType.StoredProcedure;
			objCmd.CommandText = "IGENERAL.DBP_GET_SPONSOR_INFO";
			objCmd.Parameters.Add("P_SPONSOR", OracleDbType.Varchar2).Value = Sponsor;
			objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
			objConn.Open();
			OracleDataReader reader = objCmd.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					id = Convert.ToInt64(reader["ID"].ToString());
				}
			}
			objConn.Close();
			return id;
		}

		public static bool DeleteMember(string NationalId, long policyId, string EskaConnection)
		{
			using OracleConnection objConn = new OracleConnection(EskaConnection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.DPB_DELETE_MEMNEW_SME";
				objCmd.Parameters.Add("P_MEMBER_NAT", OracleDbType.NVarchar2).Value = NationalId;
				objCmd.Parameters.Add("P_MPD_PLC_ID", OracleDbType.Int64).Value = policyId;
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

		public static void FixCalculation(long PolicyId, string Connection)
		{
			using OracleConnection objConn = new OracleConnection(Connection);
			OracleCommand objCmd = new OracleCommand();
			objCmd.Connection = objConn;
			objCmd.CommandType = CommandType.StoredProcedure;
			objCmd.CommandText = "IGENERAL.FIX_MEMBER_CALCULATION";
			objCmd.Parameters.Add("P_POLICY", OracleDbType.Int64).Value = PolicyId;
			objConn.Open();
			objCmd.ExecuteNonQuery();
			objConn.Close();
		}

		public static int validateHolder(string CR, int Product, string connection)
		{
			try
			{
				using OracleConnection objConn = new OracleConnection(connection);
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IGENERAL.CHECK_POLICY_HOLDER_SME";
				objCmd.Parameters.Add("P_CR", OracleDbType.Varchar2).Value = CR;
				objCmd.Parameters.Add("P_VALID", OracleDbType.Int32).Direction = ParameterDirection.Output;
				objCmd.Parameters.Add("P_VALID1", OracleDbType.Int32).Direction = ParameterDirection.Output;
				objConn.Open();
				objCmd.ExecuteNonQuery();
				int validate = Convert.ToInt32(objCmd.Parameters["P_VALID"].Value.ToString());
				int validate2 = Convert.ToInt32(objCmd.Parameters["P_VALID1"].Value.ToString());
				objConn.Close();
                return (validate2 <= 0) ? validate : 0;
                //return (validate <= 0) ? validate : 0;
            }
			catch (Exception)
			{
				return 0;
			}
		}
	}
}
