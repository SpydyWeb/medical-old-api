using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Primitives
{
	public class Foreach : ContainerStepBody
	{
		public IEnumerable Collection { get; set; }

		public bool RunParallel { get; set; } = true;


		public override ExecutionResult Run(IStepExecutionContext context)
		{
			if (context.PersistenceData == null)
			{
				List<object> list = Collection.Cast<object>().ToList();
				if (!list.Any())
				{
					return ExecutionResult.Next();
				}
				if (RunParallel)
				{
					return ExecutionResult.Branch(new List<object>(list), new IteratorPersistenceData
					{
						ChildrenActive = true
					});
				}
				return ExecutionResult.Branch(new List<object>(new object[1] { list.ElementAt(0) }), new IteratorPersistenceData
				{
					ChildrenActive = true
				});
			}
			if (context.PersistenceData is IteratorPersistenceData iteratorPersistenceData && iteratorPersistenceData != null && iteratorPersistenceData.ChildrenActive)
			{
				if (context.Workflow.IsBranchComplete(context.ExecutionPointer.Id))
				{
					if (!RunParallel)
					{
						IEnumerable<object> source = Collection.Cast<object>();
						iteratorPersistenceData.Index++;
						if (iteratorPersistenceData.Index < source.Count())
						{
							return ExecutionResult.Branch(new List<object>(new object[1] { source.ElementAt(iteratorPersistenceData.Index) }), iteratorPersistenceData);
						}
					}
					return ExecutionResult.Next();
				}
				return ExecutionResult.Persist(iteratorPersistenceData);
			}
			if (context.PersistenceData is ControlPersistenceData controlPersistenceData && controlPersistenceData != null && controlPersistenceData.ChildrenActive && context.Workflow.IsBranchComplete(context.ExecutionPointer.Id))
			{
				return ExecutionResult.Next();
			}
			return ExecutionResult.Persist(context.PersistenceData);
		}
	}
}
