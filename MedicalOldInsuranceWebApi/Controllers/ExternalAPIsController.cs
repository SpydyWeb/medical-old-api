using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.ServiceModel.Security;
using System.Text;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.TP_Services;
using CORE.DTOs.APIs.TPServices;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Authentications;
using CORE.Interfaces;
using InsuranceAPIs.API;
using InsuranceAPIs.Logger;
using InsuranceAPIs.Models.Configuration_Objects;
using InsuranceAPIs.Models.ExternalAPIs;
using MicroAPIs.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Cms;
using Yakeen;

namespace InsuranceAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalAPIsController : ControllerBase
    {
        private static HttpClient client = new HttpClient();

        private readonly AppSettings _appSettings;

        public static IWebHostEnvironment? _environment;

        private readonly ITracker _tracker;

        private readonly IMapping _mapping;

        private readonly IBusiness _business;

        private readonly IProcess _process;

        public ExternalAPIsController(IOptions<AppSettings> appSettings, IWebHostEnvironment environment, ITracker tracker, IMapping mapping, IBusiness business, IProcess process)
        {
            _environment = environment;
            _appSettings = appSettings.Value;
            _tracker = tracker;
            _mapping = mapping;
            _business = business;
            _process = process;
        }

        [HttpPost]
        [Route("SendSms")]
        public async Task<CORE.DTOs.APIs.Unified_Response.Results> SendSms([FromBody] SMSInput sms)
        {
            CORE.DTOs.APIs.Unified_Response.Results resultsInfo = new CORE.DTOs.APIs.Unified_Response.Results();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Prepare the request
                    var request = new HttpRequestMessage(HttpMethod.Post, _appSettings.SmsAPITaqnyat);

                    // Prepare JSON payload
                    var payload = new
                    {
                        source = "SalesPortal",                                // Sender ID
                        messageBody = sms.MessageBody,                         // SMS Body
                        mobileNumber = "966" + sms.Mobile                      // Mobile number with country code
                    };

                    // Serialize and set content
                    string json = JsonConvert.SerializeObject(payload);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Set API Key in header
                    request.Headers.Add("ApiKey", _appSettings.SMSAuthorizationTaqnyat);

                    // Send the request
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode(); // Throws exception if not successful

                    if (response.IsSuccessStatusCode)
                    {
                        // Read response content
                        string dataObjects = await response.Content.ReadAsStringAsync();

                        resultsInfo.httpStatusCode = HttpStatusCode.OK;
                        resultsInfo.message = dataObjects;
                        resultsInfo.ResponseDate = DateTime.Now;
                        resultsInfo.status = true;

                        // Log success
                        ErrorHandler.WriteLog("SMS", "TaqnyatRequest: " + json + " | SMS: " + JsonConvert.SerializeObject(sms), JsonConvert.SerializeObject(resultsInfo), "SendSms");
                    }
                    else
                    {
                        resultsInfo.httpStatusCode = HttpStatusCode.FailedDependency;
                        resultsInfo.message = "Failed to send SMS.";
                        resultsInfo.ResponseDate = DateTime.Now;
                        resultsInfo.status = false;

                        // Log failure
                        ErrorHandler.WriteLog("SMS", "TaqnyatRequest: " + json + " | SMS: " + JsonConvert.SerializeObject(sms), JsonConvert.SerializeObject(resultsInfo), "SendSms");
                    }
                }
            }
            catch (Exception ex)
            {
                resultsInfo.httpStatusCode = HttpStatusCode.ExpectationFailed;
                resultsInfo.message = "Exception occurred while sending SMS.";
                resultsInfo.ResponseDate = DateTime.Now;
                resultsInfo.status = false;

                // Log exception
                ErrorHandler.WriteLog("SMS", "TaqnyatRequest: " + sms.MessageBody + " | SMS: " + JsonConvert.SerializeObject(sms) + " | Error: " + ex.Message, JsonConvert.SerializeObject(resultsInfo), "SendSms");
            }

            return resultsInfo;
        }


        [HttpGet]
        [Route("LoadAllAPIs")]
        public APIsLists LoadAllAPIs()
        {
            APIsLists link = new APIsLists();
            link.services = new List<ServicesLink>();
            link.services = _business.LoadAPIs();
            return link;
        }

        [HttpPost]
        [Route("SendEmail")]
        public void SendEmail([FromBody] EmailInput email)
        {
            string localPath = "";
            List<string> localPaths = new List<string>();
            try
            {
                using MailMessage mail = new MailMessage();
                mail.From = new MailAddress("no-reply@ajt.com.sa");
                mail.To.Add(email.ToEmail);
                mail.Subject = email.Subject;
                mail.Body = email.Body;
                mail.IsBodyHtml = true;
                if (email.attachments != null)
                {
                    foreach (var item in email.attachments)
                    {
                        Random random = new Random();

                        localPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Document\\" + item.Name + random.Next() + "." + item.extName;
                        using (var client = new WebClient())
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                            client.DownloadFile(item.attachmentpath, localPath);
                        }
                        Attachment attachment = new Attachment(localPath); //("path/to/your/file.txt");
                        mail.Attachments.Add(attachment);
                        //MemoryStream ms = new MemoryStream(item.attachmentBinary);
                        //mail.Attachments.Add(new Attachment(ms, item.Name + "." + item.extName, "text/plain"));
                        localPaths.Add(localPath);
                    }
                }

                using (SmtpClient smtp = new SmtpClient("10.150.6.5", 25))
                {
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = false;
                    smtp.Send(mail);
                }
                if (email.isApproval)
                {
                    _process.UpdateApproval(email.approvalID.Value, true, null);
                }
                ErrorHandler.WriteLog("Email", "Email Sent Successfully", JsonConvert.SerializeObject(email), "SendEmail");
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, "", JsonConvert.SerializeObject(email), "SendEmail");
            }
            finally
            {
                if (localPaths != null)
                {
                    foreach (var item in localPaths)
                    {
                        if (!string.IsNullOrEmpty(item) && System.IO.File.Exists(item))
                        {
                            System.IO.File.Delete(localPath);
                        }
                    }
                }

            }
        }

        [HttpPost]
        [Route("YakeenSingle")]
        public SingeYakeenResponse YakeenSingle([FromBody] YakeenSingleInput obj)
        {
            SingeYakeenResponse singeYakeenResponse = new SingeYakeenResponse();
            try
            {
                YakeenMembers yakeenLocal = _business.getYakeenMembers(obj.NationalId, obj.Sponsor);
                if (yakeenLocal == null)
                {
                    //Yakeen4SolidarityClient client = new Yakeen4SolidarityClient();
                    if (obj.NationalId.Substring(0, 1) == "1")
                    {
                        citizenInfoByNINRequest CitizenReq = new citizenInfoByNINRequest();
                        //getCitizenInfoByNIN getCitizen = new getCitizenInfoByNIN();
                        //getCitizenInfoByNINResponse CitizenResp = new getCitizenInfoByNINResponse();
                        CitizenReq.password = Utilities.YAKEENPWD();
                        CitizenReq.userName = Utilities.YAKEENUSERNAME();
                        CitizenReq.chargeCode = Utilities.YAKEENPROD();
                        CitizenReq.dateOfBirth = obj.Hijri;
                        CitizenReq.nin = obj.NationalId;
                        //getCitizen.CitizenInfoByNINRequest = new citizenInfoByNINRequest();
                        //getCitizen.CitizenInfoByNINRequest = CitizenReq;
                        try
                        {
                            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            //ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                            //client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
                            //{
                            //    CertificateValidationMode = X509CertificateValidationMode.None,
                            //    RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                            //};
                            //CitizenResp = client.getCitizenInfoByNINAsync(getCitizen).Result;
                            string citizenReq = "nin=" + obj.NationalId + "&dateString=" + obj.Hijri + "&Source=PROD";
                            List<SaudiByNinResponse> CitizenResp = new List<SaudiByNinResponse>();
                            CitizenResp = ApiCall.ExecuteGetApi<List<SaudiByNinResponse>>(citizenReq, _appSettings.YakeenAPIConfig.URL + "SaudiByNin", _appSettings.YakeenAPIConfig.ApiKey);
                            //citizenInfoByNINResult Result = new citizenInfoByNINResult();
                            if (CitizenResp != null && CitizenResp.Count > 0 && CitizenResp[0].status)
                            {
                                YakeenLogsMember yakeenLogs = new YakeenLogsMember();
                                singeYakeenResponse.Name = CitizenResp[0].personBasicInfo.firstName + " " + CitizenResp[0].personBasicInfo.grandFatherName + " " + CitizenResp[0].personBasicInfo.familyName;
                                singeYakeenResponse.Gender = Convert.ToInt32(CitizenResp[0].personBasicInfo.sexCode);
                                singeYakeenResponse.DateOfBirth = CitizenResp[0].personBasicInfo.birthDateG;
                                singeYakeenResponse.status = true;
                                singeYakeenResponse.ResponseDate = DateTime.Now;
                                singeYakeenResponse.httpStatusCode = HttpStatusCode.OK;

                                //Result = CitizenResp.CitizenInfoByNINResult;
                                //singeYakeenResponse.Name = Result.firstName + " " + Result.grandFatherName + " " + Result.familyName;
                                //singeYakeenResponse.Gender = ((Result.gender == gender.M) ? 1 : 2);
                                //singeYakeenResponse.DateOfBirth = Result.dateOfBirthG;
                                //singeYakeenResponse.status = true;
                                //singeYakeenResponse.ResponseDate = DateTime.Now;
                                //singeYakeenResponse.httpStatusCode = HttpStatusCode.OK;

                            }
                            else
                            {
                                string errorMessage = "";
                                if (CitizenResp[0].errorDetail != null)
                                {
                                    //errorMessage = JsonConvert.SerializeObject(ResidentResponse[0].errorDetail);
                                    errorMessage = CitizenResp[0].errorDetail.errorMessage;
                                }
                                else
                                {
                                    errorMessage = CitizenResp[0].errorMessage;
                                }
                                singeYakeenResponse.status = false;
                                singeYakeenResponse.ResponseDate = DateTime.Now;
                                singeYakeenResponse.httpStatusCode = HttpStatusCode.InternalServerError;
                                singeYakeenResponse.message = errorMessage;
                            }
                        }
                        catch (Exception ex2)
                        {
                            singeYakeenResponse.status = false;
                            singeYakeenResponse.ResponseDate = DateTime.Now;
                            singeYakeenResponse.httpStatusCode = HttpStatusCode.InternalServerError;
                            singeYakeenResponse.message = ex2.Message;
                        }
                    }
                    else if (obj.NationalId.Substring(0, 1) == "2")
                    {
                        residentInfoByIqamaNumberRequest alienInfo = new residentInfoByIqamaNumberRequest();
                        residentInfoByIqamaNumberResult alienResult = new residentInfoByIqamaNumberResult();
                        //getResidentInfoByIqamaNumber AlienInfoResp = new getResidentInfoByIqamaNumber();
                        //getResidentInfoByIqamaNumberResponse ResidentResponse = new getResidentInfoByIqamaNumberResponse();
                        //alienInfo.password = Utilities.YAKEENPWD();
                        //alienInfo.userName = Utilities.YAKEENUSERNAME();
                        //alienInfo.chargeCode = Utilities.YAKEENPROD();
                        //alienInfo.iqamaNumber = obj.NationalId;
                        //alienInfo.sponsorId = obj.Sponsor;
                        //AlienInfoResp.ResidentInfoByIqamaNumberRequest = new residentInfoByIqamaNumberRequest();
                        //AlienInfoResp.ResidentInfoByIqamaNumberRequest = alienInfo;
                        try
                        {
                            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            //ResidentResponse = client.getResidentInfoByIqamaNumberAsync(AlienInfoResp).Result;

                            string ResidentInfoByIqamaNumberRequest = "IQamaNumber=" + obj.NationalId + "&sponsorID=" + obj.Sponsor + "&Source=PROD";
                            List<ResidentInfoByIqamaNumberResponse> ResidentResponse = new List<ResidentInfoByIqamaNumberResponse>();
                            ResidentResponse = ApiCall.ExecuteGetApi<List<ResidentInfoByIqamaNumberResponse>>(ResidentInfoByIqamaNumberRequest, _appSettings.YakeenAPIConfig.URL + "ResidentInfoByIqamaNumber", _appSettings.YakeenAPIConfig.ApiKey);

                            if (ResidentResponse != null && ResidentResponse.Count > 0 && ResidentResponse[0].status)
                            {
                                singeYakeenResponse.Name = ResidentResponse[0].personBasicInfo.firstNameT + " " + ResidentResponse[0].personBasicInfo.fatherNameT + " " + ResidentResponse[0].personBasicInfo.familyNameT;
                                singeYakeenResponse.Gender = Convert.ToInt32(ResidentResponse[0].personBasicInfo.sexCode);
                                singeYakeenResponse.DateOfBirth = ResidentResponse[0].personBasicInfo.birthDateG;
                                singeYakeenResponse.status = true;
                                singeYakeenResponse.ResponseDate = DateTime.Now;
                                singeYakeenResponse.httpStatusCode = HttpStatusCode.OK;

                                //residentInfoByIqamaNumberResult result = ResidentResponse.ResidentInfoByIqamaNumberResult;
                                //singeYakeenResponse.Name = result.englishFirstName + " " + result.englishSecondName + " " + result.englishLastName;
                                //singeYakeenResponse.Gender = ((result.gender == gender.M) ? 1 : 2);
                                //singeYakeenResponse.DateOfBirth = result.dateOfBirthG;
                                //singeYakeenResponse.status = true;
                                //singeYakeenResponse.ResponseDate = DateTime.Now;
                                //singeYakeenResponse.httpStatusCode = HttpStatusCode.OK;
                            }
                            else
                            {
                                string errorMessage = "";
                                if (ResidentResponse[0].errorDetail != null)
                                {
                                    //errorMessage = JsonConvert.SerializeObject(ResidentResponse[0].errorDetail);
                                    errorMessage = ResidentResponse[0].errorDetail.errorMessage;
                                }
                                else
                                {
                                    errorMessage = ResidentResponse[0].errorMessage;
                                }
                                singeYakeenResponse.status = false;
                                singeYakeenResponse.ResponseDate = DateTime.Now;
                                singeYakeenResponse.httpStatusCode = HttpStatusCode.InternalServerError;
                                singeYakeenResponse.message = errorMessage;
                            }
                        }
                        catch (Exception e)
                        {
                            singeYakeenResponse.status = false;
                            singeYakeenResponse.ResponseDate = DateTime.Now;
                            singeYakeenResponse.httpStatusCode = HttpStatusCode.InternalServerError;
                            singeYakeenResponse.message = e.Message;
                        }
                    }
                }
                else
                {
                    singeYakeenResponse.Name = yakeenLocal.Members.Name;
                    singeYakeenResponse.Gender = yakeenLocal.Members.Gender;
                    singeYakeenResponse.DateOfBirth = yakeenLocal.Members.DateOfBirth.ToString();
                    singeYakeenResponse.status = true;
                    singeYakeenResponse.ResponseDate = DateTime.Now;
                    singeYakeenResponse.httpStatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                singeYakeenResponse.status = false;
                singeYakeenResponse.ResponseDate = DateTime.Now;
                singeYakeenResponse.httpStatusCode = HttpStatusCode.InternalServerError;
                singeYakeenResponse.message = ex.Message;
            }
            return singeYakeenResponse;
        }

        [HttpPost]
        [Route("YakeenVehicles")]
        public YakeenCarResponse YakeenVehicle([FromBody] YakeenVehiclesInput obj)
        {
            YakeenCarResponse yakeenCarResponse = new YakeenCarResponse();
            yakeenCarResponse.lsYkeen = new List<YkeenCars>();
            obj.lstVehicleInfo.ForEach(delegate (CORE.DTOs.APIs.TP_Services.VehicleInfo item)
            {
                YkeenCars ykeenCars = new YkeenCars();
                try
                {
                    //Yakeen4SolidarityClient yakeen4SolidarityClient = new Yakeen4SolidarityClient(Yakeen4SolidarityClient.EndpointConfiguration.Yakeen4SolidarityPort);
                    if (!string.IsNullOrEmpty(item.Sequence))
                    {
                        //getCarInfoBySequence getCarInfoBySequence = new getCarInfoBySequence();
                        //carInfoBySequenceRequest carInfoBySequenceRequest = new carInfoBySequenceRequest
                        //{
                        //    sequenceNumber = Convert.ToInt32(item.Sequence),
                        //    userName = Utilities.YAKEENUSERNAME(),
                        //    password = Utilities.YAKEENPWD(),
                        //    chargeCode = Utilities.YAKEENPROD(),
                        //    ownerID = Convert.ToInt64(item.NationalId)
                        //};
                        //getCarInfoBySequence.CarInfoBySequenceRequest = new carInfoBySequenceRequest();
                        //getCarInfoBySequence.CarInfoBySequenceRequest = carInfoBySequenceRequest;
                        //getCarInfoBySequenceResponse carInfoBySequence = yakeen4SolidarityClient.getCarInfoBySequenceAsync(getCarInfoBySequence).Result;

                        //carInfoBySequenceResult carInfoBySequenceResult = new carInfoBySequenceResult();
                        //carInfoBySequenceResult = carInfoBySequence.CarInfoBySequenceResult;

                        string VehicleInfoBySequenceRequest = "ownerID=" + item.NationalId + "&vehicleSequenceNo=" + Convert.ToInt32(item.Sequence) + "&Source=PROD";
                        List<VehicleInfoBySequenceResponse> VehicleInfoBySequenceResponses = new List<VehicleInfoBySequenceResponse>();
                        VehicleInfoBySequenceResponses = ApiCall.ExecuteGetApi<List<VehicleInfoBySequenceResponse>>(VehicleInfoBySequenceRequest, _appSettings.YakeenAPIConfig.URL + "VehicleInfoBySequenceNo", _appSettings.YakeenAPIConfig.ApiKey);

                        if (VehicleInfoBySequenceResponses != null && VehicleInfoBySequenceResponses.Count > 0 && VehicleInfoBySequenceResponses[0].status)
                        {
                            ykeenCars.vehicleBodyCode = Convert.ToInt16(VehicleInfoBySequenceResponses[0].vehicleInfo.bodyTypeCode);
                            ykeenCars.vehicleMakerCode = Convert.ToInt16(VehicleInfoBySequenceResponses[0].vehicleInfo.make);
                            ykeenCars.vehicleCapacity = VehicleInfoBySequenceResponses[0].vehicleInfo.capacity;
                            ykeenCars.licenseExpiryDate = VehicleInfoBySequenceResponses[0].vehicleInfo.registrationExpiryDate;
                            ykeenCars.majorColor = VehicleInfoBySequenceResponses[0].vehicleInfo.majorColor;
                            ykeenCars.chassisNumber = "";
                            ykeenCars.plateNumber = Convert.ToInt16(VehicleInfoBySequenceResponses[0].vehicleInfo.plateNumber);
                            ykeenCars.cylinders = Convert.ToInt16(VehicleInfoBySequenceResponses[0].vehicleInfo.cylinder);
                            ykeenCars.logId = null;
                            ykeenCars.modelYear = Convert.ToInt16(VehicleInfoBySequenceResponses[0].vehicleInfo.modelYear);
                            ykeenCars.ownerName = "";
                            ykeenCars.plateText1 = VehicleInfoBySequenceResponses[0].vehicleInfo.plateText1;
                            ykeenCars.plateText2 = VehicleInfoBySequenceResponses[0].vehicleInfo.plateText2;
                            ykeenCars.plateText3 = VehicleInfoBySequenceResponses[0].vehicleInfo.plateText3;
                            ykeenCars.plateTypeCode = null;
                            ykeenCars.plateNumber = Convert.ToInt16(VehicleInfoBySequenceResponses[0].vehicleInfo.plateNumber);
                            ykeenCars.vehicleModel = VehicleInfoBySequenceResponses[0].vehicleInfo.model;
                            yakeenCarResponse.lsYkeen.Add(ykeenCars);

                            //ykeenCars.vehicleBodyCode = carInfoBySequenceResult.vehicleBodyCode;
                            //ykeenCars.vehicleMakerCode = carInfoBySequenceResult.vehicleMakerCode;
                            //ykeenCars.vehicleCapacity = carInfoBySequenceResult.vehicleCapacity;
                            //ykeenCars.licenseExpiryDate = carInfoBySequenceResult.licenseExpiryDate;
                            //ykeenCars.majorColor = carInfoBySequenceResult.majorColor;
                            //ykeenCars.chassisNumber = carInfoBySequenceResult.chassisNumber;
                            //ykeenCars.plateNumber = carInfoBySequenceResult.plateNumber;
                            //ykeenCars.chassisNumber = carInfoBySequenceResult.chassisNumber;
                            //ykeenCars.cylinders = carInfoBySequenceResult.cylinders;
                            //ykeenCars.licenseExpiryDate = carInfoBySequenceResult.licenseExpiryDate;
                            //ykeenCars.logId = carInfoBySequenceResult.logId;
                            //ykeenCars.modelYear = carInfoBySequenceResult.modelYear;
                            //ykeenCars.ownerName = carInfoBySequenceResult.ownerName;
                            //ykeenCars.plateText1 = carInfoBySequenceResult.plateText1;
                            //ykeenCars.plateText2 = carInfoBySequenceResult.plateText2;
                            //ykeenCars.plateText3 = carInfoBySequenceResult.plateText3;
                            //ykeenCars.plateTypeCode = carInfoBySequenceResult.plateTypeCode;
                            //ykeenCars.plateNumber = carInfoBySequenceResult.plateNumber;
                            //ykeenCars.vehicleModel = carInfoBySequenceResult.vehicleModel;
                            //yakeenCarResponse.lsYkeen.Add(ykeenCars);
                        }
                    }
                    else
                    {
                        //getNewVehicleInfoByCustomNumber getNewVehicleInfoByCustomNumber = new getNewVehicleInfoByCustomNumber();
                        //newVehicleInfoByCustomNumberRequest newVehicleInfoByCustomNumberRequest = new newVehicleInfoByCustomNumberRequest
                        //{
                        //    customCardNumber = item.Custom,
                        //    userName = Utilities.YAKEENUSERNAME(),
                        //    password = Utilities.YAKEENPWD(),
                        //    chargeCode = Utilities.YAKEENPROD()
                        //};
                        //getNewVehicleInfoByCustomNumber.NewVehicleInfoByCustomNumberRequest = new newVehicleInfoByCustomNumberRequest();
                        //getNewVehicleInfoByCustomNumber.NewVehicleInfoByCustomNumberRequest = newVehicleInfoByCustomNumberRequest;

                        string VehicleInfoByCustomerNoRequest = "customNo=" + item.Custom + "&modelYear=0&Source=PROD";
                        List<VehicleInfoByCustomerNoResponse> vehicleInfoByCustomerNoResponses = new List<VehicleInfoByCustomerNoResponse>();
                        vehicleInfoByCustomerNoResponses = ApiCall.ExecuteGetApi<List<VehicleInfoByCustomerNoResponse>>(VehicleInfoByCustomerNoRequest, _appSettings.YakeenAPIConfig.URL + "VehicleInfoByCustomeNo", _appSettings.YakeenAPIConfig.ApiKey);

                        //getNewVehicleInfoByCustomNumberResponse newVehicleInfoByCustomNumber = yakeen4SolidarityClient.getNewVehicleInfoByCustomNumberAsync(getNewVehicleInfoByCustomNumber).Result;
                        //getNewVehicleInfoByCustomNumberResponse getNewVehicleInfoByCustomNumberResponse = new getNewVehicleInfoByCustomNumberResponse();
                    }
                }
                catch (Exception)
                {
                }
            });
            return null;
        }
    }
}
