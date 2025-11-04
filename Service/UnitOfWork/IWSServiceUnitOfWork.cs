using System;
using Service.Interfaces;

namespace Service.UnitOfWork
{
	public interface IWSServiceUnitOfWork : IDisposable
	{
		Lazy<IWSIntegrationService> WSIntegrationService { get; }
	}
}
