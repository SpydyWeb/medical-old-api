using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Domain.Models;
using Repository.Interfaces;
using Service.Interfaces;
using Service.UnitOfWork;

namespace Service.Services
{
	public class MpdMembersCchiHistService : IMpdMembersCchiHistService, IService<MpdMembersCchiHist>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MpdMembersCchiHistService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		public IResponseResult<MpdMembersCchiHist> Add(MpdMembersCchiHist entity)
		{
			try
			{
				MpdMembersCchiHist result = _repositoryUnitOfWork.MpdMembersCchiHist.Value.Add(entity);
				if (result == null)
				{
					return new ResponseResult<MpdMembersCchiHist>
					{
						Errors = new List<string> { "Error In Update Entity(MpdMembersCchiHist)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MpdMembersCchiHist>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MpdMembersCchiHist>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}
		}

		public async Task<IResponseResult<IEnumerable<MpdMembersCchiHist>>> GetHistByMpdMemCchiId(long MpdPlcMemId)
		{
			try
			{
				List<MpdMembersCchiHist> result = (from x in _repositoryUnitOfWork.MpdMembersCchiHist.Value.Find((MpdMembersCchiHist x) => x.MpdMemCchiId == (long?)MpdPlcMemId).ToList()
					select (x)).ToList();
				return new ResponseResult<IEnumerable<MpdMembersCchiHist>>
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
				ResponseResult<IEnumerable<MpdMembersCchiHist>> responseResult = new ResponseResult<IEnumerable<MpdMembersCchiHist>>();
				responseResult.Status = ResultStatus.Failed;
				responseResult.Data = null;
				responseResult.TotalRecords = 0L;
				responseResult.Errors = new List<string> { "Exception Message : " + ex.Message + Environment.NewLine + " Exception InnerException " + ex.InnerException };
				return responseResult;
			}
		}

		public IResponseResult<IEnumerable<MpdMembersCchiHist>> AddRange(IEnumerable<MpdMembersCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdMembersCchiHist> Get(long Id)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdMembersCchiHist> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdMembersCchiHist>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdMembersCchiHist> Remove(MpdMembersCchiHist entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdMembersCchiHist>> RemoveRange(IEnumerable<MpdMembersCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdMembersCchiHist>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdMembersCchiHist> Update(MpdMembersCchiHist entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdMembersCchiHist>> UpdateRange(IEnumerable<MpdMembersCchiHist> models)
		{
			throw new NotImplementedException();
		}
	}
}
