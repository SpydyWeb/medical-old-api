using System;

namespace CORE.DTOs.MotorClaim.WorkFlow
{
	public class DelegationSetup
	{
		public int Id { get; set; }

		public DateTime From { get; set; }

		public DateTime To { get; set; }

		public string DelegateFrom { get; set; }

		public string DelegateTo { get; set; }

		public string? CreatedBy { get; set; }

		public string? ModifiedBy { get; set; }

		public int DelegateFromId { get; set; }

		public int DelegateToId { get; set; }
	}
}
