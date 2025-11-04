using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services
{
	public class StepExecutor : IStepExecutor
	{
		private readonly IEnumerable<IWorkflowStepMiddleware> _stepMiddleware;

		public StepExecutor(IEnumerable<IWorkflowStepMiddleware> stepMiddleware)
		{
			_stepMiddleware = stepMiddleware;
		}

		public async Task<ExecutionResult> ExecuteStep(IStepExecutionContext context, IStepBody body)
		{
			return await _stepMiddleware.Reverse().Aggregate<IWorkflowStepMiddleware, WorkflowStepDelegate>(Step, (WorkflowStepDelegate previous, IWorkflowStepMiddleware middleware) => () => middleware.HandleAsync(context, body, previous))();
			Task<ExecutionResult> Step()
			{
				return body.RunAsync(context);
			}
		}
	}
}
