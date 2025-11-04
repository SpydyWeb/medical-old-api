using System;
using System.Collections.Generic;
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
	internal abstract class QueueConsumer : IBackgroundTask
	{
		protected readonly IQueueProvider QueueProvider;

		protected readonly ILogger Logger;

		protected readonly WorkflowOptions Options;

		protected Task DispatchTask;

		private CancellationTokenSource _cancellationTokenSource;

		private Dictionary<string, EventWaitHandle> _activeTasks;

		private ConcurrentHashSet<string> _secondPasses;

		protected abstract QueueType Queue { get; }

		protected virtual int MaxConcurrentItems => Math.Max(Environment.ProcessorCount, 2);

		protected virtual bool EnableSecondPasses => false;

		protected QueueConsumer(IQueueProvider queueProvider, ILoggerFactory loggerFactory, WorkflowOptions options)
		{
			QueueProvider = queueProvider;
			Options = options;
			Logger = loggerFactory.CreateLogger(GetType());
			_activeTasks = new Dictionary<string, EventWaitHandle>();
			_secondPasses = new ConcurrentHashSet<string>();
		}

		protected abstract Task ProcessItem(string itemId, CancellationToken cancellationToken);

		public virtual void Start()
		{
			if (DispatchTask != null)
			{
				throw new InvalidOperationException();
			}
			_cancellationTokenSource = new CancellationTokenSource();
			DispatchTask = Task.Factory.StartNew((Func<Task>)Execute, TaskCreationOptions.LongRunning);
		}

		public virtual void Stop()
		{
			_cancellationTokenSource.Cancel();
			if (DispatchTask != null)
			{
				DispatchTask.Wait();
				DispatchTask = null;
			}
		}

		private async Task Execute()
		{
			CancellationToken cancelToken = _cancellationTokenSource.Token;
			while (!cancelToken.IsCancellationRequested)
			{
				Activity activity = null;
				try
				{
					int num = 0;
					lock (_activeTasks)
					{
						num = _activeTasks.Count;
					}
					if (num >= MaxConcurrentItems)
					{
						await Task.Delay(Options.IdleTime);
						continue;
					}
					activity = WorkflowActivity.StartConsume(Queue);
					string text = await QueueProvider.DequeueWork(Queue, cancelToken);
					if (text == null)
					{
						activity?.Dispose();
						if (!QueueProvider.IsDequeueBlocking)
						{
							await Task.Delay(Options.IdleTime, cancelToken);
						}
						continue;
					}
					activity?.EnrichWithDequeuedItem(text);
					bool flag = false;
					lock (_activeTasks)
					{
						flag = _activeTasks.ContainsKey(text);
					}
					if (flag)
					{
						_secondPasses.Add(text);
						if (!EnableSecondPasses)
						{
							await QueueProvider.QueueWork(text, Queue);
						}
						activity?.Dispose();
						continue;
					}
					_secondPasses.TryRemove(text);
					ManualResetEvent manualResetEvent = new ManualResetEvent(initialState: false);
					lock (_activeTasks)
					{
						_activeTasks.Add(text, manualResetEvent);
					}
					ExecuteItem(text, manualResetEvent, activity);
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception ex2)
				{
					Logger.LogError(ex2, ex2.Message);
					activity?.RecordException(ex2);
				}
				finally
				{
					activity?.Dispose();
				}
			}
			List<EventWaitHandle> list;
			lock (_activeTasks)
			{
				list = _activeTasks.Values.ToList();
			}
			foreach (EventWaitHandle item in list)
			{
				item.WaitOne();
			}
		}

		private async Task ExecuteItem(string itemId, EventWaitHandle waitHandle, Activity activity)
		{
			_ = 1;
			try
			{
				await ProcessItem(itemId, _cancellationTokenSource.Token);
				while (EnableSecondPasses && _secondPasses.Contains(itemId))
				{
					_secondPasses.TryRemove(itemId);
					await ProcessItem(itemId, _cancellationTokenSource.Token);
				}
			}
			catch (OperationCanceledException)
			{
				Logger.LogInformation("Operation cancelled while processing " + itemId);
			}
			catch (Exception ex2)
			{
				Logger.LogError(default(EventId), ex2, "Error executing item " + itemId + " - " + ex2.Message);
				activity?.RecordException(ex2);
			}
			finally
			{
				waitHandle.Set();
				lock (_activeTasks)
				{
					_activeTasks.Remove(itemId);
				}
			}
		}
	}
}
