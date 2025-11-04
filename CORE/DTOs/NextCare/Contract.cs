using System;

namespace CORE.DTOs.NextCare
{
	public class Contract
	{
		public int contractId { get; set; }

		public string index { get; set; }

		public string name { get; set; }

		public string irsid { get; set; }

		public int professionId { get; set; }

		public int nbrPrincipals { get; set; }

		public int nbrBeneficiaries { get; set; }

		public string contactName { get; set; }

		public string contactName2 { get; set; }

		public DateTime workHoursStart { get; set; }

		public DateTime workHoursEnd { get; set; }

		public string externalRef { get; set; }

		public int debitTo { get; set; }

		public int ledger { get; set; }

		public int accountNbr { get; set; }

		public int payModeId { get; set; }

		public int payBy { get; set; }

		public string authorization { get; set; }

		public string bank { get; set; }

		public string bankAccNbr { get; set; }

		public string coBrand { get; set; }

		public string policyHolderPin { get; set; }

		public int policyHolder { get; set; }

		public string classOfBusiness { get; set; }

		public string companyRegister { get; set; }

		public string cchiPolicyPin { get; set; }

		public int licensingAuthority { get; set; }

		public int entityType { get; set; }

		public string mainSponsorNumber { get; set; }

		public int employerPPID { get; set; }

		public bool blacklisted { get; set; }

		public DateTime tradeLicenseIssueDate { get; set; }

		public DateTime tradeLicenseExpiryDate { get; set; }

		public bool taxesCovered { get; set; }

		public string taxRegistrationNumber { get; set; }

		public string payerSubContractKey { get; set; }

		public string ibanNbr { get; set; }

		public int contactId { get; set; }

		public DateTime terminationDate { get; set; }

		public int payerProgramId { get; set; }

		public Paymentmethod paymentMethod { get; set; }

		public Address address { get; set; }

		public Endorsement endorsement { get; set; }
	}
}
