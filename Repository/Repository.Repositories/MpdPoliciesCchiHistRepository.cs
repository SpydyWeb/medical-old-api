using Domain.Context;
using Domain.Models;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MpdPoliciesCchiHistRepository : Repository<MpdPoliciesCchiHist>, IMpdPoliciesCchiHistRepository, IRepository<MpdPoliciesCchiHist>
	{
		private CchiDbContext _context;

		public MpdPoliciesCchiHistRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}
	}
}
