namespace CORE.DTOs.NextCare
{
	public class Financialinformation
	{
		public int seqId { get; set; }

		public string bankPhoneNbr { get; set; }

		public string bankEmail { get; set; }

		public int bankCountryId { get; set; }

		public string bankName { get; set; }

		public string bankBranchName { get; set; }

		public string bankAccountName { get; set; }

		public string bankAccountNbr { get; set; }

		public int bankAccountType { get; set; }

		public string bankAcctValFromType { get; set; }

		public int bankCurrencyId { get; set; }

		public string bankSwiftCode { get; set; }

		public string bankAddress { get; set; }

		public string bankCity { get; set; }

		public string chequeMailAddress { get; set; }

		public int paymentType { get; set; }

		public string payTo { get; set; }

		public int deliveryTo { get; set; }

		public int chequeCountryId { get; set; }

		public int chequeRegionId { get; set; }

		public string city { get; set; }

		public string street { get; set; }

		public string building { get; set; }

		public string phoneNumber { get; set; }

		public string zipCode { get; set; }

		public int chequeSubRegionId { get; set; }

		public bool isDefault { get; set; }

		public bool islinkedToPolicy { get; set; }
	}
}
