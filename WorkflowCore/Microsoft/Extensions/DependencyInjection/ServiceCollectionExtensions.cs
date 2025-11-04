using System;
using System.Linq;
using Microsoft.Extensions.ObjectPool;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Primitives;
using WorkflowCore.Services;
using WorkflowCore.Services.BackgroundTasks;
using WorkflowCore.Services.ErrorHandlers;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddWorkflow(this IServiceCollection services, Action<WorkflowOptions> setupAction = null)
		{
			if (services.Any((ServiceDescriptor x) => x.ServiceType == typeof(WorkflowOptions)))
			{
				throw new InvalidOperationException("Workflow services already registered");
			}
			WorkflowOptions workflowOptions = new WorkflowOptions(services);
			setupAction?.Invoke(workflowOptions);
			services.AddSingleton<ISingletonMemoryProvider, MemoryPersistenceProvider>();
			services.AddTransient(workflowOptions.PersistanceFactory);
			services.AddTransient((Func<IServiceProvider, IWorkflowRepository>)workflowOptions.PersistanceFactory);
			services.AddTransient((Func<IServiceProvider, ISubscriptionRepository>)workflowOptions.PersistanceFactory);
			services.AddTransient((Func<IServiceProvider, IEventRepository>)workflowOptions.PersistanceFactory);
			services.AddSingleton(workflowOptions.QueueFactory);
			services.AddSingleton(workflowOptions.LockFactory);
			services.AddSingleton(workflowOptions.EventHubFactory);
			services.AddSingleton(workflowOptions.SearchIndexFactory);
			services.AddSingleton<IWorkflowRegistry, WorkflowRegistry>();
			services.AddSingleton(workflowOptions);
			services.AddSingleton<ILifeCycleEventPublisher, LifeCycleEventPublisher>();
			if (workflowOptions.EnableWorkflows)
			{
				services.AddTransient<IBackgroundTask, WorkflowConsumer>();
			}
			if (workflowOptions.EnableEvents)
			{
				services.AddTransient<IBackgroundTask, EventConsumer>();
			}
			if (workflowOptions.EnableIndexes)
			{
				services.AddTransient<IBackgroundTask, IndexConsumer>();
			}
			if (workflowOptions.EnablePolling)
			{
				services.AddTransient<IBackgroundTask, RunnablePoller>();
			}
			services.AddTransient((Func<IServiceProvider, IBackgroundTask>)((IServiceProvider sp) => sp.GetService<ILifeCycleEventPublisher>()));
			services.AddTransient<IWorkflowErrorHandler, CompensateHandler>();
			services.AddTransient<IWorkflowErrorHandler, RetryHandler>();
			services.AddTransient<IWorkflowErrorHandler, TerminateHandler>();
			services.AddTransient<IWorkflowErrorHandler, SuspendHandler>();
			services.AddSingleton<IGreyList, GreyList>();
			services.AddSingleton<IWorkflowController, WorkflowController>();
			services.AddSingleton<IActivityController, ActivityController>();
			services.AddSingleton<IWorkflowHost, WorkflowHost>();
			services.AddTransient<IStepExecutor, StepExecutor>();
			services.AddTransient<IWorkflowMiddlewareErrorHandler, DefaultWorkflowMiddlewareErrorHandler>();
			services.AddTransient<IWorkflowMiddlewareRunner, WorkflowMiddlewareRunner>();
			services.AddTransient<IScopeProvider, ScopeProvider>();
			services.AddTransient<IWorkflowExecutor, WorkflowExecutor>();
			services.AddTransient<ICancellationProcessor, CancellationProcessor>();
			services.AddTransient<IWorkflowBuilder, WorkflowBuilder>();
			services.AddTransient<IDateTimeProvider, DateTimeProvider>();
			services.AddTransient<IExecutionResultProcessor, ExecutionResultProcessor>();
			services.AddTransient<IExecutionPointerFactory, ExecutionPointerFactory>();
			services.AddTransient<IPooledObjectPolicy<IPersistenceProvider>, InjectedObjectPoolPolicy<IPersistenceProvider>>();
			services.AddTransient<IPooledObjectPolicy<IWorkflowExecutor>, InjectedObjectPoolPolicy<IWorkflowExecutor>>();
			services.AddTransient<ISyncWorkflowRunner, SyncWorkflowRunner>();
			services.AddTransient<Foreach>();
			return services;
		}

		public static IServiceCollection AddWorkflowStepMiddleware<TMiddleware>(this IServiceCollection services, Func<IServiceProvider, TMiddleware> factory = null) where TMiddleware : class, IWorkflowStepMiddleware
		{
			if (factory != null)
			{
				return services.AddTransient<IWorkflowStepMiddleware, TMiddleware>(factory);
			}
			return services.AddTransient<IWorkflowStepMiddleware, TMiddleware>();
		}

		public static IServiceCollection AddWorkflowMiddleware<TMiddleware>(this IServiceCollection services, Func<IServiceProvider, TMiddleware> factory = null) where TMiddleware : class, IWorkflowMiddleware
		{
			if (factory != null)
			{
				return services.AddTransient<IWorkflowMiddleware, TMiddleware>(factory);
			}
			return services.AddTransient<IWorkflowMiddleware, TMiddleware>();
		}
	}
}
