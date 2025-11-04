using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace WorkflowCore.Services
{
	public class SingleNodeQueueProvider : IQueueProvider, IDisposable
	{
		private readonly Dictionary<QueueType, BlockingCollection<string>> _queues = new Dictionary<QueueType, BlockingCollection<string>>
		{
			[QueueType.Workflow] = new BlockingCollection<string>(),
			[QueueType.Event] = new BlockingCollection<string>(),
			[QueueType.Index] = new BlockingCollection<string>()
		};

		public bool IsDequeueBlocking => true;

		public Task QueueWork(string id, QueueType queue)
		{
			_queues[queue].Add(id);
			return Task.CompletedTask;
		}

		public Task<string> DequeueWork(QueueType queue, CancellationToken cancellationToken)
		{
			if (_queues[queue].TryTake(out var item, 100, cancellationToken))
			{
				return Task.FromResult(item);
			}
			return Task.FromResult<string>(null);
		}

		public Task Start()
		{
			return Task.CompletedTask;
		}

		public Task Stop()
		{
			return Task.CompletedTask;
		}

		public void Dispose()
		{
		}
	}
}
