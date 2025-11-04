namespace Domain.Models.DTOs
{
	public class SstCoverTypesDTO
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public short? RateFraction { get; set; }

		public bool? IsAutoAdd { get; set; }

		public bool? IsEditable { get; set; }

		public bool? IsBasicCover { get; set; }

		public bool? IsAgentCommission { get; set; }

		public bool? ApplyPremium { get; set; }

		public short? DeductibleFrom { get; set; }
	}
}
