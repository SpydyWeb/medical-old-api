using CORE.Extensions;

namespace CORE.DTOs.APIs.MotorClaim
{
	public class SetupClaimsRequestcs
	{
		public object Request { get; set; }

		public ClaimTransactionType TransactionType { get; set; }
	}
}
