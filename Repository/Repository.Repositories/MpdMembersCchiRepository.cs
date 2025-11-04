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
	internal class MpdMembersCchiRepository : Repository<MpdMembersCchi>, IMpdMembersCchiRepository, IRepository<MpdMembersCchi>
	{
		private CchiDbContext _context;

		public MpdMembersCchiRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}

		public IResponseResult<string> OnHoldMembers(long PolicyId, string MemberIds, long Flag, string CreationUser)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD.DBP_ON_HOLD_MEMBERS";
				command.Parameters.Add(new OracleParameter("P_MPD_PLC_ID", OracleDbType.Int64, PolicyId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MPD_MBR_IDS", OracleDbType.Varchar2, MemberIds, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_ACTION", OracleDbType.Int64, Flag, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CREATION_USER", OracleDbType.Varchar2, CreationUser, ParameterDirection.Input));
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
					Errors = new List<string> { "Exception Message = " + ex.Message },
					Data = null
				};
			}
		}

		public List<MpdMembersCchi> LoadMembers(int PolicyCchiId)
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_LOAD_MEMBERS_FOR_CCHI";
			command.Parameters.Add(new OracleParameter("P_MPD_CCHI_PLC_ID", OracleDbType.Int64, PolicyCchiId, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				List<MpdMembersCchi> lstMpdMembersCchi = new List<MpdMembersCchi>();
				MpdMembersCchi oMpdMembersCchi = new MpdMembersCchi();
				long totalRecords = 0L;
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oMpdMembersCchi = new MpdMembersCchi();
							Map(reader, oMpdMembersCchi);
							lstMpdMembersCchi.Add(oMpdMembersCchi);
							totalRecords++;
						}
					}
				}
				return lstMpdMembersCchi;
			}
			catch (Exception)
			{
				return new List<MpdMembersCchi>();
			}
		}

		public long LoadCodeById(long Id)
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_GET_OCC_MINOR_CODE";
			command.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int64, Id, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				Code code = new Code();
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							code.MinorCode = ((reader["MINOR_CODE"] != DBNull.Value) ? Convert.ToInt64(reader["MINOR_CODE"].ToString()) : 0);
						}
					}
				}
				return code.MinorCode.Value;
			}
			catch (Exception)
			{
				return 0L;
			}
		}

		public IResponseResult<string> UpdateMembersStatusDB(long MpdPlcCchiId, string MpdMbrSegmentCode, string Status, string StatusDesc, string TransactionType, string CreationUser)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBPKG_CCHI_UPLOAD.DBP_MEMBERS_CCHI_STATUS";
				command.Parameters.Add(new OracleParameter("P_MPD_PLC_CCHI_ID", OracleDbType.Int64, MpdPlcCchiId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_MBR_SEGMENT_CODE", OracleDbType.Varchar2, MpdMbrSegmentCode, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_STATUS", OracleDbType.Varchar2, Status, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_STATUS_DESC", OracleDbType.Varchar2, StatusDesc, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_TRANSACTION_TYPE", OracleDbType.Varchar2, TransactionType, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_CREATION_USER", OracleDbType.Varchar2, CreationUser, ParameterDirection.Input));
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

		public int CheckMemberActionType(long MpdPlmId)
		{
			int Status = 0;
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_GET_MEMBER_CCHI_STATUS";
			command.Parameters.Add(new OracleParameter("P_MPD_PLM_ID", OracleDbType.Int64, MpdPlmId, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_STATUS", OracleDbType.Int16, ParameterDirection.Output));
			try
			{
				command.ExecuteNonQuery();
				return (command.Parameters["P_STATUS"].Value != DBNull.Value) ? Convert.ToInt32(command.Parameters["P_STATUS"].Value.ToString()) : 0;
			}
			catch (Exception)
			{
				return 0;
			}
		}
	}
}
