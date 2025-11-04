using System;
using WorkflowCore.Models;

namespace WorkflowCore.Interface
{
	public delegate void StepErrorEventHandler(WorkflowInstance workflow, WorkflowStep step, Exception exception);
}
