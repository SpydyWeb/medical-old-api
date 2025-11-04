using System;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class FiscalYearInput
	{
		public int CompanyId { get; set; }

		public DateTime? DateFrom { get; set; }

		public DateTime? DateTo { get; set; }

		public int? IsClosed { get; set; }

		public int Year { get; set; }
	}
}
