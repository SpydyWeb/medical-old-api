using System;

namespace CORE.DTOs.APIs.Business
{
	public class MMPInsert
	{
		public int Id { get; set; }

		public string NationalId { get; set; }

		public string Sponsor { get; set; }

		public string? DateOfBirth { get; set; }

		public string Mobile { get; set; }

		public string AccountManagerMobile { get; set; }

		public string Email { get; set; }

		public string? InsurerName { get; set; }

		public string? PolicyNumber { get; set; }

		public DateTime? ExpiryDate { get; set; }

		public bool? Proffision2Q { get; set; }

		public string? txtProffision2Q { get; set; }

		public bool? Proffision3Q { get; set; }

		public string? txtProffision3Q { get; set; }

		public bool? Proffision4Q { get; set; }

		public string? txtProffision4Q { get; set; }

		public bool? Proffision5Q { get; set; }

		public string? txtProffision5Q { get; set; }

		public string IndemnityLimit { get; set; }

		public string AggregatedLimit { get; set; }

		public DateTime EffectiveDate { get; set; }

		public int PolicyPeriod { get; set; }

		public int ProffessionId { get; set; }

		public DateTime? Retroactive { get; set; }

		public bool Proffision1Q { get; set; }
	}
}
