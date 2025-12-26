using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.StaticDetails
{
    public class GetStaticDetails
    {
        public static DataTable GetStaticDetail(int flag, string Connection)
        {
            using OracleConnection objConn = new OracleConnection(Connection);
            DataTable dt = new DataTable();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "USP_GET_STATICDETAILS_PENTA";
                objCmd.Parameters.Add("P_FLAG", OracleDbType.Int32).Value = flag;
                objCmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                objConn.Open();
                OracleDataReader dr = objCmd.ExecuteReader();
                dt.Load(dr);
                objConn.Close();
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static DataTable GetTransformData(int flag, string source, string sourceCode, string sourceType, string quoteRequestReferenceNo, string Connection)
        {
            try
            {

                using (OracleConnection objConn = new OracleConnection(Connection))
                {
                    // Ensure the connection is open
                    if (objConn.State != ConnectionState.Open)
                    {
                        objConn.Open();
                    }
                    var objCmd = new OracleCommand();
                    using (objCmd)
                    {
                        objCmd.Connection = objConn;
                        objCmd.CommandText = "APIIntegration.USP_GET_TRANSFORM_DETAILS";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.Add("P_FLAG", OracleDbType.Int32).Value = flag;
                        objCmd.Parameters.Add("P_SOURCE", OracleDbType.Varchar2).Value = source;
                        objCmd.Parameters.Add("P_SOURCE_CODE", OracleDbType.Varchar2).Value = sourceCode;
                        objCmd.Parameters.Add("P_SRC_TYPE", OracleDbType.Varchar2).Value = sourceType;
                        objCmd.Parameters.Add("P_REFERENCE_NO", OracleDbType.Varchar2).Value = !string.IsNullOrEmpty(quoteRequestReferenceNo) ? quoteRequestReferenceNo : (Object)DBNull.Value;
                        OracleParameter param = new OracleParameter("P_RESULT", OracleDbType.RefCursor);
                        param.Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add(param);
                        return Execute(ref objCmd);
                    }

                }

            }
            catch (Exception ex)
            {
                // Log the exception here
                Console.WriteLine($"Error in GetSegmentCode: {ex.Message}");
                return null;
            }


        }
        public static DataTable Execute(ref OracleCommand _cmd)
        {
            try
            {
                //_cmd.Connection.Open();
                OracleDataReader dr = _cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
            catch (Exception exx)
            {
                throw exx;
            }
            finally
            {
                _cmd.Connection.Close();
                _cmd.Connection.Dispose();
            }
        }

    }
}
