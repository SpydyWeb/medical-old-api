using System;

namespace CORE.DTOs.APIs.Business
{
	public class LoadDocumentList
	{
		public string? CreatedBy { get; set; }

		public int? RoleId { get; set; }

		public string? PolicyNo { get; set; } = null;


		public string? SponserNo { get; set; } = null;


		public string? ClientName { get; set; } = null;


		public DateTime? IssueDate { get; set; } = null;


		public int? Status { get; set; } = null;


		public int? Count { get; set; } = null;

	}
}
