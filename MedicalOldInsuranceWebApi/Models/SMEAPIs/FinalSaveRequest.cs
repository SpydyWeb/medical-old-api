namespace InsuranceAPIs.Models.SMEAPIs
{
    public class FinalSaveRequest
    {
        public int policyId { get; set; }
        public string policySegment { get; set; }
        public string referenceId { get; set; }
        public string paymentMethod { get; set; }
        public string paymentBody { get; set; }
        public string vatNumber { get; set; }
        public int idType { get; set; } = 1;
        public string source { get; set; } = "PartnerPortal";
    }
    public class FinalSaveResponse
    {
        public bool status { get; set; }
        public string errorMessage { get; set; }
    }
    public enum IdType
    {
        TINNumber = 1,
        CRNumber = 2,
        VATAccountNumber = 3,
        VATCertificateNumber = 4,
        SaudiID = 5,
        Iqama = 6,
        CompanyID = 7,
        VATNationalID = 8,
        VATIqamaID = 9
    }
    public enum PaymentMethod
    {
        Payfort = 1,
        SADAD = 2
    }
}
