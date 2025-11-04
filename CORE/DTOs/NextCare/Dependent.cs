using System;

namespace CORE.DTOs.NextCare
{
	public class Dependent
	{
		public int beneficiaryId { get; set; }

		public string index { get; set; }

		public int familyIndex { get; set; }

		public int principalId { get; set; }

		public string principalPin { get; set; }

		public string firstName { get; set; }

		public string middleName { get; set; }

		public string familyName { get; set; }

		public string maidenName { get; set; }

		public DateTime dob { get; set; }

		public int gender { get; set; }

		public int nationality { get; set; }

		public DateTime startDate { get; set; }

		public int importOP { get; set; }

		public bool importIsAmount { get; set; }

		public bool amountOnGrossPremium { get; set; }

		public string ssNbr { get; set; }

		public string beneficiaryPin { get; set; }

		public int idType { get; set; }

		public string idNumber { get; set; }

		public string govermentIdNumber { get; set; }

		public string qaNote { get; set; }

		public string altBenefCode { get; set; }

		public int grlgLegacyDays { get; set; }

		public DateTime grlgStartDate { get; set; }

		public DateTime idExpiryDate { get; set; }

		public string borderEntryVisa { get; set; }

		public int infoSource { get; set; }

		public string passportNumber { get; set; }

		public string uidNumber { get; set; }

		public string externalId { get; set; }

		public int dependencyId { get; set; }

		public int heightValue { get; set; }

		public int heightUnit { get; set; }

		public int weightValue { get; set; }

		public int weightUnit { get; set; }

		public int professionId { get; set; }

		public int maritalStatus { get; set; }

		public int residence { get; set; }

		public int salary { get; set; }

		public int gradeId { get; set; }

		public string grade { get; set; }

		public int categSeqId { get; set; }

		public int categId { get; set; }

		public int payerId { get; set; }

		public int productId { get; set; }

		public int prdClassId { get; set; }

		public bool isDMP { get; set; }

		public string cardNumber { get; set; }

		public bool isLG { get; set; }

		public bool notCovered { get; set; }

		public bool hasLimit { get; set; }

		public bool hasExclusion { get; set; }

		public string certificateNumber { get; set; }

		public string sponsorId { get; set; }

		public bool hasSpecialMatrixBenefits { get; set; }

		public int priorityPayerRelation { get; set; }

		public DateTime priorityPayerEmploymentDate { get; set; }

		public bool commision { get; set; }

		public int sponsorType { get; set; }

		public int residenceVisaPlace { get; set; }

		public string dmpProgram { get; set; }

		public string benefInCaseOfDeath { get; set; }

		public string otherInsuranceCompany { get; set; }

		public string syndicateNumber { get; set; }

		public string regulatorFileNumber { get; set; }

		public string birthCertificateId { get; set; }

		public string regulatorMemberId { get; set; }

		public int memberType { get; set; }

		public Product product { get; set; }

		public Address address { get; set; }

		public string note { get; set; }

		public string imageName { get; set; }

		public int externalEndoNbr { get; set; }

		public string coverageConstraint { get; set; }

		public bool isNewPrincipal { get; set; }

		public string IBANNumber { get; set; }

		public string channelType { get; set; }

		public string consentType { get; set; }

		public int grossPremium { get; set; }

		public Financialinformation financialInformation { get; set; }

		public int netPremium { get; set; }

		public int proPrem { get; set; }

		public int iaf { get; set; }

		public int tpa { get; set; }

		public int ac { get; set; }

		public int cpm { get; set; }

		public int grossFrequencyLoading { get; set; }

		public int grossAmount { get; set; }

		public int tax1 { get; set; }

		public int tax2 { get; set; }

		public int tax3 { get; set; }

		public int tax4 { get; set; }

		public int tax5 { get; set; }

		public int tax6 { get; set; }

		public Duepremium[] duePremiums { get; set; }
	}
}
