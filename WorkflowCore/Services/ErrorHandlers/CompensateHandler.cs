using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services.ErrorHandlers
{
	public class CompensateHandler : IWorkflowErrorHandler
	{
		private readonly IExecutionPointerFactory _pointerFactory;

		private readonly IDateTimeProvider _datetimeProvider;

		private readonly WorkflowOptions _options;

		public WorkflowErrorHandling Type => WorkflowErrorHandling.Compensate;

		public CompensateHandler(IExecutionPointerFactory pointerFactory, IDateTimeProvider datetimeProvider, WorkflowOptions options)
		{
			_pointerFactory = pointerFactory;
			_datetimeProvider = datetimeProvider;
			_options = options;
		}

		public void Handle(WorkflowInstance workflow, WorkflowDefinition def, ExecutionPointer exceptionPointer, WorkflowStep exceptionStep, Exception exception, Queue<ExecutionPointer> bubbleUpQueue)
		{
			Stack<string> stack = new Stack<string>(exceptionPointer.Scope.Reverse());
			stack.Push(exceptionPointer.Id);
			ExecutionPointer executionPointer = null;
			while (stack.Any())
			{
				string id = stack.Pop();
				ExecutionPointer scopePointer = workflow.ExecutionPointers.FindById(id);
				WorkflowStep workflowStep = def.Steps.FindById(scopePointer.StepId);
				bool flag = true;
				bool flag2 = false;
				Stack<string> stack2 = new Stack<string>(stack.Reverse());
				while (stack2.Count > 0)
				{
					string id2 = stack2.Pop();
					ExecutionPointer executionPointer2 = workflow.ExecutionPointers.FindById(id2);
					WorkflowStep workflowStep2 = def.Steps.FindById(executionPointer2.StepId);
					if (!workflowStep2.ResumeChildrenAfterCompensation || workflowStep2.RevertChildrenAfterCompensation)
					{
						flag = workflowStep2.ResumeChildrenAfterCompensation;
						flag2 = workflowStep2.RevertChildrenAfterCompensation;
						break;
					}
				}
				if ((workflowStep.ErrorBehavior ?? WorkflowErrorHandling.Compensate) != WorkflowErrorHandling.Compensate)
				{
					bubbleUpQueue.Enqueue(scopePointer);
					continue;
				}
				scopePointer.Active = false;
				scopePointer.EndTime = _datetimeProvider.UtcNow;
				scopePointer.Status = PointerStatus.Failed;
				if (workflowStep.CompensationStepId.HasValue)
				{
					scopePointer.Status = PointerStatus.Compensated;
					ExecutionPointer executionPointer3 = _pointerFactory.BuildCompensationPointer(def, scopePointer, exceptionPointer, workflowStep.CompensationStepId.Value);
					if (executionPointer != null)
					{
						executionPointer3.Active = false;
						executionPointer3.Status = PointerStatus.PendingPredecessor;
						executionPointer3.PredecessorId = executionPointer.Id;
					}
					executionPointer = executionPointer3;
					workflow.ExecutionPointers.Add(executionPointer);
					if (flag)
					{
						foreach (IStepOutcome item in workflowStep.Outcomes.Where((IStepOutcome x) => x.Matches(workflow.Data)))
						{
							workflow.ExecutionPointers.Add(_pointerFactory.BuildNextPointer(def, scopePointer, item));
						}
					}
				}
				if (!flag2)
				{
					continue;
				}
				foreach (ExecutionPointer item2 in (from x in workflow.ExecutionPointers
					where scopePointer.Scope.SequenceEqual(x.Scope) && x.Id != scopePointer.Id && x.Status == PointerStatus.Complete
					orderby x.EndTime descending
					select x).ToList())
				{
					WorkflowStep workflowStep3 = def.Steps.FindById(item2.StepId);
					if (workflowStep3.CompensationStepId.HasValue)
					{
						ExecutionPointer executionPointer4 = _pointerFactory.BuildCompensationPointer(def, item2, exceptionPointer, workflowStep3.CompensationStepId.Value);
						if (executionPointer != null)
						{
							executionPointer4.Active = false;
							executionPointer4.Status = PointerStatus.PendingPredecessor;
							executionPointer4.PredecessorId = executionPointer.Id;
							executionPointer = executionPointer4;
						}
						workflow.ExecutionPointers.Add(executionPointer4);
						item2.Status = PointerStatus.Compensated;
					}
				}
			}
		}
	}
}
