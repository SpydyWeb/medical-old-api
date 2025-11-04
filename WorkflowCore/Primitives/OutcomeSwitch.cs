using System.Collections.Generic;
using WorkflowCore.Exceptions;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Primitives
{
	public class OutcomeSwitch : ContainerStepBody
	{
		public override ExecutionResult Run(IStepExecutionContext context)
		{
			if (context.PersistenceData == null)
			{
				ExecutionResult executionResult = ExecutionResult.Branch(new List<object> { context.Item }, new ControlPersistenceData
				{
					ChildrenActive = true
				});
				executionResult.OutcomeValue = GetPreviousOutcome(context);
				return executionResult;
			}
			if (context.PersistenceData is ControlPersistenceData && (context.PersistenceData as ControlPersistenceData).ChildrenActive)
			{
				if (context.Workflow.IsBranchComplete(context.ExecutionPointer.Id))
				{
					return ExecutionResult.Next();
				}
				ExecutionResult executionResult2 = ExecutionResult.Persist(context.PersistenceData);
				executionResult2.OutcomeValue = GetPreviousOutcome(context);
				return executionResult2;
			}
			throw new CorruptPersistenceDataException();
		}

		private object GetPreviousOutcome(IStepExecutionContext context)
		{
			return context.Workflow.ExecutionPointers.FindById(context.ExecutionPointer.PredecessorId).Outcome;
		}
	}
}
