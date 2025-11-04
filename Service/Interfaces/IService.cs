using System.Collections.Generic;
using Domain.Interfaces.Shared;

namespace Service.Interfaces
{
	public interface IService<Model>
	{
		IResponseResult<Model> Add(Model entity);

		IResponseResult<Model> Get(long Id);

		IResponseResult<Model> Get(long Id, int companyId);

		IResponseResult<IEnumerable<Model>> AddRange(IEnumerable<Model> models);

		IResponseResult<IEnumerable<Model>> GetAll();

		IResponseResult<Model> Remove(Model entity);

		IResponseResult<Model> Update(Model entity);

		IResponseResult<IEnumerable<Model>> RemoveRange(IEnumerable<Model> models);

		IResponseResult<IEnumerable<Model>> RemoveRangeByIDs(IEnumerable<long> IDs);

		IResponseResult<IEnumerable<Model>> UpdateRange(IEnumerable<Model> models);
	}
}
