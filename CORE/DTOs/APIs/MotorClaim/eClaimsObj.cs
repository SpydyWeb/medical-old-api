using System;

namespace CORE.DTOs.APIs.MotorClaim
{
	public class eClaimsObj
	{
		public int? Status { get; set; }

		public string? AccidentReport { get; set; }

		public string? Reference { get; set; }

		public string? SequenceNumber { get; set; }

		public string? TaqdeerNumber { get; set; }

		public string? OwnerNationalID { get; set; }

		public DateTime? RegisteredFrom { get; set; }

		public DateTime? RegisteredTo { get; set; }
	}
}
