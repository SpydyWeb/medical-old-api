using Domain.Context;
using Domain.Models;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MntNetCchiHistRepository : Repository<MntNetCchiHist>, IMntNetCchiHistRepository, IRepository<MntNetCchiHist>
	{
		private CchiDbContext _context;

		public MntNetCchiHistRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}
	}
}
