using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Domain.Common;
using Domain.Context;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;
using Oracle.ManagedDataAccess.Client;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	internal class MpdPoliciesCchiRepository : Repository<MpdPoliciesCchi>, IMpdPoliciesCchiRepository, IRepository<MpdPoliciesCchi>
	{
		private CchiDbContext _context;

		public MpdPoliciesCchiRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> GetByCriteria(MpdPoliciesSearchCriteria searchCriteria)
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_MPD_POL_CCHI_INQUIRY_LOAD";
			command.Parameters.Add(new OracleParameter("P_FCS_CST_ID ", OracleDbType.Int64, searchCriteria.PolicyHolderId, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_MPD_PLC_ID", OracleDbType.Int64, searchCriteria.PolicyNo, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_MPD_MBR_ID", OracleDbType.Int64, searchCriteria.MemberId, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_ENDT_NUMBER", OracleDbType.Int16, searchCriteria.EndorsmentNo, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_ISSUE_DATE", OracleDbType.Date, searchCriteria.IssueDate, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_FROM_EFFECTIVE_DATE", OracleDbType.Date, searchCriteria.EffectiveDate, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_TO_EFFECTIVE_DATE", OracleDbType.Date, searchCriteria.ExpiryDate, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_POLICY_TYPE", OracleDbType.Int64, searchCriteria.PolicyType, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_MPD_PLN_ID", OracleDbType.Int64, searchCriteria.PlanNo, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_BUSINESS_TYPE ", OracleDbType.Int64, searchCriteria.BusinessType, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_CCHI_STATUS", OracleDbType.Int64, searchCriteria.CCHIStatus, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_UPLOAD_STATUS", OracleDbType.Int64, searchCriteria.UploudStatus, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, null, ParameterDirection.Output));
			try
			{
				List<MpdPoliciesCchi> lstMpdPoliciesCchi = new List<MpdPoliciesCchi>();
				MpdPoliciesCchi oMpdPoliciesCchi = new MpdPoliciesCchi();
				long totalRecords = 0L;
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oMpdPoliciesCchi = new MpdPoliciesCchi();
							Map(reader, oMpdPoliciesCchi);
							oMpdPoliciesCchi.PolicyTypeName = ((reader["Policy_Type_Name"] != DBNull.Value) ? reader["Policy_Type_Name"].ToString() : string.Empty);
							oMpdPoliciesCchi.BusinessTypeName = ((reader["Business_Type_Name"] != DBNull.Value) ? reader["Business_Type_Name"].ToString() : string.Empty);
							oMpdPoliciesCchi.UploadStatus = ((reader["UPLOAD_STATUS"] != DBNull.Value) ? reader["UPLOAD_STATUS"].ToString() : string.Empty);
							oMpdPoliciesCchi.Status = ((reader["CCHI_STATUS"] != DBNull.Value) ? reader["CCHI_STATUS"].ToString() : string.Empty);
							lstMpdPoliciesCchi.Add(oMpdPoliciesCchi);
						}
					}
				}
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Status = ResultStatus.Success,
					Data = lstMpdPoliciesCchi,
					TotalRecords = lstMpdPoliciesCchi.Count()
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { ex.Message },
					TotalRecords = 0L
				};
			}
		}

		public IResponseResult<string> ChangePlcPriority(long PolicyId, long Priority, string creationUser)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD.DBP_CHANGE_PLC_PRIORITY";
				command.Parameters.Add(new OracleParameter("P_MPD_PLC_ID", OracleDbType.Int64, PolicyId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_ACTION", OracleDbType.Int64, Priority, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CREATION_USER", OracleDbType.Varchar2, creationUser, ParameterDirection.Input));
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

		public List<MpdPoliciesCchi> LoadPolicies()
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_LOAD_POLICIES_FOR_CCHI";
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				List<MpdPoliciesCchi> lstMpdPoliciesCchi = new List<MpdPoliciesCchi>();
				MpdPoliciesCchi oMpdPoliciesCchi = new MpdPoliciesCchi();
				long totalRecords = 0L;
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oMpdPoliciesCchi = new MpdPoliciesCchi();
							Map(reader, oMpdPoliciesCchi);
							lstMpdPoliciesCchi.Add(oMpdPoliciesCchi);
							totalRecords++;
						}
					}
				}
				return lstMpdPoliciesCchi;
			}
			catch (Exception)
			{
				return new List<MpdPoliciesCchi>();
			}
		}

		public List<MpdPoliciesCchi> LoadTransactionsForCCHI()
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_LOAD_TRANSACTIONS_FOR_CCHI";
				command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
				try
				{
					List<MpdPoliciesCchi> lstMpdPoliciesCchi = new List<MpdPoliciesCchi>();
					MpdPoliciesCchi oMpdPoliciesCchi = new MpdPoliciesCchi();
					using (DbDataReader reader = command.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								oMpdPoliciesCchi = new MpdPoliciesCchi();
								oMpdPoliciesCchi.Id = ((reader["MPD_PLC_CCHI_ID"] != DBNull.Value) ? Convert.ToInt64(reader["MPD_PLC_CCHI_ID"]) : 0);
								oMpdPoliciesCchi.CchiPolicyNo = Convert.ToString(reader["CCHI_POLICY_NO"]);
								oMpdPoliciesCchi.CchiId = Convert.ToString(reader["CCHI_ID"]);
								Map(reader, oMpdPoliciesCchi);
								lstMpdPoliciesCchi.Add(oMpdPoliciesCchi);
							}
						}
					}
					return lstMpdPoliciesCchi;
				}
				catch (Exception)
				{
					return null;
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		public IResponseResult<string> UpdatePoliciesStatus(long CchiPlcId, string CchiId, string Status, string StatusDesc, string TransactionType, string CreationUser, long? SeqNo)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD.DBP_POLICIES_CCHI_STATUS";
				command.Parameters.Add(new OracleParameter("P_MPD_CCHI_PLC_ID", OracleDbType.Int64, CchiPlcId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CCHI_ID", OracleDbType.Varchar2, CchiId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_STATUS", OracleDbType.Varchar2, Status, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_STATUS_DESC", OracleDbType.Varchar2, StatusDesc, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_TRANSACTION_TYPE", OracleDbType.Varchar2, TransactionType, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CREATION_USER", OracleDbType.Varchar2, CreationUser, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_SEQ_NO", OracleDbType.Int64, SeqNo, ParameterDirection.Input));
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

		public List<MpdPoliciesCchi> CollectClassesInfo(int Flag)
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_COLLECT_CLASSES_INFO";
			command.Parameters.Add(new OracleParameter("P_FLAG", OracleDbType.Int16, Flag, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				List<MpdPoliciesCchi> lstMpdPoliciesCchi = new List<MpdPoliciesCchi>();
				MpdPoliciesCchi oMpdPoliciesCchi = new MpdPoliciesCchi();
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oMpdPoliciesCchi = new MpdPoliciesCchi();
							Map(reader, oMpdPoliciesCchi);
							lstMpdPoliciesCchi.Add(oMpdPoliciesCchi);
						}
					}
				}
				return lstMpdPoliciesCchi;
			}
			catch (Exception)
			{
				return new List<MpdPoliciesCchi>();
			}
		}
	}
}
