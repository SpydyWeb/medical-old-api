using System;
using Domain.Context;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Services;

namespace Service.UnitOfWork
{
	public class ServiceUnitOfWork : IServiceUnitOfWork, IDisposable
	{
		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		public ITPServiceUnitOfWork _tPServiceUnitOfWork { get; set; }

		public IEwsService _mailService { get; set; }

		public Lazy<IMntNetCchiService> MntNetCchiService { get; set; }

		public Lazy<IMntPrvNetCchiService> MntPrvNetCchiService { get; set; }

		public Lazy<IMpdPoliciesCchiService> MpdPoliciesCchiService { get; set; }

		public Lazy<IMpdMembersCchiService> MpdMembersCchiService { get; set; }

		public Lazy<IMntPrevNetCchiHistService> MntPrevNetCchiHistService { get; set; }

		public Lazy<IMntNetCchiHistService> MntNetCchiHistService { get; set; }

		public Lazy<IMpdSponsorsCchiService> MpdSponsorsCchiService { get; set; }

		public Lazy<IMpdClassesCchiService> MpdClassesCchiService { get; set; }

		public Lazy<IMpdPoliciesCchiHistService> MpdPoliciesCchiHistService { get; set; }

		public Lazy<IMpdMembersCchiHistService> MpdMembersCchiHistService { get; set; }

		public Lazy<IMpdBenefitsCchiService> MpdBenefitsCchiService { get; set; }

		public ServiceUnitOfWork(CchiDbContext context, ILogger<MpdPoliciesCchiService> logger, ILogger<MpdPoliciesCchiHistService> _logger)
		{
			ServiceUnitOfWork serviceUnitOfWork = this;
			_repositoryUnitOfWork = new RepositoryUnitOfWork(context);
			MntNetCchiService = new Lazy<IMntNetCchiService>(() => new MntNetCchiService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
			MntPrvNetCchiService = new Lazy<IMntPrvNetCchiService>(() => new MntPrvNetCchiService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
			MntPrevNetCchiHistService = new Lazy<IMntPrevNetCchiHistService>(() => new MntPrevNetCchiHistService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
			MntNetCchiHistService = new Lazy<IMntNetCchiHistService>(() => new MntNetCchiHistService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
			MpdPoliciesCchiService = new Lazy<IMpdPoliciesCchiService>(() => new MpdPoliciesCchiService(serviceUnitOfWork._repositoryUnitOfWork, logger, serviceUnitOfWork._tPServiceUnitOfWork));
			MpdMembersCchiService = new Lazy<IMpdMembersCchiService>(() => new MpdMembersCchiService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
			MpdSponsorsCchiService = new Lazy<IMpdSponsorsCchiService>(() => new MpdSponsorsCchiService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
			MpdClassesCchiService = new Lazy<IMpdClassesCchiService>(() => new MpdClassesCchiService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
			MpdPoliciesCchiHistService = new Lazy<IMpdPoliciesCchiHistService>(() => new MpdPoliciesCchiHistService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork, _logger));
			MpdMembersCchiHistService = new Lazy<IMpdMembersCchiHistService>(() => new MpdMembersCchiHistService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
			MpdBenefitsCchiService = new Lazy<IMpdBenefitsCchiService>(() => new MpdBenefitsCchiService(serviceUnitOfWork._repositoryUnitOfWork, serviceUnitOfWork._tPServiceUnitOfWork));
		}

		public void Dispose()
		{
		}
	}
}
