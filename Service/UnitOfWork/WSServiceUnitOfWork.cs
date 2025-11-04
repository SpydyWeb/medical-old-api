using System;
using Domain.Context;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Services;

namespace Service.UnitOfWork
{
	public class WSServiceUnitOfWork : IWSServiceUnitOfWork, IDisposable
	{
		private readonly ILogger<WSIntegrationService> _Logger;

		private readonly IEwsService _IMailService;

		private IRepositoryUnitOfWork _repositoryUnitOfWork;

		public Lazy<IWSIntegrationService> WSIntegrationService { get; set; }

		public WSServiceUnitOfWork(CchiDbContext context, ILogger<WSIntegrationService> logger, IEwsService IMailService, IServiceUnitOfWork serviceUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork)
		{
			WSServiceUnitOfWork wSServiceUnitOfWork = this;
			_repositoryUnitOfWork = new RepositoryUnitOfWork(context);
			_Logger = logger;
			_IMailService = IMailService;
			WSIntegrationService = new Lazy<IWSIntegrationService>(() => new WSIntegrationService(serviceUnitOfWork, wSServiceUnitOfWork._repositoryUnitOfWork, tPServiceUnitOfWork, wSServiceUnitOfWork._Logger, wSServiceUnitOfWork._IMailService));
		}

		public void Dispose()
		{
			WSIntegrationService = null;
		}
	}
}
