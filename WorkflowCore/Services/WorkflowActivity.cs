using System.Diagnostics;
using OpenTelemetry.Trace;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services
{
	internal static class WorkflowActivity
	{
		private static readonly ActivitySource ActivitySource = new ActivitySource("WorkflowCore");

		internal static Activity StartHost()
		{
			string name = "workflow start host";
			return ActivitySource.StartRootActivity(name, ActivityKind.Internal);
		}

		internal static Activity StartConsume(QueueType queueType)
		{
			string name = "workflow consume " + GetQueueType(queueType);
			Activity activity = ActivitySource.StartRootActivity(name, ActivityKind.Consumer);
			if (activity != null)
			{
				activity.SetTag("workflow.queue", queueType);
				return activity;
			}
			return activity;
		}

		internal static Activity StartPoll(string type)
		{
			string name = "workflow poll " + type;
			Activity activity = ActivitySource.StartRootActivity(name, ActivityKind.Client);
			if (activity != null)
			{
				activity.SetTag("workflow.poll", type);
				return activity;
			}
			return activity;
		}

		internal static void Enrich(WorkflowInstance workflow, string action)
		{
			Activity current = Activity.Current;
			if (current != null)
			{
				current.DisplayName = "workflow " + action + " " + workflow.WorkflowDefinitionId;
				current.SetTag("workflow.id", workflow.Id);
				current.SetTag("workflow.definition", workflow.WorkflowDefinitionId);
				current.SetTag("workflow.status", workflow.Status);
			}
		}

		internal static void Enrich(WorkflowStep workflowStep)
		{
			Activity current = Activity.Current;
			if (current != null)
			{
				string text = (string.IsNullOrEmpty(workflowStep.Name) ? "inline" : workflowStep.Name);
				current.DisplayName = current.DisplayName + " step " + text;
				current.SetTag("workflow.step.id", workflowStep.Id);
				current.SetTag("workflow.step.name", workflowStep.Name);
				current.SetTag("workflow.step.type", workflowStep.BodyType.Name);
			}
		}

		internal static void Enrich(WorkflowExecutorResult result)
		{
			Activity current = Activity.Current;
			if (current != null)
			{
				current.SetTag("workflow.subscriptions.count", result.Subscriptions.Count);
				current.SetTag("workflow.errors.count", result.Errors.Count);
				if (result.Errors.Count > 0)
				{
					current.SetStatus(Status.Error);
					current.SetStatus(ActivityStatusCode.Error);
				}
			}
		}

		internal static void Enrich(Event evt)
		{
			Activity current = Activity.Current;
			if (current != null)
			{
				current.DisplayName = "workflow process " + evt.EventName;
				current.SetTag("workflow.event.id", evt.Id);
				current.SetTag("workflow.event.name", evt.EventName);
				current.SetTag("workflow.event.processed", evt.IsProcessed);
			}
		}

		internal static void EnrichWithDequeuedItem(this Activity activity, string item)
		{
			activity?.SetTag("workflow.queue.item", item);
		}

		private static Activity StartRootActivity(this ActivitySource activitySource, string name, ActivityKind kind)
		{
			Activity.Current = null;
			return activitySource.StartActivity(name, kind);
		}

		private static string GetQueueType(QueueType queueType)
		{
			return queueType switch
			{
				QueueType.Workflow => "workflow", 
				QueueType.Event => "event", 
				QueueType.Index => "index", 
				_ => "unknown", 
			};
		}
	}
}
