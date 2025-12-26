using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Models
{
    class PentaRequestsResp
    {
    }
    public class PentaCreateQuotationReq
    {
        public string quotationNo { get; set; }
        public string planCode { get; set; }
        public string changePlanFlag { get; set; }
        public string cashBeforeCover { get; set; }
        public string confirmFlag { get; set; }
        public string proposerType { get; set; }
        public string crNumber { get; set; }
        public string crRegNo { get; set; }
        public string crName { get; set; }
        public List<CrAddress> crAddress { get; set; }
        public string businessType { get; set; }
        public string businessDesc { get; set; }
        public string activityId { get; set; }
        public string activityDescEn { get; set; }
        public string activityDescAr { get; set; }
        public string crIssueDate { get; set; }
        public string crExpiryDate { get; set; }
        public string companyCode { get; set; }
        public string companyBranch { get; set; }
        public int participatingEmployees { get; set; }
        public int totalEmployees { get; set; }
        public string introducerCode { get; set; }
        public string tpaCompCode { get; set; }
        public string tpaCompBranch { get; set; }
        public string correspondingLanguage { get; set; }
        public string paymentFrequency { get; set; }
        public string paymentMethod { get; set; }
        public string currency { get; set; }
        public string policyTerm { get; set; }
        public string policyEffectiveDate { get; set; }
        public string policyExpiryDate { get; set; }
        public string backDatedFlag { get; set; }
        public string backDatedReason { get; set; }
        public string headCount { get; set; }
        public string experienceSurplus { get; set; }
        public string riskCategory { get; set; }
        public string policyBranch { get; set; }
        public string serviceBranch { get; set; }
        public string ageDefinition { get; set; }
        public string multiCompany { get; set; }
        public string masterCompanyControl { get; set; }
        public string serviceTaxApplicable { get; set; }
        public string portalUserId { get; set; }
        public string sourceType { get; set; }
        public string sourceOfBusiness { get; set; }

        public List<AgentDetails> agentDetails { get; set; }
        public List<SponsorDetail> sponsorDetails { get; set; }
        public List<MemberDetails> memberDetails { get; set; }
    }

    public class CrAddress
    {
        public string addressType { get; set; }
        public int? buildingNo { get; set; }
        public string street { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postCode { get; set; }
        public int? additionalNo { get; set; }
        public string isPrimaryAddress { get; set; }
        public string yakeenCity { get; set; }
        public string yakeenDetails { get; set; }
    }

    public class AgentDetails
    {
        public string agentNo { get; set; }
        public string rank { get; set; }
        public int percent { get; set; }
        public string commissionType { get; set; }
        public string commissionPercent { get; set; }
    }

    public class SponsorDetail
    {
        public string crNumber { get; set; }
        public string crRegNo { get; set; }
        public string crName { get; set; }
        public List<CrAddress> crAddress { get; set; }
        public string businessType { get; set; }
        public string businessDesc { get; set; }
        public string activityId { get; set; }
        public string activityDescEn { get; set; }
        public string activityDescAr { get; set; }
        public string crIssueDate { get; set; }
        public string crExpiryDate { get; set; }
        public string sponsorCompanyCode { get; set; }
        public string sponsorCompanyBranch { get; set; }
        public string sponsorServiceTaxApplicable { get; set; }
        public string serviceTaxPercentage { get; set; }
        public string isMasterCompany { get; set; }
    }

    public class MemberDetails
    {
        public string idenCode { get; set; }
        public string idenNo { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string name { get; set; }
        public string maritalStatus { get; set; }
        public string subPlanCode { get; set; }
        public string annualLimitCriteria { get; set; }
        public string occupationClass { get; set; }
        public string memberEffectiveDate { get; set; }
        public string memberExpiryDate { get; set; }
        public string employeeId { get; set; }
        public string relation { get; set; }
        public string occupation { get; set; }
        public string city { get; set; }
        public string nationality { get; set; }
        public string memberSponsorNo { get; set; }

        public string loadingType { get; set; }
        public int loading { get; set; }
        public string discountType { get; set; }
        public int discount { get; set; }

        // public List<UwQuestions> uwQuestions { get; set; }
        public UwQuestions[] uwQuestions { get; set; }
        //public List<MemberDocumentDetails> memberDocumentDetails { get; set; }
        public documentDetails[] documentDetails { get; set; }
        public List<MemberAddressDetails> memberAddressDetails { get; set; }
    }

    public class UwQuestions
    {
        public string questionCode { get; set; }
        public string reply { get; set; }
        public string replyDetails { get; set; }
    }

    public class MemberDocumentDetails
    {
        public string documentCode { get; set; }
        public string documentRefNo { get; set; }
        public string reason { get; set; }
    }

    public class MemberAddressDetails
    {
        public string addressType { get; set; }
        public int? buildingNo { get; set; }
        public string street { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postCode { get; set; }
        public int? additionalNo { get; set; }
        public string isPrimaryAddress { get; set; }
        public string yakeenCity { get; set; }
        public string yakeenDetails { get; set; }
    }
    public class PentaCreateQuotationRes
    {
        public bool status { get; set; }
        public ReturnValue returnValue { get; set; }
        public object returnValues { get; set; }
        public object errors { get; set; }
    }

    public class ReturnValue
    {
        public string quotationNo { get; set; }
        public string referenceQuotationNo { get; set; }
        public string policyStatus { get; set; }
        public string policyStatusDesc { get; set; }
        public string issueDate { get; set; }
        public string expiryDate { get; set; }
        public double grossPremium { get; set; }
        public double vatAmount { get; set; }
        public double netPremium { get; set; }
        public double totalBilledAmount { get; set; }
        public double commissionAmount { get; set; }
        public List<ChargesBreakdown> chargesBreakdown { get; set; }
        public List<MemberWiseDetail> memberWiseDetails { get; set; }
    }

    public class ChargesBreakdown
    {
        public string chargeCode { get; set; }
        public string chargeDesc { get; set; }
        public double amount { get; set; }
    }

    public class MemberWiseDetail
    {
        public string idenCode { get; set; }
        public string idenNo { get; set; }
        public string name { get; set; }
        public double memeberTotalPremium { get; set; }
        public List<object> uwRulesFailed { get; set; }
        public PremiumDetails premiumDetails { get; set; }
    }

    public class PremiumDetails
    {
        public double grossPremium { get; set; }
        public double discountAmount { get; set; }
        public double loadingAmount { get; set; }
        public double netPremium { get; set; }
        public double vat { get; set; }
        public double totalPremium { get; set; }
    }

    public class uwQuestion
    {

    }
    public class documentDetails
    {

    }
    public class PentaTokenRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class PentatokenResponse
    {
        public string status { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string message { get; set; }
    }

    public class CreateProposalResp
    {
        public bool Status { get; set; }
        public ReturnValues ReturnValue { get; set; }
        public object ReturnValues { get; set; }
        public object Errors { get; set; }
    }
    public class ReturnValues
    {
        public string QuotationNo { get; set; }
        public string ReferenceQuotationNo { get; set; }
        public string PolicyNo { get; set; }
        public string PolicyStatus { get; set; }
        public string PolicyStatusDesc { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal GrossPremium { get; set; }
        public decimal VatAmount { get; set; }
        public decimal NetPremium { get; set; }
        public decimal TotalBilledAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public List<object> ChargesBreakdown { get; set; }
        public List<MemberWiseDetails> MemberWiseDetails { get; set; }
    }
    public class MemberWiseDetails
    {
        public string IdenCode { get; set; }
        public string IdenNo { get; set; }
        public string Name { get; set; }
        public decimal MemeberTotalPremium { get; set; }
        public List<object> UwRulesFailed { get; set; }
        public PremiumDetail PremiumDetails { get; set; }
    }

    public class PremiumDetail
    {
        public decimal GrossPremium { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal LoadingAmount { get; set; }
        public decimal NetPremium { get; set; }
        public decimal Vat { get; set; }
        public decimal TotalPremium { get; set; }
    }
    public class CreateProposalRequest
    {
        public string quotationNo { get; set; }
    }
    //public class IssuePolicyRequest
    //{
    //    public string quotationNo { get; set; }
    //    public ReceiptDetails receiptDetails { get; set; }
    //}
    //public class ReceiptDetails
    //{
    //    public string proposalNo { get; set; }
    //    public string instrumentType { get; set; }
    //    public string instrumentBank { get; set; }
    //    public string instrumentBankBranch { get; set; }
    //    public string instrumentNo { get; set; }
    //    public string creditCardType { get; set; }
    //    public string creditCardNo { get; set; }
    //    public string creditCardValidFrom { get; set; }
    //    public string creditCardValidTo { get; set; }
    //    public string receiptCode { get; set; }
    //}
    //public class IssuePolicyResponse
    //{
    //    public bool Status { get; set; }
    //    public ReceiptReturnValue ReturnValue { get; set; }
    //    public object ReturnValues { get; set; }
    //    public object Errors { get; set; }
    //}

    //public class ReceiptReturnValue
    //{
    //    public string ReceiptNo { get; set; }
    //    public decimal ReceiptAmount { get; set; }
    //    public string PolicyStatus { get; set; }
    //    public string Description { get; set; }
    //}
    public class LookupResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public LookupReturnValue ReturnValue { get; set; }
        public object ReturnValues { get; set; }
    }

    public class LookupReturnValue
    {
        public int Offset { get; set; }
        public bool HasMore { get; set; }
        public int Limit { get; set; }
        public int Count { get; set; }
        public List<Link> Links { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
    }

    public class Item
    {
        public List<LookupValue> Lookup_Values { get; set; }
    }

    public class LookupValue
    {
        public string V_Ins_Code { get; set; }
        public string V_Desc { get; set; }
    }
    public class LookupTable
    {
        public InputValues inputValues { get; set; }
    }
    public class InputValues
    {
        public string procedureName { get; set; }
        public string lookupCode { get; set; }
    }

    public class memberAdditionRequest
    {
        public string processCode { get; set; }
        public string alterationEffectiveDate { get; set; }
        public string policyNo { get; set; }
        public string refundType { get; set; }
        [JsonProperty("memberCorrection")]
        public memberCorrection[] memberCorrection { get; set; }
        public List<memberAddition> memberAddition { get; set; }
        [JsonProperty("memberDeletion")]
        public memberDeletion[] memberDeletion { get; set; }
    }

    public class memberAddition
    {
        public string idenCode { get; set; }
        public string idenNo { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string fourthName { get; set; }
        public string maritalStatus { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string relation { get; set; }
        public string sponsorNumber { get; set; }
        public string occupation { get; set; }
        public string nationality { get; set; }
        public string effectiveDate { get; set; }
        public string expiryDate { get; set; }
        public string idIssueDate { get; set; }
        public string idExpiryDate { get; set; }
        public string memberEffectiveDate { get; set; }
        public string memberExpiryDate { get; set; }
        public string subPlanCode { get; set; }
        public string city { get; set; }
        public string consumeAlcohol { get; set; }
        public int alcoholPerDay { get; set; }
        public string pregnantFlag { get; set; }
        public int pregnancyMonths { get; set; }
        public string smokerFlag { get; set; }
        public int noOfSticksPerDay { get; set; }
        public string loadingType { get; set; }
        public int loadingAmount { get; set; }
        public string discountType { get; set; }
        public int discountAmount { get; set; }
        public string companyCode { get; set; }
        public string companyBranch { get; set; }
        public string employeeId { get; set; }
        public List<addressDetails> addressDetails { get; set; }
        public uwQuestion[] uwQuestions { get; set; }
        public documentDetails[] documentDetails { get; set; }
        public List<agentDetails> agentDetails { get; set; }


    }

    public class addressDetails
    {
        public string addressType { get; set; }
        public int additionalNo { get; set; }
        public int buildingNo { get; set; }
        public string street { get; set; }
        public string postCode { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string isPrimaryAddress { get; set; }
        public string yakeenAddress { get; set; }
        public string yakeenCity { get; set; }
    }
    public class agentDetails
    {
        public string agentNumber { get; set; }
        public string rank { get; set; }
        public string agentSharePercent { get; set; }
        public string commissionType { get; set; }
        public string commissionPercent { get; set; }
    }
    public class HPolicyAdditionRequest
    {
        public string PolicyRequestReferenceNo { set; get; }
        public int InsuranceCompanyCode { set; get; }
        public string QuoteRequestReferenceNo { set; get; }
        public string QuoteReferenceNo { set; get; }
        public PolicyAdditionDetail Details { set; get; }
    }
    public class PolicyAdditionDetail
    {
        public Int64 EntityCR { set; get; }
        public Int64 SponsorID { set; get; }
        public string CurrentPolicyNumber { set; get; }
        public int PaymentMethodID { set; get; }
        public decimal MembersPremium { set; get; }
        public string AdditionalEffectiveDate { set; get; }
        public string PaymentReferenceNo { set; get; }

        //[Required, StringLength(25, ErrorMessage = "TransactionNumber Invalid Length")]//changes made by vardhan on 17-11-2025
        public string TransactionNumber { set; get; }
        public decimal Amount { set; get; }
        public List<FinalMembersList> FinalMembersList { set; get; }
        public List<CustomizedParameter> CustomizedParameter { get; set; }
    }

    public class memberDeletion
    {

    }
    public class FinalMembersList
    {
        public string MemberID { get; set; }
        public string MemberMobileNo { get; set; }
    }
    public class CustomizedParameter
    {
        public string Key { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
    }

    public class memberCorrection
    {

    }

    public class memberAdditionApiResponse
    {
        public bool status { get; set; }
        public returnValue returnValue { get; set; }
        public object returnValues { get; set; }
        public List<Error> errors { get; set; }
    }

    public class Error
    {
        public string Field { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public int Code { get; set; }

    }
    public class returnValue
    {
        public memberAdditionDetails memberAdditionDetails { get; set; }
        public object memberDeletionDetails { get; set; }
    }

    public class memberAdditionDetails
    {
        public int serviceRequestNo { get; set; }
        public string policyNo { get; set; }
        public string quotationNo { get; set; }
        public string referenceQuotationNo { get; set; }
        public string endorsmentStatusCode { get; set; }
        public string endorsmentStatusDesc { get; set; }
        public string endorsementType { get; set; }
        public string policyStatus { get; set; }
        public string issueDate { get; set; }
        public string effectiveDate { get; set; }
        public string expiryDate { get; set; }
        public decimal grossPremium { get; set; }
        public decimal vatAmount { get; set; }
        public decimal netPremium { get; set; }
        public decimal totalBilledAmount { get; set; }
        public decimal commissionAmount { get; set; }
        public List<object> chargesBreakdown { get; set; }
        public List<memberAlteration> memberAlteration { get; set; }
        public decimal surrenderNo { get; set; }
    }

    public class memberAlteration
    {
        public int seqNo { get; set; }
        public string idenCode { get; set; }
        public string idenNo { get; set; }
        public string name { get; set; }
        public decimal memeberTotalPremium { get; set; }
        public List<object> uwRulesFailed { get; set; }
        public List<premiumDetails> premiumDetails { get; set; }
    }


    public class premiumDetails
    {
        public decimal grossPremium { get; set; }
        public decimal discountAmount { get; set; }
        public decimal loadingAmount { get; set; }
        public decimal netPremium { get; set; }
        public decimal vat { get; set; }
        public decimal totalPremium { get; set; }
    }
}
