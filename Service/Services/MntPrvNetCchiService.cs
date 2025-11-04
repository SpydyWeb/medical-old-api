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
	public class MntPrvNetCchiService : IMntPrvNetCchiService, IService<MntPrvNetCchi>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MntPrvNetCchiService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		public IResponseResult<MntPrvNetCchi> Add(MntPrvNetCchi entity)
		{
			try
			{
				MntPrvNetCchi result = _repositoryUnitOfWork.MntPrvNetCchi.Value.Add(entity);
				if (result == null)
				{
					return new ResponseResult<MntPrvNetCchi>
					{
						Errors = new List<string> { "Error In Adding Entity(MntPrvNetCchi)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MntPrvNetCchi>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MntPrvNetCchi>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}
		}

		public IResponseResult<IEnumerable<MntPrvNetCchi>> AddRange(IEnumerable<MntPrvNetCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntPrvNetCchi> Get(long Id)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntPrvNetCchi> Get(long Id, int companyId = 1)
		{
			try
			{
				MntPrvNetCchi result = _repositoryUnitOfWork.MntPrvNetCchi.Value.Get(Id);
				if (result == null)
				{
					return new ResponseResult<MntPrvNetCchi>
					{
						Errors = new List<string> { "Empty data" },
						Data = null,
						Status = ResultStatus.SuccessWithWarning,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MntPrvNetCchi>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MntPrvNetCchi>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}
		}

		public IResponseResult<IEnumerable<MntPrvNetCchi>> GetAll()
		{
			IQueryable<MntPrvNetCchi> AllData = _repositoryUnitOfWork.MntPrvNetCchi.Value.GetAll();
			return new ResponseResult<IEnumerable<MntPrvNetCchi>>
			{
				Errors = new List<string>(),
				Data = AllData,
				Status = ResultStatus.Success,
				TotalRecords = AllData.Count()
			};
		}

		public IResponseResult<MntPrvNetCchi> Remove(MntPrvNetCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntPrvNetCchi>> RemoveRange(IEnumerable<MntPrvNetCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntPrvNetCchi>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntPrvNetCchi> Update(MntPrvNetCchi entity)
		{
			try
			{
				MntPrvNetCchi result = _repositoryUnitOfWork.MntPrvNetCchi.Value.Update(entity);
				if (result == null)
				{
					return new ResponseResult<MntPrvNetCchi>
					{
						Errors = new List<string> { "Error In Update Entity(MntPrvNetCchi)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MntPrvNetCchi>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MntPrvNetCchi>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}
		}

		public IResponseResult<IEnumerable<MntPrvNetCchi>> UpdateRange(IEnumerable<MntPrvNetCchi> models)
		{
			throw new NotImplementedException();
		}

		public async Task<IResponseResult<IEnumerable<MntPrvNetCchi>>> GetPrvByNetId(long Id)
		{
			try
			{
				new List<MntPrvNetCchi>();
				List<MntPrvNetCchi> result = _repositoryUnitOfWork.MntPrvNetCchi.Value.Find((MntPrvNetCchi entity) => entity.MntPrvNetId == Id).ToList();
				return new ResponseResult<IEnumerable<MntPrvNetCchi>>
				{
					Status = ResultStatus.Success,
					Data = result,
					TotalRecords = result.Count
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<IEnumerable<MntPrvNetCchi>>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}
		}

		public async Task<IResponseResult<string>> getStatus(long NetCchiId, long ProvNetId)
		{
			try
			{
				string result = (from x in _repositoryUnitOfWork.MntPrvNetCchi.Value.Find((MntPrvNetCchi entity) => entity.MntNetCchiId == (long?)NetCchiId && entity.MntPrvNetId == ProvNetId)
					select x.Status).FirstOrDefault();
				return new ResponseResult<string>
				{
					Status = ResultStatus.Success,
					Data = result,
					TotalRecords = ((result != null) ? 1 : 0)
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<string>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}
		}

		public IMntOldMIProvidersResponse<MntPrvNetOldMedical> GetNetworksProviders(MntPrvNetSearchCriteria searchCriteria)
		{
			try
			{
				MntOldMIProvidersResponse<MntPrvNetOldMedical> result = _tPServiceUnitOfWork.TPIntegrationService.Value.GetNetworkProviders(searchCriteria).Result;
				if (result != null)
				{
					List<MntPrvNetOldMedical> models = result?.dtNetworkProviders;
					if (models != null)
					{
						foreach (MntPrvNetOldMedical i in models)
						{
							MntPrvNetCchi model = _repositoryUnitOfWork.MntPrvNetCchi.Value.Find((MntPrvNetCchi entity) => entity.MntPrvNetId == i.ID).FirstOrDefault();
							if (model != null)
							{
								i.CCHI_STATUS = model.Status;
								i.CCHI_Prv_ID = model.Id;
							}
						}
					}
					return new MntOldMIProvidersResponse<MntPrvNetOldMedical>
					{
						dtNetworkProviders = models,
						PageCount = result.PageCount
					};
				}
				return new MntOldMIProvidersResponse<MntPrvNetOldMedical>
				{
					dtNetworkProviders = null,
					PageCount = 0L
				};
			}
			catch (Exception ex)
			{
				return new MntOldMIProvidersResponse<MntPrvNetOldMedical>
				{
					dtNetworkProviders = null,
					PageCount = 0L,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}
		}
	}
}
