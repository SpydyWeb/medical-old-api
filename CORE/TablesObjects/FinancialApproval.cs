using System;

namespace CORE.TablesObjects
{
	public class FinancialApproval
	{
		public int Id { get; set; }

		public string Attachment { get; set; }

		public string CustomerName { get; set; }

		public string CommercialRegistration { get; set; }

		public int Status { get; set; }

		public string RejectionReason { get; set; }

		public DateTime? ResponseDate { get; set; }

		public DateTime RequestDate { get; set; }

		public long policyId { get; set; }
	}
}
