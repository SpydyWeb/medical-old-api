using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;

namespace WorkflowCore.Services
{
	public class GreyList : IGreyList, IDisposable
	{
		private readonly Timer _cycleTimer;

		private readonly ConcurrentDictionary<string, DateTime> _list;

		private readonly ILogger _logger;

		private readonly IDateTimeProvider _dateTimeProvider;

		private const int CYCLE_TIME = 30;

		private const int TTL = 5;

		public GreyList(ILoggerFactory loggerFactory, IDateTimeProvider dateTimeProvider)
		{
			_logger = loggerFactory.CreateLogger<GreyList>();
			_dateTimeProvider = dateTimeProvider;
			_list = new ConcurrentDictionary<string, DateTime>();
			_cycleTimer = new Timer(Cycle, null, TimeSpan.FromMinutes(30.0), TimeSpan.FromMinutes(30.0));
		}

		public void Add(string id)
		{
			_list.AddOrUpdate(id, _dateTimeProvider.Now, (string key, DateTime val) => _dateTimeProvider.Now);
		}

		public bool Contains(string id)
		{
			if (!_list.TryGetValue(id, out var value))
			{
				return false;
			}
			DateTime dateTime = value;
			DateTime value2 = _dateTimeProvider.Now;
			bool num = dateTime > value2.AddMinutes(-5.0);
			if (!num)
			{
				_list.TryRemove(id, out value2);
			}
			return num;
		}

		private void Cycle(object target)
		{
			try
			{
				_list.Clear();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
			}
		}

		public void Dispose()
		{
			_cycleTimer.Dispose();
		}

		public void Remove(string id)
		{
			_list.TryRemove(id, out var _);
		}
	}
}
