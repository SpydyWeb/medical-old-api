namespace WorkflowCore.Models
{
	public enum WorkflowErrorHandling
	{
		Retry,
		Suspend,
		Terminate,
		Compensate
	}
}
