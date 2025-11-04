namespace SharedSetup.Domain.DTO.Financial
{
	public class BankBranchesInput
	{
		public string Address { get; set; }

		public int? Code { get; set; }

		public string ContactPerson { get; set; }

		public int? CompanyId { get; set; }

		public string DefaultAll { get; set; }

		public string DefaultAP { get; set; }

		public string DefaultAR { get; set; }

		public string Email { get; set; }

		public string Fax { get; set; }

		public int? BankCode { get; set; }

		public string IsAccessible { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public string Phone { get; set; }

		public decimal? ReturnFees { get; set; }

		public decimal? ReturnFeesPercentage { get; set; }

		public string SwiftCode { get; set; }

		public string Username { get; set; }
	}
}
