using System;

namespace CORE.TablesObjects
{
	public class Approvals
	{
		public int Id { get; set; }

		public string PolicyNo { get; set; }

		public long PolicyId { get; set; }

		public string Attachments { get; set; }

		public string CustomerName { get; set; }

		public int Status { get; set; }

		public string? RejectionReason { get; set; }

		public DateTime? ResponseTime { get; set; }

		public DateTime RequestDate { get; set; }
	}
}
