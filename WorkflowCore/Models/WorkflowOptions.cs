using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Services;

namespace WorkflowCore.Models
{
	public class WorkflowOptions
	{
		internal Func<IServiceProvider, IPersistenceProvider> PersistanceFactory;

		internal Func<IServiceProvider, IQueueProvider> QueueFactory;

		internal Func<IServiceProvider, IDistributedLockProvider> LockFactory;

		internal Func<IServiceProvider, ILifeCycleEventHub> EventHubFactory;

		internal Func<IServiceProvider, ISearchIndex> SearchIndexFactory;

		internal TimeSpan PollInterval;

		internal TimeSpan IdleTime;

		internal TimeSpan ErrorRetryInterval;

		internal int MaxConcurrentWorkflows = Math.Max(Environment.ProcessorCount, 4);

		public IServiceCollection Services { get; private set; }

		public bool EnableWorkflows { get; set; } = true;


		public bool EnableEvents { get; set; } = true;


		public bool EnableIndexes { get; set; } = true;


		public bool EnablePolling { get; set; } = true;


		public bool EnableLifeCycleEventsPublisher { get; set; } = true;


		public WorkflowOptions(IServiceCollection services)
		{
			Services = services;
			PollInterval = TimeSpan.FromSeconds(10.0);
			IdleTime = TimeSpan.FromMilliseconds(100.0);
			ErrorRetryInterval = TimeSpan.FromSeconds(60.0);
			QueueFactory = (IServiceProvider sp) => new SingleNodeQueueProvider();
			LockFactory = (IServiceProvider sp) => new SingleNodeLockProvider();
			PersistanceFactory = (IServiceProvider sp) => new TransientMemoryPersistenceProvider(sp.GetService<ISingletonMemoryProvider>());
			SearchIndexFactory = (IServiceProvider sp) => new NullSearchIndex();
			EventHubFactory = (IServiceProvider sp) => new SingleNodeEventHub(sp.GetService<ILoggerFactory>());
		}

		public void UsePersistence(Func<IServiceProvider, IPersistenceProvider> factory)
		{
			PersistanceFactory = factory;
		}

		public void UseDistributedLockManager(Func<IServiceProvider, IDistributedLockProvider> factory)
		{
			LockFactory = factory;
		}

		public void UseQueueProvider(Func<IServiceProvider, IQueueProvider> factory)
		{
			QueueFactory = factory;
		}

		public void UseEventHub(Func<IServiceProvider, ILifeCycleEventHub> factory)
		{
			EventHubFactory = factory;
		}

		public void UseSearchIndex(Func<IServiceProvider, ISearchIndex> factory)
		{
			SearchIndexFactory = factory;
		}

		public void UsePollInterval(TimeSpan interval)
		{
			PollInterval = interval;
		}

		public void UseErrorRetryInterval(TimeSpan interval)
		{
			ErrorRetryInterval = interval;
		}

		public void UseIdleTime(TimeSpan interval)
		{
			IdleTime = interval;
		}

		public void UseMaxConcurrentWorkflows(int maxConcurrentWorkflows)
		{
			MaxConcurrentWorkflows = maxConcurrentWorkflows;
		}
	}
}
