using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Primitives;

namespace WorkflowCore.Services
{
	public class WorkflowBuilder : IWorkflowBuilder
	{
		protected WorkflowErrorHandling DefaultErrorBehavior;

		protected TimeSpan? DefaultErrorRetryInterval;

		public List<WorkflowStep> Steps { get; set; } = new List<WorkflowStep>();


		protected ICollection<IWorkflowBuilder> Branches { get; set; } = new List<IWorkflowBuilder>();


		public int LastStep => Steps.Max((WorkflowStep x) => x.Id);

		public IWorkflowBuilder<T> UseData<T>()
		{
			return new WorkflowBuilder<T>(Steps);
		}

		public virtual WorkflowDefinition Build(string id, int version)
		{
			AttachExternalIds();
			return new WorkflowDefinition
			{
				Id = id,
				Version = version,
				Steps = new WorkflowStepCollection(Steps),
				DefaultErrorBehavior = DefaultErrorBehavior,
				DefaultErrorRetryInterval = DefaultErrorRetryInterval
			};
		}

		public void AddStep(WorkflowStep step)
		{
			step.Id = Steps.Count();
			Steps.Add(step);
		}

		private void AttachExternalIds()
		{
			foreach (WorkflowStep step in Steps)
			{
				foreach (IStepOutcome outcome in step.Outcomes.Where((IStepOutcome x) => !string.IsNullOrEmpty(x.ExternalNextStepId)))
				{
					if (Steps.All((WorkflowStep x) => x.ExternalId != outcome.ExternalNextStepId))
					{
						throw new KeyNotFoundException("Cannot find step id " + outcome.ExternalNextStepId);
					}
					outcome.NextStep = Steps.Single((WorkflowStep x) => x.ExternalId == outcome.ExternalNextStepId).Id;
				}
			}
		}

		public void AttachBranch(IWorkflowBuilder branch)
		{
			if (Branches.Contains(branch))
			{
				return;
			}
			int num = LastStep + branch.LastStep + 1;
			foreach (WorkflowStep step in branch.Steps)
			{
				int id = step.Id;
				step.Id = id + num;
				foreach (WorkflowStep step2 in branch.Steps)
				{
					foreach (IStepOutcome outcome in step2.Outcomes)
					{
						if (outcome.NextStep == id)
						{
							outcome.NextStep = step.Id;
						}
					}
					for (int i = 0; i < step2.Children.Count; i++)
					{
						if (step2.Children[i] == id)
						{
							step2.Children[i] = step.Id;
						}
					}
					if (step2.CompensationStepId == id)
					{
						step2.CompensationStepId = step.Id;
					}
				}
			}
			foreach (WorkflowStep step3 in branch.Steps)
			{
				int id2 = step3.Id;
				AddStep(step3);
				foreach (WorkflowStep step4 in branch.Steps)
				{
					foreach (IStepOutcome outcome2 in step4.Outcomes)
					{
						if (outcome2.NextStep == id2)
						{
							outcome2.NextStep = step3.Id;
						}
					}
					for (int j = 0; j < step4.Children.Count; j++)
					{
						if (step4.Children[j] == id2)
						{
							step4.Children[j] = step3.Id;
						}
					}
					if (step4.CompensationStepId == id2)
					{
						step4.CompensationStepId = step3.Id;
					}
				}
			}
			Branches.Add(branch);
		}
	}
	public class WorkflowBuilder<TData> : WorkflowBuilder, IWorkflowBuilder<TData>, IWorkflowBuilder, IWorkflowModifier<TData, InlineStepBody>
	{
		public override WorkflowDefinition Build(string id, int version)
		{
			WorkflowDefinition workflowDefinition = base.Build(id, version);
			workflowDefinition.DataType = typeof(TData);
			return workflowDefinition;
		}

		public WorkflowBuilder(IEnumerable<WorkflowStep> steps)
		{
			Steps.AddRange(steps);
		}

		public IStepBuilder<TData, TStep> StartWith<TStep>(Action<IStepBuilder<TData, TStep>> stepSetup = null) where TStep : IStepBody
		{
			WorkflowStep<TStep> workflowStep = new WorkflowStep<TStep>();
			StepBuilder<TData, TStep> stepBuilder = new StepBuilder<TData, TStep>(this, workflowStep);
			stepSetup?.Invoke(stepBuilder);
			workflowStep.Name = workflowStep.Name ?? typeof(TStep).Name;
			AddStep(workflowStep);
			return stepBuilder;
		}

		public IStepBuilder<TData, InlineStepBody> StartWith(Func<IStepExecutionContext, ExecutionResult> body)
		{
			WorkflowStepInline workflowStepInline = new WorkflowStepInline();
			workflowStepInline.Body = body;
			StepBuilder<TData, InlineStepBody> result = new StepBuilder<TData, InlineStepBody>(this, workflowStepInline);
			AddStep(workflowStepInline);
			return result;
		}

