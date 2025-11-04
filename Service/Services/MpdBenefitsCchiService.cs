using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Domain.Models;
using Repository.Interfaces;
using Service.Interfaces;
using Service.UnitOfWork;

namespace Service.Services
{
	public class MpdBenefitsCchiService : IMpdBenefitsCchiService, IService<MpdBenefitsCchi>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MpdBenefitsCchiService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		public IResponseResult<MpdBenefitsCchi> Add(MpdBenefitsCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdBenefitsCchi>> AddRange(IEnumerable<MpdBenefitsCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdBenefitsCchi> Get(long Id)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdBenefitsCchi> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdBenefitsCchi>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdBenefitsCchi> Remove(MpdBenefitsCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdBenefitsCchi>> RemoveRange(IEnumerable<MpdBenefitsCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdBenefitsCchi>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdBenefitsCchi> Update(MpdBenefitsCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdBenefitsCchi>> UpdateRange(IEnumerable<MpdBenefitsCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<List<MpdBenefitsCchi>> GetBenefitsList(int classID)
		{
			try
			{
				Expression<Func<MpdBenefitsCchi, object>> Benefits = (MpdBenefitsCchi i) => i.CchiBenefit;
				Expression<Func<MpdBenefitsCchi, object>>[] exp = new Expression<Func<MpdBenefitsCchi, object>>[1] { Benefits };
				List<MpdBenefitsCchi> model = _repositoryUnitOfWork.MpdBenefitsCchi.Value.Find((MpdBenefitsCchi x) => x.MpdPclCchiId == (long?)(long)classID, exp).ToList();
				List<MpdBenefitsCchi> result = model.Select(delegate(MpdBenefitsCchi x)
				{
					x.CchiBenefitName = x.CchiBenefit.CchiBenefitName;
					x.RecodeLevel = x.CchiBenefit.RecordLevel;
					x.CchiBenefit = null;
					return x;
				}).ToList();
				return new ResponseResult<List<MpdBenefitsCchi>>
				{
					Status = ResultStatus.Success,
					Data = result,
					TotalRecords = result.Count
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<List<MpdBenefitsCchi>>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}
		}
	}
}
