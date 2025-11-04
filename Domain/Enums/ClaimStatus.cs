namespace Domain.Enums
{
	public enum ClaimStatus
	{
		Open = 1,
		Closed,
		Rejected,
		ConfirmedFraud,
		OnHold,
		PartiallyPaid,
		PartiallyRecovered,
		CompletePayment,
		CompleteRecovery,
		PendingForRecovery
	}
}