		public IStepBuilder<TData, ActionStepBody> StartWith(Action<IStepExecutionContext> body)
		{
			WorkflowStep<ActionStepBody> step = new WorkflowStep<ActionStepBody>();
			AddStep(step);
			StepBuilder<TData, ActionStepBody> stepBuilder = new StepBuilder<TData, ActionStepBody>(this, step);
			stepBuilder.Input((ActionStepBody x) => x.Body, (TData x) => body);
			return stepBuilder;
		}

		public IEnumerable<WorkflowStep> GetUpstreamSteps(int id)
		{
			return Steps.Where((WorkflowStep x) => x.Outcomes.Any((IStepOutcome y) => y.NextStep == id)).ToList();
		}

		public IWorkflowBuilder<TData> UseDefaultErrorBehavior(WorkflowErrorHandling behavior, TimeSpan? retryInterval = null)
		{
			DefaultErrorBehavior = behavior;
			DefaultErrorRetryInterval = retryInterval;
			return this;
		}

		public IWorkflowBuilder<TData> CreateBranch()
		{
			return new WorkflowBuilder<TData>(new List<WorkflowStep>());
		}

		public IStepBuilder<TData, TStep> Then<TStep>(Action<IStepBuilder<TData, TStep>> stepSetup = null) where TStep : IStepBody
		{
			return Start().Then(stepSetup);
		}

		public IStepBuilder<TData, TStep> Then<TStep>(IStepBuilder<TData, TStep> newStep) where TStep : IStepBody
		{
			return Start().Then(newStep);
		}

		public IStepBuilder<TData, InlineStepBody> Then(Func<IStepExecutionContext, ExecutionResult> body)
		{
			return Start().Then(body);
		}

		public IStepBuilder<TData, ActionStepBody> Then(Action<IStepExecutionContext> body)
		{
			return Start().Then(body);
		}

		public IStepBuilder<TData, WaitFor> WaitFor(string eventName, Expression<Func<TData, string>> eventKey, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null)
		{
			return Start().WaitFor(eventName, eventKey, effectiveDate, cancelCondition);
		}

		public IStepBuilder<TData, WaitFor> WaitFor(string eventName, Expression<Func<TData, IStepExecutionContext, string>> eventKey, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null)
		{
			return Start().WaitFor(eventName, eventKey, effectiveDate, cancelCondition);
		}

		public IStepBuilder<TData, Delay> Delay(Expression<Func<TData, TimeSpan>> period)
		{
			return Start().Delay(period);
		}

		public IStepBuilder<TData, Decide> Decide(Expression<Func<TData, object>> expression)
		{
			return Start().Decide(expression);
		}

		public IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IEnumerable>> collection)
		{
			return Start().ForEach(collection);
		}

		public IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IEnumerable>> collection, Expression<Func<TData, bool>> runParallel)
		{
			return Start().ForEach(collection, runParallel);
		}

		public IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IStepExecutionContext, IEnumerable>> collection, Expression<Func<TData, bool>> runParallel)
		{
			return Start().ForEach(collection, runParallel);
		}

		public IContainerStepBuilder<TData, While, While> While(Expression<Func<TData, bool>> condition)
		{
			return Start().While(condition);
		}

		public IContainerStepBuilder<TData, While, While> While(Expression<Func<TData, IStepExecutionContext, bool>> condition)
		{
			return Start().While(condition);
		}

		public IContainerStepBuilder<TData, If, If> If(Expression<Func<TData, bool>> condition)
		{
			return Start().If(condition);
		}

		public IContainerStepBuilder<TData, If, If> If(Expression<Func<TData, IStepExecutionContext, bool>> condition)
		{
			return Start().If(condition);
		}

		public IContainerStepBuilder<TData, When, OutcomeSwitch> When(Expression<Func<TData, object>> outcomeValue, string label = null)
		{
			return ((IWorkflowModifier<TData, InlineStepBody>)Start()).When(outcomeValue, label);
		}

		public IParallelStepBuilder<TData, Sequence> Parallel()
		{
			return Start().Parallel();
		}

		public IStepBuilder<TData, Sequence> Saga(Action<IWorkflowBuilder<TData>> builder)
		{
			return Start().Saga(builder);
		}

		public IContainerStepBuilder<TData, Schedule, InlineStepBody> Schedule(Expression<Func<TData, TimeSpan>> time)
		{
			return Start().Schedule(time);
		}

		public IContainerStepBuilder<TData, Recur, InlineStepBody> Recur(Expression<Func<TData, TimeSpan>> interval, Expression<Func<TData, bool>> until)
		{
			return Start().Recur(interval, until);
		}

		public IStepBuilder<TData, Activity> Activity(string activityName, Expression<Func<TData, object>> parameters = null, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null)
		{
			return Start().Activity(activityName, parameters, effectiveDate, cancelCondition);
		}

		public IStepBuilder<TData, Activity> Activity(Expression<Func<TData, IStepExecutionContext, string>> activityName, Expression<Func<TData, object>> parameters = null, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null)
		{
			return Start().Activity(activityName, parameters, effectiveDate, cancelCondition);
		}

		private IStepBuilder<TData, InlineStepBody> Start()
		{
			return StartWith((IStepExecutionContext _) => ExecutionResult.Next());
		}
	}
}
