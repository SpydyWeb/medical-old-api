using System;
using System.Threading;
using System.Threading.Tasks;
using WorkflowCore.Exceptions;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services
{
	public class SyncWorkflowRunner : ISyncWorkflowRunner
	{
		private readonly IWorkflowHost _host;

		private readonly IWorkflowExecutor _executor;

		private readonly IDistributedLockProvider _lockService;

		private readonly IWorkflowRegistry _registry;

		private readonly IPersistenceProvider _persistenceStore;

		private readonly IExecutionPointerFactory _pointerFactory;

		private readonly IQueueProvider _queueService;

		private readonly IDateTimeProvider _dateTimeProvider;

		public SyncWorkflowRunner(IWorkflowHost host, IWorkflowExecutor executor, IDistributedLockProvider lockService, IWorkflowRegistry registry, IPersistenceProvider persistenceStore, IExecutionPointerFactory pointerFactory, IQueueProvider queueService, IDateTimeProvider dateTimeProvider)
		{
			_host = host;
			_executor = executor;
			_lockService = lockService;
			_registry = registry;
			_persistenceStore = persistenceStore;
			_pointerFactory = pointerFactory;
			_queueService = queueService;
			_dateTimeProvider = dateTimeProvider;
		}

		public Task<WorkflowInstance> RunWorkflowSync<TData>(string workflowId, int version, TData data, string reference, TimeSpan timeOut, bool persistSate = true) where TData : new()
		{
			return RunWorkflowSync(workflowId, version, data, reference, new CancellationTokenSource(timeOut).Token, persistSate);
		}

		public async Task<WorkflowInstance> RunWorkflowSync<TData>(string workflowId, int version, TData data, string reference, CancellationToken token, bool persistSate = true) where TData : new()
		{
			WorkflowDefinition definition = _registry.GetDefinition(workflowId, version);
			if (definition == null)
			{
				throw new WorkflowNotRegisteredException(workflowId, version);
			}
			WorkflowInstance wf = new WorkflowInstance
			{
				WorkflowDefinitionId = workflowId,
				Version = definition.Version,
				Data = data,
				Description = definition.Description,
				NextExecution = 0L,
				CreateTime = _dateTimeProvider.UtcNow,
				Status = WorkflowStatus.Suspended,
				Reference = reference
			};
			if (definition.DataType != null && data == null)
			{
				if (typeof(TData) == definition.DataType)
				{
					wf.Data = new TData();
				}
				else
				{
					wf.Data = definition.DataType.GetConstructor(new Type[0]).Invoke(new object[0]);
				}
			}
			wf.ExecutionPointers.Add(_pointerFactory.BuildGenesisPointer(definition));
			string id = Guid.NewGuid().ToString();
			if (persistSate)
			{
				id = await _persistenceStore.CreateNewWorkflow(wf, token);
			}
			else
			{
				wf.Id = id;
			}
			wf.Status = WorkflowStatus.Runnable;
			if (!(await _lockService.AcquireLock(id, CancellationToken.None)))
			{
				throw new InvalidOperationException();
			}
			try
			{
				while (wf.Status == WorkflowStatus.Runnable && !token.IsCancellationRequested)
				{
					await _executor.Execute(wf, token);
					if (persistSate)
					{
						await _persistenceStore.PersistWorkflow(wf, token);
					}
				}
			}
			finally
			{
				await _lockService.ReleaseLock(id);
			}
			if (persistSate)
			{
				await _queueService.QueueWork(id, QueueType.Index);
			}
			return wf;
		}
	}
}
