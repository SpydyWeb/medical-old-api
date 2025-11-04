using System;

namespace CORE.DTOs.MotorClaim
{
	public class ProductionInfo
	{
		public int Id { get; set; }

		public string PolicyNumber { get; set; }

		public int PolicyType { get; set; }

		public DateTime PolicyEffectiveDate { get; set; }

		public DateTime PolicyExpiryDate { get; set; }

		public string OwnerId { get; set; }

		public string OwnerName { get; set; }

		public DateTime PolicyIssueDate { get; set; }

		public int PolicyId { get; set; }

		public string BusinessType { get; set; }

		public int PolicyUWYear { get; set; }

		public DateTime TransferDate { get; set; }

		public string? LesseeName { get; set; }

		public string? LesseeId { get; set; }

		public string? BenefecieryName { get; set; }

		public int? BusinessTypeId { get; set; }

		public int? BranchId { get; set; }

		public string? BranchName { get; set; }

		public int? InsuredId { get; set; }

		public string? Insured { get; set; }

		public string? PolicyTypeName { get; set; }
	}
}
