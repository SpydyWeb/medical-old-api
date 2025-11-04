using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowCore.Exceptions;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Primitives
{
	public class When : ContainerStepBody
	{
		public object ExpectedOutcome { get; set; }

		public override ExecutionResult Run(IStepExecutionContext context)
		{
			object switchOutcome = GetSwitchOutcome(context);
			if (ExpectedOutcome != switchOutcome && Convert.ToString(ExpectedOutcome) != Convert.ToString(switchOutcome))
			{
				return ExecutionResult.Next();
			}
			if (context.PersistenceData == null)
			{
				return ExecutionResult.Branch(new List<object> { context.Item }, new ControlPersistenceData
				{
					ChildrenActive = true
				});
			}
			if (context.PersistenceData is ControlPersistenceData && (context.PersistenceData as ControlPersistenceData).ChildrenActive)
			{
				if (context.Workflow.IsBranchComplete(context.ExecutionPointer.Id))
				{
					return ExecutionResult.Next();
				}
				return ExecutionResult.Persist(context.PersistenceData);
			}
			throw new CorruptPersistenceDataException();
		}

		private object GetSwitchOutcome(IStepExecutionContext context)
		{
			return context.Workflow.ExecutionPointers.First((ExecutionPointer x) => x.Children.Contains(context.ExecutionPointer.Id)).Outcome;
		}
	}
}
