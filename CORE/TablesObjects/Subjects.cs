using System;

namespace CORE.TablesObjects
{
	public class Subjects
	{
		public int Id { get; set; }

		public int SumInsured { get; set; }

		public string? MemberNo { get; set; }

		public string Name { get; set; }

		public string? Name2 { get; set; }

		public string NationalId { get; set; }

		public string? PassportNo { get; set; }

		public string? Occupation { get; set; }

		public string? Height { get; set; }

		public string? Weight { get; set; }

		public string? Mobile { get; set; }

		public string CreatedBy { get; set; }

		public DateTime CreationDate { get; set; }

		public string? NationalityCode { get; set; }

		public string? IdentityExpiryDate { get; set; }

		public int PolicyId { get; set; }

		public DateTime IssueDate { get; set; }

		public DateTime EffectiveDate { get; set; }

		public DateTime ExpiryDate { get; set; }

		public decimal GrossAmount { get; set; }

		public decimal TotalFees { get; set; }

		public decimal CommissionAmount { get; set; }

		public decimal VAT { get; set; }

		public decimal? DiscountAmount { get; set; }

		public decimal? LoadingAmount { get; set; }

		public decimal NetPremium { get; set; }

		public string? PlateNo { get; set; }

		public string? ChassisNo { get; set; }

		public int? NoOfSeats { get; set; }

		public string? OwnerName { get; set; }

		public int? ProductionYear { get; set; }

		public int? Usage { get; set; }

		public int? BodyType { get; set; }

		public int? Make { get; set; }

		public int? Model { get; set; }

		public int? RepaireCondition { get; set; }

		public int? Deductible { get; set; }

		public string? SequanceNo { get; set; }

		public string? CustomNo { get; set; }

		public string? Princible { get; set; }

		public int? ClassId { get; set; }

		public int? Relation { get; set; }

		public int? MartialStatus { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public int? Age { get; set; }

		public int? Gender { get; set; }

		public bool? PushedToYakeen { get; set; }

		public string? YakeenError { get; set; }

		public bool? NeedsReCalculation { get; set; }

		public string? HijriDate { get; set; }

		public bool? IsCancelled { get; set; } = false;


		public int? LiabilityId { get; set; }

		public int? PolicyPeriod { get; set; }

		public int? ProffessionId { get; set; }

		public DateTime? Retroactive { get; set; }

		public string? PreviouseInsurerName { get; set; }

		public string? PreviousePolicyNumber { get; set; }

		public DateTime? PreviouseExpiryDate { get; set; }

		public string? AggregatedLimit { get; set; }

		public string? IndemnityLimit { get; set; }

		public bool? Proffision2Q { get; set; }

		public string? txtProffision2Q { get; set; }

		public bool? Proffision3Q { get; set; }

		public string? txtProffision3Q { get; set; }

		public bool? Proffision4Q { get; set; }

		public bool? Proffision1Q { get; set; }

		public string? txtProffision4Q { get; set; }

		public decimal? AdditionalPremium { get; set; }
        public int? InsuranceClassCode { get; set; }
    }
}
