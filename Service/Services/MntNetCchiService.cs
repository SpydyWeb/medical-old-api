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
	public class MntNetCchiService : IMntNetCchiService, IService<MntNetCchi>
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		private ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MntNetCchiService(IRepositoryUnitOfWork repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			_repositoryUnitOfWork = repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
		}

		

		public IResponseResult<MntNetCchi> Add(MntNetCchi entity)
		{
			try
			{
				MntNetCchi result = _repositoryUnitOfWork.MntNetCchi.Value.Add(entity);
				if (result == null)
				{
					return new ResponseResult<MntNetCchi>
					{
						Errors = new List<string> { "Error In Adding Entity(MntNetCchi)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MntNetCchi>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MntNetCchi>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}			
		}

		public IResponseResult<IEnumerable<MntNetCchi>> AddRange(IEnumerable<MntNetCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntNetCchi> Get(long Id)
		{
			try
			{
				MntNetCchi result = _repositoryUnitOfWork.MntNetCchi.Value.Get(Id);
				return new ResponseResult<MntNetCchi>
				{
					Status = ResultStatus.Success,
					Data = result
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<MntNetCchi>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}
		}

		public IResponseResult<MntNetCchi> Get(long Id, int companyId)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntNetCchi>> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<ResponseResult<MntNetCchi>> GetByNetId(long netId)
		{
			try
			{
				MntNetCchi result = (from x in _repositoryUnitOfWork.MntNetCchi.Value.Find((MntNetCchi x) => x.MntNetId == netId)
									 select new MntNetCchi
									 {
										 Id = x.Id,
										 CreationDate = x.CreationDate,
										 CreationUser = x.CreationUser,
										 ErrorCode = x.ErrorCode,
										 Status = x.Status,
										 ReferenceNo = x.ReferenceNo,
										 ErrorDesc = x.ErrorDesc,
										 MntNetCchiHists = x.MntNetCchiHists,
										 MntNetId = x.MntNetId,
										 MntPrvNetCchis = x.MntPrvNetCchis,
										 ModificationDate = x.ModificationDate,
										 Name = x.Name,
										 StatusDate = x.StatusDate,
										 ModificationUser = x.ModificationUser
									 }).FirstOrDefault();
				return new ResponseResult<MntNetCchi>
				{
					Status = ResultStatus.Success,
					Data = result,
					TotalRecords = ((result != null) ? 1 : 0)
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<MntNetCchi>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}
		}

		public async Task<ResponseResult<MntNetCchi>> GetDataByNetId(long netId)
		{
			try
			{
				MntNetCchi result = (from x in _repositoryUnitOfWork.MntNetCchi.Value.Find((MntNetCchi x) => x.MntNetId == netId)
									 select new MntNetCchi
									 {
										 Id = x.Id,
										 CreationDate = x.CreationDate,
										 CreationUser = x.CreationUser,
										 ErrorCode = x.ErrorCode,
										 Status = x.Status,
										 ReferenceNo = x.ReferenceNo,
										 ErrorDesc = x.ErrorDesc,
										 MntNetId = x.MntNetId,
										 ModificationDate = x.ModificationDate,
										 Name = x.Name,
										 StatusDate = x.StatusDate,
										 ModificationUser = x.ModificationUser
									 }).FirstOrDefault();
				return new ResponseResult<MntNetCchi>
				{
					Status = ResultStatus.Success,
					Data = result,
					TotalRecords = ((result != null) ? 1 : 0)
				};
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				return new ResponseResult<MntNetCchi>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message + "\r\n Exception InnerException " + ex.InnerException }
				};
			}
		}

		public async Task<ResponseResult<string>> getReferenceNumber(long netId)
		{
			try
			{
				string result = (from x in _repositoryUnitOfWork.MntNetCchi.Value.Find((MntNetCchi x) => x.MntNetId == netId)
								 select x.ReferenceNo).SingleOrDefault();
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

		public async Task<ResponseResult<string>> getStatus(long netId)
		{
			try
			{
				string result = (from x in _repositoryUnitOfWork.MntNetCchi.Value.Find((MntNetCchi x) => x.MntNetId == netId)
								 select x.Status).SingleOrDefault();
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

		public IResponseResult<MntNetCchi> Remove(MntNetCchi entity)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntNetCchi>> RemoveRange(IEnumerable<MntNetCchi> models)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<IEnumerable<MntNetCchi>> RemoveRangeByIDs(IEnumerable<long> IDs)
		{
			throw new NotImplementedException();
		}

		public IResponseResult<MntNetCchi> Update(MntNetCchi entity)
		{
			try
			{
				MntNetCchi result = _repositoryUnitOfWork.MntNetCchi.Value.Update(entity);
				if (result == null)
				{
					return new ResponseResult<MntNetCchi>
					{
						Errors = new List<string> { "Error In Updating Entity(MntNetCchi)" },
						Data = null,
						Status = ResultStatus.Failed,
						TotalRecords = 0L
					};
				}
				return new ResponseResult<MntNetCchi>
				{
					Errors = new List<string>(),
					Data = result,
					Status = ResultStatus.Success,
					TotalRecords = 1L
				};
			}
			catch (Exception e)
			{
				return new ResponseResult<MntNetCchi>
				{
					Errors = new List<string> { e.Message },
					Data = null,
					Status = ResultStatus.Failed,
					TotalRecords = 0L
				};
			}
		}

		public IResponseResult<IEnumerable<MntNetCchi>> UpdateRange(IEnumerable<MntNetCchi> models)
		{
			throw new NotImplementedException();
		}
	}
}
