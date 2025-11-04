using System;

namespace Domain.Models.SearchCriteria
{
	public class MpdPoliciesSearchCriteria
	{
		public int? PolicyNo { get; set; }

		public int? PolicyHolderId { get; set; }

		public int? EndorsmentNo { get; set; }

		public int? PolicyType { get; set; }

		public int? PlanNo { get; set; }

		public int? BusinessType { get; set; }

		public DateTime? IssueDate { get; set; }

		public DateTime? EffectiveDate { get; set; }

		public DateTime? ExpiryDate { get; set; }

		public int? MemberId { get; set; }

		public int? CCHIStatus { get; set; }

		public int? UploudStatus { get; set; }

		public int? DocumentType { get; set; }

		public int? MasterDocumentId { get; set; }

		public int? MpdPlcId { get; set; }

		public int PageIndex { get; set; }

		public int PageSize { get; set; }

		public string Query { get; set; }
	}
}
