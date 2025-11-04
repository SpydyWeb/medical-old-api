using System;

namespace SharedSetup.Domain.DTO.Financial
{
	public class FiscalYearDTO
	{
		public int CompanyId { get; set; }

		public DateTime DateFrom { get; set; }

		public DateTime DateTo { get; set; }

		public int IsClosed { get; set; }

		public int Year { get; set; }
	}
}
