using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services
{
	public class WorkflowMiddlewareRunner : IWorkflowMiddlewareRunner
	{
		private static readonly WorkflowDelegate NoopWorkflowDelegate = () => Task.CompletedTask;

		private readonly IEnumerable<IWorkflowMiddleware> _middleware;

		private readonly IServiceProvider _serviceProvider;

		public WorkflowMiddlewareRunner(IEnumerable<IWorkflowMiddleware> middleware, IServiceProvider serviceProvider)
		{
			_middleware = middleware;
			_serviceProvider = serviceProvider;
		}

		public async Task RunPreMiddleware(WorkflowInstance workflow, WorkflowDefinition def)
		{
			IEnumerable<IWorkflowMiddleware> middlewareCollection = _middleware.Where((IWorkflowMiddleware m) => m.Phase == WorkflowMiddlewarePhase.PreWorkflow);
			await RunWorkflowMiddleware(workflow, middlewareCollection);
		}

		public Task RunPostMiddleware(WorkflowInstance workflow, WorkflowDefinition def)
		{
			return RunWorkflowMiddlewareWithErrorHandling(workflow, WorkflowMiddlewarePhase.PostWorkflow, def.OnPostMiddlewareError);
		}

		public Task RunExecuteMiddleware(WorkflowInstance workflow, WorkflowDefinition def)
		{
			return RunWorkflowMiddlewareWithErrorHandling(workflow, WorkflowMiddlewarePhase.ExecuteWorkflow, def.OnExecuteMiddlewareError);
		}

		public async Task RunWorkflowMiddlewareWithErrorHandling(WorkflowInstance workflow, WorkflowMiddlewarePhase phase, Type middlewareErrorType)
		{
			IEnumerable<IWorkflowMiddleware> middlewareCollection = _middleware.Where((IWorkflowMiddleware m) => m.Phase == phase);
			try
			{
				await RunWorkflowMiddleware(workflow, middlewareCollection);
			}
			catch (Exception ex)
			{
				Type serviceType = middlewareErrorType ?? typeof(IWorkflowMiddlewareErrorHandler);
				using IServiceScope scope = _serviceProvider.CreateScope();
				if (scope.ServiceProvider.GetService(serviceType) is IWorkflowMiddlewareErrorHandler workflowMiddlewareErrorHandler)
				{
					await workflowMiddlewareErrorHandler.HandleAsync(ex);
				}
			}
		}

		private static Task RunWorkflowMiddleware(WorkflowInstance workflow, IEnumerable<IWorkflowMiddleware> middlewareCollection)
		{
			return middlewareCollection.Reverse().Aggregate<IWorkflowMiddleware, WorkflowDelegate>(NoopWorkflowDelegate, (WorkflowDelegate previous, IWorkflowMiddleware middleware) => () => middleware.HandleAsync(workflow, previous))();
		}
	}
}
