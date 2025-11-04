using System;

namespace WorkflowCore.Interface
{
	public interface IContainerStepBuilder<TData, TStepBody, TReturnStep> where TStepBody : IStepBody where TReturnStep : IStepBody
	{
		IStepBuilder<TData, TReturnStep> Do(Action<IWorkflowBuilder<TData>> builder);
	}
}
