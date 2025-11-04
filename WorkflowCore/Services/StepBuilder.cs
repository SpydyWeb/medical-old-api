using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Primitives;

namespace WorkflowCore.Services
{
	public class StepBuilder<TData, TStepBody> : IStepBuilder<TData, TStepBody>, IWorkflowModifier<TData, TStepBody>, IContainerStepBuilder<TData, TStepBody, TStepBody> where TStepBody : IStepBody
	{
		public IWorkflowBuilder<TData> WorkflowBuilder { get; private set; }

		public WorkflowStep<TStepBody> Step { get; set; }

		public StepBuilder(IWorkflowBuilder<TData> workflowBuilder, WorkflowStep<TStepBody> step)
		{
			WorkflowBuilder = workflowBuilder;
			Step = step;
		}

		public IStepBuilder<TData, TStepBody> Name(string name)
		{
			Step.Name = name;
			return this;
		}

		public IStepBuilder<TData, TStepBody> Id(string id)
		{
			Step.ExternalId = id;
			return this;
		}

		public IStepBuilder<TData, TStep> Then<TStep>(Action<IStepBuilder<TData, TStep>> stepSetup = null) where TStep : IStepBody
		{
			WorkflowStep<TStep> workflowStep = new WorkflowStep<TStep>();
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, TStep> stepBuilder = new StepBuilder<TData, TStep>(WorkflowBuilder, workflowStep);
			stepSetup?.Invoke(stepBuilder);
			workflowStep.Name = workflowStep.Name ?? typeof(TStep).Name;
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return stepBuilder;
		}

