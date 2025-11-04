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
	public class MntNetCchiHistService : IMntNetCchiHistService, IService<MntNetCchiHist>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MntNetCchiHistService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		public IResponseResult<MntNetCchiHist> Add(MntNetCchiHist entity)
		{
			try
			{
				MntNetCchiHist result = _repositoryUnitOfWork.MntNetCchiHist.Value.Add(entity);
				if (result == null)
				{
					return new ResponseResult<MntNetCchiHist>
					{
						Errors = new List<string> { "Error In Adding Entity(MntPrvNetCchiHist)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MntNetCchiHist>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MntNetCchiHist>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}
		}

		public IResponseResult<IEnumerable<MntNetCchiHist>> AddRange(IEnumerable<MntNetCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntNetCchiHist> Get(long Id)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntNetCchiHist> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntNetCchiHist>> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<ResponseResult<List<MntNetCchiHist>>> GetByNetId(long netId)
		{
			try
			{
				List<MntNetCchiHist> result = (from x in _repositoryUnitOfWork.MntNetCchiHist.Value.Find((MntNetCchiHist x) => x.MntNetCchiId == (long?)netId)
											   select new MntNetCchiHist
											   {
												   Id = x.Id,
												   CreationDate = x.CreationDate,
												   CreationUser = x.CreationUser,
												   ErrorCode = x.ErrorCode,
												   Status = x.Status,
												   StatusDate = x.StatusDate,
												   ErrorDesc = x.ErrorDesc,
												   TransactionType = x.TransactionType,
												   MntNetCchi = x.MntNetCchi,
												   MntNetCchiId = x.MntNetCchiId
											   }).ToList();
				return new ResponseResult<List<MntNetCchiHist>>
				{
					Status = ResultStatus.Success,
					Data = result,
					TotalRecords = result.Count
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<List<MntNetCchiHist>>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}
		}

		public IResponseResult<MntNetCchiHist> Remove(MntNetCchiHist entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntNetCchiHist>> RemoveRange(IEnumerable<MntNetCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntNetCchiHist>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntNetCchiHist> Update(MntNetCchiHist entity)
		{
			try
			{
				MntNetCchiHist result = _repositoryUnitOfWork.MntNetCchiHist.Value.Update(entity);
				if (result == null)
				{
					return new ResponseResult<MntNetCchiHist>
					{
						Errors = new List<string> { "Error In Adding Entity(MntPrvNetCchiHist)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MntNetCchiHist>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MntNetCchiHist>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}
		}

		public IResponseResult<IEnumerable<MntNetCchiHist>> UpdateRange(IEnumerable<MntNetCchiHist> models)
		{
			throw new NotImplementedException();
		}
	}
}
