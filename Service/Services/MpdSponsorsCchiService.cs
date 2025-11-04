using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;
using Repository.Interfaces;
using Service.Interfaces;
using Service.UnitOfWork;

namespace Service.Services
{
	public class MpdSponsorsCchiService : IMpdSponsorsCchiService, IService<MpdSponsorsCchi>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MpdSponsorsCchiService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		public IResponseResult<MpdSponsorsCchi> Add(MpdSponsorsCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdSponsorsCchi>> AddRange(IEnumerable<MpdSponsorsCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdSponsorsCchi> Get(long Id)
		{
			MpdSponsorsCchi result = _repositoryUnitOfWork.MpdSponsorsCchi.Value.Get(Id);
			return new ResponseResult<MpdSponsorsCchi>
			{
				Status = ResultStatus.Success,
				Data = result
			};
		}

		public IResponseResult<MpdSponsorsCchi> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdSponsorsCchi>> GetAll()
		{
			List<MpdSponsorsCchi> result = _repositoryUnitOfWork.MpdSponsorsCchi.Value.GetAll().ToList();
			return new ResponseResult<IEnumerable<MpdSponsorsCchi>>
			{
				Status = ResultStatus.Success,
				Data = result
			};
		}

		public IResponseResult<MpdSponsorsCchi> Remove(MpdSponsorsCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdSponsorsCchi>> RemoveRange(IEnumerable<MpdSponsorsCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdSponsorsCchi>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdSponsorsCchi> Update(MpdSponsorsCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdSponsorsCchi>> UpdateRange(IEnumerable<MpdSponsorsCchi> models)
		{
			throw new NotImplementedException();
		}

		public async Task<IResponseResult<IEnumerable<MpdSponsorsCchi>>> GetByCriteria(MpdSponsorsCchiSearchCriteria search)
		{
			try
			{
				List<MpdSponsorsCchi> result = (from y in _repositoryUnitOfWork.MpdSponsorsCchi.Value.Find((MpdSponsorsCchi x) => x.MpdPlcCchiId == (long?)search.PolicyNo).ToList()
					select (y)).ToList();
				return new ResponseResult<IEnumerable<MpdSponsorsCchi>>
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
				ResponseResult<IEnumerable<MpdSponsorsCchi>> responseResult = new ResponseResult<IEnumerable<MpdSponsorsCchi>>();
				responseResult.Status = ResultStatus.Failed;
				responseResult.Data = null;
				responseResult.TotalRecords = 0L;
				responseResult.Errors = new List<string> { "Exception Message : " + ex.Message + Environment.NewLine + " Exception InnerException " + ex.InnerException };
				return responseResult;
			}
		}
	}
}
