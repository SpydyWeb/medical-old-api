using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services
{
	public class CancellationProcessor : ICancellationProcessor
	{
		protected readonly ILogger _logger;

		private readonly IExecutionResultProcessor _executionResultProcessor;

		private readonly IDateTimeProvider _dateTimeProvider;

		public CancellationProcessor(IExecutionResultProcessor executionResultProcessor, ILoggerFactory logFactory, IDateTimeProvider dateTimeProvider)
		{
			_executionResultProcessor = executionResultProcessor;
			_logger = logFactory.CreateLogger<CancellationProcessor>();
			_dateTimeProvider = dateTimeProvider;
		}

		public void ProcessCancellations(WorkflowInstance workflow, WorkflowDefinition workflowDef, WorkflowExecutorResult executionResult)
		{
			foreach (WorkflowStep step in workflowDef.Steps.Where((WorkflowStep x) => x.CancelCondition != null))
			{
				Delegate @delegate = step.CancelCondition.Compile();
				bool flag = false;
				try
				{
					flag = (bool)@delegate.DynamicInvoke(workflow.Data);
				}
				catch (Exception ex)
				{
					_logger.LogError(default(EventId), ex, ex.Message);
				}
				if (!flag)
				{
					continue;
				}
				foreach (ExecutionPointer item in workflow.ExecutionPointers.Where((ExecutionPointer x) => x.StepId == step.Id && x.Status != PointerStatus.Complete && x.Status != PointerStatus.Cancelled).ToList())
				{
					if (step.ProceedOnCancel)
					{
						_executionResultProcessor.ProcessExecutionResult(workflow, workflowDef, item, step, ExecutionResult.Next(), executionResult);
					}
					item.EndTime = _dateTimeProvider.UtcNow;
					item.Active = false;
					item.Status = PointerStatus.Cancelled;
					foreach (ExecutionPointer item2 in from x in workflow.ExecutionPointers.FindByScope(item.Id)
						where x.Status != PointerStatus.Complete && x.Status != PointerStatus.Cancelled
						select x)
					{
						item2.EndTime = _dateTimeProvider.UtcNow;
						item2.Active = false;
						item2.Status = PointerStatus.Cancelled;
					}
				}
			}
		}
	}
}
