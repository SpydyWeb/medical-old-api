using System;
using WorkflowCore.Exceptions;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Primitives
{
	public class Activity : StepBody
	{
		public string ActivityName { get; set; }

		public DateTime EffectiveDate { get; set; }

		public object Parameters { get; set; }

		public object Result { get; set; }

		public override ExecutionResult Run(IStepExecutionContext context)
		{
			if (!context.ExecutionPointer.EventPublished)
			{
				DateTime minValue = DateTime.MinValue;
				_ = EffectiveDate;
				minValue = EffectiveDate;
				return ExecutionResult.WaitForActivity(ActivityName, Parameters, minValue);
			}
			if (context.ExecutionPointer.EventData is ActivityResult)
			{
				ActivityResult activityResult = context.ExecutionPointer.EventData as ActivityResult;
				if (activityResult.Status != 0)
				{
					throw new ActivityFailedException(activityResult.Data);
				}
				Result = activityResult.Data;
			}
			else
			{
				Result = context.ExecutionPointer.EventData;
			}
			return ExecutionResult.Next();
		}
	}
}
