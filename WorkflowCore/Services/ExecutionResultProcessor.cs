using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Models.LifeCycleEvents;

namespace WorkflowCore.Services
{
	public class ExecutionResultProcessor : IExecutionResultProcessor
	{
		private readonly IExecutionPointerFactory _pointerFactory;

		private readonly IDateTimeProvider _datetimeProvider;

		private readonly ILogger _logger;

		private readonly ILifeCycleEventPublisher _eventPublisher;

		private readonly IEnumerable<IWorkflowErrorHandler> _errorHandlers;

		private readonly WorkflowOptions _options;

		public ExecutionResultProcessor(IExecutionPointerFactory pointerFactory, IDateTimeProvider datetimeProvider, ILifeCycleEventPublisher eventPublisher, IEnumerable<IWorkflowErrorHandler> errorHandlers, WorkflowOptions options, ILoggerFactory loggerFactory)
		{
			_pointerFactory = pointerFactory;
			_datetimeProvider = datetimeProvider;
			_eventPublisher = eventPublisher;
			_errorHandlers = errorHandlers;
			_options = options;
			_logger = loggerFactory.CreateLogger<ExecutionResultProcessor>();
		}

		public void ProcessExecutionResult(WorkflowInstance workflow, WorkflowDefinition def, ExecutionPointer pointer, WorkflowStep step, ExecutionResult result, WorkflowExecutorResult workflowResult)
		{
			pointer.PersistenceData = result.PersistenceData;
			pointer.Outcome = result.OutcomeValue;
			if (result.SleepFor.HasValue)
			{
				pointer.SleepUntil = _datetimeProvider.UtcNow.Add(result.SleepFor.Value);
				pointer.Status = PointerStatus.Sleeping;
			}
			if (!string.IsNullOrEmpty(result.EventName))
			{
				pointer.EventName = result.EventName;
				pointer.EventKey = result.EventKey;
				pointer.Active = false;
				pointer.Status = PointerStatus.WaitingForEvent;
				workflowResult.Subscriptions.Add(new EventSubscription
				{
					WorkflowId = workflow.Id,
					StepId = pointer.StepId,
					ExecutionPointerId = pointer.Id,
					EventName = pointer.EventName,
					EventKey = pointer.EventKey,
					SubscribeAsOf = result.EventAsOf,
					SubscriptionData = result.SubscriptionData
				});
			}
			if (result.Proceed)
			{
				pointer.Active = false;
				pointer.EndTime = _datetimeProvider.UtcNow;
				pointer.Status = PointerStatus.Complete;
				foreach (IStepOutcome item in step.Outcomes.Where((IStepOutcome x) => x.Matches(result, workflow.Data)))
				{
					workflow.ExecutionPointers.Add(_pointerFactory.BuildNextPointer(def, pointer, item));
				}
				foreach (ExecutionPointer item2 in from x in workflow.ExecutionPointers.FindByStatus(PointerStatus.PendingPredecessor)
					where x.PredecessorId == pointer.Id
					select x)
				{
					item2.Status = PointerStatus.Pending;
					item2.Active = true;
				}
				_eventPublisher.PublishNotification(new StepCompleted
				{
					EventTimeUtc = _datetimeProvider.UtcNow,
					Reference = workflow.Reference,
					ExecutionPointerId = pointer.Id,
					StepId = step.Id,
					WorkflowInstanceId = workflow.Id,
					WorkflowDefinitionId = workflow.WorkflowDefinitionId,
					Version = workflow.Version
				});
				return;
			}
			foreach (object branchValue in result.BranchValues)
			{
				foreach (int child in step.Children)
				{
					workflow.ExecutionPointers.Add(_pointerFactory.BuildChildPointer(def, pointer, child, branchValue));
				}
			}
		}

		public void HandleStepException(WorkflowInstance workflow, WorkflowDefinition def, ExecutionPointer pointer, WorkflowStep step, Exception exception)
		{
			_eventPublisher.PublishNotification(new WorkflowError
			{
				EventTimeUtc = _datetimeProvider.UtcNow,
				Reference = workflow.Reference,
				WorkflowInstanceId = workflow.Id,
				WorkflowDefinitionId = workflow.WorkflowDefinitionId,
				Version = workflow.Version,
				ExecutionPointerId = pointer.Id,
				StepId = step.Id,
				Message = exception.Message
			});
			pointer.Status = PointerStatus.Failed;
			Queue<ExecutionPointer> queue = new Queue<ExecutionPointer>();
			queue.Enqueue(pointer);
			while (queue.Count > 0)
			{
				ExecutionPointer executionPointer = queue.Dequeue();
				WorkflowStep workflowStep = def.Steps.FindById(executionPointer.StepId);
				bool flag = ShouldCompensate(workflow, def, executionPointer);
				WorkflowErrorHandling errorOption = workflowStep.ErrorBehavior ?? (flag ? WorkflowErrorHandling.Compensate : def.DefaultErrorBehavior);
				foreach (IWorkflowErrorHandler item in _errorHandlers.Where((IWorkflowErrorHandler x) => x.Type == errorOption))
				{
					item.Handle(workflow, def, executionPointer, workflowStep, exception, queue);
				}
			}
		}

		private bool ShouldCompensate(WorkflowInstance workflow, WorkflowDefinition def, ExecutionPointer currentPointer)
		{
			Stack<string> stack = new Stack<string>(currentPointer.Scope);
			stack.Push(currentPointer.Id);
			while (stack.Count > 0)
			{
				string id = stack.Pop();
				ExecutionPointer executionPointer = workflow.ExecutionPointers.FindById(id);
				WorkflowStep workflowStep = def.Steps.FindById(executionPointer.StepId);
				if (workflowStep.CompensationStepId.HasValue || workflowStep.RevertChildrenAfterCompensation)
				{
					return true;
				}
			}
			return false;
		}
	}
}
