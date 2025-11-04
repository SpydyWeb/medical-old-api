using System.Threading.Tasks;
using WorkflowCore.Models;

namespace WorkflowCore.Interface
{
	public interface IStepExecutor
	{
		Task<ExecutionResult> ExecuteStep(IStepExecutionContext context, IStepBody body);
	}
}
