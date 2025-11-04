using System.Threading.Tasks;
using WorkflowCore.Models;

namespace WorkflowCore.Interface
{
	public interface IWorkflowMiddleware
	{
		WorkflowMiddlewarePhase Phase { get; }

		Task HandleAsync(WorkflowInstance workflow, WorkflowDelegate next);
	}
}
