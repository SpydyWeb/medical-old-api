using System;

namespace Domain.Models.SearchCriteria
{
	public class EntitiesSearch
	{
		public long CompanyId { get; set; }

		public long[] EntityType { get; set; }

		public string SegmentCode { get; set; }

		public string Country { get; set; }

		public long? BusinessSector { get; set; }

		public long? SubSector { get; set; }

		public long? Subsidiary { get; set; }

		public string HoldingCompany { get; set; }

		public string RegistrationNo { get; set; }

		public long? DateType { get; set; }

		public DateTime? FromDate { get; set; }

		public DateTime? ToDate { get; set; }

		public long? Status { get; set; }

		public long? Stage { get; set; }

		public long? KYCCleared { get; set; }
	}
}
