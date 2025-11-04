using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;

namespace WorkflowCore.Services
{
	public class DefaultWorkflowMiddlewareErrorHandler : IWorkflowMiddlewareErrorHandler
	{
		private readonly ILogger<DefaultWorkflowMiddlewareErrorHandler> _log;

		public DefaultWorkflowMiddlewareErrorHandler(ILogger<DefaultWorkflowMiddlewareErrorHandler> log)
		{
			_log = log;
		}

		public Task HandleAsync(Exception ex)
		{
			_log.LogError(ex, "An error occurred running workflow middleware: {Message}", ex.Message);
			return Task.CompletedTask;
		}
	}
}
