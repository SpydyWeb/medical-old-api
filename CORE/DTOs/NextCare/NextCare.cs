using System;

namespace CORE.DTOs.NextCare
{
	public class NextCare
	{
		public string transactionNo { get; set; }

		public string name { get; set; }

		public DateTime effDate { get; set; }

		public DateTime expDate { get; set; }

		public bool isImported { get; set; }

		public DateTime startDate { get; set; }

		public Distributor distributor { get; set; }

		public string producer { get; set; }

		public int moralEntity { get; set; }

		public int nbrPrincipals { get; set; }

		public int nbrBeneficiaries { get; set; }

		public int currencyId { get; set; }

		public string contactName { get; set; }

		public string contactName2 { get; set; }

		public bool multipleContracts { get; set; }

		public DateTime quotationDate { get; set; }

		public DateTime validityDate { get; set; }

		public int nbrRenewals { get; set; }

		public string importedFromPayerId { get; set; }

		public int contactId { get; set; }

		public bool blackListed { get; set; }

		public bool hasSpecialReInsurance { get; set; }

		public string contractNoteFile { get; set; }

		public string policyHolderPin { get; set; }

		public int PolicyHolder { get; set; }

		public string applicationNbr { get; set; }

		public string payerPolicyKey { get; set; }

		public bool SkipCategories { get; set; }

		public bool generateBenefCards { get; set; }

		public bool excludeSendClaimsByWS { get; set; }

		public int lineOfBusiness { get; set; }

		public int fromCountry { get; set; }

		public int toCountry { get; set; }

		public DateTime dateOfPremSentForConfirmation { get; set; }

		public int visaValidity { get; set; }

		public int visaType { get; set; }

		public int visitType { get; set; }

		public string visaInsuranceNumber { get; set; }

		public string visaNumber { get; set; }

		public int source { get; set; }

		public string claimsEmailDestination { get; set; }

		public bool noPremiumRefund { get; set; }

		public int issuanceSource { get; set; }

		public string note { get; set; }

		public string previousPolicyNumber { get; set; }

		public Branch branch { get; set; }

		public Address address { get; set; }

		public Contract[] contracts { get; set; }

		public string contractNoteFileData { get; set; }

		public int sellingCurrency { get; set; }

		public string financialNote { get; set; }
	}
}
