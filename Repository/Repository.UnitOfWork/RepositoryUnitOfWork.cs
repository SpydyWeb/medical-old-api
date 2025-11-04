using System;
using Domain.Context;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
	public class RepositoryUnitOfWork : IRepositoryUnitOfWork, IDisposable
	{
		private CchiDbContext _context;

		public Lazy<IMntNetCchiRepository> MntNetCchi { get; set; }

		public Lazy<IMntPrvNetCchiRepository> MntPrvNetCchi { get; set; }

		public Lazy<IMpdPoliciesCchiRepository> MpdPoliciesCchi { get; set; }

		public Lazy<IMpdMembersCchiRepository> MpdMembersCchi { get; set; }

		public Lazy<IMntPrevNetCchiHistRepository> MntPrevNetCchiHist { get; set; }

		public Lazy<IMntNetCchiHistRepository> MntNetCchiHist { get; set; }

		public Lazy<IMpdSponsorsCchiRepository> MpdSponsorsCchi { get; set; }

		public Lazy<IMpdClassesCchiRepository> MpdClassesCchi { get; set; }

		public Lazy<IMpdPoliciesCchiHistRepository> MpdPoliciesCchiHist { get; set; }

		public Lazy<IMpdMembersCchiHistRepository> MpdMembersCchiHist { get; set; }

		public Lazy<IMpdBenefitsCchiRepository> MpdBenefitsCchi { get; set; }

		public Lazy<IMpdCchiBenefitsMappingRepository> MpdCchiBenefitsMapping { get; set; }

		public RepositoryUnitOfWork(CchiDbContext context)
		{
			_context = context;
			MntNetCchi = new Lazy<IMntNetCchiRepository>(() => new MntNetCchiRepository(_context));
			MntPrvNetCchi = new Lazy<IMntPrvNetCchiRepository>(() => new MntPrvNetCchiRepository(_context));
			MpdPoliciesCchi = new Lazy<IMpdPoliciesCchiRepository>(() => new MpdPoliciesCchiRepository(_context));
			MpdMembersCchi = new Lazy<IMpdMembersCchiRepository>(() => new MpdMembersCchiRepository(_context));
			MntPrevNetCchiHist = new Lazy<IMntPrevNetCchiHistRepository>(() => new MntPrevNetCchiHistRepository(_context));
			MntNetCchiHist = new Lazy<IMntNetCchiHistRepository>(() => new MntNetCchiHistRepository(_context));
			MpdSponsorsCchi = new Lazy<IMpdSponsorsCchiRepository>(() => new MpdSponsorsCchiRepository(_context));
			MpdClassesCchi = new Lazy<IMpdClassesCchiRepository>(() => new MpdClassesCchiRepository(_context));
			MpdPoliciesCchiHist = new Lazy<IMpdPoliciesCchiHistRepository>(() => new MpdPoliciesCchiHistRepository(_context));
			MpdMembersCchiHist = new Lazy<IMpdMembersCchiHistRepository>(() => new MpdMembersCchiHistRepository(_context));
			MpdBenefitsCchi = new Lazy<IMpdBenefitsCchiRepository>(() => new MpdBenefitsCchiRepository(_context));
			MpdCchiBenefitsMapping = new Lazy<IMpdCchiBenefitsMappingRepository>(() => new MpdCchiBenefitsMappingRepository(_context));
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
