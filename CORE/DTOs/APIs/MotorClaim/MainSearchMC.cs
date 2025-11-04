using System;

namespace CORE.DTOs.APIs.MotorClaim
{
	public class MainSearchMC
	{
		public int? Id { get; set; }

		public int? PolicyId { get; set; }

		public string? NationalID { get; set; }

		public int? ClaimId { get; set; }

		public int? ClaimantId { get; set; }

		public int? TransactionType { get; set; }

		public string? Sequence { get; set; }

		public int? ScoreFrom { get; set; }

		public int? ScoreTo { get; set; }

		public int? Status { get; set; }

		public int? ModuleId { get; set; }

		public int? UserId { get; set; }

		public int? WorkFlowId { get; set; }

		public int? TransactionId { get; set; }

		public int? ClaimStatus { get; set; }

		public string? OwnerId { get; set; }

		public string? Name { get; set; }

		public string? AccidentNo { get; set; }

		public string? claimno { get; set; }

		public string? mobile { get; set; }

		public string? chassis { get; set; }

		public string? policy { get; set; }

		public int? Branch { get; set; }

		public DateTime? RegisteredFrom { get; set; }

		public DateTime? RegisteredTo { get; set; }
	}
}
