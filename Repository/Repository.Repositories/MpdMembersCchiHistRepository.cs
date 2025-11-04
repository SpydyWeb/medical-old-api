using Domain.Context;
using Domain.Models;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MpdMembersCchiHistRepository : Repository<MpdMembersCchiHist>, IMpdMembersCchiHistRepository, IRepository<MpdMembersCchiHist>
	{
		private CchiDbContext _context;

		public MpdMembersCchiHistRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}
	}
}
