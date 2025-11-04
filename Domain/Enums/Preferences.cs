namespace Domain.Enums
{
	public static class Preferences
	{
		public static readonly string ApplyClassSecurityOnSetupModule = "SST001";

		public static readonly string StopDeleteAttachmentAfterDocumentPosting = "GST001";

		public static readonly string ExpiryDateLessThanIssueDateForPoliciesAndEndt = "GPD006";

		public static readonly string PerviousDaysValidation = "GPD007";

		public static readonly string ExcludeClassesfromDocumentIssueDateMinTodaysDatedifference = "GPD008";

		public static readonly string MarineCargoExpiryDateOptional = "GPD009";

		public static readonly string FollowOpenCover = "GPD013";

		public static readonly string RoundationOfDecimalPoints = "GPD016";

		public static readonly string EnableFinancialDateInDocumentEntry = "GPD020";

		public static readonly string EnableParentPolicyInDocumentEntry = "GPD021";

		public static readonly string ApplyManualEntryOnClaimSerial = "GCL001";

		public static readonly string ActivateClaimCurrencyAndExRate = "GCL002";

		public static readonly string ShowRecoverySide = "GCL003";

		public static readonly string AutomaticReserveCalculation = "GCL004";

		public static readonly string PlateNumberOnSingleORAllActivePolicies = "GPD025";

		public static readonly string ChassisOnSingleORAllActivePolicies = "GPD026";

		public static readonly string ExcludeChassisNoFromDuplicationCheck = "GPD027";

		public static readonly string StopInsertNewRiskOnDuplicateChassisNo = "GPD029";

		public static readonly string ChassisNumberAndInsuredIDDuplicationcheck = "GPD030";

		public static readonly string MotorRegistrationCountries = "GPD031";

		public static readonly string MotorMinimumProductionYear = "GPD032";

		public static readonly string NoOfCoverPassengersToNoOfSeats = "GPD033";

		public static readonly string FillVehicleCardAndMakeThemMandatory = "GPD034";

		public static readonly string ChassisNoDuplicationCheckExclusionOnPolicyType = "GPD035";

		public static readonly string MakePlateNoAndSequenceNoMandatoryPerDefinedBy = "GPD036";

		public static readonly string AutoAddPolicyHolderAsDriverOnInterestSave = "GPD039";

		public static readonly string AllowReserveAmountToExceedClaimRiskSI = "GCL006";

		public static readonly string ApplyRiskSIAgainstReserveAmountAccumulatively = "GCL007";

		public static readonly string AutoPostPolicyOnConvertIsActivated = "GPD022";

		public static readonly string AutoPostingUponRenewal = "GPD041";

		public static readonly string RenewalValidityDays = "GPD046";

		public static readonly string AllowRiskCurrencyToBeDifferentFromDocumentCurrency = "GPD012";

		public static readonly string DeclarationRiskNamesToBeSelectedFromOpenCover = "GPD061";

		public static readonly string PropertyDeclarationsAllowedRiskTypes = "GPD062";
	}
}
