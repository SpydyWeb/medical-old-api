using System;
using Service.Interfaces;

namespace Service.UnitOfWork
{
	public interface ITPServiceUnitOfWork : IDisposable
	{
		Lazy<ITPIntegrationService> TPIntegrationService { get; }
	}
}
