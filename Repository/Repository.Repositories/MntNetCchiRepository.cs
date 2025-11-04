using Domain.Context;
using Domain.Models;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MntNetCchiRepository : Repository<MntNetCchi>, IMntNetCchiRepository, IRepository<MntNetCchi>
	{
		private CchiDbContext _context;

		public MntNetCchiRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}
	}
}
