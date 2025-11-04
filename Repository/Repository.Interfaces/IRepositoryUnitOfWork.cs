using System;

namespace Repository.Interfaces
{
	public interface IRepositoryUnitOfWork : IDisposable
	{
		Lazy<IMntNetCchiRepository> MntNetCchi { get; set; }

		Lazy<IMntPrvNetCchiRepository> MntPrvNetCchi { get; set; }

		Lazy<IMpdPoliciesCchiRepository> MpdPoliciesCchi { get; set; }

		Lazy<IMpdMembersCchiRepository> MpdMembersCchi { get; set; }

		Lazy<IMntPrevNetCchiHistRepository> MntPrevNetCchiHist { get; set; }

		Lazy<IMntNetCchiHistRepository> MntNetCchiHist { get; set; }

		Lazy<IMpdSponsorsCchiRepository> MpdSponsorsCchi { get; set; }

		Lazy<IMpdClassesCchiRepository> MpdClassesCchi { get; set; }

		Lazy<IMpdPoliciesCchiHistRepository> MpdPoliciesCchiHist { get; set; }

		Lazy<IMpdMembersCchiHistRepository> MpdMembersCchiHist { get; set; }

		Lazy<IMpdBenefitsCchiRepository> MpdBenefitsCchi { get; set; }

		Lazy<IMpdCchiBenefitsMappingRepository> MpdCchiBenefitsMapping { get; set; }
	}
}
