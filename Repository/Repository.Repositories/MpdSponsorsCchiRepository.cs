using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Domain.Common;
using Domain.Context;
using Domain.Models;
using Oracle.ManagedDataAccess.Client;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MpdSponsorsCchiRepository : Repository<MpdSponsorsCchi>, IMpdSponsorsCchiRepository, IRepository<MpdSponsorsCchi>
	{
		private CchiDbContext _context;

		public MpdSponsorsCchiRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}

		public List<MpdSponsorsCchi> LoadSponsors(long PolicyCchiId)
		{
			using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
			connection.Open();
			using DbCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "DBPKG_CCHI_UPLOAD_QUERY.DBP_LOAD_SPONSORS_FOR_CCHI";
			command.Parameters.Add(new OracleParameter("P_MPD_CCHI_PLC_ID", OracleDbType.Int64, PolicyCchiId, ParameterDirection.Input));
			command.Parameters.Add(new OracleParameter("P_REF_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));
			try
			{
				List<MpdSponsorsCchi> lstMpdSponsorsCchi = new List<MpdSponsorsCchi>();
				MpdSponsorsCchi oMpdSponsorsCchi = new MpdSponsorsCchi();
				long totalRecords = 0L;
				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							oMpdSponsorsCchi = new MpdSponsorsCchi();
							Map(reader, oMpdSponsorsCchi);
							lstMpdSponsorsCchi.Add(oMpdSponsorsCchi);
							totalRecords++;
						}
					}
				}
				return lstMpdSponsorsCchi;
			}
			catch (Exception)
			{
				return new List<MpdSponsorsCchi>();
			}
		}
	}
}
