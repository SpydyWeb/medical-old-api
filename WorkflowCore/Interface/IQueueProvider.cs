using System;
using System.Threading;
using System.Threading.Tasks;

namespace WorkflowCore.Interface
{
	public interface IQueueProvider : IDisposable
	{
		bool IsDequeueBlocking { get; }

		Task QueueWork(string id, QueueType queue);

		Task<string> DequeueWork(QueueType queue, CancellationToken cancellationToken);

		Task Start();

		Task Stop();
	}
}
