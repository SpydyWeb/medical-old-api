using System;
using System.Threading.Tasks;
using CORE.Services;
using DataAccessLayer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace InfraStructure.Services
{
	public class Svc : ISvc
	{
		public IMemoryCache cache;

		public readonly IUnitOfWork unitOfWork;

		public readonly IConfiguration configuration;

		public Svc(IUnitOfWork _unitOfWork, IMemoryCache _cache = null, IConfiguration _configuration = null)
		{
			unitOfWork = _unitOfWork;
			configuration = _configuration;
			cache = _cache;
		}

		public T Transaction<T>(Func<DataBaseContext, T> transactional)
		{
			Func<DataBaseContext, T> transactional2 = transactional;
			return With.Transaction(unitOfWork, (DataBaseContext context) => transactional2(context));
		}

		public void Transaction(Action<DataBaseContext> transactional)
		{
			Action<DataBaseContext> transactional2 = transactional;
			With.Transaction(unitOfWork, delegate(DataBaseContext context)
			{
				transactional2(context);
			});
		}

		public T Action<T>(Func<DataBaseContext, T> actional)
		{
			Func<DataBaseContext, T> actional2 = actional;
			return With.Action(unitOfWork, (DataBaseContext context) => actional2(context));
		}

		public void Action(Action<DataBaseContext> actional)
		{
			Action<DataBaseContext> actional2 = actional;
			With.Action(unitOfWork, delegate(DataBaseContext context)
			{
				actional2(context);
			});
		}

		public async Task<T> ActionAsyncParallel<T>(Func<DataBaseContext, Task<T>> actional)
		{
			Func<DataBaseContext, Task<T>> actional2 = actional;
			return await With.ActionAsyncParallel(unitOfWork, async (DataBaseContext context) => await actional2(unitOfWork.DatabaseContext));
		}

		public async Task<T> ActionAsync<T>(Func<DataBaseContext, Task<T>> actional)
		{
			Func<DataBaseContext, Task<T>> actional2 = actional;
			return await With.ActionAsync(unitOfWork, async (DataBaseContext context) => await actional2(context));
		}

		public T Get<T>(string keyName)
		{
			return cache.Get<T>(keyName);
		}

		public void Set<T>(string keyName, T data, long count)
		{
			cache.Set(keyName, data, new MemoryCacheEntryOptions
			{
				Size = count
			});
		}

		public void Remove(string keyName)
		{
			cache.Remove(keyName);
		}

		public TResult CloneObject<T, TResult>(T _entity)
		{
			string tmp = JsonConvert.SerializeObject(_entity);
			return JsonConvert.DeserializeObject<TResult>(tmp);
		}
	}
}
