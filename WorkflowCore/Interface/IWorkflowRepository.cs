using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WorkflowCore.Models;

namespace WorkflowCore.Interface
{
	public interface IWorkflowRepository
	{
		Task<string> CreateNewWorkflow(WorkflowInstance workflow, CancellationToken cancellationToken = default(CancellationToken));

		Task PersistWorkflow(WorkflowInstance workflow, CancellationToken cancellationToken = default(CancellationToken));

		Task PersistWorkflow(WorkflowInstance workflow, List<EventSubscription> subscriptions, CancellationToken cancellationToken = default(CancellationToken));

		Task<IEnumerable<string>> GetRunnableInstances(DateTime asAt, CancellationToken cancellationToken = default(CancellationToken));

		[Obsolete]
		Task<IEnumerable<WorkflowInstance>> GetWorkflowInstances(WorkflowStatus? status, string type, DateTime? createdFrom, DateTime? createdTo, int skip, int take);

		Task<WorkflowInstance> GetWorkflowInstance(string Id, CancellationToken cancellationToken = default(CancellationToken));

		Task<IEnumerable<WorkflowInstance>> GetWorkflowInstances(IEnumerable<string> ids, CancellationToken cancellationToken = default(CancellationToken));
	}
}
