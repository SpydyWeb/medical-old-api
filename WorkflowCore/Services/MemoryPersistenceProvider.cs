using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services
{
	public class MemoryPersistenceProvider : ISingletonMemoryProvider, IPersistenceProvider, IWorkflowRepository, ISubscriptionRepository, IEventRepository, IScheduledCommandRepository
	{
		private readonly List<WorkflowInstance> _instances = new List<WorkflowInstance>();

		private readonly List<EventSubscription> _subscriptions = new List<EventSubscription>();

		private readonly List<Event> _events = new List<Event>();

		private readonly List<ExecutionError> _errors = new List<ExecutionError>();

		public bool SupportsScheduledCommands => false;

		public async Task<string> CreateNewWorkflow(WorkflowInstance workflow, CancellationToken _ = default(CancellationToken))
		{
			lock (_instances)
			{
				workflow.Id = Guid.NewGuid().ToString();
				_instances.Add(workflow);
				return workflow.Id;
			}
		}

		public async Task PersistWorkflow(WorkflowInstance workflow, CancellationToken _ = default(CancellationToken))
		{
			lock (_instances)
			{
				WorkflowInstance item = _instances.First((WorkflowInstance x) => x.Id == workflow.Id);
				_instances.Remove(item);
				_instances.Add(workflow);
			}
		}

		public async Task PersistWorkflow(WorkflowInstance workflow, List<EventSubscription> subscriptions, CancellationToken cancellationToken = default(CancellationToken))
		{
			lock (_instances)
			{
				WorkflowInstance item = _instances.First((WorkflowInstance x) => x.Id == workflow.Id);
				_instances.Remove(item);
				_instances.Add(workflow);
				lock (_subscriptions)
				{
					foreach (EventSubscription subscription in subscriptions)
					{
						subscription.Id = Guid.NewGuid().ToString();
						_subscriptions.Add(subscription);
					}
				}
			}
		}

		public async Task<IEnumerable<string>> GetRunnableInstances(DateTime asAt, CancellationToken _ = default(CancellationToken))
		{
			lock (_instances)
			{
				long now = asAt.ToUniversalTime().Ticks;
				return (from x in _instances
					where x.NextExecution.HasValue && x.NextExecution <= now
					select x.Id).ToList();
			}
		}

		public async Task<WorkflowInstance> GetWorkflowInstance(string Id, CancellationToken _ = default(CancellationToken))
		{
			lock (_instances)
			{
				return _instances.First((WorkflowInstance x) => x.Id == Id);
			}
		}

		public async Task<IEnumerable<WorkflowInstance>> GetWorkflowInstances(IEnumerable<string> ids, CancellationToken _ = default(CancellationToken))
		{
			if (ids == null)
			{
				return new List<WorkflowInstance>();
			}
			lock (_instances)
			{
				return _instances.Where((WorkflowInstance x) => ids.Contains(x.Id));
			}
		}

		public async Task<IEnumerable<WorkflowInstance>> GetWorkflowInstances(WorkflowStatus? status, string type, DateTime? createdFrom, DateTime? createdTo, int skip, int take)
		{
			lock (_instances)
			{
				IQueryable<WorkflowInstance> source = _instances.AsQueryable();
				if (status.HasValue)
				{
					source = source.Where((WorkflowInstance x) => (int)x.Status == (int)((WorkflowStatus?)status).Value);
				}
				if (!string.IsNullOrEmpty(type))
				{
					source = source.Where((WorkflowInstance x) => x.WorkflowDefinitionId == type);
				}
				if (createdFrom.HasValue)
				{
					source = source.Where((WorkflowInstance x) => x.CreateTime >= ((DateTime?)createdFrom).Value);
				}
				if (createdTo.HasValue)
				{
					source = source.Where((WorkflowInstance x) => x.CreateTime <= ((DateTime?)createdTo).Value);
				}
				return source.Skip(skip).Take(take).ToList();
			}
		}

		public async Task<string> CreateEventSubscription(EventSubscription subscription, CancellationToken _ = default(CancellationToken))
		{
			lock (_subscriptions)
			{
				subscription.Id = Guid.NewGuid().ToString();
				_subscriptions.Add(subscription);
				return subscription.Id;
			}
		}

		public async Task<IEnumerable<EventSubscription>> GetSubscriptions(string eventName, string eventKey, DateTime asOf, CancellationToken _ = default(CancellationToken))
		{
			lock (_subscriptions)
			{
				return _subscriptions.Where((EventSubscription x) => x.EventName == eventName && x.EventKey == eventKey && x.SubscribeAsOf <= asOf);
			}
		}

		public async Task TerminateSubscription(string eventSubscriptionId, CancellationToken _ = default(CancellationToken))
		{
			lock (_subscriptions)
			{
				EventSubscription item = _subscriptions.Single((EventSubscription x) => x.Id == eventSubscriptionId);
				_subscriptions.Remove(item);
			}
		}

		public Task<EventSubscription> GetSubscription(string eventSubscriptionId, CancellationToken _ = default(CancellationToken))
		{
			lock (_subscriptions)
			{
				return Task.FromResult(_subscriptions.Single((EventSubscription x) => x.Id == eventSubscriptionId));
			}
		}

		public Task<EventSubscription> GetFirstOpenSubscription(string eventName, string eventKey, DateTime asOf, CancellationToken _ = default(CancellationToken))
		{
			lock (_subscriptions)
			{
				return Task.FromResult(_subscriptions.FirstOrDefault((EventSubscription x) => x.ExternalToken == null && x.EventName == eventName && x.EventKey == eventKey && x.SubscribeAsOf <= asOf));
			}
		}

		public Task<bool> SetSubscriptionToken(string eventSubscriptionId, string token, string workerId, DateTime expiry, CancellationToken _ = default(CancellationToken))
		{
			lock (_subscriptions)
			{
				EventSubscription eventSubscription = _subscriptions.Single((EventSubscription x) => x.Id == eventSubscriptionId);
				eventSubscription.ExternalToken = token;
				eventSubscription.ExternalWorkerId = workerId;
				eventSubscription.ExternalTokenExpiry = expiry;
				return Task.FromResult(result: true);
			}
		}

		public Task ClearSubscriptionToken(string eventSubscriptionId, string token, CancellationToken _ = default(CancellationToken))
		{
			lock (_subscriptions)
			{
				EventSubscription eventSubscription = _subscriptions.Single((EventSubscription x) => x.Id == eventSubscriptionId);
				if (eventSubscription.ExternalToken != token)
				{
					throw new InvalidOperationException();
				}
				eventSubscription.ExternalToken = null;
				eventSubscription.ExternalWorkerId = null;
				eventSubscription.ExternalTokenExpiry = null;
				return Task.CompletedTask;
			}
		}

		public void EnsureStoreExists()
		{
		}

		public async Task<string> CreateEvent(Event newEvent, CancellationToken _ = default(CancellationToken))
		{
			lock (_events)
			{
				newEvent.Id = Guid.NewGuid().ToString();
				_events.Add(newEvent);
				return newEvent.Id;
			}
		}

		public async Task MarkEventProcessed(string id, CancellationToken _ = default(CancellationToken))
		{
			lock (_events)
			{
				Event @event = _events.FirstOrDefault((Event x) => x.Id == id);
				if (@event != null)
				{
					@event.IsProcessed = true;
				}
			}
		}

		public async Task<IEnumerable<string>> GetRunnableEvents(DateTime asAt, CancellationToken _ = default(CancellationToken))
		{
			lock (_events)
			{
				return (from x in _events
					where !x.IsProcessed
					where x.EventTime <= asAt.ToUniversalTime()
					select x.Id).ToList();
			}
		}

		public async Task<Event> GetEvent(string id, CancellationToken _ = default(CancellationToken))
		{
			lock (_events)
			{
				return _events.FirstOrDefault((Event x) => x.Id == id);
			}
		}

		public async Task<IEnumerable<string>> GetEvents(string eventName, string eventKey, DateTime asOf, CancellationToken _ = default(CancellationToken))
		{
			lock (_events)
			{
				return (from x in _events
					where x.EventName == eventName && x.EventKey == eventKey
					where x.EventTime >= asOf
					select x.Id).ToList();
			}
		}

		public async Task MarkEventUnprocessed(string id, CancellationToken _ = default(CancellationToken))
		{
			lock (_events)
			{
				Event @event = _events.FirstOrDefault((Event x) => x.Id == id);
				if (@event != null)
				{
					@event.IsProcessed = false;
				}
			}
		}

		public async Task PersistErrors(IEnumerable<ExecutionError> errors, CancellationToken _ = default(CancellationToken))
		{
			lock (errors)
			{
				_errors.AddRange(errors);
			}
		}

		public Task ScheduleCommand(ScheduledCommand command)
		{
			throw new NotImplementedException();
		}

		public Task ProcessCommands(DateTimeOffset asOf, Func<ScheduledCommand, Task> action, CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new NotImplementedException();
		}
	}
}
