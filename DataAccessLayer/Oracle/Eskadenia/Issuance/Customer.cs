using System;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Issuance
{
	public static class Customer
	{
		public static long insertCustomer(int Title, string Name, string NationalIDandCR, string Mobile, string Email, int Gender, int? BankCode, string BankAccount, string TaxNo, string ExpiryDate, string? fixedmobile, string FinanceConnection)
		{
			try
			{
				long Id = 0;
				using (OracleConnection objConn = new OracleConnection(FinanceConnection))
				{
					OracleCommand objCmd = new OracleCommand();
					objCmd.Connection = objConn;
					objCmd.CommandType = CommandType.StoredProcedure;
					objCmd.CommandText = "IGENERAL.DBP_INSERT_NEWSME_CUSTOMERS";
					objCmd.Parameters.Add("P_customerName", OracleDbType.Varchar2).Value = Name;
					objCmd.Parameters.Add("P_nationalOrCommercial", OracleDbType.Varchar2).Value = NationalIDandCR;
					objCmd.Parameters.Add("P_PHONE", OracleDbType.Varchar2).Value = Mobile;
					objCmd.Parameters.Add("P_mail", OracleDbType.Varchar2).Value = Email;
					objCmd.Parameters.Add("P_gender", OracleDbType.Int32).Value = Gender;
					objCmd.Parameters.Add("P_ExpiryDate", OracleDbType.Date).Value = ExpiryDate;
					objCmd.Parameters.Add("P_bankid", OracleDbType.Int32).Value = (BankCode.HasValue ? ((object)BankCode.Value) : DBNull.Value);
					objCmd.Parameters.Add("P_IBAN", OracleDbType.Varchar2).Value = string.Empty;
					objCmd.Parameters.Add("p_fixed_mobile", OracleDbType.Varchar2).Value = ((!string.IsNullOrEmpty(fixedmobile)) ? ((IConvertible)fixedmobile) : ((IConvertible)DBNull.Value));
					objCmd.Parameters.Add("P_ID", OracleDbType.Int64).Direction = ParameterDirection.Output;
					objConn.Open();
					objCmd.ExecuteNonQuery();
					Id = Convert.ToInt64(objCmd.Parameters["P_ID"].Value.ToString());
					objConn.Close();
				}
				return Id;
			}
			catch (Exception ex)
			{
				string pathMDF = "C:\\Logs\\CustomerInsert";
				string fieNameWithExt = "ErrorLogs_" + NationalIDandCR + Guid.NewGuid().ToString() + ".txt";
				string filePath = Path.Combine(pathMDF, fieNameWithExt);
				using (StreamWriter fileStream = new StreamWriter(filePath))
				{
					fileStream.Write(ex.Message.ToString());
				}
				return 0;
			}
		}
	}
}
