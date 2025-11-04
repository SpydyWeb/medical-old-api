namespace SharedSetup.Domain.DTO.Financial
{
	public class BanksInput
	{
		public int? ID { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public string Address { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string Email { get; set; }

		public string ChequeName { get; set; }

		public int CompanyId { get; set; }

		public string IsAccessible { get; set; }

		public string DefaultAll { get; set; }

		public string DefaultAR { get; set; }

		public string DefaultAP { get; set; }
	}
}
