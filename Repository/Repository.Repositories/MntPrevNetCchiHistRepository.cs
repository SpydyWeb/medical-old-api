using Domain.Context;
using Domain.Models;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MntPrevNetCchiHistRepository : Repository<MntPrvNetCchiHist>, IMntPrevNetCchiHistRepository, IRepository<MntPrvNetCchiHist>
	{
		private CchiDbContext _context;

		public MntPrevNetCchiHistRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}
	}
}
