using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class ClaimTransactions
	{
		public int Id { get; set; }

		public int TransactionType { get; set; }

		public DateTime TransactionDate { get; set; }

		public decimal TransactionAmount { get; set; }

		public decimal? Commission { get; set; }

		public decimal? Fees { get; set; }

		public int? ParentTransactions { get; set; }

		public int ClaimantID { get; set; }

		public long ClaimId { get; set; }

		public int? Collector { get; set; }

		public string? Note { get; set; }

		public string? Payment { get; set; }

		public string? CollectionType { get; set; }

		public bool isActive { get; set; }

		public string CreatedBy { get; set; }
	}
}
