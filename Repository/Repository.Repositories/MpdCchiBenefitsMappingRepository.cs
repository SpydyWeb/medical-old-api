using Domain.Context;
using Domain.Models;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MpdCchiBenefitsMappingRepository : Repository<MpdCchiBenefitsMapping>, IMpdCchiBenefitsMappingRepository, IRepository<MpdCchiBenefitsMapping>
	{
		private CchiDbContext _context;

		public MpdCchiBenefitsMappingRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}
	}
}
