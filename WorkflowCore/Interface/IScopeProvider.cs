using Microsoft.Extensions.DependencyInjection;

namespace WorkflowCore.Interface
{
	public interface IScopeProvider
	{
		IServiceScope CreateScope(IStepExecutionContext context);
	}
}
