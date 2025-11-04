using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkflowCore.Models;

namespace WorkflowCore.Interface
{
	public interface IWorkflowHost : IWorkflowController, IActivityController, IHostedService
	{
		IPersistenceProvider PersistenceStore { get; }

		IDistributedLockProvider LockProvider { get; }

		IWorkflowRegistry Registry { get; }

		WorkflowOptions Options { get; }

		IQueueProvider QueueProvider { get; }

		ILogger Logger { get; }

		event StepErrorEventHandler OnStepError;

		event LifeCycleEventHandler OnLifeCycleEvent;

		void Start();

		void Stop();

		void ReportStepError(WorkflowInstance workflow, WorkflowStep step, Exception exception);
	}
}
