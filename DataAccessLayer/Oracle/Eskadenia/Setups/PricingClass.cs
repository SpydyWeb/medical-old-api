using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.Authentications;
using CORE.Interfaces;
using CORE.TablesObjects;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Oracle.Eskadenia.Setups
{
    public static class PricingClass
    {

        public static MemberPrices MemberPrice(Subjects member, int PlanId, string Connection)
        {
            MemberPrices memberPrices = new MemberPrices();
            try
            {
                using OracleConnection objConn = new OracleConnection(Connection);
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                //if (member.ClassId == 1 && PlanId == 7828)
                //{
                //    member.ClassId = 9186;
                //}
                //if (member.ClassId == 2 && PlanId == 7828)
                //{
                //    member.ClassId = 9187;
                //}
                //if (member.ClassId == 3 && PlanId == 7828)
                //{
                //    member.ClassId = 9188;
                //}
                //if (member.ClassId == 1 && PlanId == 7648)
                //{
                //    member.ClassId = 8946;
                //}
                //if (member.ClassId == 2 && PlanId == 7648)
                //{
                //    member.ClassId = 8947;
                //}
                //if (member.ClassId == 3 && PlanId == 7648)
                //{
                //    member.ClassId = 8948;
                //}
                //if (member.ClassId == 1 && PlanId == 7848)
                //{
                //    member.ClassId = 9209;
                //}
                //if (member.ClassId == 2 && PlanId == 7848)
                //{
                //    member.ClassId = 9211;
                //}
                //if (member.ClassId == 3 && PlanId == 7848)
                //{
                //    member.ClassId = 9210;
                //}
                if (member.Relation == 3)//child
                {
                    objCmd.CommandText = "IMEDICAL.GET_DEP_SME_PREMIUM";
                    objCmd.Parameters.Add("P_AGE", OracleDbType.Int32).Value = member.Age;
                    objCmd.Parameters.Add("P_PLAN", OracleDbType.Int32).Value = PlanId;
                    objCmd.Parameters.Add("P_CLASS", OracleDbType.Int32).Value = member.ClassId;
                    objCmd.Parameters.Add("P_NET", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                }
                else
                {
                    objCmd.CommandText = "IMEDICAL.GET_OTH_SME_PREMIUM";
                    objCmd.Parameters.Add("P_AGE", OracleDbType.Int32).Value = member.Age;
                    objCmd.Parameters.Add("P_PLAN", OracleDbType.Int32).Value = PlanId;
                    objCmd.Parameters.Add("P_CLASS", OracleDbType.Int32).Value = member.ClassId;
                    objCmd.Parameters.Add("P_RELATION", OracleDbType.Int32).Value = member.Relation;
                    objCmd.Parameters.Add("P_GENDER", OracleDbType.Int32).Value = member.Gender;
                    objCmd.Parameters.Add("P_MARTIAL", OracleDbType.Int32).Value = member.MartialStatus;
                    objCmd.Parameters.Add("P_NET", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                }
                objConn.Open();
                objCmd.ExecuteNonQuery();
                memberPrices.NetPremium = Convert.ToDecimal(objCmd.Parameters["P_NET"].Value.ToString());
                memberPrices.Subjects = member;
                objConn.Close();
            }
            catch (Exception)
            {
                memberPrices.NetPremium = 0m;
                memberPrices.GrossPremium = 0m;
                memberPrices.Subjects = member;
            }
            return memberPrices;
        }

        public static decimal Calculation(decimal NetPremium, decimal? LoadingPercent, decimal? LoadingPremium, decimal DiscountPercent, decimal DiscountAmt, int ClassID, string Connection)
        {
            try
            {
                using OracleConnection objConn = new OracleConnection(Connection);
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "imedical.DBPKG_PRODUCTION_CALCULATIONS.DBP_CALC_GROSS_PRM";
                objCmd.Parameters.Add("P_NET_PREMIUM", OracleDbType.Decimal).Value = NetPremium;
                objCmd.Parameters.Add("P_EXTRA_NRP_PER", OracleDbType.Decimal).Value = 0;
                objCmd.Parameters.Add("P_LOADING_PER", OracleDbType.Decimal).Value = LoadingPercent;
                objCmd.Parameters.Add("P_LOADING_PRM", OracleDbType.Decimal).Value = LoadingPremium;
                objCmd.Parameters.Add("P_DISCOUNT_PER", OracleDbType.Decimal).Value = DiscountPercent;
                objCmd.Parameters.Add("P_DISCOUNT_PREM", OracleDbType.Decimal).Value = DiscountAmt;
                objCmd.Parameters.Add("P_EXTRA_NRP_PREM", OracleDbType.Decimal).Value = 0;
                objCmd.Parameters.Add("P_MPD_PCL_ID", OracleDbType.Int32).Value = ClassID;
                objCmd.Parameters.Add("P_EXTRA_NRP_AMT", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                objCmd.Parameters.Add("P_LOADING_AMT", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                objCmd.Parameters.Add("P_DISCOUNT_AMT", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                objCmd.Parameters.Add("P_GROSS_PREMIUM", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                objConn.Open();
                objCmd.ExecuteNonQuery();
                return Convert.ToDecimal(objCmd.Parameters["P_GROSS_PREMIUM"].Value.ToString());
            }
            catch (Exception)
            {
                return 0m;
            }
        }

        public static decimal? CalculateMMP(string connection, int Liability, int Proffession, string PltCode, int LobId)
        {
            try
            {
                using OracleConnection objConn = new OracleConnection(connection);
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "imedical.CALC_MMP_PREMIUM";
                objCmd.Parameters.Add("P_LBL_ID", OracleDbType.Int32).Value = Liability;
                objCmd.Parameters.Add("P_SBT_ID", OracleDbType.Int32).Value = Proffession;
                objCmd.Parameters.Add("P_PLT_CODE", OracleDbType.NVarchar2).Value = PltCode;
                objCmd.Parameters.Add("P_CLS_ID", OracleDbType.Int32).Value = LobId;
                objCmd.Parameters.Add("P_GROSS", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                objConn.Open();
                objCmd.ExecuteNonQuery();
                decimal amount = Convert.ToDecimal(objCmd.Parameters["P_GROSS"].Value);
                objConn.Close();
                return amount;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static MemberPrices MemberPriceClass(Subjects member, int PlanId, int classCode, int YakeenNationalityCode, string planCode, string Connection, int P_NOOFNONSAUDIPRINCMEM = 0,
        int P_NOOFSAUDIPRINCMEM = 0,
        int P_NOOFSAUDIDEPMEM = 0,
        int P_NOOFNONSAUDIDEPMEM = 0)
        {
            //9207 C          C Non MENA
            //9206 C+         C MENA
            //9208 C Basic    C Saudi
            //9209 VIP        VIP
            //9211 VIP+       VIP+
            //9210 VIP Basic  VIP Basic
            MemberPrices memberPrices = new MemberPrices();
            OracleConnection objConn = new OracleConnection();
            try
            {
                using (objConn = new OracleConnection(Connection))
                {

                    OracleCommand objCmd = new OracleCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "APIINTEGRATION.USP_GET_PRICING_DETAILS_SME";
                    objCmd.Parameters.Add("P_FLAG", OracleDbType.Int32).Value = 1;
                    objCmd.Parameters.Add("P_AGE", OracleDbType.Int32).Value = member.Age;
                    objCmd.Parameters.Add("P_GENDER", OracleDbType.Int32).Value = member.Gender;
                    objCmd.Parameters.Add("P_RELATIONID", OracleDbType.Int32).Value = member.Relation;
                    objCmd.Parameters.Add("P_MARITALSTATUSID", OracleDbType.Int32).Value = member.MartialStatus;
                    objCmd.Parameters.Add("P_NATIONALITY", OracleDbType.Int32).Value = YakeenNationalityCode;
                    objCmd.Parameters.Add("P_ACTIVITYCODE", OracleDbType.Varchar2).Value = 0;
                    objCmd.Parameters.Add("P_AGGREGATORNAME", OracleDbType.Varchar2).Value = "PARTNERPORTAL";
                    objCmd.Parameters.Add("P_CLASS", OracleDbType.Int32).Value = classCode;
                    //objCmd.Parameters.Add("P_CITY", OracleDbType.NVarchar2).Value = null;
                    objCmd.Parameters.Add("P_NOOFNONSAUDIPRINCMEM", OracleDbType.Int32).Value = P_NOOFNONSAUDIPRINCMEM;
                    objCmd.Parameters.Add("P_NOOFSAUDIPRINCMEM", OracleDbType.Int32).Value = P_NOOFSAUDIPRINCMEM;
                    objCmd.Parameters.Add("P_NOOFSAUDIDEPMEM", OracleDbType.Int32).Value = P_NOOFSAUDIDEPMEM;
                    objCmd.Parameters.Add("P_NOOFNONSAUDIDEPMEM", OracleDbType.Int32).Value = P_NOOFNONSAUDIDEPMEM;
                    objCmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                    objConn.Open();
                    OracleDataReader reader = objCmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        memberPrices.Subjects = member;
                        memberPrices.NetPremium = Convert.ToDecimal(dt.Rows[0]["BASE_RATE"].ToString());
                        memberPrices.Subjects.AdditionalPremium = Convert.ToDecimal(dt.Rows[0]["ActivityRate"].ToString());
                        if (dt.Rows[0]["PLAN_ID"].ToString() == planCode)
                        {
                            memberPrices.Subjects.ClassId = Convert.ToInt32(dt.Rows[0]["CLASS_ID"].ToString());
                            
                        }

                    }
                    else
                    {
                        memberPrices.NetPremium = 0m;
                        memberPrices.GrossPremium = 0m;
                    }


                    objConn.Close();
                    //objCmd.ExecuteNonQuery();
                    //memberPrices.NetPremium = Convert.ToDecimal(objCmd.Parameters["P_NET"].Value.ToString());
                    //memberPrices.Subjects = member;
                    //objConn.Close();
                }
            }
            catch (Exception ex)
            {
                memberPrices.NetPremium = 0m;
                memberPrices.GrossPremium = 0m;
                memberPrices.Subjects = member;
            }
            return memberPrices;
        }
    }
}
