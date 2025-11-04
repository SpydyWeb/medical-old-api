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
	public class MpdMembersCchiService : IMpdMembersCchiService, IService<MpdMembersCchi>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MpdMembersCchiService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		public IResponseResult<MpdMembersCchi> Add(MpdMembersCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdMembersCchi>> AddRange(IEnumerable<MpdMembersCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdMembersCchi> Get(long Id)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdMembersCchi> Get(long Id, int companyId)
		{
			MpdMembersCchi result = _repositoryUnitOfWork.MpdMembersCchi.Value.Get(Id);
			return new ResponseResult<MpdMembersCchi>
			{
				Status = ResultStatus.Success,
				Data = result
			};
		}

		public IResponseResult<IEnumerable<MpdMembersCchi>> GetAll()
		{
			List<MpdMembersCchi> result = _repositoryUnitOfWork.MpdMembersCchi.Value.GetAll().ToList();
			return new ResponseResult<IEnumerable<MpdMembersCchi>>
			{
				Status = ResultStatus.Success,
				Data = result
			};
		}

		public IResponseResult<MpdMembersCchi> Remove(MpdMembersCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdMembersCchi>> RemoveRange(IEnumerable<MpdMembersCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MpdMembersCchi>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MpdMembersCchi> Update(MpdMembersCchi entity)
		{
			try
			{
				MpdMembersCchi result = _repositoryUnitOfWork.MpdMembersCchi.Value.Update(entity);
				return new ResponseResult<MpdMembersCchi>
				{
					Status = ResultStatus.Success,
					Data = result
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<MpdMembersCchi>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public IResponseResult<IEnumerable<MpdMembersCchi>> UpdateRange(IEnumerable<MpdMembersCchi> models)
		{
			throw new NotImplementedException();
		}

		public async Task<IResponseResult<IEnumerable<MpdMembersCchi>>> GetByCriteria(MpdMembersCchiSearchCriteria search)
		{
			try
			{
				List<SelectItem> RelationList = await _tPServiceUnitOfWork.TPIntegrationService.Value.GetDomainValues(7, 422, search.CompanyId);
				List<SelectItem> MaritalStatusList = await _tPServiceUnitOfWork.TPIntegrationService.Value.GetDomainValues(6, 422, search.CompanyId);
				await _tPServiceUnitOfWork.TPIntegrationService.Value.GetDomainValues(2, 422, search.CompanyId);
				List<MpdPoliciesCchi> PolicyList = _repositoryUnitOfWork.MpdPoliciesCchi.Value.Find((MpdPoliciesCchi p) => (long?)p.Id == (long?)search.PolicyNo).ToList();
				List<MpdMembersCchi> result = _repositoryUnitOfWork.MpdMembersCchi.Value.Find((MpdMembersCchi x) => (!search.PolicyNo.HasValue || x.MpdPlcCchiId == (long?)search.PolicyNo) && (string.IsNullOrEmpty(search.Name) || x.Name == search.Name) && (string.IsNullOrEmpty(search.ReferenceNo) || x.StaffNo == search.ReferenceNo) && (!search.Gender.HasValue || (int?)x.Gender == search.Gender) && (!search.MpdOldPolicyId.HasValue || x.MpdPlcId == (long?)search.MpdOldPolicyId) && (!search.MaritalStatus.HasValue || x.MaritalStatus == search.MaritalStatus) && (!search.Relation.HasValue || (int?)x.Relation == search.Relation) && (!search.BirthDate.HasValue || x.BirthDate.Value.Date == search.BirthDate.Value.Date) && (!search.MemberNo.HasValue || x.MemberNo == (long?)search.MemberNo) && (string.IsNullOrEmpty(search.SegmentCode) || x.SegmentCode == search.SegmentCode) && (string.IsNullOrEmpty(search.NationalId) || x.NationalId == search.NationalId) && (!search.AgeFrom.HasValue || (int?)x.Age >= (int?)search.AgeFrom) && (!search.AgeTo.HasValue || (int?)x.Age <= (int?)search.AgeTo) && (string.IsNullOrEmpty(search.CchiStatus) || x.StatusDesc == search.CchiStatus) && (!search.PrincipleId.HasValue || x.MpdMbrIdRelation == (long?)search.PrincipleId) && (!search.ClassCchiId.HasValue || x.MpdPclId == search.ClassCchiId) && (!search.CustomerId.HasValue || x.FcsCstId == search.CustomerId)).ToList().Select(delegate(MpdMembersCchi y)
				{
					y.RelationName = (RelationList.Any((SelectItem x) => x.value == y.Relation.ToString()) ? RelationList.Find((SelectItem x) => x.value == y.Relation.ToString()).label : null);
					y.MaritalStatusName = (MaritalStatusList.Any((SelectItem x) => x.value == y.MaritalStatus.ToString()) ? MaritalStatusList.Find((SelectItem x) => x.value == y.MaritalStatus.ToString()).label : null);
					y.UploadStatus = ((!PolicyList.Any((MpdPoliciesCchi x) => x.Id == y.MpdPlcCchiId)) ? string.Empty : ((!string.IsNullOrEmpty(PolicyList.Find((MpdPoliciesCchi x) => x.Id == y.MpdPlcCchiId).Status)) ? "Uploaded" : "Not Uploaded"));
					return y;
				})
					.DistinctBy((MpdMembersCchi x) => x.CchiId)
					.ToList();
				return new ResponseResult<IEnumerable<MpdMembersCchi>>
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
				ResponseResult<IEnumerable<MpdMembersCchi>> responseResult = new ResponseResult<IEnumerable<MpdMembersCchi>>();
				responseResult.Status = ResultStatus.Failed;
				responseResult.Data = null;
				responseResult.TotalRecords = 0L;
				responseResult.Errors = new List<string> { "Exception Message : " + ex.Message + Environment.NewLine + " Exception InnerException " + ex.InnerException };
				return responseResult;
			}
		}

		public async Task<IResponseResult<IEnumerable<MpdMembersCchi>>> GetMembersSuggest(MpdMembersCchiSearchCriteria search)
		{
			try
			{
				long totalRecords = 0L;
				search.Query = ((!string.IsNullOrEmpty(search.Query)) ? search.Query.ToUpper() : string.Empty);
				List<MpdMembersCchi> result = _repositoryUnitOfWork.MpdMembersCchi.Value.Find((MpdMembersCchi x) => string.IsNullOrEmpty(search.Query) || x.Name.ToUpper().Contains(search.Query)).ApplyQueryablePaging(search.PageIndex, search.PageSize, ref totalRecords).ToList();
				return new ResponseResult<IEnumerable<MpdMembersCchi>>
				{
					Status = ResultStatus.Success,
					Data = result,
					Errors = null
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<IEnumerable<MpdMembersCchi>>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public IResponseResult<string> OnHoldMembers(long PolicyId, string MemberIds, long Flag, string CreationUser)
		{
			try
			{
				IResponseResult<string> result = _repositoryUnitOfWork.MpdMembersCchi.Value.OnHoldMembers(PolicyId, MemberIds, Flag, CreationUser);
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
	}
}
