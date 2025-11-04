using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;
using Domain.Extension;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;
using Repository.Interfaces;
using Service.Interfaces;
using Service.UnitOfWork;

namespace Service.Services
{
	public class MpdClassesCchiService : IMpdClassesCchiService, IService<MpdClassesCchi>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MpdClassesCchiService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		public IResponseResult<MpdClassesCchi> Add(MpdClassesCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdClassesCchi>> AddRange(IEnumerable<MpdClassesCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdClassesCchi> Get(long Id)
		{
			MpdClassesCchi result = _repositoryUnitOfWork.MpdClassesCchi.Value.Get(Id);
			return new ResponseResult<MpdClassesCchi>
			{
				Status = ResultStatus.Success,
				Data = result
			};
		}

		public IResponseResult<MpdClassesCchi> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdClassesCchi>> GetAll()
		{
			List<MpdClassesCchi> result = _repositoryUnitOfWork.MpdClassesCchi.Value.GetAll().ToList();
			return new ResponseResult<IEnumerable<MpdClassesCchi>>
			{
				Status = ResultStatus.Success,
				Data = result
			};
		}

		public IResponseResult<MpdClassesCchi> Remove(MpdClassesCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdClassesCchi>> RemoveRange(IEnumerable<MpdClassesCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdClassesCchi>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdClassesCchi> Update(MpdClassesCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdClassesCchi>> UpdateRange(IEnumerable<MpdClassesCchi> models)
		{
			throw new NotImplementedException();
		}

		public async Task<IResponseResult<IEnumerable<MpdClassesCchi>>> GetClassesSuggest(MpdClassesCchiSearchCriteria search)
		{
			try
			{
				long totalRecords = 0L;
				search.Query = ((!string.IsNullOrEmpty(search.Query)) ? search.Query.ToUpper() : string.Empty);
				List<MpdClassesCchi> result = _repositoryUnitOfWork.MpdClassesCchi.Value.Find((MpdClassesCchi x) => string.IsNullOrEmpty(search.Query) || x.Name.ToUpper().Contains(search.Query)).ApplyQueryablePaging(search.PageIndex, search.PageSize, ref totalRecords).ToList();
				return new ResponseResult<IEnumerable<MpdClassesCchi>>
				{
					Status = ResultStatus.Success,
					Data = result,
					Errors = null,
					TotalRecords = result.Count
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<IEnumerable<MpdClassesCchi>>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public async Task<IResponseResult<IEnumerable<MpdClassesCchi>>> GetByCriteria(MpdClassesCchiSearchCriteria search)
		{
			try
			{
				List<MpdClassesCchi> result = _repositoryUnitOfWork.MpdClassesCchi.Value.Find((MpdClassesCchi x) => x.MpdPlcCchiId == (long?)search.PolicyNo).ToList().Select(delegate(MpdClassesCchi y)
				{
					y.MedicalCCHICompanyId = SharedSettings.MedicalCCHICompanyId;
					return y;
				})
					.ToList();
				return new ResponseResult<IEnumerable<MpdClassesCchi>>
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
				ResponseResult<IEnumerable<MpdClassesCchi>> responseResult = new ResponseResult<IEnumerable<MpdClassesCchi>>();
				responseResult.Status = ResultStatus.Failed;
				responseResult.Data = null;
				responseResult.TotalRecords = 0L;
				responseResult.Errors = new List<string> { "Exception Message : " + ex.Message + Environment.NewLine + " Exception InnerException " + ex.InnerException };
				return responseResult;
			}
		}
	}
}
