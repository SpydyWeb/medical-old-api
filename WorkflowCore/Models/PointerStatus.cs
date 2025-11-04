namespace WorkflowCore.Models
{
	public enum PointerStatus
	{
		Legacy,
		Pending,
		Running,
		Complete,
		Sleeping,
		WaitingForEvent,
		Failed,
		Compensated,
		Cancelled,
		PendingPredecessor
	}
}
