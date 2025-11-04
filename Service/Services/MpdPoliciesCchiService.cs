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
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Service.Interfaces;
using Service.UnitOfWork;

namespace Service.Services
{
	public class MpdPoliciesCchiService : IMpdPoliciesCchiService, IService<MpdPoliciesCchi>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		private readonly ILogger<MpdPoliciesCchiService> _Logger;

		public MpdPoliciesCchiService(IRepositoryUnitOfWork repositoryUnitOfWork, ILogger<MpdPoliciesCchiService> Logger, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_Logger = Logger;
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		public IResponseResult<MpdPoliciesCchi> Add(MpdPoliciesCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> AddRange(IEnumerable<MpdPoliciesCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdPoliciesCchi> Get(long Id)
		{
			MpdPoliciesCchi result = _repositoryUnitOfWork.MpdPoliciesCchi.Value.Get(Id);
			return new ResponseResult<MpdPoliciesCchi>
			{
				Status = ResultStatus.Success,
				Data = result
			};
		}

		public IResponseResult<MpdPoliciesCchi> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> GetAll()
		{
			List<MpdPoliciesCchi> result = _repositoryUnitOfWork.MpdPoliciesCchi.Value.GetAll().ToList();
			return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
			{
				Status = ResultStatus.Success,
				Data = result
			};
		}

		public IResponseResult<MpdPoliciesCchi> Remove(MpdPoliciesCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> RemoveRange(IEnumerable<MpdPoliciesCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdPoliciesCchi> Update(MpdPoliciesCchi entity)
		{
			try
			{
				MpdPoliciesCchi result = _repositoryUnitOfWork.MpdPoliciesCchi.Value.Update(entity);
				if (result == null)
				{
					_Logger.LogInformation("update mpd_policies_cchi the result is null");
					return new ResponseResult<MpdPoliciesCchi>
					{
						Errors = new List<string> { "Error In Update Entity(MntPrvNetCchi)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MpdPoliciesCchi>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				_Logger.LogInformation("update mpd_policies_cchi catch ex=" + e.Message);
				return new ResponseResult<MpdPoliciesCchi>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}
		}

		public IResponseResult<MpdPoliciesCchi> ReUpload(MpdPoliciesCchi entity)
		{
			try
			{
				MpdPoliciesCchi MpdPoliciesCchiList = _repositoryUnitOfWork.MpdPoliciesCchi.Value.Find((MpdPoliciesCchi x) => x.Id == entity.Id).FirstOrDefault();
				List<MpdMembersCchi> MpdMemberCchiList = (from y in _repositoryUnitOfWork.MpdMembersCchi.Value.Find((MpdMembersCchi x) => x.MpdPlcCchiId == (long?)entity.Id)
					where y.Status == CchiPolicyStatus.Failed
					select y).ToList();
				MpdPoliciesCchiList.Status = null;
				MpdPoliciesCchiList.TransactionType = "Reupload";
				MpdPoliciesCchi result = _repositoryUnitOfWork.MpdPoliciesCchi.Value.Update(MpdPoliciesCchiList);
				if (MpdMemberCchiList != null && MpdMemberCchiList.Count() > 0)
				{
					MpdMemberCchiList.ForEach(delegate(MpdMembersCchi y)
					{
						y.IsUploaded = 0;
					});
					MpdMemberCchiList.ForEach(delegate(MpdMembersCchi y)
					{
						y.Status = null;
					});
					MpdMemberCchiList.ForEach(delegate(MpdMembersCchi y)
					{
						y.StatusDesc = null;
					});
					IEnumerable<MpdMembersCchi> UpdateMember = _repositoryUnitOfWork.MpdMembersCchi.Value.UpdateRange(MpdMemberCchiList);
				}
				MpdPoliciesCchiHist MpdPoliciesCchiHis = new MpdPoliciesCchiHist
				{
					MpdPlcCchiId = MpdPoliciesCchiList.Id,
					CreationUser = MpdPoliciesCchiList.CreationUser,
					CreationDate = MpdPoliciesCchiList.CreationDate,
					TransactionType = "Reupload",
					StatusDate = DateTime.Now,
					Notes = "Reupload"
				};
				_repositoryUnitOfWork.MpdPoliciesCchiHist.Value.Add(MpdPoliciesCchiHis);
				return new ResponseResult<MpdPoliciesCchi>
				{
					Status = ResultStatus.Success,
					Data = result
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<MpdPoliciesCchi>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> UpdateRange(IEnumerable<MpdPoliciesCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> GetByCriteria(MpdPoliciesSearchCriteria searchCriteria)
		{
			try
			{
				IResponseResult<IEnumerable<MpdPoliciesCchi>> searchResult = _repositoryUnitOfWork.MpdPoliciesCchi.Value.GetByCriteria(searchCriteria);
				if (searchResult.Status == ResultStatus.Failed)
				{
					return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
					{
						Status = ResultStatus.Failed,
						Data = null,
						Errors = searchResult.Errors
					};
				}
				List<MpdPoliciesCchi> models = ((searchResult.Data.Count() > 0) ? searchResult.Data.ToList() : new List<MpdPoliciesCchi>());
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Status = ResultStatus.Success,
					Data = models,
					TotalRecords = searchResult.TotalRecords
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public async Task<IResponseResult<IEnumerable<MpdPoliciesCchi>>> GetPolicySuggest(MpdPoliciesSearchCriteria searchCriteria)
		{
			try
			{
				long totalRecords = 0L;
				searchCriteria.Query = ((!string.IsNullOrEmpty(searchCriteria.Query)) ? searchCriteria.Query.ToUpper() : string.Empty);
				List<MpdPoliciesCchi> result = _repositoryUnitOfWork.MpdPoliciesCchi.Value.Find((MpdPoliciesCchi x) => (string.IsNullOrEmpty(searchCriteria.Query) || x.SegmentCode.ToUpper().Contains(searchCriteria.Query)) && (x.DocumentType == searchCriteria.DocumentType || searchCriteria.DocumentType == null) && (x.MpdPlcIdOrigin == (long?)searchCriteria.MasterDocumentId || searchCriteria.MasterDocumentId == null)).ApplyQueryablePaging(searchCriteria.PageIndex, searchCriteria.PageSize, ref totalRecords).ToList();
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Status = ResultStatus.Success,
					Data = result,
					Errors = null,
					TotalRecords = totalRecords
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> GetPolicyData(MpdPoliciesSearchCriteria searchCriteria)
		{
			try
			{
				long totalRecords = 0L;
				List<MpdPoliciesCchi> model = _repositoryUnitOfWork.MpdPoliciesCchi.Value.Find((MpdPoliciesCchi x) => ((long?)x.Id == (long?)searchCriteria.PolicyNo || searchCriteria.PolicyNo == null) && (x.MpdPlcId == (long?)searchCriteria.MpdPlcId || searchCriteria.MpdPlcId == null) && (x.DocumentType == searchCriteria.DocumentType || searchCriteria.DocumentType == null)).ToList();
				IEnumerable<MpdPoliciesCchi> result = model.Select((MpdPoliciesCchi e) => e);
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Status = ResultStatus.Success,
					Data = result,
					Errors = null,
					TotalRecords = totalRecords
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public IResponseResult<string> ChangePlcPriority(long PolicyId, long Priority, string CreationUser)
		{
			try
			{
				IResponseResult<string> result = _repositoryUnitOfWork.MpdPoliciesCchi.Value.ChangePlcPriority(PolicyId, Priority, CreationUser);
				if (result.Status == ResultStatus.Success)
				{
					return new ResponseResult<string>
					{
						Status = ResultStatus.Success,
						Data = string.Empty
					};
				}
				return new ResponseResult<string>
				{
					Status = ResultStatus.Failed,
					Data = string.Empty,
					Errors = result.Errors
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<string>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = string.Empty
				};
			}
		}

		public IResponseResult<IEnumerable<MpdPoliciesCchi>> LoadPolicies()
		{
			try
			{
				List<MpdPoliciesCchi> MpdPoliciesCchi = _repositoryUnitOfWork.MpdPoliciesCchi.Value.LoadPolicies();
				if (MpdPoliciesCchi.Count > 0)
				{
					foreach (MpdPoliciesCchi item in MpdPoliciesCchi)
					{
					}
					return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
					{
						Status = ResultStatus.Success,
						Data = MpdPoliciesCchi
					};
				}
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Status = ResultStatus.SuccessWithWarning,
					Data = MpdPoliciesCchi,
					Errors = new List<string> { "No Data Found " }
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<IEnumerable<MpdPoliciesCchi>>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}
	}
}
