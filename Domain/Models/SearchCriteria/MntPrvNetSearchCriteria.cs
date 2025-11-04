namespace Domain.Models.SearchCriteria
{
	public class MntPrvNetSearchCriteria
	{
		public long NetworkID { get; set; }

		public long? BranchId { get; set; }

		public long? ProviderType { get; set; }

		public long? ProviderName { get; set; }

		public long? Specialty { get; set; }

		public long? ProviderNumber { get; set; }

		public long? ParentProviderID { get; set; }

		public string CountryCode { get; set; }

		public long? CityCode { get; set; }

		public string AreaCode { get; set; }

		public long? StatusID { get; set; }

		public long? Classification { get; set; }

		public long? MemberID { get; set; }

		public long? NationalID { get; set; }

		public long? XCoordinates { get; set; }

		public long? YCoordinates { get; set; }

		public long? HOID { get; set; }

		public long? LicenseNo { get; set; }

		public long? CCHIStatus { get; set; }

		public long? PageSize { get; set; }

		public long? PageNumber { get; set; }

		public string SortExpression { get; set; }

		public long? Lang { get; set; }
	}
}
