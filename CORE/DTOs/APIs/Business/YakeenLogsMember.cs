using System;

namespace CORE.DTOs.APIs.Business
{
	public class YakeenLogsMember
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string NationalId { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public string Sponsor { get; set; }

		public string Nationality { get; set; }

		public int MartialStatus { get; set; }

		public int Gender { get; set; }

		public int? Relation { get; set; }

		public DateTime RecordDate { get; set; }

		public int Occupation { get; set; }

		public DateTime? IdentityExpiryDate { get; set; }
	}
}
