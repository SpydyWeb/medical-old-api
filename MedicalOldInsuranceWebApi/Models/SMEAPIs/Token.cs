namespace InsuranceAPIs.Models.SMEAPIs
{
    public class Token
    {
    }

    public class GenerateTokenResponse
    {
        public bool status { get; set; }
        public string token { get; set; }
        public string errorMessage { get; set; }
    }

}
