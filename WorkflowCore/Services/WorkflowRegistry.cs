using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services
{
	public class WorkflowRegistry : IWorkflowRegistry
	{
		private readonly IServiceProvider _serviceProvider;

		private readonly ConcurrentDictionary<string, WorkflowDefinition> _registry = new ConcurrentDictionary<string, WorkflowDefinition>();

		private readonly ConcurrentDictionary<string, WorkflowDefinition> _lastestVersion = new ConcurrentDictionary<string, WorkflowDefinition>();

		public WorkflowRegistry(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public WorkflowDefinition GetDefinition(string workflowId, int? version = null)
		{
			if (version.HasValue)
			{
				if (!_registry.ContainsKey($"{workflowId}-{version}"))
				{
					return null;
				}
				return _registry[$"{workflowId}-{version}"];
			}
			if (!_lastestVersion.ContainsKey(workflowId))
			{
				return null;
			}
			return _lastestVersion[workflowId];
		}

		public void DeregisterWorkflow(string workflowId, int version)
		{
			if (!_registry.ContainsKey($"{workflowId}-{version}"))
			{
				return;
			}
			lock (_registry)
			{
				_registry.TryRemove($"{workflowId}-{version}", out var value);
				if (_lastestVersion[workflowId].Version == version)
				{
					_lastestVersion.TryRemove(workflowId, out value);
					WorkflowDefinition workflowDefinition = (from x in _registry.Values
						where x.Id == workflowId
						orderby x.Version descending
						select x).FirstOrDefault();
					if (workflowDefinition != null)
					{
						_lastestVersion[workflowId] = workflowDefinition;
					}
				}
			}
		}

		public void RegisterWorkflow(IWorkflow workflow)
		{
			IWorkflowBuilder<object> workflowBuilder = _serviceProvider.GetService<IWorkflowBuilder>().UseData<object>();
			workflow.Build(workflowBuilder);
			WorkflowDefinition definition = workflowBuilder.Build(workflow.Id, workflow.Version);
			RegisterWorkflow(definition);
		}

		public void RegisterWorkflow(WorkflowDefinition definition)
		{
			if (_registry.ContainsKey($"{definition.Id}-{definition.Version}"))
			{
				throw new InvalidOperationException($"Workflow {definition.Id} version {definition.Version} is already registered");
			}
			lock (_registry)
			{
				_registry[$"{definition.Id}-{definition.Version}"] = definition;
				if (!_lastestVersion.ContainsKey(definition.Id))
				{
					_lastestVersion[definition.Id] = definition;
				}
				else if (_lastestVersion[definition.Id].Version <= definition.Version)
				{
					_lastestVersion[definition.Id] = definition;
				}
			}
		}

		public void RegisterWorkflow<TData>(IWorkflow<TData> workflow) where TData : new()
		{
			IWorkflowBuilder<TData> workflowBuilder = _serviceProvider.GetService<IWorkflowBuilder>().UseData<TData>();
			workflow.Build(workflowBuilder);
			WorkflowDefinition definition = workflowBuilder.Build(workflow.Id, workflow.Version);
			RegisterWorkflow(definition);
		}

		public bool IsRegistered(string workflowId, int version)
		{
			return _registry.ContainsKey($"{workflowId}-{version}");
		}

		public IEnumerable<WorkflowDefinition> GetAllDefinitions()
		{
			return _registry.Values;
		}
	}
}
