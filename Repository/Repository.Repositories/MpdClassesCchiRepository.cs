using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Domain.Common;
using Domain.Context;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.DTOs;
using Oracle.ManagedDataAccess.Client;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MpdClassesCchiRepository : Repository<MpdClassesCchi>, IMpdClassesCchiRepository, IRepository<MpdClassesCchi>
	{
		private CchiDbContext _context;

		public MpdClassesCchiRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}

		public List<MpdClassesCchi> LoadClasses(int PolicyCchiId)
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_LOAD_CLASSES_FOR_CCHI";
			command.Parameters.Add(new OracleParameter("P_MPD_CCHI_PLC_ID", OracleDbType.Int64, PolicyCchiId, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				List<MpdClassesCchi> lstMpdClassesCchi = new List<MpdClassesCchi>();
				MpdClassesCchi oMpdClassesCchi = new MpdClassesCchi();
				long totalRecords = 0L;
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oMpdClassesCchi = new MpdClassesCchi();
							Map(reader, oMpdClassesCchi);
							lstMpdClassesCchi.Add(oMpdClassesCchi);
							totalRecords++;
						}
					}
				}
				return lstMpdClassesCchi;
			}
			catch (Exception)
			{
				return new List<MpdClassesCchi>();
			}
		}

		public List<CCHIUploadStandardBenefitsRequest> CollectStandardClasses()
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_COLLECT_STANDARD_CLASSES";
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				List<CCHIUploadStandardBenefitsRequest> lstCCHIUploadStandardBenefitsRequest = new List<CCHIUploadStandardBenefitsRequest>();
				CCHIUploadStandardBenefitsRequest oCCHIUploadStandardBenefitsRequest = new CCHIUploadStandardBenefitsRequest();
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oCCHIUploadStandardBenefitsRequest = new CCHIUploadStandardBenefitsRequest();
							oCCHIUploadStandardBenefitsRequest.POLICYNUMBER = reader["CCHI_POLICY_NO"].ToString();
							oCCHIUploadStandardBenefitsRequest.COMPANYCLASSID = reader["CCHI_CLASS_ID"].ToString();
							lstCCHIUploadStandardBenefitsRequest.Add(oCCHIUploadStandardBenefitsRequest);
						}
					}
				}
				return lstCCHIUploadStandardBenefitsRequest;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<PrepareNonStandardClassesRequest> PrepareNonStandardClasses()
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_COLLECT_NON_STD_CLS_INFO";
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				List<PrepareNonStandardClassesRequest> lstPrepareNonStandardClassesRequest = new List<PrepareNonStandardClassesRequest>();
				PrepareNonStandardClassesRequest oPrepareNonStandardClassesRequest = new PrepareNonStandardClassesRequest();
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oPrepareNonStandardClassesRequest = new PrepareNonStandardClassesRequest();
							oPrepareNonStandardClassesRequest.CchiPolicyNo = reader["CCHI_POLICY_NO"].ToString();
							oPrepareNonStandardClassesRequest.CchiClassId = reader["CCHI_CLASS_ID"].ToString();
							lstPrepareNonStandardClassesRequest.Add(oPrepareNonStandardClassesRequest);
						}
					}
				}
				return lstPrepareNonStandardClassesRequest;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public CCHIUploadNonStandardBenefitsRequest CollectNonStandardClasses(string CchiPolicyNo, string CchiClassId)
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_COLLECT_CLASSES_BENEFITS";
			command.Parameters.Add(new OracleParameter("P_CCHI_POLICY_NO", OracleDbType.Int64, CchiPolicyNo, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_CCHI_CLASS_ID", OracleDbType.Int64, CchiClassId, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				CCHIUploadNonStandardBenefitsRequest oCCHIUploadNonStandardBenefitsRequest = new CCHIUploadNonStandardBenefitsRequest();
				BENEFITS oBENEFITS = new BENEFITS();
				List<BENEFITS> lstBenefits = new List<BENEFITS>();
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oCCHIUploadNonStandardBenefitsRequest = new CCHIUploadNonStandardBenefitsRequest();
							oBENEFITS = new BENEFITS();
							oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER = reader["CCHI_POLICY_NO"].ToString();
							oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID = reader["CCHI_CLASS_ID"].ToString();
							oBENEFITS.ID = Convert.ToInt64(reader["ID"]);
							oBENEFITS.VALUE = reader["VALUE"].ToString();
							lstBenefits.Add(oBENEFITS);
						}
					}
				}
				oCCHIUploadNonStandardBenefitsRequest.BENEFITS = lstBenefits;
				return oCCHIUploadNonStandardBenefitsRequest;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public IResponseResult<string> UpdateClassesInfo(string CchiPolicyNo, string CchiClassId, string ClassId, string IsBenefit, string ClassStatus, string ClassStatusDesc, string ModificationUser)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD.DBP_MPD_CLASSES_CCHI_UPDATE";
				command.Parameters.Add(new OracleParameter("P_CCHI_POLICY_NO", OracleDbType.Varchar2, CchiPolicyNo, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CCHI_CLASS_ID", OracleDbType.Varchar2, CchiClassId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CLASS_ID", OracleDbType.Varchar2, ClassId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_IS_BENEFIT", OracleDbType.Varchar2, IsBenefit, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CLASS_STATUS", OracleDbType.Varchar2, ClassStatus, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CLASS_STATUS_DESC", OracleDbType.Varchar2, ClassStatusDesc, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MODIFICATION_USER", OracleDbType.Varchar2, ModificationUser, ParameterDirection.Input));
				command.ExecuteNonQuery();
				return new ResponseResult<string>
				{
					Status = ResultStatus.Success,
					Data = string.Empty
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<string>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { ex.Message }
				};
			}
		}

		public IResponseResult<string> UpdateStandardClasses(string CchiPolicyNo, string CchiClassId, string ReferenceNo, string Status, string StatusDesc, string ModificationUser)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD.DBP_UPDATE_STANDARD_CLASSES";
				command.Parameters.Add(new OracleParameter("P_CCHI_POLICY_NO", OracleDbType.Varchar2, CchiPolicyNo, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CCHI_CLASS_ID", OracleDbType.Varchar2, CchiClassId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_REFERENCE_NO", OracleDbType.Varchar2, ReferenceNo, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_STD_STATUS", OracleDbType.Varchar2, Status, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_STD_STATUS_DESC", OracleDbType.Varchar2, StatusDesc, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MODIFICATION_USER", OracleDbType.Varchar2, ModificationUser, ParameterDirection.Input));
				command.ExecuteNonQuery();
				return new ResponseResult<string>
				{
					Status = ResultStatus.Success,
					Data = string.Empty
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<string>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Error in Procedure: " + ex.Message }
				};
			}
		}

		public IResponseResult<string> UpdateNonStandardClasses(string CchiPolicyNo, string CchiClassId, long? CchiBenefitId, string ReferenceNo, string TransactionType, string Status, string StatusDesc, string ModificationUser)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD.DBP_UPDATE_BENEFIT_STATUS";
				command.Parameters.Add(new OracleParameter("P_CCHI_POLICY_NO", OracleDbType.Varchar2, CchiPolicyNo, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CCHI_CLASS_ID", OracleDbType.Varchar2, CchiClassId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CCHI_BENEFIT_ID", OracleDbType.Varchar2, CchiBenefitId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_REFERENCE_NO", OracleDbType.Varchar2, ReferenceNo, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_TRANSACTION_TYPE", OracleDbType.Varchar2, TransactionType, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_STD_STATUS", OracleDbType.Varchar2, Status, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_STD_STATUS_DESC", OracleDbType.Varchar2, StatusDesc, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MODIFICATION_USER", OracleDbType.Varchar2, ModificationUser, ParameterDirection.Input));
				command.ExecuteNonQuery();
				return new ResponseResult<string>
				{
					Status = ResultStatus.Success,
					Data = string.Empty
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<string>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { ex.Message }
				};
			}
		}

		public IResponseResult<ClassBenefitClassDeductibleResponse> GetClassBenefits(int classID, int benefitID)
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_LOAD_CLASS_BENEFITS";
			command.Parameters.Add(new OracleParameter("P_MPD_PCL_CCHI_ID", OracleDbType.Int64, classID, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_CCHI_BENEFIT_ID", OracleDbType.Int64, benefitID, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				ClassBenefitClassDeductibleResponse oClassBenefitClassDeductibleResponse = new ClassBenefitClassDeductibleResponse();
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();
						oClassBenefitClassDeductibleResponse.MpbBnfCchiId = Convert.ToInt32(reader["MPD_BNF_CCHI_ID"]);
						oClassBenefitClassDeductibleResponse.MpdPbnId = ((!string.IsNullOrEmpty(reader["MPD_PBN_ID"].ToString())) ? new int?(Convert.ToInt32(reader["MPD_PBN_ID"])) : null);
						oClassBenefitClassDeductibleResponse.MpdPclId = ((!string.IsNullOrEmpty(reader["MPD_PCL_ID"].ToString())) ? new int?(Convert.ToInt32(reader["MPD_PCL_ID"])) : null);
						oClassBenefitClassDeductibleResponse.CchiBenefitName = reader["CCHI_BENEFIT_NAME"].ToString();
						oClassBenefitClassDeductibleResponse.CchiBenefitName2 = reader["CCHI_BENEFIT_NAME2"].ToString();
						oClassBenefitClassDeductibleResponse.EskaBenefitName = reader["ESKA_BENEFIT_NAME"].ToString();
						oClassBenefitClassDeductibleResponse.TerritoryScope = reader["TERRITORY_SCOPE"].ToString();
						oClassBenefitClassDeductibleResponse.AnnualLimit = ((!string.IsNullOrEmpty(reader["ANNUAL_LIMIT"].ToString())) ? new decimal?(Convert.ToDecimal(reader["ANNUAL_LIMIT"])) : null);
						oClassBenefitClassDeductibleResponse.NumberOfUsage = ((!string.IsNullOrEmpty(reader["NUMBER_OF_USAGE"].ToString())) ? new int?(Convert.ToInt32(reader["NUMBER_OF_USAGE"])) : null);
						oClassBenefitClassDeductibleResponse.NetCopayment = ((!string.IsNullOrEmpty(reader["NET_COPAYMENT"].ToString())) ? new decimal?(Convert.ToDecimal(reader["NET_COPAYMENT"])) : null);
						oClassBenefitClassDeductibleResponse.NetDeductible = ((!string.IsNullOrEmpty(reader["NET_DEDUCTIBLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["NET_DEDUCTIBLE"])) : null);
						oClassBenefitClassDeductibleResponse.NetMinDeductible = ((!string.IsNullOrEmpty(reader["NET_MIN_DEDUCTIBLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["NET_MIN_DEDUCTIBLE"])) : null);
						oClassBenefitClassDeductibleResponse.NetMaxDeductible = ((!string.IsNullOrEmpty(reader["NET_MAX_DEDUCTIBLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["NET_MAX_DEDUCTIBLE"])) : null);
						oClassBenefitClassDeductibleResponse.ReimbCopayment = ((!string.IsNullOrEmpty(reader["REIMB_COPAYMENT"].ToString())) ? new decimal?(Convert.ToDecimal(reader["REIMB_COPAYMENT"])) : null);
						oClassBenefitClassDeductibleResponse.ReimbDeductible = ((!string.IsNullOrEmpty(reader["REIMB_DEDUCTABLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["REIMB_DEDUCTABLE"])) : null);
						oClassBenefitClassDeductibleResponse.ReimbMaxDeductible = ((!string.IsNullOrEmpty(reader["REIMB_MAX_DEDUCTIBLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["ANREIMB_MAX_DEDUCTIBLENUAL_LIMIT"])) : null);
						oClassBenefitClassDeductibleResponse.ReimbMinDeductible = ((!string.IsNullOrEmpty(reader["REIMB_MIN_DEDUCTIBLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["REIMB_MIN_DEDUCTIBLE"])) : null);
						oClassBenefitClassDeductibleResponse.MaxCoverLimit = ((!string.IsNullOrEmpty(reader["MAX_COVER_LIMIT"].ToString())) ? new decimal?(Convert.ToDecimal(reader["MAX_COVER_LIMIT"])) : null);
						oClassBenefitClassDeductibleResponse.RoomType = ((!string.IsNullOrEmpty(reader["ROOM_TYPE"].ToString())) ? new int?(Convert.ToInt32(reader["ROOM_TYPE"])) : null);
						oClassBenefitClassDeductibleResponse.RoomTypeDesc = reader["ROOM_TYPE_DESC"].ToString();
						oClassBenefitClassDeductibleResponse.MpnDeductible = ((!string.IsNullOrEmpty(reader["MPN_DEDUCTIBLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["MPN_DEDUCTIBLE"])) : null);
						oClassBenefitClassDeductibleResponse.MpnCopayment = ((!string.IsNullOrEmpty(reader["MPN_COPAYMENT"].ToString())) ? new decimal?(Convert.ToDecimal(reader["MPN_COPAYMENT"])) : null);
						oClassBenefitClassDeductibleResponse.OcnDeductible = ((!string.IsNullOrEmpty(reader["OCN_DEDUCTIBLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["OCN_DEDUCTIBLE"])) : null);
						oClassBenefitClassDeductibleResponse.OcnCopayment = ((!string.IsNullOrEmpty(reader["OCN_COPAYMENT"].ToString())) ? new decimal?(Convert.ToDecimal(reader["OCN_COPAYMENT"])) : null);
						oClassBenefitClassDeductibleResponse.OhnDeductible = ((!string.IsNullOrEmpty(reader["OHN_DEDUCTIBLE"].ToString())) ? new decimal?(Convert.ToDecimal(reader["OHN_DEDUCTIBLE"])) : null);
						oClassBenefitClassDeductibleResponse.OhnCopayment = ((!string.IsNullOrEmpty(reader["OHN_COPAYMENT"].ToString())) ? new decimal?(Convert.ToDecimal(reader["OHN_COPAYMENT"])) : null);
						oClassBenefitClassDeductibleResponse.RecordLevel = ((!string.IsNullOrEmpty(reader["RECORD_LEVEL"].ToString())) ? new int?(Convert.ToInt32(reader["RECORD_LEVEL"])) : null);
					}
				}
				return new ResponseResult<ClassBenefitClassDeductibleResponse>
				{
					Status = ResultStatus.Success,
					Data = oClassBenefitClassDeductibleResponse
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<ClassBenefitClassDeductibleResponse>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { ex.Message }
				};
			}
		}

		public IResponseResult<string> UpdateClassBenefit(ClassBenefitClassDeductibleResponse oClassBenefitClassDeductibleResponse)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD.DBP_UPDATE_BENEFIT";
				command.Parameters.Add(new OracleParameter("P_MPD_BNF_CCHI_ID", OracleDbType.Int64, oClassBenefitClassDeductibleResponse.MpbBnfCchiId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MPD_PBN_ID", OracleDbType.Int64, oClassBenefitClassDeductibleResponse.MpdPbnId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MPD_PCL_ID", OracleDbType.Int64, oClassBenefitClassDeductibleResponse.MpdPclId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_ANNUAL_LIMIT", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.AnnualLimit, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_NUMBER_OF_USAGE", OracleDbType.Int32, oClassBenefitClassDeductibleResponse.NumberOfUsage, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_NET_COPAYMENT", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.NetCopayment, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_NET_DEDUCTIBLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.NetDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_NET_MIN_DEDUCTIBLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.NetMinDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_NET_MAX_DEDUCTIBLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.NetMaxDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_REIMB_COPAYMENT", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.ReimbCopayment, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_REIMB_DEDUCTABLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.ReimbDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_REIMB_MAX_DEDUCTIBLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.ReimbMaxDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_REIMB_MIN_DEDUCTIBLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.ReimbMinDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MAX_COVER_LIMIT", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.MaxCoverLimit, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_ROOM_TYPE", OracleDbType.Int32, oClassBenefitClassDeductibleResponse.RoomType, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_ROOM_TYPE_DESC", OracleDbType.Varchar2, oClassBenefitClassDeductibleResponse.RoomTypeDesc, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MPN_DEDUCTIBLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.MpnDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MPN_COPAYMENT", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.MpnCopayment, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_OCN_DEDUCTIBLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.OcnDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_OCN_COPAYMENT", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.OcnCopayment, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_OHN_DEDUCTIBLE", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.OhnDeductible, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_OHN_COPAYMENT", OracleDbType.Decimal, oClassBenefitClassDeductibleResponse.OhnCopayment, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_RECORD_LEVEL", OracleDbType.Int32, oClassBenefitClassDeductibleResponse.RecordLevel, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CREATION_USER", OracleDbType.Varchar2, oClassBenefitClassDeductibleResponse.CreationUser, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_ERROR_MSG", OracleDbType.Varchar2, 800, DBNull.Value, ParameterDirection.Output));
				command.ExecuteNonQuery();
				if (command.Parameters["P_ERROR_MSG"].Value == DBNull.Value || command.Parameters["P_ERROR_MSG"].Value.ToString() == "null")
				{
					return new ResponseResult<string>
					{
						Status = ResultStatus.Success,
						Data = null
					};
				}
				return new ResponseResult<string>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { command.Parameters["P_ERR_MSG"].Value.ToString() }
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<string>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { ex.Message }
				};
			}
		}
	}
}
