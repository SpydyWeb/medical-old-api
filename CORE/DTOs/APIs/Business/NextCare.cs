namespace CORE.DTOs.APIs.Business
{
	public class NextCare
	{
		public class Rootobject
		{
			public Transaction Transaction { get; set; }
		}

		public class Transaction
		{
			public string TrnNo { get; set; }

			public string TrnType { get; set; }

			public Mastercontract MasterContract { get; set; }
		}

		public class Mastercontract
		{
			public string Imported { get; set; }

			public string ImportedFromPayer { get; set; }

			public string Name { get; set; }

			public string PolicyType { get; set; }

			public int LineofBusiness { get; set; }

			public string TaxID { get; set; }

			public string MContractID { get; set; }

			public string PrevMContractID { get; set; }

			public string PayerMContractUID { get; set; }

			public string PayerPrevMContractUID { get; set; }

			public string PolicyHolderPin { get; set; }

			public string MasterContractName { get; set; }

			public string EffectiveDate { get; set; }

			public string ExpiryDate { get; set; }

			public int PolicyCurrency { get; set; }

			public int Distributor { get; set; }

			public int Branch { get; set; }

			public string NumberOfRenewals { get; set; }

			public string StartDate { get; set; }

			public string TOB { get; set; }

			public string Notes { get; set; }

			public int Country { get; set; }

			public int Region { get; set; }

			public int SubRegion { get; set; }

			public string PhoneNumber { get; set; }

			public string EmailAddress { get; set; }

			public Categories Categories { get; set; }

			public Policies Policies { get; set; }
		}

		public class Categories
		{
			public Category Category { get; set; }
		}

		public class Category
		{
			public string CategDescription { get; set; }

			public string ProductCode { get; set; }

			public string ProductClass { get; set; }
		}

		public class Policies
		{
			public Policyinformation PolicyInformation { get; set; }
		}

		public class Policyinformation
		{
			public string ContractID { get; set; }

			public string PayerContractUID { get; set; }

			public string PolicyHolderPin { get; set; }

			public string ExternalRef { get; set; }

			public string ContractName { get; set; }

			public string PayMode { get; set; }

			public string PayWay { get; set; }

			public string Bank { get; set; }

			public string BankAccount { get; set; }

			public int Profession { get; set; }

			public int SponsorType { get; set; }

			public string MainSponsorNumber { get; set; }

			public string TradeLicenseNumber { get; set; }

			public string TradeLicenseIssuedate { get; set; }

			public string TradeLicenseExpiryDate { get; set; }

			public int HealthAuthority { get; set; }

			public int Country { get; set; }

			public int Region { get; set; }

			public int SubRegion { get; set; }

			public string PhoneNumber { get; set; }

			public string EmailAddress { get; set; }

			public Principal[] principals { get; set; }
		}

		public class Principal
		{
			public Dependent[] dependents { get; set; }

			public string CardNumber { get; set; }

			public string BeneficiaryID { get; set; }

			public string PrincipalID { get; set; }

			public string BeneficiaryPIN { get; set; }

			public string PrincipalPIN { get; set; }

			public string FirstName { get; set; }

			public string MiddleName { get; set; }

			public string LastName { get; set; }

			public string MaidenName { get; set; }

			public string DOB { get; set; }

			public string Gender { get; set; }

			public string Height { get; set; }

			public string Weight { get; set; }

			public string MaritalStatus { get; set; }

			public int NationalityCode { get; set; }

			public int CountryOfResidence { get; set; }

			public int IDType { get; set; }

			public string IDNumber { get; set; }

			public int SponsorType { get; set; }

			public string SponsorID { get; set; }

			public string StaffNumber { get; set; }

			public string CertificateCode { get; set; }

			public string PassportNumber { get; set; }

			public string UIDNumber { get; set; }

			public int ResidenceVisaPlace { get; set; }

			public string NationalIdNumber { get; set; }

			public string Dependency { get; set; }

			public string ProductCode { get; set; }

			public string ProductClass { get; set; }

			public string Remarks { get; set; }

			public string StartDate { get; set; }

			public string HasExclusions { get; set; }

			public string OverPremium { get; set; }

			public string OPType { get; set; }

			public string OPonGross { get; set; }

			public string Salary { get; set; }

			public string Commission { get; set; }

			public int Country { get; set; }

			public int Region { get; set; }

			public int SubRegion { get; set; }

			public string MobileNumber { get; set; }

			public string EmailAddress { get; set; }

			public string VisaFileNumber { get; set; }

			public string MemberType { get; set; }

			public string BirthCertificateID { get; set; }

			public string DHPOMemberID { get; set; }

			public string DHPOIntermediaryID { get; set; }
		}

		public class Dependent
		{
			public string CardNumber { get; set; }

			public string BeneficiaryID { get; set; }

			public string PrincipalID { get; set; }

			public string BeneficiaryPIN { get; set; }

			public string PrincipalPIN { get; set; }

			public string FirstName { get; set; }

			public string MiddleName { get; set; }

			public string LastName { get; set; }

			public string MaidenName { get; set; }

			public string DOB { get; set; }

			public string Gender { get; set; }

			public string Height { get; set; }

			public string Weight { get; set; }

			public string MaritalStatus { get; set; }

			public int NationalityCode { get; set; }

			public int CountryOfResidence { get; set; }

			public int IDType { get; set; }

			public string IDNumber { get; set; }

			public int SponsorType { get; set; }

			public string SponsorID { get; set; }

			public string StaffNumber { get; set; }

			public string CertificateCode { get; set; }

			public string PassportNumber { get; set; }

			public string UIDNumber { get; set; }

			public int ResidenceVisaPlace { get; set; }

			public string NationalIdNumber { get; set; }

			public string Dependency { get; set; }

			public string ProductCode { get; set; }

			public string ProductClass { get; set; }

			public string Remarks { get; set; }

			public string StartDate { get; set; }

			public string HasExclusions { get; set; }

			public string OverPremium { get; set; }

			public string OPType { get; set; }

			public string OPonGross { get; set; }

			public string Salary { get; set; }

			public string Commission { get; set; }

			public int Country { get; set; }

			public int Region { get; set; }

			public int SubRegion { get; set; }

			public string MobileNumber { get; set; }

			public string EmailAddress { get; set; }

			public string VisaFileNumber { get; set; }

			public string MemberType { get; set; }

			public string BirthCertificateID { get; set; }

			public string DHPOMemberID { get; set; }

			public string DHPOIntermediaryID { get; set; }
		}
	}
}
