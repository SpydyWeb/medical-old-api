using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services.BackgroundTasks
{
	internal class RunnablePoller : IBackgroundTask
	{
		private readonly IPersistenceProvider _persistenceStore;

		private readonly IDistributedLockProvider _lockProvider;

		private readonly IQueueProvider _queueProvider;

		private readonly ILogger _logger;

		private readonly IGreyList _greylist;

		private readonly WorkflowOptions _options;

		private readonly IDateTimeProvider _dateTimeProvider;

		private Timer _pollTimer;

		public RunnablePoller(IPersistenceProvider persistenceStore, IQueueProvider queueProvider, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IWorkflowRegistry registry, IDistributedLockProvider lockProvider, IGreyList greylist, IDateTimeProvider dateTimeProvider, WorkflowOptions options)
		{
			_persistenceStore = persistenceStore;
			_greylist = greylist;
			_queueProvider = queueProvider;
			_logger = loggerFactory.CreateLogger<RunnablePoller>();
			_lockProvider = lockProvider;
			_dateTimeProvider = dateTimeProvider;
			_options = options;
		}

		public void Start()
		{
			_pollTimer = new Timer(PollRunnables, null, TimeSpan.FromSeconds(0.0), _options.PollInterval);
		}

		public void Stop()
		{
			if (_pollTimer != null)
			{
				_pollTimer.Dispose();
				_pollTimer = null;
			}
		}

		private async void PollRunnables(object target)
		{
			await PollWorkflows();
			await PollEvents();
			await PollCommands();
		}

		private async Task PollWorkflows()
		{
			Activity activity = WorkflowActivity.StartPoll("workflows");
			try
			{
				if (!(await _lockProvider.AcquireLock("poll runnables", default(CancellationToken))))
				{
					return;
				}
				try
				{
					_logger.LogDebug("Polling for runnable workflows");
					foreach (string item in await _persistenceStore.GetRunnableInstances(_dateTimeProvider.Now))
					{
						if (_persistenceStore.SupportsScheduledCommands)
						{
							try
							{
								await _persistenceStore.ScheduleCommand(new ScheduledCommand
								{
									CommandName = "ProcessWorkflow",
									Data = item,
									ExecuteTime = _dateTimeProvider.UtcNow.Ticks
								});
							}
							catch (Exception ex)
							{
								_logger.LogError(ex, ex.Message);
								activity?.RecordException(ex);
								goto IL_026c;
							}
							continue;
						}
						goto IL_026c;
						IL_026c:
						if (_greylist.Contains("wf:" + item))
						{
							_logger.LogDebug("Got greylisted workflow " + item);
							continue;
						}
						_logger.LogDebug("Got runnable instance {0}", item);
						_greylist.Add("wf:" + item);
						await _queueProvider.QueueWork(item, QueueType.Workflow);
					}
				}
				finally
				{
					await _lockProvider.ReleaseLock("poll runnables");
				}
			}
			catch (Exception ex2)
			{
				_logger.LogError(ex2, ex2.Message);
				activity?.RecordException(ex2);
			}
			finally
			{
				activity?.Dispose();
			}
		}

		private async Task PollEvents()
		{
			Activity activity = WorkflowActivity.StartPoll("events");
			try
			{
				if (!(await _lockProvider.AcquireLock("unprocessed events", default(CancellationToken))))
				{
					return;
				}
				try
				{
					_logger.LogDebug("Polling for unprocessed events");
					foreach (string item in (await _persistenceStore.GetRunnableEvents(_dateTimeProvider.Now)).ToList())
					{
						if (_persistenceStore.SupportsScheduledCommands)
						{
							try
							{
								await _persistenceStore.ScheduleCommand(new ScheduledCommand
								{
									CommandName = "ProcessEvent",
									Data = item,
									ExecuteTime = _dateTimeProvider.UtcNow.Ticks
								});
							}
							catch (Exception ex)
							{
								_logger.LogError(ex, ex.Message);
								activity?.RecordException(ex);
								goto IL_0271;
							}
							continue;
						}
						goto IL_0271;
						IL_0271:
						if (_greylist.Contains("evt:" + item))
						{
							_logger.LogDebug("Got greylisted event " + item);
							continue;
						}
						_logger.LogDebug("Got unprocessed event " + item);
						_greylist.Add("evt:" + item);
						await _queueProvider.QueueWork(item, QueueType.Event);
					}
				}
				finally
				{
					await _lockProvider.ReleaseLock("unprocessed events");
				}
			}
			catch (Exception ex2)
			{
				_logger.LogError(ex2, ex2.Message);
				activity?.RecordException(ex2);
			}
			finally
			{
				activity?.Dispose();
			}
		}

		private async Task PollCommands()
		{
			Activity activity = WorkflowActivity.StartPoll("commands");
			try
			{
				if (!_persistenceStore.SupportsScheduledCommands || !(await _lockProvider.AcquireLock("poll-commands", default(CancellationToken))))
				{
					return;
				}
				try
				{
					_logger.LogDebug("Polling for scheduled commands");
					await _persistenceStore.ProcessCommands(new DateTimeOffset(_dateTimeProvider.UtcNow), async delegate(ScheduledCommand command)
					{
						string commandName = command.CommandName;
						if (!(commandName == "ProcessWorkflow"))
						{
							if (commandName == "ProcessEvent")
							{
								await _queueProvider.QueueWork(command.Data, QueueType.Event);
							}
						}
						else
						{
							await _queueProvider.QueueWork(command.Data, QueueType.Workflow);
						}
					});
				}
				finally
				{
					await _lockProvider.ReleaseLock("poll-commands");
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				activity?.RecordException(ex);
			}
			finally
			{
				activity?.Dispose();
			}
		}
	}
}
