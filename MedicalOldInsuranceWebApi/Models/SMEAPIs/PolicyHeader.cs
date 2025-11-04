namespace InsuranceAPIs.Models.SMEAPIs
{
    public class PolicyHeader
    {
    }

    public class PolicyHeaderRequest
    {
        public long referenceId { get; set; }
        public int channelID { get; set; }
        public string policyEffectiveDate { get; set; }
        public int agentId { get; set; }
        public int agentBusinesType { get; set; }
        public string policyHolderNameAr { get; set; }
        public string policyHolderNameEn { get; set; }
        public string policyHolderNationality { get; set; }
        public string policyHolderMobileNumber { get; set; }
        public string policyHolderId { get; set; }
        public string createdBy { get; set; }
        public int entityType { get; set; }
        public int entityBusinessType { get; set; }
        public int entityClassification { get; set; }
        public int entityRevenue { get; set; }
        public string entityCRIssueDate { get; set; }
        public string entityCRExpiryDate { get; set; }
        public string entityCRCity { get; set; }
        public List<ISICActivity> iSICActivities { get; set; }
        public AddressDetails addressDetails { get; set; }
        public List<MemberSaveData> memberSaveDatas { get; set; }
    }
    public class ISICActivity
    {
        public int isicCode { get; set; }
        public string isicName { get; set; }
        public string isicNameEN { get; set; }
    }

    public class AddressDetails
    {
        public string buildingNumber { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string postCode { get; set; }
        public string additionalNumber { get; set; }
    }
    public class MemberSaveData
    {
        public string nationalId { get; set; }
        public int relationTypeId { get; set; }
        public string sponsorCRNo { get; set; }
        public string memberName { get; set; }
        public string nationalityCode { get; set; }
        public string dateOfBirth { get; set; }
        public int maritalStatus { get; set; }
        public int occupation { get; set; }
        public int genderCode { get; set; }
        public int memberInsuranceClass { get; set; }
        public double additionalPremium { get; set; }
        public string identityExpiry { get; set; }
        public bool isDeclaration { get; set; }
        public MemberDeclaration memberDeclaration { get; set; }
    }
    public class MemberDeclaration
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool? PregnantStatus { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public List<DeclarationQuestion> DeclarationQuestions { get; set; }
    }
    public class DeclarationQuestion
    {
        public int QuestionID { get; set; }
        public bool QuestionAnswer { get; set; }
    }


    public class PolicyHeaderResponse
    {
        public StatusCT statusCT { get; set; }
        public PolicyInfo policyInfo { get; set; }
        public PolicyEndoInfo policyEndoInfo { get; set; }
        public List<MemberInfo>? memberInfo { get; set; }
    }
    public class StatusCT
    {
        public int statusCode { get; set; }
        public string reason { get; set; }
        public DateTime reasonDate { get; set; }
    }
    public class PolicyInfo
    {
        public long policyId { get; set; }
        public long referenceId { get; set; }
        public int eNDT_NO { get; set; }
        public string sEGMENT_CODE { get; set; }
        public DateTime iSSUE_DATE { get; set; }
        public DateTime eFFECTIVE_DATE { get; set; }
        public DateTime eXPIRY_DATE { get; set; }
        public string cCHI_POLICY_NO { get; set; }
        public int planId { get; set; }
        public double? pOLICY_TOTAL_PREMIUM { get; set; }
        public double? pOLICY_GROSS_PREMIUM { get; set; }
        public double? pOLICY_VAT_PREMIUM { get; set; }
        public double? pOLICY_AGT_PREMIUM { get; set; }
    }
    public class MemberInfo
    {
        public string nationalId { get; set; }
        public long memberCode { get; set; }
        public double memberPremium { get; set; }
        public int memberInsuranceClassCode { get; set; }
        public int errorCode { get; set; }
        public object errorMessage { get; set; }
    }

    public class PolicyEndoHeaderRequest
    {
        public long referenceId { get; set; }
        public string endorsementEffectiveDate { get; set; }
        public int agentId { get; set; }
        public int agentBusinesType { get; set; }
        public int policyId { get; set; }
        public string segmentCode { get; set; }
        public string createdBy { get; set; }
        public List<MemberSaveData> memberSaveDatas { get; set; }
    }
    public class PolicyEndoInfo
    {
        public int policyId { get; set; }
        public long referenceId { get; set; }
        public int eNDT_NO { get; set; }
        public string? sEGMENT_CODE { get; set; }
        public DateTime iSSUE_DATE { get; set; }
        public DateTime eFFECTIVE_DATE { get; set; }
        public DateTime eXPIRY_DATE { get; set; }
        public string? cCHI_POLICY_NO { get; set; }
        public int planId { get; set; }
        public double? eNDORSEMENT_TOTAL_PREMIUM { get; set; }
        public double? eNDORSEMENT_GROSS_PREMIUM { get; set; }
        public double? eNDORSEMENT_VAT_PREMIUM { get; set; }
        public double? eNDORSEMENT_AGT_PREMIUM { get; set; }
    }
}
