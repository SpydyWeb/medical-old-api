using System.Threading.Tasks;
using WorkflowCore.Models;

namespace WorkflowCore.Interface
{
	public interface IWorkflowStepMiddleware
	{
		Task<ExecutionResult> HandleAsync(IStepExecutionContext context, IStepBody body, WorkflowStepDelegate next);
	}
}
