using System.Threading;
using System.Threading.Tasks;

namespace WorkflowCore.Interface
{
	public interface IDistributedLockProvider
	{
		Task<bool> AcquireLock(string Id, CancellationToken cancellationToken);

		Task ReleaseLock(string Id);

		Task Start();

		Task Stop();
	}
}
