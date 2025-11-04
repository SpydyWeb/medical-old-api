using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Service.Interfaces;
using Service.UnitOfWork;

namespace Service.Services
{
	public class MpdPoliciesCchiHistService : IMpdPoliciesCchiHistService, IService<MpdPoliciesCchiHist>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		private readonly ILogger<MpdPoliciesCchiHistService> _Logger;

		public MpdPoliciesCchiHistService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork, ILogger<MpdPoliciesCchiHistService> logger)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
			_Logger = logger;
		}

		public IResponseResult<MpdPoliciesCchiHist> Add(MpdPoliciesCchiHist entity)
		{
			try
			{
				_Logger.LogInformation("MpdPoliciesCchiHist.Add");
				MpdPoliciesCchiHist result = _repositoryUnitOfWork.MpdPoliciesCchiHist.Value.Add(entity);
				return new ResponseResult<MpdPoliciesCchiHist>
				{
					Status = ResultStatus.Success,
					Data = entity
				};
			}
			catch (Exception ex)
			{
				_Logger.LogInformation("MpdPoliciesCchiHist.ex " + ex.Message);
				return new ResponseResult<MpdPoliciesCchiHist>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException.Message }
				};
			}
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchiHist>> AddRange(IEnumerable<MpdPoliciesCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdPoliciesCchiHist> Get(long Id)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdPoliciesCchiHist> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchiHist>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdPoliciesCchiHist> Remove(MpdPoliciesCchiHist entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchiHist>> RemoveRange(IEnumerable<MpdPoliciesCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchiHist>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdPoliciesCchiHist> Update(MpdPoliciesCchiHist entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchiHist>> UpdateRange(IEnumerable<MpdPoliciesCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public async Task<IResponseResult<IEnumerable<MpdPoliciesCchiHist>>> GetHistByMpdPlcCchiId(long MpdPlcCchiId)
		{
			try
			{
				List<MpdPoliciesCchiHist> result = (from y in _repositoryUnitOfWork.MpdPoliciesCchiHist.Value.Find((MpdPoliciesCchiHist x) => x.MpdPlcCchiId == (long?)MpdPlcCchiId).ToList()
					select (y)).ToList();
				return new ResponseResult<IEnumerable<MpdPoliciesCchiHist>>
				{
					Status = ResultStatus.Success,
					Data = result,
					Errors = null,
					TotalRecords = result.Count()
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ResponseResult<IEnumerable<MpdPoliciesCchiHist>> responseResult = new ResponseResult<IEnumerable<MpdPoliciesCchiHist>>();
				responseResult.Status = ResultStatus.Failed;
				responseResult.Data = null;
				responseResult.TotalRecords = 0L;
				responseResult.Errors = new List<string> { "Exception Message : " + ex.Message + Environment.NewLine + " Exception InnerException " + ex.InnerException };
				return responseResult;
			}
		}
	}
}
