using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Primitives;

namespace WorkflowCore.Services
{
	public class StepOutcomeBuilder<TData> : IStepOutcomeBuilder<TData>
	{
		public IWorkflowBuilder<TData> WorkflowBuilder { get; private set; }

		public ValueOutcome Outcome { get; private set; }

		public StepOutcomeBuilder(IWorkflowBuilder<TData> workflowBuilder, ValueOutcome outcome)
		{
			WorkflowBuilder = workflowBuilder;
			Outcome = outcome;
		}

		public IStepBuilder<TData, TStep> Then<TStep>(Action<IStepBuilder<TData, TStep>> stepSetup = null) where TStep : IStepBody
		{
			WorkflowStep<TStep> workflowStep = new WorkflowStep<TStep>();
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, TStep> stepBuilder = new StepBuilder<TData, TStep>(WorkflowBuilder, workflowStep);
			stepSetup?.Invoke(stepBuilder);
			workflowStep.Name = workflowStep.Name ?? typeof(TStep).Name;
			Outcome.NextStep = workflowStep.Id;
			return stepBuilder;
		}

		public IStepBuilder<TData, TStep> Then<TStep>(IStepBuilder<TData, TStep> step) where TStep : IStepBody
		{
			Outcome.NextStep = step.Step.Id;
			return new StepBuilder<TData, TStep>(WorkflowBuilder, step.Step);
		}

		public IStepBuilder<TData, InlineStepBody> Then(Func<IStepExecutionContext, ExecutionResult> body)
		{
			WorkflowStepInline workflowStepInline = new WorkflowStepInline();
			workflowStepInline.Body = body;
			WorkflowBuilder.AddStep(workflowStepInline);
			StepBuilder<TData, InlineStepBody> result = new StepBuilder<TData, InlineStepBody>(WorkflowBuilder, workflowStepInline);
			Outcome.NextStep = workflowStepInline.Id;
			return result;
		}

		public void EndWorkflow()
		{
			EndStep endStep = new EndStep();
			WorkflowBuilder.AddStep(endStep);
			Outcome.NextStep = endStep.Id;
		}
	}
}
