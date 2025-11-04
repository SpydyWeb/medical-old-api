using System;
using Service.Interfaces;

namespace Service.UnitOfWork
{
	public interface IWSCoreUniteOfWork : IDisposable
	{
		Lazy<IWSCoreService> WSCoreService { get; }
	}
}
