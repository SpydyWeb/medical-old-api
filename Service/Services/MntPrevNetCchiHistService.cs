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
	public class MntPrevNetCchiHistService : IMntPrevNetCchiHistService, IService<MntPrvNetCchiHist>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MntPrevNetCchiHistService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}


		public IResponseResult<MntPrvNetCchiHist> Add(MntPrvNetCchiHist entity)
		{
			try
			{
				MntPrvNetCchiHist result = _repositoryUnitOfWork.MntPrevNetCchiHist.Value.Add(entity);
				if (result == null)
				{
					return new ResponseResult<MntPrvNetCchiHist>
					{
						Errors = new List<string> { "Error In Adding Entity(MntPrvNetCchiHist)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MntPrvNetCchiHist>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MntPrvNetCchiHist>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}			
		}

		public IResponseResult<IEnumerable<MntPrvNetCchiHist>> AddRange(IEnumerable<MntPrvNetCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntPrvNetCchiHist> Get(long Id)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntPrvNetCchiHist> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntPrvNetCchiHist>> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<IResponseResult<List<MntPrvNetCchiHist>>> GetByNetId(long netId)
		{
			try
			{
				List<MntPrvNetCchiHist> result = (from x in _repositoryUnitOfWork.MntPrevNetCchiHist.Value.Find((MntPrvNetCchiHist x) => x.MntPrvNetCchiId == (long?)netId)
												  select new MntPrvNetCchiHist
												  {
													  Id = x.Id,
													  CreationDate = x.CreationDate,
													  CreationUser = x.CreationUser,
													  ErrorCode = x.ErrorCode,
													  Status = x.Status,
													  ErrorDesc = x.ErrorDesc,
													  StatusDate = x.StatusDate,
													  MntPrvNetCchi = x.MntPrvNetCchi,
													  MntPrvNetCchiId = x.MntPrvNetCchiId,
													  TransactionType = x.TransactionType
												  }).ToList();
				return new ResponseResult<List<MntPrvNetCchiHist>>
				{
					Status = ResultStatus.Success,
					Data = result,
					TotalRecords = result.Count
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<List<MntPrvNetCchiHist>>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}			
		}

		public IResponseResult<MntPrvNetCchiHist> Remove(MntPrvNetCchiHist entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntPrvNetCchiHist>> RemoveRange(IEnumerable<MntPrvNetCchiHist> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntPrvNetCchiHist>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntPrvNetCchiHist> Update(MntPrvNetCchiHist entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntPrvNetCchiHist>> UpdateRange(IEnumerable<MntPrvNetCchiHist> models)
		{
			throw new NotImplementedException();
		}
	}
}
