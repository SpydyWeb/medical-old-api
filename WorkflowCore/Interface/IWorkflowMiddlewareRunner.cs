using System.Threading.Tasks;
using WorkflowCore.Models;

namespace WorkflowCore.Interface
{
	public interface IWorkflowMiddlewareRunner
	{
		Task RunPreMiddleware(WorkflowInstance workflow, WorkflowDefinition def);

		Task RunPostMiddleware(WorkflowInstance workflow, WorkflowDefinition def);

		Task RunExecuteMiddleware(WorkflowInstance workflow, WorkflowDefinition def);
	}
}
