using System;

namespace CORE.DTOs.APIs.Business
{
	public class FilterDocumentInput
	{
		public string? PolicyChar { get; set; }

		public DateTime? FromEffectiveDate { get; set; }

		public DateTime? FromIssueDate { get; set; }

		public DateTime? ToEffectiveDate { get; set; }

		public DateTime? ToIssueDate { get; set; }

		public int? Status { get; set; }

		public bool? IsPaid { get; set; }

		public int? DocumentType { get; set; }

		public int UserId { get; set; }
	}
}
