namespace SharedSetup.Domain.DTO.Core
{
	public class LeadDTO
	{
		public bool IsInquiry { get; set; }

		public bool IsInquiryById { get; set; }

		public LeadObj LeadObj { get; set; }

		public bool ConvertToCustomer { get; set; }

		public int OpportunityId { get; set; }
	}
}
