using Domain.Context;
using Domain.Models;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MpdBenefitsCchiRepository : Repository<MpdBenefitsCchi>, IMpdBenefitsCchiRepository, IRepository<MpdBenefitsCchi>
	{
		private CchiDbContext _context;

		public MpdBenefitsCchiRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}
	}
}
