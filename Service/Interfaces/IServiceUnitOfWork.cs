using System;
using Service.UnitOfWork;

namespace Service.Interfaces
{
	public interface IServiceUnitOfWork : IDisposable
	{
		ITPServiceUnitOfWork _tPServiceUnitOfWork { get; set; }

		Lazy<IMntNetCchiService> MntNetCchiService { get; set; }

		Lazy<IMntPrvNetCchiService> MntPrvNetCchiService { get; set; }

		Lazy<IMntPrevNetCchiHistService> MntPrevNetCchiHistService { get; set; }

		Lazy<IMntNetCchiHistService> MntNetCchiHistService { get; set; }

		Lazy<IMpdPoliciesCchiService> MpdPoliciesCchiService { get; set; }

		Lazy<IMpdMembersCchiService> MpdMembersCchiService { get; set; }

		Lazy<IMpdSponsorsCchiService> MpdSponsorsCchiService { get; set; }

		Lazy<IMpdClassesCchiService> MpdClassesCchiService { get; set; }

		Lazy<IMpdPoliciesCchiHistService> MpdPoliciesCchiHistService { get; set; }

		Lazy<IMpdMembersCchiHistService> MpdMembersCchiHistService { get; set; }

		Lazy<IMpdBenefitsCchiService> MpdBenefitsCchiService { get; set; }
	}
}
