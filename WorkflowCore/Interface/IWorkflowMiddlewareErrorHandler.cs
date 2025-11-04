using System;
using System.Threading.Tasks;

namespace WorkflowCore.Interface
{
	public interface IWorkflowMiddlewareErrorHandler
	{
		Task HandleAsync(Exception ex);
	}
}
