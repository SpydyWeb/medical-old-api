namespace InsuranceAPIs.Models.SMEAPIs
{
    public class DeletePolicySME
    {
    }
    public class DeletePolicyDataResult
    {
        public Status status { get; set; }
    }

    public class DeletePolicyResponse
    {
        public DeletePolicyDataResult deletePolicyDataResult { get; set; }
    }

    public class Status
    {
        public int statusCode { get; set; }
        public string reason { get; set; }
        public DateTime reasonDate { get; set; }
    }
}
