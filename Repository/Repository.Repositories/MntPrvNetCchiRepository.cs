using Domain.Context;
using Domain.Models;
using Repository.Common;
using Repository.Interfaces;

namespace Repository.Repositories
{
	public class MntPrvNetCchiRepository : Repository<MntPrvNetCchi>, IMntPrvNetCchiRepository, IRepository<MntPrvNetCchi>
	{
		private CchiDbContext _context;

		public MntPrvNetCchiRepository(CchiDbContext context)
			: base(context)
		{
			_context = context;
		}
	}
}
