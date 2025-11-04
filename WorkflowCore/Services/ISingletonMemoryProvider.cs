using WorkflowCore.Interface;

namespace WorkflowCore.Services
{
	public interface ISingletonMemoryProvider : IPersistenceProvider, IWorkflowRepository, ISubscriptionRepository, IEventRepository, IScheduledCommandRepository
	{
	}
}
