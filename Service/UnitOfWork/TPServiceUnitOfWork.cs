using System;
using System.Net.Http;
using Service.Interfaces;
using Service.Services;

namespace Service.UnitOfWork
{
	public class TPServiceUnitOfWork : ITPServiceUnitOfWork, IDisposable
	{
		private HttpClient _client;

		public Lazy<ITPIntegrationService> TPIntegrationService { get; set; }

		public TPServiceUnitOfWork(HttpClient client)
		{
			_client = client;
			TPIntegrationService = new Lazy<ITPIntegrationService>(() => new TPIntegrationService(_client));
		}

		public void Dispose()
		{
			_client.Dispose();
			TPIntegrationService = null;
		}
	}
}
