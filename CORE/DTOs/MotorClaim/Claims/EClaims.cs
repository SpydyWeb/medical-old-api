using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class EClaims
	{
		public int Id { get; set; }

		public string ReportType { get; set; }

		public string ReportNumber { get; set; }

		public string Takdeer { get; set; }

		public string NationalId { get; set; }

		public string PhoneNumber { get; set; }

		public DateTime BirthDate { get; set; }

		public string PolicySegment { get; set; }

		public string BankName { get; set; }

		public string ReportCopy { get; set; }

		public string TakdeerCopy { get; set; }

		public string NationalIdCopy { get; set; }

		public string BankCopy { get; set; }

		public string BankIban { get; set; }
	}
}
