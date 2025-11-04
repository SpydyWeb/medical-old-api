using System;

namespace SharedSetup.Domain.DTO.Financial
{
	public class StatementOfAccountRequest
	{
		public string Branches { get; set; }

		public int CustomerId { get; set; }

		public int IsPosted { get; set; }

		public DateTime FromDate { get; set; }

		public DateTime ToDate { get; set; }

		public string Currency { get; set; }

		public int? Account { get; set; }

		public int CompanyId { get; set; }

		public int? StatementType { get; set; }
	}
}
