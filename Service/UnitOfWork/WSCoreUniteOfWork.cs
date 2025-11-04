using System;
using CORE.Interfaces;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using Service.Services;

namespace Service.UnitOfWork
{
	public class WSCoreUniteOfWork : IWSCoreUniteOfWork, IDisposable
	{
		private readonly IEwsService _MailService;

		private readonly ILogger<WSCoreImplementations> _Logger;

		private readonly IBusiness _Business;

		private readonly IUserManagment _User;

		public Lazy<IWSCoreService> WSCoreService { get; set; }

		public WSCoreUniteOfWork(ILogger<WSCoreImplementations> _logger, IEwsService mailService, IBusiness business, IUserManagment Users)
		{
			_MailService = mailService;
			_Logger = _logger;
			_Business = business;
			_User = Users;
			WSCoreService = new Lazy<IWSCoreService>(() => new WSCoreImplementations(_logger, mailService, business, Users));
		}

		public void Dispose()
		{
			WSCoreService = null;
		}
	}
}
