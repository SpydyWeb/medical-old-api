using System;
using System.Collections;
using System.Linq.Expressions;
using WorkflowCore.Models;
using WorkflowCore.Primitives;

namespace WorkflowCore.Interface
{
	public interface IWorkflowModifier<TData, TStepBody> where TStepBody : IStepBody
	{
		IStepBuilder<TData, TStep> Then<TStep>(Action<IStepBuilder<TData, TStep>> stepSetup = null) where TStep : IStepBody;

		IStepBuilder<TData, TStep> Then<TStep>(IStepBuilder<TData, TStep> newStep) where TStep : IStepBody;

		IStepBuilder<TData, InlineStepBody> Then(Func<IStepExecutionContext, ExecutionResult> body);

		IStepBuilder<TData, ActionStepBody> Then(Action<IStepExecutionContext> body);

		IStepBuilder<TData, WaitFor> WaitFor(string eventName, Expression<Func<TData, string>> eventKey, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null);

		IStepBuilder<TData, WaitFor> WaitFor(string eventName, Expression<Func<TData, IStepExecutionContext, string>> eventKey, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null);

		IStepBuilder<TData, Delay> Delay(Expression<Func<TData, TimeSpan>> period);

		IStepBuilder<TData, Decide> Decide(Expression<Func<TData, object>> expression);

		IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IEnumerable>> collection);

		IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IEnumerable>> collection, Expression<Func<TData, bool>> runParallel);

		IContainerStepBuilder<TData, Foreach, Foreach> ForEach(Expression<Func<TData, IStepExecutionContext, IEnumerable>> collection, Expression<Func<TData, bool>> runParallel);

		IContainerStepBuilder<TData, While, While> While(Expression<Func<TData, bool>> condition);

		IContainerStepBuilder<TData, While, While> While(Expression<Func<TData, IStepExecutionContext, bool>> condition);

		IContainerStepBuilder<TData, If, If> If(Expression<Func<TData, bool>> condition);

		IContainerStepBuilder<TData, If, If> If(Expression<Func<TData, IStepExecutionContext, bool>> condition);

		IContainerStepBuilder<TData, When, OutcomeSwitch> When(Expression<Func<TData, object>> outcomeValue, string label = null);

		IParallelStepBuilder<TData, Sequence> Parallel();

		IStepBuilder<TData, Sequence> Saga(Action<IWorkflowBuilder<TData>> builder);

		IContainerStepBuilder<TData, Schedule, TStepBody> Schedule(Expression<Func<TData, TimeSpan>> time);

		IContainerStepBuilder<TData, Recur, TStepBody> Recur(Expression<Func<TData, TimeSpan>> interval, Expression<Func<TData, bool>> until);

		IStepBuilder<TData, Activity> Activity(string activityName, Expression<Func<TData, object>> parameters = null, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null);

		IStepBuilder<TData, Activity> Activity(Expression<Func<TData, IStepExecutionContext, string>> activityName, Expression<Func<TData, object>> parameters = null, Expression<Func<TData, DateTime>> effectiveDate = null, Expression<Func<TData, bool>> cancelCondition = null);
	}
}
