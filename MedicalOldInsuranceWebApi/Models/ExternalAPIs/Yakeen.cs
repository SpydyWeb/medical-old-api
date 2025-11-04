namespace InsuranceAPIs.Models.ExternalAPIs
{
    public class Yakeen
    {

    }
    public class SaudiByNinResponse
    {
        public PersonIdInfo personIdInfo { get; set; }
        public PersonBasicInfo personBasicInfo { get; set; }
        public string errorId { get; set; }
        public ErrorDetail errorDetail { get; set; }
        public bool status { get; set; }
        public string errorMessage { get; set; }
    }
    //public class PersonIdInfo
    //{
    //    public int idIssuePlaceCode { get; set; }
    //    public DateTime idExpirationDate { get; set; }
    //    public string idIssuePlaceDescAR { get; set; }
    //}

    //public class PersonBasicInfo
    //{
    //    public string birthDateG { get; set; }
    //    public string familyName { get; set; }
    //    public string familyNameT { get; set; }
    //    public string fatherName { get; set; }
    //    public string fatherNameT { get; set; }
    //    public string firstNameT { get; set; }
    //    public string firstName { get; set; }
    //    public string grandFatherName { get; set; }
    //    public string grandFatherNameT { get; set; }
    //    public int sexCode { get; set; }
    //    public string sexDescAr { get; set; }
    //    public string subTribeName { get; set; }
    //}


    public class ResidentInfoByIqamaNumberResponse
    {
        public PersonIdInfo personIdInfo { get; set; }
        public PersonBasicInfo personBasicInfo { get; set; }
        public string errorId { get; set; }
        public ErrorDetail errorDetail { get; set; }
        public bool status { get; set; }
        public string errorMessage { get; set; }
    }
    public class ErrorDetail
    {
        public string errorCode { get; set; }
        public string errorTitle { get; set; }
        public string errorMessage { get; set; }
        public string timestamp { get; set; }
    }

    public class PersonBasicInfo
    {
        public string birthDateG { get; set; }
        public string familyName { get; set; }
        public string familyNameT { get; set; }
        public string fatherName { get; set; }
        public string fatherNameT { get; set; }
        public string firstNameT { get; set; }
        public string firstName { get; set; }
        public string grandFatherName { get; set; }
        public string grandFatherNameT { get; set; }
        public string maritalStatusCode { get; set; }
        public string maritalStatusDescAr { get; set; }
        public string sexCode { get; set; }
        public string sexDescAr { get; set; }
        public string nationalityCode { get; set; }
        public string nationalityDescAr { get; set; }
        public string occupationCode { get; set; }
        public string occupationDescAr { get; set; }
    }

    public class PersonIdInfo
    {
        public int idIssuePlaceCode { get; set; }
        public string idExpirationDate { get; set; }
        public string idIssuePlaceDescAR { get; set; }
    }


    public class VehicleInfoBySequenceResponse
    {
        public VehicleInfo vehicleInfo { get; set; }
        public string errorId { get; set; }
        public ErrorDetail errorDetail { get; set; }
        public bool status { get; set; }
        public string errorMessage { get; set; }
    }

    public class VehicleInfo
    {
        public string plateText1 { get; set; }
        public string plateText2 { get; set; }
        public string plateText3 { get; set; }
        public int plateNumber { get; set; }
        public int regTypeCode { get; set; }
        public string regTypeDescAr { get; set; }
        public string vehicleIDNumber { get; set; }
        public string registrationLocationDescAr { get; set; }
        public string registrationExpiryDate { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int modelYear { get; set; }
        public int bodyTypeCode { get; set; }
        public string bodyTypeDescAr { get; set; }
        public string majorColor { get; set; }
        public int vehicleClassCode { get; set; }
        public string vehicleClassDescAr { get; set; }
        public int cylinder { get; set; }
        public int capacity { get; set; }
        public int weight { get; set; }
    }

    public class VehicleInfoByCustomerNoResponse
    {
        public VehicleCustomCardInfo vehicleCustomCardInfo { get; set; }
        public string errorId { get; set; }
        public ErrorDetail errorDetail { get; set; }
        public bool status { get; set; }
        public string errorMessage { get; set; }
    }

    public class VehicleCustomCardInfo
    {
        public string majorColor { get; set; }
        public string vehcileTypeDescAr { get; set; }
        public string vehicleMaker { get; set; }
        public string vehicleModel { get; set; }
        public VehicleInfoByCustomerNo vehicleInfo { get; set; }
    }

    public class VehicleInfoByCustomerNo
    {
        public string vehicleIDNumber { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int bodyTypeCode { get; set; }
        public string bodyTypeDescAr { get; set; }
        public string majorColor { get; set; }
        public int cylinder { get; set; }
        public int weight { get; set; }
        public string regTypeCode { get; set; }
        public string regTypeDescAr { get; set; }
        public string vehicleClassCode { get; set; }
        public string vehicleClassDescAr { get; set; }
    }
       
    public class NonSaudiByBorderResponse
    {
        public PersonBasicInfo personBasicInfo { get; set; }
        public string errorId { get; set; }
        public ErrorDetail errorDetail { get; set; }
        public bool status { get; set; }
        public string errorMessage { get; set; }
    }



}
