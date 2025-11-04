using System;
using System.Linq.Expressions;
using WorkflowCore.Models;

namespace WorkflowCore.Interface
{
	public interface IStepBuilder<TData, TStepBody> : IWorkflowModifier<TData, TStepBody> where TStepBody : IStepBody
	{
		IWorkflowBuilder<TData> WorkflowBuilder { get; }

		WorkflowStep<TStepBody> Step { get; set; }

		IStepBuilder<TData, TStepBody> Name(string name);

		IStepBuilder<TData, TStepBody> Id(string id);

		IStepBuilder<TData, TStepBody> Attach(string id);

		[Obsolete]
		IStepOutcomeBuilder<TData> When(object outcomeValue, string label = null);

		IStepBuilder<TData, TStepBody> Branch<TStep>(object outcomeValue, IStepBuilder<TData, TStep> branch) where TStep : IStepBody;

		IStepBuilder<TData, TStepBody> Branch<TStep>(Expression<Func<TData, object, bool>> outcomeExpression, IStepBuilder<TData, TStep> branch) where TStep : IStepBody;

		IStepBuilder<TData, TStepBody> Input<TInput>(Expression<Func<TStepBody, TInput>> stepProperty, Expression<Func<TData, TInput>> value);

		IStepBuilder<TData, TStepBody> Input<TInput>(Expression<Func<TStepBody, TInput>> stepProperty, Expression<Func<TData, IStepExecutionContext, TInput>> value);

		IStepBuilder<TData, TStepBody> Input(Action<TStepBody, TData> action);

		IStepBuilder<TData, TStepBody> Input(Action<TStepBody, TData, IStepExecutionContext> action);

		IStepBuilder<TData, TStepBody> Output<TOutput>(Expression<Func<TData, TOutput>> dataProperty, Expression<Func<TStepBody, object>> value);

		IStepBuilder<TData, TStepBody> Output(Action<TStepBody, TData> action);

		IStepBuilder<TData, TStep> End<TStep>(string name) where TStep : IStepBody;

		IStepBuilder<TData, TStepBody> OnError(WorkflowErrorHandling behavior, TimeSpan? retryInterval = null);

		IStepBuilder<TData, TStepBody> EndWorkflow();

		IStepBuilder<TData, TStepBody> CompensateWith<TStep>(Action<IStepBuilder<TData, TStep>> stepSetup = null) where TStep : IStepBody;

		IStepBuilder<TData, TStepBody> CompensateWith(Func<IStepExecutionContext, ExecutionResult> body);

		IStepBuilder<TData, TStepBody> CompensateWith(Action<IStepExecutionContext> body);

		IStepBuilder<TData, TStepBody> CompensateWithSequence(Action<IWorkflowBuilder<TData>> builder);

		IStepBuilder<TData, TStepBody> CancelCondition(Expression<Func<TData, bool>> cancelCondition, bool proceedAfterCancel = false);
	}
}
