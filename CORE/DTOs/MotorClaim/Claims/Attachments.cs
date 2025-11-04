using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class Attachments
	{
		public int Id { get; set; }

		public int ModuleId { get; set; }

		public int? ClaimId { get; set; }

		public int? ClaimantId { get; set; }

		public string FileName { get; set; }

		public string ContentType { get; set; }

		public int DocumentSetupId { get; set; }

		public bool? IsDeleted { get; set; }

		public string? DeletedBy { get; set; }

		public DateTime? DeletionDate { get; set; }

		public string CreatedBy { get; set; }

		public DateTime CreationDate { get; set; }

		public string? ModifiedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }
	}
}
