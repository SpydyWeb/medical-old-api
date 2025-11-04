using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace WorkflowCore.Services
{
	public class ScopeProvider : IScopeProvider
	{
		private readonly IServiceScopeFactory _serviceScopeFactory;

		public ScopeProvider(IServiceScopeFactory serviceScopeFactory)
		{
			_serviceScopeFactory = serviceScopeFactory;
		}

		public IServiceScope CreateScope(IStepExecutionContext context)
		{
			return _serviceScopeFactory.CreateScope();
		}
	}
}
