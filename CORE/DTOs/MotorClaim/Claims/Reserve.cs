using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class Reserve
	{
		public int Id { get; set; }

		public int ClaimId { get; set; }

		public int TransactionId { get; set; }

		public int CreatedBy { get; set; }

		public string CreatedByName { get; set; }

		public DateTime Creationdate { get; set; }

		public decimal? SparePartCost { get; set; }

		public decimal? LaborCost { get; set; }

		public decimal? OtherCost { get; set; }

		public string? Note { get; set; }
	}
}
