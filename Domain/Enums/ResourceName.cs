namespace Domain.Enums
{
	public static class ResourceName
	{
		public static readonly string NoDataFound = "GST0001";

		public static readonly string MinimizetheOSReserve = "GCL0001";

		public static readonly string FeesAlreadyBinded = "GCL0002";

		public static readonly string DiscAlreadyBinded = "GCL0003";

		public static readonly string PaymentAmount = "GCL0004";

		public static readonly string RecoveryCollectionAmount = "GCL0005";

		public static readonly string ValidModificationClaimsTransactions = "GCL0006";

		public static readonly string ValidModificationClaimParty = "GCL0007";

		public static readonly string ValidModificationClaim = "GCL0008";

		public static readonly string AmountOnRecoveryCollection = "GCL0009";

		public static readonly string RecoveryCollectionUnPosted = "GCL0010";

		public static readonly string LawyerClaimPartyRegistration = "GCL0011";

		public static readonly string SharePercentageInstallmentSchedule = "GCL0012";

		public static readonly string CoveredCountryExists = "GPD0001";

		public static readonly string CannotFlagSignedAsNotPrinted = "GPD0002";

		public static readonly string CanFlagPrintedPoliciesAssigned = "GPD0003";

		public static readonly string PolicyHasBeenFlaggedAsPrinted = "GPD0004";

		public static readonly string PolicyHasBeenFlaggedAsNotPrinted = "GPD0005";

		public static readonly string PolicyHasBeenFlaggedAsSigned = "GPD0006";

		public static readonly string PolicyHasBeenFlaggedAsNotSigned = "GPD0007";

		public static readonly string InvalidTransactionType = "GPD0008";

		public static readonly string OnlyFinalizedQuotationCanBeFlaggedAsPrinted = "GPD0009";

		public static readonly string QuotationHasBeenFlaggedAsPrinted = "GPD0010";

		public static readonly string QuotationHasBeenFlaggedAsNotPrinted = "GPD0011";

		public static readonly string CanOnlyFlagFinalizedAndConvertedQuotationAsSigned = "GPD0012";

		public static readonly string QuotationHasBeenFlaggedAsSigned = "GPD0013";

		public static readonly string QuotationHasBeenFlaggedAsNotSigned = "GPD0014";

		public static readonly string OnlyFinalizedQuotationsCanBeConverted = "GPD0015";

		public static readonly string QuotationConvertedSuccessfully = "GPD0016";

		public static readonly string CanNotFinalizeQuotationWithoutCustomerDefined = "GPD0017";

		public static readonly string QuotationFinalizedSuccessfully = "GPD0018";

		public static readonly string CannontFlagAsNotTakenUp = "GPD0019";

		public static readonly string QuotationHasBeenFlaggedAsNotTakenUp = "GPD0020";

		public static readonly string ClaimChangeStatusValidation = "GCL0013";

		public static readonly string PolicyIsHavingAnOSPremium = "GCL0014";

		public static readonly string PaymentTransactionNotPosted = "GCL0015";

		public static readonly string ClaimPartyClosedStatusPaymentValidation = "GCL0016";

		public static readonly string ClaimPartyClosedStatusRecoveryValidation = "GCL0017";

		public static readonly string ClaimPartyClosedStatusReserveValidation = "GCL0018";

		public static readonly string ClaimPartyClosedStatusExpectedRecoveryValidation = "GCL0019";

		public static readonly string ClaimClosedStatusValidation = "GCL0020";

		public static readonly string ExpectedRecoveryTransactionUnposted = "GCL0021";

		public static readonly string ReserveTransactionUnposted = "GCL0022";

		public static readonly string TotalReserveAmountOfClaimExceededClaimRiskSI = "GCL0023";

		public static readonly string TotalReserveAmountShouldBeGreaterThanZero = "GCL0024";

		public static readonly string TotalReserveAmountExceededRiskSumInsured = "GCL0025";

		public static readonly string TotalReserveAmountExceededCoverCaseLimit = "GCL0026";

		public static readonly string TotalReserveAmountForAllClaimsUnderSingelPolicy = "GCL0027";

		public static readonly string TotalReserveAmountExceededAggregateLimit = "GCL0028";

		public static readonly string TotalReserveAmountExceededCoverSumInsured = "GCL0029";

		public static readonly string TotalReserveAmountExceededCaseLimitCoverType = "GCL0030";

		public static readonly string EnginneringandGeneralAccidentDateValidation = "GCL0034";

		public static readonly string DamagedPartAlreadyExistsValidation = "GCL0035";

		public static readonly string ClaimTransactiondDateShouldNotBeLessThanClaimLossDate = "GCL0036";

		public static readonly string ClaimTransactionDateShouldNotBeLessThanClaimParty = "GCL0037";

		public static readonly string PaymentAmountShallBeLessThanOrEqualOsBalance = "GCL0038";

		public static readonly string PaymentDateShouldNotBeLessThanTodayDate = "GCL0039";

		public static readonly string MotorClaimPartySaveValidation = "GCL0040";

		public static readonly string MotorClaimRiskDuplicationValidation = "GCL0041";

		public static readonly string ClaimNoticeConvertClaimError = "GCL0042";

		public static readonly string ClaimNoticeConvertRiskError = "GCL0043";

		public static readonly string ReserveAmountZeroValidation = "GCL0044";

		public static readonly string SumInsuredOnEndorsmentRisk = "GPD0022";

		public static readonly string SumInsuredInCoinsurane = "GPD0021";

		public static readonly string SumInsuredMarineOpenCover = "GPD0023";

		public static readonly string CannotDeleteMainLawyerDefinedInCourtCaseEntry = "GCL0045";

		public static readonly string RegisterLawyerClaimantValidation = "GCL0046";

		public static readonly string EffectiveDateShouldNotBeLessThanPolicyEffectiveDate = "GPD0026";

		public static readonly string EffectiveDateShouldNotBeMoreThanPolicyExpiryDate = "GPD0027";

		public static readonly string ParentSuminsuredShouldEqualTotalChildrenSuminsured = "GPD0028";

		public static readonly string QuantityShouldBeGreaterThanOne = "GPD0029";

		public static readonly string SumInsuredShouldBeGreaterThanZero = "GPD0030";

		public static readonly string NewVesionValidation = "GPD0031";

		public static readonly string RiskAlreadyAdded = "GPD0032";

		public static readonly string InceptionDateCanNotBeGreaterThanExpiryDate = "GPD0033";

		public static readonly string CanNotIssueDocumentWithinClosingPeriod = "GPD0034";

		public static readonly string FinancialDateIsWithinClosingPeriod = "GPD0035";

		public static readonly string ExpiryDateShouldNotBeLessThanIssueDate = "GPD0036";

		public static readonly string TheDifferanceBetweenSystemDateAndIssueDateShouldNotExceeds = "GPD0037";

		public static readonly string FinancialDateShouldBeNotLessThanInceptionDateOrGreaterThanExpiryDate = "GPD0038";

		public static readonly string QuotationOfferDateCanNotBeLessThanDocumentIssueDate = "GPD0039";

		public static readonly string TotalOurSharePercentShouldNotExceed = "GPD0040";

		public static readonly string IssueDateCanNotBeLessThanOpenCoverPolicyIssueDateAndCanNotBeGreaterThanTodaysDate = "GPD0041";

		public static readonly string InceptionDateCanNotBeLessThanOpenCoverPolicyInceptionDateAndCanNotBeGreaterThanTodaysDate = "GPD0042";

		public static readonly string PreviousCertificateOrDeclarationMustBePosted = "GPD0043";

		public static readonly string InceptionDateShouldBeGreaterThanThePerviousCertificateOrDeclarationInceptionDate = "GPD0044";

		public static readonly string InceptionDateCanNotBeGreaterThanOriginalPolicyExpiryDateOrLessThanOriginalPolicyInceptionDate = "GPD0045";

		public static readonly string InceptionDateCanNotBeLessThanPeviousEndorsementInceptionDate = "GPD0046";

		public static readonly string LastEndorsmentShouldBePsted = "GPD0047";

		public static readonly string NoOfSeatsMustBeFilled = "GPD0048";

		public static readonly string NoOfCoveredPassengersMustBeLessThanOrEqualThanNoOfSeats = "GPD0049";

		public static readonly string SameCreditNoAndBankNameCombinedExistOnOtherRisks = "GPD0050";

		public static readonly string MarineCargoAnyOneShipmentValidationQuotationPolicy = "GPD0051";

		public static readonly string MarineCargoAnyOneShipmentValidationCertificateDeclaration = "GPD0052";

		public static readonly string ShipmentDateValidation = "GPD0053";

		public static readonly string CodeShouldBeUnique = "GST0002";

		public static readonly string ThisCriteriaIsAlreadyBound = "GST0003";

		public static readonly string SomeOfTheRecordsAreadBound = "GST0004";

		public static readonly string SpecifyEitherAmountOrPercentageCannotAddBoth = "GST0005";

		public static readonly string SpecifyEitherAmountOrPercentage = "GST0006";

		public static readonly string VehiclePartChild = "GST0007";

		public static readonly string ClaimRiskCoverInsertFailed = "GCL0047";

		public static readonly string AutoPostPolicyFailed = "GPD0054";

		public static readonly string noOfCoveredPassengersShouldBeGreaterThanZero = "GPD0055";

		public static readonly string NoOfSeatsShouldBeGreaterThanZero = "GPD0056";

		public static readonly string dailyIndemnityShouldBeGreaterThanZero = "GPD0057";

		public static readonly string DocumentExpiryValidation = "GPD0058";

		public static readonly string NotificationDateCompareWithRegistrationDate = "GPD0059";

		public static readonly string NotificationDateCompareWithClaimNotificationDate = "GPD0060";

		public static readonly string RegistrationDateCompareWithclaimRegistrationDate = "GPD0061";

		public static readonly string SurveyDateCompareWithclaimRegistrationDate = "GPD0062";

		public static readonly string RecoverableAmountandOurShareS1ummationShouldNotExceed100 = "GPD0063";

		public static readonly string ClaimRiskDuplicated = "GPD0064";

		public static readonly string IssueDateGreaterthanSysDate = "GPD0065";

		public static readonly string FinancialDateGreaterthanSysDate = "GPD0066";

		public static readonly string BlackListAlertMessage = "GPD0067";

		public static readonly string BlackListErrorMessage = "GPD0068";

		public static readonly string SurveyDueDateValidation = "GCL0048";

		public static readonly string InsertChildClaimRiskWithoutAparent = "GCL0068";

		public static readonly string LimitperOccurrenceGreaterthanAggregateLimit = "GPD0069";

		public static readonly string LastOnlyRiskOnThePolicy = "GPD0070";

		public static readonly string RiskHasAnOpenClaimOnRiskDeletion = "GPD0071";

		public static readonly string ClaimClosedDateOfLossGreaterThanTheEndorsementRiskDeletionInceptionDate = "GPD0072";

		public static readonly string PolicyHasAnOpenClaim = "GPD0073";

		public static readonly string CannotModifyCancelledPolicies = "GPD0074";

		public static readonly string CannotModifyReinsurnedOrClaimedOrPostedPolicies = "GPD0075";

		public static readonly string CannotModifyPostedEndorsements = "GPD0076";

		public static readonly string CannotModifyFinalizedQuotations = "GPD0077";

		public static readonly string CannotModifyConvertedQuotations = "GPD0078";

		public static readonly string CannotModifyNotTakenupQuotations = "GPD0079";

		public static readonly string CannotModifyPrintedQuotations = "GPD0080";

		public static readonly string CannotModifySignedQuotations = "GPD0081";

		public static readonly string CannotModifyPrintedOrReinsurnedOrClaimedOrPostedOrCancelledPolicies = "GPD0082";

		public static readonly string TheAccumulationAmountIsGreaterThanMaxLimtInSetup = "GPD0083";

		public static readonly string PremiumInstallmentsShare = "GPD0084";

		public static readonly string AccountIntegrationShouldNotDuplicated = "GST0008";

		public static readonly string FeeTypeWasNotDefindInFeeTiers = "GST0009";

		public static readonly string FeesCombinationAreadyExists = "GPD0086";

		public static readonly string DiscountLoadingAlreadyExists = "GPD0085";

		public static readonly string CommissionAlreadyExists = "GPD0087";

		public static readonly string CoinsuranceFeesAlreadyExists = "GPD0088";

		public static readonly string InstallmentsShareMustEqualHundred = "GPD0089";

		public static readonly string YouShouldAddBRMFirst = "GPD0090";

		public static readonly string OnlyOneBRMCanBeAddedPerDocument = "GPD0091";

		public static readonly string DocumentSharesPercentageValidation = "GPD0092";

		public static readonly string YouCanOnlyAddAgentsToSpecificDocuments = "GPD0093";

		public static readonly string YouShouldDeleteAgentsFirst = "GPD0094";

		public static readonly string DuplicatedRecord = "GPD0095";

		public static readonly string DocumentSharesBRMValidation = "GPD0096";

		public static readonly string DataAlreadyExists = "GPD0097";

		public static readonly string CannotUpdateAgentTypeForTheBRM = "GPD0098";

		public static readonly string LongTermGrossPermiumNotEqualtoRiskRiPremium = "GPD0102";

		public static readonly string LongTermNetPermiumNotEqualtoRiskPremium = "GPD0103";

		public static readonly string TransactionAlreadyReversed = "GCL0069";

		public static readonly string TheDateNumberExceedsTheMaxPolicyPeriod = "GPD0109";

		public static readonly string NoEndorsementAddedBefor = "GPD0110";

		public static readonly string InceptionDateMustNotBeLessThanRisk = "GPD0111";

		public static readonly string EndorsmentEffectiveDate = "GPD0112";

		public static readonly string NoClaimsLessThanEndorsementInception = "GPD0113";

		public static readonly string PolicyTypeShouldAcceptLongTerm = "GPD0114";

		public static readonly string ExpiryShouldBeGreaterThanEffective = "GPD0115";

		public static readonly string NoClaimsGreaterThanEndorsementInception = "GPD0116";

		public static readonly string EndorsmentEffectiveDateGreater = "GPD0117";

		public static readonly string ExceedMaxPolicyPeriod = "GPD0118";

		public static readonly string RecoveryCollectionLinkedWithanettedPaymentTransaction = "GCL0070";

		public static readonly string DuplicateSalvageDamagePart = "GCL0071";
	}
}