		public IStepBuilder<TData, TStep> Then<TStep>(IStepBuilder<TData, TStep> newStep) where TStep : IStepBody
		{
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = newStep.Step.Id
			});
			return new StepBuilder<TData, TStep>(WorkflowBuilder, newStep.Step);
		}

		public IStepBuilder<TData, InlineStepBody> Then(Func<IStepExecutionContext, ExecutionResult> body)
		{
			WorkflowStepInline workflowStepInline = new WorkflowStepInline();
			workflowStepInline.Body = body;
			WorkflowBuilder.AddStep(workflowStepInline);
			StepBuilder<TData, InlineStepBody> result = new StepBuilder<TData, InlineStepBody>(WorkflowBuilder, workflowStepInline);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStepInline.Id
			});
			return result;
		}

		public IStepBuilder<TData, ActionStepBody> Then(Action<IStepExecutionContext> body)
		{
			WorkflowStep<ActionStepBody> workflowStep = new WorkflowStep<ActionStepBody>();
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, ActionStepBody> stepBuilder = new StepBuilder<TData, ActionStepBody>(WorkflowBuilder, workflowStep);
			stepBuilder.Input((ActionStepBody x) => x.Body, (TData x) => body);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return stepBuilder;
		}

		public IStepBuilder<TData, TStepBody> Attach(string id)
		{
			Step.Outcomes.Add(new ValueOutcome
			{
				ExternalNextStepId = id
			});
			return this;
		}

		public IStepOutcomeBuilder<TData> When(object outcomeValue, string label = null)
		{
			Expression<Func<object, object>> value = (object x) => outcomeValue;
			ValueOutcome valueOutcome = new ValueOutcome
			{
				Value = value,
				Label = label
			};
			Step.Outcomes.Add(valueOutcome);
			return new StepOutcomeBuilder<TData>(WorkflowBuilder, valueOutcome);
		}

		public IStepBuilder<TData, TStepBody> Branch<TStep>(object outcomeValue, IStepBuilder<TData, TStep> branch) where TStep : IStepBody
		{
			if (branch.WorkflowBuilder.Steps.Count == 0)
			{
				return this;
			}
			WorkflowBuilder.AttachBranch(branch.WorkflowBuilder);
			Expression<Func<object, object>> value = (object x) => outcomeValue;
			Step.Outcomes.Add(new ValueOutcome
			{
				Value = value,
				NextStep = branch.WorkflowBuilder.Steps[0].Id
			});
			return this;
		}

		public IStepBuilder<TData, TStepBody> Branch<TStep>(Expression<Func<TData, object, bool>> outcomeExpression, IStepBuilder<TData, TStep> branch) where TStep : IStepBody
		{
			if (branch.WorkflowBuilder.Steps.Count == 0)
			{
				return this;
			}
			WorkflowBuilder.AttachBranch(branch.WorkflowBuilder);
			Step.Outcomes.Add(new ExpressionOutcome<TData>(outcomeExpression)
			{
				NextStep = branch.WorkflowBuilder.Steps[0].Id
			});
			return this;
		}

		public IStepBuilder<TData, TStepBody> Input<TInput>(Expression<Func<TStepBody, TInput>> stepProperty, Expression<Func<TData, TInput>> value)
		{
			Step.Inputs.Add(new MemberMapParameter(value, stepProperty));
			return this;
		}

		public IStepBuilder<TData, TStepBody> Input<TInput>(Expression<Func<TStepBody, TInput>> stepProperty, Expression<Func<TData, IStepExecutionContext, TInput>> value)
		{
			Step.Inputs.Add(new MemberMapParameter(value, stepProperty));
			return this;
		}

		public IStepBuilder<TData, TStepBody> Input(Action<TStepBody, TData> action)
		{
			Step.Inputs.Add(new ActionParameter<TStepBody, TData>(action));
			return this;
		}

		public IStepBuilder<TData, TStepBody> Input(Action<TStepBody, TData, IStepExecutionContext> action)
		{
			Step.Inputs.Add(new ActionParameter<TStepBody, TData>(action));
			return this;
		}

		public IStepBuilder<TData, TStepBody> Output<TOutput>(Expression<Func<TData, TOutput>> dataProperty, Expression<Func<TStepBody, object>> value)
		{
			Step.Outputs.Add(new MemberMapParameter(value, dataProperty));
			return this;
		}

		public IStepBuilder<TData, TStepBody> Output(Action<TStepBody, TData> action)
		{
			Step.Outputs.Add(new ActionParameter<TStepBody, TData>(action));
			return this;
		}

		public IStepBuilder<TData, WaitFor> WaitFor(string eventName, Expression<Func<TData, string>> eventKey, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null)
		{
			WorkflowStep<WaitFor> workflowStep = new WorkflowStep<WaitFor>();
			workflowStep.CancelCondition = cancelCondition;
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, WaitFor> stepBuilder = new StepBuilder<TData, WaitFor>(WorkflowBuilder, workflowStep);
			stepBuilder.Input((WaitFor step) => step.EventName, (TData data) => eventName);
			stepBuilder.Input((WaitFor step) => step.EventKey, eventKey);
			if (effectiveDate != null)
			{
				stepBuilder.Input((WaitFor step) => step.EffectiveDate, effectiveDate);
			}
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return stepBuilder;
		}

		public IStepBuilder<TData, WaitFor> WaitFor(string eventName, Expression<Func<TData, IStepExecutionContext, string>> eventKey, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null)
		{
			WorkflowStep<WaitFor> workflowStep = new WorkflowStep<WaitFor>();
			workflowStep.CancelCondition = cancelCondition;
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, WaitFor> stepBuilder = new StepBuilder<TData, WaitFor>(WorkflowBuilder, workflowStep);
			stepBuilder.Input((WaitFor step) => step.EventName, (TData data) => eventName);
			stepBuilder.Input((WaitFor step) => step.EventKey, eventKey);
			if (effectiveDate != null)
			{
				stepBuilder.Input((WaitFor step) => step.EffectiveDate, effectiveDate);
			}
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return stepBuilder;
		}

		public IStepBuilder<TData, TStep> End<TStep>(string name) where TStep : IStepBody
		{
			WorkflowStep workflowStep = IterateParents(Step.Id, name);
			if (workflowStep == null)
			{
				throw new InvalidOperationException("Parent step of name " + name + " not found");
			}
			if (!(workflowStep is WorkflowStep<TStep>))
			{
				throw new InvalidOperationException($"Parent step of name {name} is not of type {typeof(TStep)}");
			}
			return new StepBuilder<TData, TStep>(WorkflowBuilder, workflowStep as WorkflowStep<TStep>);
		}

		public IStepBuilder<TData, TStepBody> OnError(WorkflowErrorHandling behavior, TimeSpan? retryInterval = null)
		{
			Step.ErrorBehavior = behavior;
			Step.RetryInterval = retryInterval;
			return this;
		}

		private WorkflowStep IterateParents(int id, string name)
		{
			IEnumerable<WorkflowStep> upstreamSteps = WorkflowBuilder.GetUpstreamSteps(id);
			foreach (WorkflowStep item in upstreamSteps)
			{
				if (item.Name == name)
				{
					return item;
				}
			}
			foreach (WorkflowStep item2 in upstreamSteps)
			{
				WorkflowStep workflowStep = IterateParents(item2.Id, name);
				if (workflowStep != null)
				{
					return workflowStep;
				}
			}
			return null;
		}

		public IStepBuilder<TData, TStepBody> EndWorkflow()
		{
			EndStep endStep = new EndStep();
			WorkflowBuilder.AddStep(endStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = endStep.Id
			});
			return this;
		}

		public IStepBuilder<TData, Delay> Delay(Expression<Func<TData, TimeSpan>> period)
		{
			WorkflowStep<Delay> workflowStep = new WorkflowStep<Delay>();
			Expression<Func<Delay, TimeSpan>> target = (Delay x) => x.Period;
			workflowStep.Inputs.Add(new MemberMapParameter(period, target));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, Delay> result = new StepBuilder<TData, Delay>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IStepBuilder<TData, Decide> Decide(Expression<Func<TData, object>> expression)
		{
			WorkflowStep<Decide> workflowStep = new WorkflowStep<Decide>();
			Expression<Func<Decide, object>> target = (Decide x) => x.Expression;
			workflowStep.Inputs.Add(new MemberMapParameter(expression, target));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, Decide> result = new StepBuilder<TData, Decide>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IEnumerable>> collection)
		{
			WorkflowStep<Foreach> workflowStep = new WorkflowStep<Foreach>();
			Expression<Func<Foreach, IEnumerable>> target = (Foreach x) => x.Collection;
			workflowStep.Inputs.Add(new MemberMapParameter(collection, target));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, Foreach> result = new StepBuilder<TData, Foreach>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IEnumerable>> collection, Expression<Func<TData, bool>> runParallel)
		{
			WorkflowStep<Foreach> workflowStep = new WorkflowStep<Foreach>();
			Expression<Func<Foreach, IEnumerable>> target = (Foreach x) => x.Collection;
			workflowStep.Inputs.Add(new MemberMapParameter(collection, target));
			Expression<Func<Foreach, bool>> target2 = (Foreach x) => x.RunParallel;
			workflowStep.Inputs.Add(new MemberMapParameter(runParallel, target2));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, Foreach> result = new StepBuilder<TData, Foreach>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IStepExecutionContext, IEnumerable>> collection, Expression<Func<TData, bool>> runParallel)
		{
			WorkflowStep<Foreach> workflowStep = new WorkflowStep<Foreach>();
			Expression<Func<Foreach, IEnumerable>> target = (Foreach x) => x.Collection;
			workflowStep.Inputs.Add(new MemberMapParameter(collection, target));
			Expression<Func<Foreach, bool>> target2 = (Foreach x) => x.RunParallel;
			workflowStep.Inputs.Add(new MemberMapParameter(runParallel, target2));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, Foreach> result = new StepBuilder<TData, Foreach>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, While, While> While(Expression<Func<TData, bool>> condition)
		{
			WorkflowStep<While> workflowStep = new WorkflowStep<While>();
			Expression<Func<While, bool>> target = (While x) => x.Condition;
			workflowStep.Inputs.Add(new MemberMapParameter(condition, target));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, While> result = new StepBuilder<TData, While>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, While, While> While(Expression<Func<TData, IStepExecutionContext, bool>> condition)
		{
			WorkflowStep<While> workflowStep = new WorkflowStep<While>();
			Expression<Func<While, bool>> target = (While x) => x.Condition;
			workflowStep.Inputs.Add(new MemberMapParameter(condition, target));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, While> result = new StepBuilder<TData, While>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, If, If> If(Expression<Func<TData, bool>> condition)
		{
			WorkflowStep<If> workflowStep = new WorkflowStep<If>();
			Expression<Func<If, bool>> target = (If x) => x.Condition;
			workflowStep.Inputs.Add(new MemberMapParameter(condition, target));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, If> result = new StepBuilder<TData, If>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, If, If> If(Expression<Func<TData, IStepExecutionContext, bool>> condition)
		{
			WorkflowStep<If> workflowStep = new WorkflowStep<If>();
			Expression<Func<If, bool>> target = (If x) => x.Condition;
			workflowStep.Inputs.Add(new MemberMapParameter(condition, target));
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, If> result = new StepBuilder<TData, If>(WorkflowBuilder, workflowStep);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, When, OutcomeSwitch> When(Expression<Func<TData, object>> outcomeValue, string label = null)
		{
			WorkflowStep<When> workflowStep = new WorkflowStep<When>();
			Expression<Func<When, object>> target = (When x) => x.ExpectedOutcome;
			workflowStep.Inputs.Add(new MemberMapParameter(outcomeValue, target));
			IStepBuilder<TData, OutcomeSwitch> stepBuilder;
			if (Step.BodyType != typeof(OutcomeSwitch))
			{
				WorkflowStep<OutcomeSwitch> workflowStep2 = new WorkflowStep<OutcomeSwitch>();
				WorkflowBuilder.AddStep(workflowStep2);
				Step.Outcomes.Add(new ValueOutcome
				{
					NextStep = workflowStep2.Id,
					Label = label
				});
				stepBuilder = new StepBuilder<TData, OutcomeSwitch>(WorkflowBuilder, workflowStep2);
			}
			else
			{
				stepBuilder = this as IStepBuilder<TData, OutcomeSwitch>;
			}
			WorkflowBuilder.AddStep(workflowStep);
			ReturnStepBuilder<TData, When, OutcomeSwitch> result = new ReturnStepBuilder<TData, When, OutcomeSwitch>(WorkflowBuilder, workflowStep, stepBuilder);
			stepBuilder.Step.Children.Add(workflowStep.Id);
			return result;
		}

		public IStepBuilder<TData, Sequence> Saga(Action<IWorkflowBuilder<TData>> builder)
		{
			SagaContainer<Sequence> sagaContainer = new SagaContainer<Sequence>();
			WorkflowBuilder.AddStep(sagaContainer);
			StepBuilder<TData, Sequence> stepBuilder = new StepBuilder<TData, Sequence>(WorkflowBuilder, sagaContainer);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = sagaContainer.Id
			});
			builder(WorkflowBuilder);
			stepBuilder.Step.Children.Add(stepBuilder.Step.Id + 1);
			return stepBuilder;
		}

		public IParallelStepBuilder<TData, Sequence> Parallel()
		{
			WorkflowStep<Sequence> workflowStep = new WorkflowStep<Sequence>();
			StepBuilder<TData, Sequence> stepBuilder = new StepBuilder<TData, Sequence>(WorkflowBuilder, workflowStep);
			WorkflowBuilder.AddStep(workflowStep);
			ParallelStepBuilder<TData, Sequence> result = new ParallelStepBuilder<TData, Sequence>(WorkflowBuilder, stepBuilder, stepBuilder);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, Schedule, TStepBody> Schedule(Expression<Func<TData, TimeSpan>> time)
		{
			WorkflowStep<Schedule> workflowStep = new WorkflowStep<Schedule>();
			Expression<Func<Schedule, TimeSpan>> target = (Schedule x) => x.Interval;
			workflowStep.Inputs.Add(new MemberMapParameter(time, target));
			WorkflowBuilder.AddStep(workflowStep);
			ReturnStepBuilder<TData, Schedule, TStepBody> result = new ReturnStepBuilder<TData, Schedule, TStepBody>(WorkflowBuilder, workflowStep, this);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IContainerStepBuilder<TData, Recur, TStepBody> Recur(Expression<Func<TData, TimeSpan>> interval, Expression<Func<TData, bool>> until)
		{
			WorkflowStep<Recur> workflowStep = new WorkflowStep<Recur>();
			workflowStep.CancelCondition = until;
			Expression<Func<Recur, TimeSpan>> target = (Recur x) => x.Interval;
			Expression<Func<Recur, bool>> target2 = (Recur x) => x.StopCondition;
			workflowStep.Inputs.Add(new MemberMapParameter(interval, target));
			workflowStep.Inputs.Add(new MemberMapParameter(until, target2));
			WorkflowBuilder.AddStep(workflowStep);
			ReturnStepBuilder<TData, Recur, TStepBody> result = new ReturnStepBuilder<TData, Recur, TStepBody>(WorkflowBuilder, workflowStep, this);
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return result;
		}

		public IStepBuilder<TData, TStepBody> Do(Action<IWorkflowBuilder<TData>> builder)
		{
			builder(WorkflowBuilder);
			Step.Children.Add(Step.Id + 1);
			return this;
		}

		public IStepBuilder<TData, TStepBody> CompensateWith<TStep>(Action<IStepBuilder<TData, TStep>> stepSetup = null) where TStep : IStepBody
		{
			WorkflowStep<TStep> workflowStep = new WorkflowStep<TStep>();
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, TStep> obj = new StepBuilder<TData, TStep>(WorkflowBuilder, workflowStep);
			stepSetup?.Invoke(obj);
			workflowStep.Name = workflowStep.Name ?? typeof(TStep).Name;
			Step.CompensationStepId = workflowStep.Id;
			return this;
		}

		public IStepBuilder<TData, TStepBody> CompensateWith(Func<IStepExecutionContext, ExecutionResult> body)
		{
			WorkflowStepInline workflowStepInline = new WorkflowStepInline();
			workflowStepInline.Body = body;
			WorkflowBuilder.AddStep(workflowStepInline);
			new StepBuilder<TData, InlineStepBody>(WorkflowBuilder, workflowStepInline);
			Step.CompensationStepId = workflowStepInline.Id;
			return this;
		}

		public IStepBuilder<TData, TStepBody> CompensateWith(Action<IStepExecutionContext> body)
		{
			WorkflowStep<ActionStepBody> workflowStep = new WorkflowStep<ActionStepBody>();
			WorkflowBuilder.AddStep(workflowStep);
			new StepBuilder<TData, ActionStepBody>(WorkflowBuilder, workflowStep).Input((ActionStepBody x) => x.Body, (TData x) => body);
			Step.CompensationStepId = workflowStep.Id;
			return this;
		}

		public IStepBuilder<TData, TStepBody> CompensateWithSequence(Action<IWorkflowBuilder<TData>> builder)
		{
			WorkflowStep<Sequence> workflowStep = new WorkflowStep<Sequence>();
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, Sequence> stepBuilder = new StepBuilder<TData, Sequence>(WorkflowBuilder, workflowStep);
			Step.CompensationStepId = workflowStep.Id;
			builder(WorkflowBuilder);
			stepBuilder.Step.Children.Add(stepBuilder.Step.Id + 1);
			return this;
		}

		public IStepBuilder<TData, TStepBody> CancelCondition(Expression<Func<TData, bool>> cancelCondition, bool proceedAfterCancel = false)
		{
			Step.CancelCondition = cancelCondition;
			Step.ProceedOnCancel = proceedAfterCancel;
			return this;
		}

		public IStepBuilder<TData, Activity> Activity(string activityName, Expression<Func<TData, object>> parameters = null, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null)
		{
			WorkflowStep<Activity> workflowStep = new WorkflowStep<Activity>();
			workflowStep.CancelCondition = cancelCondition;
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, Activity> stepBuilder = new StepBuilder<TData, Activity>(WorkflowBuilder, workflowStep);
			stepBuilder.Input((Activity step) => step.ActivityName, (TData data) => activityName);
			if (parameters != null)
			{
				stepBuilder.Input((Activity step) => step.Parameters, parameters);
			}
			if (effectiveDate != null)
			{
				stepBuilder.Input((Activity step) => step.EffectiveDate, effectiveDate);
			}
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return stepBuilder;
		}

		public IStepBuilder<TData, Activity> Activity(Expression<Func<TData, IStepExecutionContext, string>> activityName, Expression<Func<TData, object>> parameters = null, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null)
		{
			WorkflowStep<Activity> workflowStep = new WorkflowStep<Activity>();
			workflowStep.CancelCondition = cancelCondition;
			WorkflowBuilder.AddStep(workflowStep);
			StepBuilder<TData, Activity> stepBuilder = new StepBuilder<TData, Activity>(WorkflowBuilder, workflowStep);
			stepBuilder.Input((Activity step) => step.ActivityName, activityName);
			if (parameters != null)
			{
				stepBuilder.Input((Activity step) => step.Parameters, parameters);
			}
			if (effectiveDate != null)
			{
				stepBuilder.Input((Activity step) => step.EffectiveDate, effectiveDate);
			}
			Step.Outcomes.Add(new ValueOutcome
			{
				NextStep = workflowStep.Id
			});
			return stepBuilder;
		}
	}
}
