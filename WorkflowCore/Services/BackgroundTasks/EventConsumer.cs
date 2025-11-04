using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services.BackgroundTasks
{
	internal class EventConsumer : QueueConsumer, IBackgroundTask
	{
		private readonly IWorkflowRepository _workflowRepository;

		private readonly ISubscriptionRepository _subscriptionRepository;

		private readonly IEventRepository _eventRepository;

		private readonly IDistributedLockProvider _lockProvider;

		private readonly IDateTimeProvider _datetimeProvider;

		private readonly IGreyList _greylist;

		protected override int MaxConcurrentItems => 2;

		protected override QueueType Queue => QueueType.Event;

		public EventConsumer(IWorkflowRepository workflowRepository, ISubscriptionRepository subscriptionRepository, IEventRepository eventRepository, IQueueProvider queueProvider, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IWorkflowRegistry registry, IDistributedLockProvider lockProvider, WorkflowOptions options, IDateTimeProvider datetimeProvider, IGreyList greylist)
			: base(queueProvider, loggerFactory, options)
		{
			_workflowRepository = workflowRepository;
			_greylist = greylist;
			_subscriptionRepository = subscriptionRepository;
			_eventRepository = eventRepository;
			_lockProvider = lockProvider;
			_datetimeProvider = datetimeProvider;
		}

		protected override async Task ProcessItem(string itemId, CancellationToken cancellationToken)
		{
			if (!(await _lockProvider.AcquireLock("evt:" + itemId, cancellationToken)))
			{
				Logger.LogInformation("Event locked " + itemId);
				return;
			}
			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				Event evt = await _eventRepository.GetEvent(itemId, cancellationToken);
				WorkflowActivity.Enrich(evt);
				if (evt.IsProcessed)
				{
					_greylist.Add("evt:" + evt.Id);
					return;
				}
				if (!(evt.EventTime <= _datetimeProvider.UtcNow))
				{
					return;
				}
				IEnumerable<EventSubscription> source;
				if (evt.EventData is ActivityResult)
				{
					EventSubscription eventSubscription = await _subscriptionRepository.GetSubscription((evt.EventData as ActivityResult).SubscriptionId, cancellationToken);
					if (eventSubscription == null)
					{
						Logger.LogWarning("Activity already processed - " + (evt.EventData as ActivityResult).SubscriptionId);
						await _eventRepository.MarkEventProcessed(itemId, cancellationToken);
						return;
					}
					source = new List<EventSubscription> { eventSubscription };
				}
				else
				{
					source = await _subscriptionRepository.GetSubscriptions(evt.EventName, evt.EventKey, evt.EventTime, cancellationToken);
				}
				HashSet<string> toQueue = new HashSet<string>();
				bool flag = true;
				foreach (EventSubscription item in source.ToList())
				{
					bool flag2 = flag;
					if (flag2)
					{
						flag2 = await SeedSubscription(evt, item, toQueue, cancellationToken);
					}
					flag = flag2;
				}
				if (flag)
				{
					await _eventRepository.MarkEventProcessed(itemId, cancellationToken);
				}
				else
				{
					_greylist.Remove("evt:" + evt.Id);
				}
				foreach (string item2 in toQueue)
				{
					await QueueProvider.QueueWork(item2, QueueType.Event);
				}
			}
			finally
			{
				await _lockProvider.ReleaseLock("evt:" + itemId);
			}
		}

		private async Task<bool> SeedSubscription(Event evt, EventSubscription sub, HashSet<string> toQueue, CancellationToken cancellationToken)
		{
			foreach (string eventId in await _eventRepository.GetEvents(sub.EventName, sub.EventKey, sub.SubscribeAsOf, cancellationToken))
			{
				if (!(eventId == evt.Id))
				{
					Event @event = await _eventRepository.GetEvent(eventId, cancellationToken);
					if (!@event.IsProcessed && @event.EventTime < evt.EventTime)
					{
						await QueueProvider.QueueWork(eventId, QueueType.Event);
						return false;
					}
					if (!@event.IsProcessed)
					{
						toQueue.Add(@event.Id);
					}
				}
			}
			if (!(await _lockProvider.AcquireLock(sub.WorkflowId, cancellationToken)))
			{
				Logger.LogInformation("Workflow locked {0}", sub.WorkflowId);
				return false;
			}
			bool result;
			try
			{
				int num;
				//_ = num - 4;
				_ = 2;
				try
				{
					WorkflowInstance workflowInstance = await _workflowRepository.GetWorkflowInstance(sub.WorkflowId, cancellationToken);
					IEnumerable<ExecutionPointer> enumerable = (string.IsNullOrEmpty(sub.ExecutionPointerId) ? workflowInstance.ExecutionPointers.Where((ExecutionPointer p) => p.EventName == sub.EventName && p.EventKey == sub.EventKey && !p.EventPublished && !p.EndTime.HasValue) : workflowInstance.ExecutionPointers.Where((ExecutionPointer p) => p.Id == sub.ExecutionPointerId && !p.EventPublished && !p.EndTime.HasValue));
					foreach (ExecutionPointer item in enumerable)
					{
						item.EventData = evt.EventData;
						item.EventPublished = true;
						item.Active = true;
					}
					workflowInstance.NextExecution = 0L;
					await _workflowRepository.PersistWorkflow(workflowInstance, cancellationToken);
					await _subscriptionRepository.TerminateSubscription(sub.Id, cancellationToken);
					result = true;
				}
				catch (Exception ex)
				{
					Logger.LogError(ex, ex.Message);
					result = false;
				}
			}
			finally
			{
				await _lockProvider.ReleaseLock(sub.WorkflowId);
				await QueueProvider.QueueWork(sub.WorkflowId, QueueType.Workflow);
			}
			return result;
		}
	}
}
