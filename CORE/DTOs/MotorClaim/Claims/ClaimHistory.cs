using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class ClaimHistory
	{
		public int Id { get; set; }

		public long ClaimId { get; set; }

		public int Status { get; set; }

		public string Reason { get; set; }

		public DateTime ChangeDate { get; set; }

		public int UserId { get; set; }
	}
}
