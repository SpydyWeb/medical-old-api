using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Security;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.Authentications;
using CORE.Helpers;
using CORE.Interfaces;
using CORE.TablesObjects;
using DataAccessLayer.Oracle.Eskadenia.Endorsments;
using DataAccessLayer.Oracle.Eskadenia.Issuance;
using Endoresement;
using EskaPolicies;
using Microsoft.Extensions.Logging;
using Service.Common;
using Service.Interfaces;
using Yakeen;

namespace Service.Services
{
    public class WSCoreImplementations : IWSCoreService
    {
        private readonly IEwsService _MailService;

        private readonly ILogger<WSCoreImplementations> _Logger;

        private readonly IBusiness _Business;

        private readonly IUserManagment _User;

        public WSCoreImplementations(ILogger<WSCoreImplementations> _logger, IEwsService mailService, IBusiness business, IUserManagment Users)
        {
            _MailService = mailService;
            _Logger = _logger;
            _Business = business;
            _User = Users;
        }

        public bool PushYakeen()
        {
            List<Policy> policies = new List<Policy>();
            List<Subjects> MemberstoUpdate = new List<Subjects>();
            policies = _Business.LoadPendingForSyncSubject();
            foreach (Policy policy in policies)
            {
                List<Subjects> EmployeesDirect = policy.Members.Where((Subjects p) => p.Relation == 1).ToList();
                List<Subjects> Family = policy.Members.Where((Subjects p) => p.Relation != 1).ToList();
                YakeenProccess yakeenProccess = new YakeenProccess();
                foreach (Subjects employee in EmployeesDirect)
                {
                    YakeenMembers yakeenLocal = _Business.getYakeenMembers(employee.NationalId, employee.Princible);
                    Members ObjMem2 = new Members();
                    ObjMem2.membersData = new MembersData();
                    ObjMem2.membersData.MainMember = new Subjects();
                    if (yakeenLocal == null && yakeenLocal.Members == null)
                    {
                        yakeenProccess = InsertYakeenAsync(employee, _Business);
                        if (!yakeenProccess.Status)
                        {
                            employee.YakeenError = yakeenProccess.errorMembers.membersData.Error;
                            employee.NeedsReCalculation = true;
                            employee.PushedToYakeen = false;
                            MemberstoUpdate.Add(employee);
                            break;
                        }
                        yakeenLocal = _Business.getYakeenMembers(employee.NationalId, employee.Princible);
                    }
                    NationalityMapping nationality2 = _Business.GetEskaNationalityByEska(yakeenLocal.Members.Nationality);
                    int Age2 = Utilities.AgeCalculation(yakeenLocal.Members.DateOfBirth.Value);
                    if (yakeenLocal.Members.MartialStatus == employee.MartialStatus && nationality2.EskaCode == employee.NationalityCode && Age2 == employee.Age && yakeenLocal.Members.Gender == employee.Gender)
                    {
                        employee.PushedToYakeen = true;
                        employee.YakeenError = null;
                        employee.NeedsReCalculation = false;
                    }
                    else
                    {
                        employee.PushedToYakeen = true;
                        employee.YakeenError = null;
                        employee.NeedsReCalculation = true;
                    }
                    employee.Name = yakeenLocal.Members.Name;
                    employee.Age = Age2;
                    employee.Princible = yakeenLocal.Members.Sponsor;
                    employee.DateOfBirth = yakeenLocal.Members.DateOfBirth;
                    employee.Occupation = yakeenLocal.Members.Occupation.ToString();
                    employee.PassportNo = yakeenLocal.Members.NationalId;
                    employee.MartialStatus = yakeenLocal.Members.MartialStatus;
                    employee.NationalityCode = nationality2.EskaCode;
                    employee.ClassId = nationality2.ClassId;
                    employee.Gender = yakeenLocal.Members.Gender;
                    if (employee.MartialStatus != 2)
                    {
                        employee.MartialStatus = yakeenLocal.Members.MartialStatus;
                    }
                    MemberstoUpdate.Add(employee);
                }
                foreach (Subjects Member in Family)
                {
                    YakeenMembers yakeenLocalMember = _Business.getYakeenMembers(Member.NationalId, Member.Princible);
                    Members ObjMem = new Members();
                    ObjMem.membersData = new MembersData();
                    ObjMem.membersData.MainMember = new Subjects();
                    yakeenProccess = new YakeenProccess();
                    if (yakeenLocalMember == null && yakeenLocalMember.Members == null)
                    {
                        yakeenProccess = InsertYakeenAsync(Member, _Business);
                        if (yakeenProccess.Status)
                        {
                            yakeenLocalMember = _Business.getYakeenMembers(Member.NationalId, Member.Princible);
                            continue;
                        }
                        Member.YakeenError = yakeenProccess.errorMembers.membersData.Error;
                        Member.NeedsReCalculation = true;
                        MemberstoUpdate.Add(Member);
                        break;
                    }
                    NationalityMapping nationality = _Business.GetEskaNationalityByEska(yakeenLocalMember.Members.Nationality);
                    int Age = Utilities.AgeCalculation(yakeenLocalMember.Members.DateOfBirth.Value);
                    if (yakeenLocalMember.Members.MartialStatus == Member.MartialStatus && nationality.EskaCode == Member.NationalityCode && Age == Member.Age && yakeenLocalMember.Members.Gender == Member.Gender)
                    {
                        Member.PushedToYakeen = true;
                        Member.YakeenError = null;
                        Member.NeedsReCalculation = false;
                    }
                    else
                    {
                        Member.PushedToYakeen = true;
                        Member.YakeenError = null;
                        Member.NeedsReCalculation = true;
                    }
                    Member.Name = yakeenLocalMember.Members.Name;
                    Member.Age = Age;
                    Member.Princible = yakeenLocalMember.Members.Sponsor;
                    Member.DateOfBirth = yakeenLocalMember.Members.DateOfBirth;
                    Member.Occupation = yakeenLocalMember.Members.Occupation.ToString();
                    Member.PassportNo = yakeenLocalMember.Members.NationalId;
                    Member.MartialStatus = yakeenLocalMember.Members.MartialStatus;
                    Member.NationalityCode = nationality.EskaCode;
                    Member.ClassId = nationality.ClassId;
                    Member.Gender = yakeenLocalMember.Members.Gender;
                    if (Member.MartialStatus != 2)
                    {
                        Member.MartialStatus = yakeenLocalMember.Members.MartialStatus;
                    }
                    MemberstoUpdate.Add(Member);
                }
            }
            return true;
        }

        private static YakeenProccess InsertYakeenAsync(Subjects mainMemberInfo, IBusiness business)
        {
            YakeenProccess yakeenProccess = new YakeenProccess();
            Yakeen4SolidarityClient client = new Yakeen4SolidarityClient();
            if (mainMemberInfo.NationalId.Substring(0, 1) == "1")
            {
                Dates dates = new Dates();
                string Date = dates.ConverToHijri(mainMemberInfo.HijriDate);
                if (Date.Length <= 6)
                {
                    Date = "0" + Date;
                }
                citizenInfoByNINRequest CitizenReq = new citizenInfoByNINRequest();
                getCitizenInfoByNIN getCitizen = new getCitizenInfoByNIN();
                getCitizenInfoByNINResponse CitizenResp = new getCitizenInfoByNINResponse();
                CitizenReq.password = Utilities.YAKEENPWD();
                CitizenReq.userName = Utilities.YAKEENUSERNAME();
                CitizenReq.chargeCode = Utilities.YAKEENPROD();
                CitizenReq.dateOfBirth = Date;
                CitizenReq.nin = mainMemberInfo.NationalId;
                getCitizen.CitizenInfoByNINRequest = new citizenInfoByNINRequest();
                getCitizen.CitizenInfoByNINRequest = CitizenReq;
                try
                {
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                    client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
                    {
                        CertificateValidationMode = X509CertificateValidationMode.None,
                        RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                    };

                    CitizenResp = client.getCitizenInfoByNINAsync(getCitizen).Result;
                    citizenInfoByNINResult Result = new citizenInfoByNINResult();
                    if (CitizenResp != null)
                    {
                        YakeenLogsMember yakeenLogs = new YakeenLogsMember();
                        Result = CitizenResp.CitizenInfoByNINResult;
                        Members ObjMem = new Members();
                        ObjMem.membersData = new MembersData();
                        ObjMem.membersData.MainMember = new Subjects();
                        NationalityMapping nationality = business.GetEskaNationality(0);
                        ObjMem.membersData.MainMember.Name = Result.firstName + " " + Result.fatherName + " " + Result.familyName;
                        ObjMem.membersData.MainMember.DateOfBirth = Convert.ToDateTime(Result.dateOfBirthG);
                        ObjMem.membersData.MainMember.Gender = ((Result.gender != gender.F) ? 1 : 2);
                        ObjMem.membersData.MainMember.MartialStatus = mainMemberInfo.MartialStatus;
                        ObjMem.membersData.MainMember.Age = Utilities.AgeCalculation(ObjMem.membersData.MainMember.DateOfBirth.Value);
                        ObjMem.membersData.MainMember.Occupation = "6331025";
                        ObjMem.membersData.MainMember.NationalityCode = "SA";
                        ObjMem.membersData.MainMember.PassportNo = mainMemberInfo.NationalId;
                        ObjMem.membersData.MainMember.NationalId = mainMemberInfo.NationalId;
                        ObjMem.membersData.MainMember.ClassId = nationality.ClassId;
                        ObjMem.membersData.MainMember.Relation = mainMemberInfo.Relation;
                        ObjMem.membersData.MainMember.Princible = mainMemberInfo.Princible;
                        ObjMem.membersData.OccupationName = "Normal Worker";
                        ObjMem.membersData.NationalityAr = "Saudi Arabia";
                        ObjMem.membersData.NationalityEn = "Saudi Arabia";
                        yakeenLogs.Name = Result.firstName + " " + Result.fatherName + " " + Result.familyName;
                        yakeenLogs.DateOfBirth = Convert.ToDateTime(Result.dateOfBirthG);
                        yakeenLogs.Gender = ((Result.gender != gender.F) ? 1 : 2);
                        yakeenLogs.MartialStatus = mainMemberInfo.MartialStatus.Value;
                        yakeenLogs.DateOfBirth = Convert.ToDateTime(Result.dateOfBirthG);
                        yakeenLogs.Occupation = 6331025;
                        yakeenLogs.Nationality = "SA";
                        yakeenLogs.NationalId = mainMemberInfo.NationalId;
                        yakeenLogs.Sponsor = mainMemberInfo.Princible;
                        yakeenLogs.RecordDate = DateTime.Now;
                        yakeenLogs.Relation = mainMemberInfo.Relation;
                        business.AddUpdateYakeenMembers(yakeenLogs);
                        yakeenProccess.membersData = ObjMem.membersData;
                        yakeenProccess.Status = true;
                    }
                }
                catch (Exception e)
                {
                    ErrorMembers errorMembers = new ErrorMembers();
                    errorMembers.dependMember = new List<ErrorsDependent>();
                    errorMembers.membersData = new Princible();
                    ErrorsDependent data = new ErrorsDependent();
                    errorMembers.membersData.NationalId = mainMemberInfo.NationalId;
                    errorMembers.membersData.IsSuccess = false;
                    errorMembers.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                    errorMembers.membersData.Error = e.Message;
                    yakeenProccess.errorMembers = errorMembers;
                    yakeenProccess.Status = false;
                }
            }
            else if (mainMemberInfo.NationalId.Substring(0, 1) == "2")
            {
                residentInfoByIqamaNumberRequest alienInfo = new residentInfoByIqamaNumberRequest();
                residentInfoByIqamaNumberResult alienResult = new residentInfoByIqamaNumberResult();
                getResidentInfoByIqamaNumber AlienInfoResp = new getResidentInfoByIqamaNumber();
                getResidentInfoByIqamaNumberResponse ResidentResponse = new getResidentInfoByIqamaNumberResponse();
                alienInfo.password = Utilities.YAKEENPWD();
                alienInfo.userName = Utilities.YAKEENUSERNAME();
                alienInfo.chargeCode = Utilities.YAKEENPROD();
                alienInfo.iqamaNumber = mainMemberInfo.NationalId;
                alienInfo.sponsorId = mainMemberInfo.Princible;
                AlienInfoResp.ResidentInfoByIqamaNumberRequest = new residentInfoByIqamaNumberRequest();
                AlienInfoResp.ResidentInfoByIqamaNumberRequest = alienInfo;
                try
                {
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                    client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
                    {
                        CertificateValidationMode = X509CertificateValidationMode.None,
                        RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                    };
                    ResidentResponse = client.getResidentInfoByIqamaNumberAsync(AlienInfoResp).Result;
                    if (ResidentResponse != null && ResidentResponse.ResidentInfoByIqamaNumberResult != null)
                    {
                        YakeenLogsMember yakeenLogs2 = new YakeenLogsMember();
                        Members ObjMem2 = new Members();
                        ObjMem2.membersData = new MembersData();
                        ObjMem2.membersData.MainMember = new Subjects();
                        ObjMem2.membersData.MainMember.Name = ResidentResponse.ResidentInfoByIqamaNumberResult.englishFirstName + " " + ResidentResponse.ResidentInfoByIqamaNumberResult.englishSecondName + " " + ResidentResponse.ResidentInfoByIqamaNumberResult.englishThirdName;
                        ObjMem2.membersData.MainMember.DateOfBirth = Convert.ToDateTime(ResidentResponse.ResidentInfoByIqamaNumberResult.dateOfBirthG);
                        ObjMem2.membersData.MainMember.Gender = ((ResidentResponse.ResidentInfoByIqamaNumberResult.gender != gender.F) ? 1 : 2);
                        ObjMem2.membersData.MainMember.MartialStatus = ((ResidentResponse.ResidentInfoByIqamaNumberResult.socialStatus.Contains("???") || ResidentResponse.ResidentInfoByIqamaNumberResult.socialStatus.Contains("????") || ResidentResponse.ResidentInfoByIqamaNumberResult.socialStatus.Contains("????") || ResidentResponse.ResidentInfoByIqamaNumberResult.socialStatus.Contains("????") || ResidentResponse.ResidentInfoByIqamaNumberResult.socialStatus.Contains("????") || ResidentResponse.ResidentInfoByIqamaNumberResult.socialStatus.Contains("?????")) ? 1 : 2);
                        ObjMem2.membersData.MainMember.Age = Utilities.AgeCalculation(ObjMem2.membersData.MainMember.DateOfBirth.Value);
                        ObjMem2.membersData.MainMember.PassportNo = mainMemberInfo.NationalId;
                        ObjMem2.membersData.MainMember.NationalId = mainMemberInfo.NationalId;
                        ObjMem2.membersData.MainMember.Relation = mainMemberInfo.Relation;
                        ObjMem2.membersData.MainMember.Princible = mainMemberInfo.Princible;
                        ObjMem2.membersData.MainMember.IdentityExpiryDate = ResidentResponse.ResidentInfoByIqamaNumberResult.iqamaExpiryDateG;
                        NationalityMapping nationality2 = business.GetEskaNationality(ResidentResponse.ResidentInfoByIqamaNumberResult.nationalityCode);
                        ObjMem2.membersData.MainMember.NationalityCode = nationality2.EskaCode;
                        ObjMem2.membersData.MainMember.ClassId = nationality2.ClassId;
                        ObjMem2.membersData.NationalityAr = nationality2.NationalityNameAr;
                        ObjMem2.membersData.NationalityEn = nationality2.NationalityNameEn;
                        ObjMem2.membersData.OccupationName = ResidentResponse.ResidentInfoByIqamaNumberResult.occupationCode.ToString();
                        ObjMem2.membersData.MainMember.Occupation = ResidentResponse.ResidentInfoByIqamaNumberResult.occupationCode.ToString();
                        yakeenLogs2.Name = ObjMem2.membersData.MainMember.Name;
                        yakeenLogs2.DateOfBirth = ObjMem2.membersData.MainMember.DateOfBirth;
                        yakeenLogs2.Gender = ObjMem2.membersData.MainMember.Gender.Value;
                        yakeenLogs2.MartialStatus = mainMemberInfo.MartialStatus.Value;
                        yakeenLogs2.Occupation = Convert.ToInt32(ObjMem2.membersData.MainMember.Occupation);
                        yakeenLogs2.Nationality = nationality2.EskaCode;
                        yakeenLogs2.NationalId = mainMemberInfo.NationalId;
                        yakeenLogs2.Sponsor = mainMemberInfo.Princible;
                        yakeenLogs2.RecordDate = DateTime.Now;
                        yakeenLogs2.Relation = mainMemberInfo.Relation;
                        yakeenLogs2.IdentityExpiryDate = Convert.ToDateTime(ResidentResponse.ResidentInfoByIqamaNumberResult.iqamaExpiryDateG);
                        business.AddUpdateYakeenMembers(yakeenLogs2);
                        yakeenProccess.membersData = ObjMem2.membersData;
                        yakeenProccess.Status = true;
                    }
                }
                catch (Exception e2)
                {
                    ErrorMembers errorMembers2 = new ErrorMembers();
                    errorMembers2.dependMember = new List<ErrorsDependent>();
                    errorMembers2.membersData = new Princible();
                    ErrorsDependent data2 = new ErrorsDependent();
                    errorMembers2.membersData.NationalId = mainMemberInfo.NationalId;
                    errorMembers2.membersData.IsSuccess = false;
                    errorMembers2.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                    errorMembers2.membersData.Error = e2.Message;
                    yakeenProccess.errorMembers = errorMembers2;
                    yakeenProccess.Status = false;
                }
            }
            else
            {
                getResidentInfoByBorderNumber Request = new getResidentInfoByBorderNumber();
                residentInfoByBorderNumberRequest CrRequest = new residentInfoByBorderNumberRequest();
                residentInfoByBorderNumberResult CrResult = new residentInfoByBorderNumberResult();
                getResidentInfoByBorderNumberResponse Response = new getResidentInfoByBorderNumberResponse();
                Yakeen4SolidarityClient yakeenClient = new Yakeen4SolidarityClient();
                CrRequest.borderNumber = mainMemberInfo.NationalId;
                CrRequest.password = Utilities.YAKEENPWD();
                CrRequest.userName = Utilities.YAKEENUSERNAME();
                CrRequest.chargeCode = Utilities.YAKEENPROD();
                CrRequest.sponsorId = mainMemberInfo.Princible;
                Request.ResidentInfoByBorderNumberRequest = new residentInfoByBorderNumberRequest();
                Request.ResidentInfoByBorderNumberRequest = CrRequest;
                try
                {
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                    yakeenClient.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
                    {
                        CertificateValidationMode = X509CertificateValidationMode.None,
                        RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                    };
                    Response = yakeenClient.getResidentInfoByBorderNumberAsync(Request).Result;
                    if (Response != null)
                    {
                        YakeenLogsMember yakeenLogs3 = new YakeenLogsMember();
                        Members ObjMem3 = new Members();
                        ObjMem3.membersData = new MembersData();
                        ObjMem3.membersData.MainMember = new Subjects();
                        ObjMem3.ErrDep = new List<ErrorMembers>();
                        ObjMem3.membersData.MainMember.Name = Response.ResidentInfoByBorderNumberResult.firstName + " " + Response.ResidentInfoByBorderNumberResult.seconedName + " " + Response.ResidentInfoByBorderNumberResult.familyName;
                        ObjMem3.membersData.MainMember.DateOfBirth = Convert.ToDateTime(Response.ResidentInfoByBorderNumberResult.birthDateG);
                        ObjMem3.membersData.MainMember.Gender = ((Response.ResidentInfoByBorderNumberResult.gender != gender.F) ? 1 : 2);
                        ObjMem3.membersData.MainMember.MartialStatus = mainMemberInfo.MartialStatus;
                        ObjMem3.membersData.MainMember.Age = Utilities.AgeCalculation(ObjMem3.membersData.MainMember.DateOfBirth.Value);
                        ObjMem3.membersData.MainMember.PassportNo = mainMemberInfo.NationalId;
                        ObjMem3.membersData.MainMember.NationalId = mainMemberInfo.NationalId;
                        ObjMem3.membersData.MainMember.Relation = mainMemberInfo.Relation;
                        ObjMem3.membersData.MainMember.Princible = mainMemberInfo.Princible;
                        ObjMem3.membersData.MainMember.IdentityExpiryDate = DateTime.Today.AddDays(90.0).ToShortDateString();
                        NationalityMapping Nationality = business.GetEskaNationality(Response.ResidentInfoByBorderNumberResult.nationalityCode);
                        ObjMem3.membersData.MainMember.NationalityCode = Nationality.EskaCode;
                        ObjMem3.membersData.MainMember.ClassId = Nationality.ClassId;
                        ObjMem3.membersData.NationalityEn = Nationality.NationalityNameEn;
                        ObjMem3.membersData.NationalityAr = Nationality.NationalityNameAr;
                        ObjMem3.membersData.OccupationName = Response.ResidentInfoByBorderNumberResult.occupationCode.ToString();
                        ObjMem3.membersData.MainMember.Occupation = Response.ResidentInfoByBorderNumberResult.occupationCode.ToString();
                        yakeenLogs3.Name = ObjMem3.membersData.MainMember.Name;
                        yakeenLogs3.DateOfBirth = ObjMem3.membersData.MainMember.DateOfBirth;
                        yakeenLogs3.Gender = ObjMem3.membersData.MainMember.Gender.Value;
                        yakeenLogs3.MartialStatus = mainMemberInfo.MartialStatus.Value;
                        yakeenLogs3.Occupation = Convert.ToInt32(ObjMem3.membersData.MainMember.Occupation);
                        yakeenLogs3.Nationality = Nationality.EskaCode;
                        yakeenLogs3.NationalId = mainMemberInfo.NationalId;
                        yakeenLogs3.Sponsor = mainMemberInfo.Princible;
                        yakeenLogs3.RecordDate = DateTime.Now;
                        yakeenLogs3.Relation = mainMemberInfo.Relation;
                        business.AddUpdateYakeenMembers(yakeenLogs3);
                        yakeenProccess.membersData = ObjMem3.membersData;
                        yakeenProccess.Status = true;
                    }
                }
                catch (Exception e3)
                {
                    ErrorMembers errorMembers3 = new ErrorMembers();
                    errorMembers3.dependMember = new List<ErrorsDependent>();
                    errorMembers3.membersData = new Princible();
                    ErrorsDependent data3 = new ErrorsDependent();
                    errorMembers3.membersData.NationalId = mainMemberInfo.NationalId;
                    errorMembers3.membersData.IsSuccess = false;
                    errorMembers3.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                    errorMembers3.membersData.Error = e3.Message;
                    yakeenProccess.errorMembers = errorMembers3;
                    yakeenProccess.Status = false;
                }
            }
            return yakeenProccess;
        }

        public (bool, string?) PushToPolicyWrapperCore(int? Id, string? connection, string? FinanceConnection, bool deletependingEnd, string ESKAServiceURL, string ESKAServiceEndoURL, string? EskaIGeneralConnection)
        {
            (bool, string) Response = (false, null);
            List<Production> Policies = new List<Production>();
            EndpointAddress endpointAddressPolicy = new EndpointAddress(ESKAServiceURL);
            Policies = ((!Id.HasValue) ? _Business.LoadPendingForSyncProduction() : _Business.LoadProductionById(Id.Value, Eska: true));
            if (Policies != null && Policies.Count > 0)
            {
                foreach (Production Policy in Policies)
                {
                    if (Policy.ProductId == 2)
                    {
                        return (false, null);//PushGeneralWrapperCore(Id, connection, FinanceConnection, deletependingEnd);
                    }
                    PolicyHolders PolicyHolder = _Business.LoadPolicyHolders(Convert.ToInt32(Policy.CustomerId));
                    Types UserType = _User.getTypeUser(Convert.ToInt32(Policy.CreatedBy));
                    Users UserInfo = _User.GetUser(Convert.ToInt32(Policy.CreatedBy));
                    if (PolicyHolder == null)
                    {
                        continue;
                    }
                    if (!Policy.EndosmentType.HasValue)
                    {
                        long FCS_CUSTOMER_ID2 = Customer.insertCustomer(18, PolicyHolder.Name, PolicyHolder.CommercialNo, PolicyHolder.MobileNo, PolicyHolder.Email, 1, null, null, PolicyHolder.VatNumber, null, null, FinanceConnection);
                        PolicyHolder.EskaId = FCS_CUSTOMER_ID2;
                        _Business.InsertUpdatePolicyHolder(PolicyHolder);
                        if (FCS_CUSTOMER_ID2 <= 0)
                        {
                            continue;
                        }
                        EskaPolicies.POLICIES_DOL pOLICIES_DOL = new EskaPolicies.POLICIES_DOL();
                        PolicyOutput policyOutput = new PolicyOutput();
                        EskaPolicies.POLICYClient clientPolicy3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                        //EskaPolicies.InsertPolicyRequest policyInsertRequest = new EskaPolicies.InsertPolicyRequest();
                        //EskaPolicies.InsertPolicyResponse policyInsertResponse = new EskaPolicies.InsertPolicyResponse();
                        pOLICIES_DOL.CREATED_BY = "Admin";
                        pOLICIES_DOL.MODIFIED_BY = "Admin";
                        pOLICIES_DOL.CREATION_DATE = DateTime.Now;
                        pOLICIES_DOL.MODIFICATION_DATE = DateTime.Now;
                        pOLICIES_DOL.DOCUMENT_TYPE = 1;
                        pOLICIES_DOL.POLICY_TYPE = 2;
                        pOLICIES_DOL.RENEWAL_NO = 0;
                        pOLICIES_DOL.ENDT_NO = 0;
                        pOLICIES_DOL.VERSION_NO = 0;
                        pOLICIES_DOL.APPLICANT_TYPE = 0;
                        pOLICIES_DOL.UW_YEAR = DateTime.Now.Year;
                        pOLICIES_DOL.REFERENCE_DATE = DateTime.Now;
                        pOLICIES_DOL.ISSUE_DATE = DateTime.Now;
                        pOLICIES_DOL.EFFECTIVE_DATE = Policy.EffectiveDate;
                        pOLICIES_DOL.EXPIRY_DATE = Policy.ExpiryDate;
                        pOLICIES_DOL.DURATION = 365;
                        pOLICIES_DOL.DURATION_UNIT = 1;
                        pOLICIES_DOL.BUSINESS_TYPE = UserType.BusinessType.Value;
                        pOLICIES_DOL.CALCULATION_TYPE = 1;
                        pOLICIES_DOL.ACCOUNTED_FOR = Policy.AccountedFor;
                        pOLICIES_DOL.IS_FAMILY_PRM = 0;
                        pOLICIES_DOL.FAMILY_CLASS_FLAG = 1;
                        pOLICIES_DOL.RENEWAL_STATUS = 0;
                        pOLICIES_DOL.EXTRA_NRP_AMT = default(decimal);
                        pOLICIES_DOL.EXTRA_NRP_AMT_LC = default(decimal);
                        pOLICIES_DOL.NOTES = "ONLINE Production BY POS PORTAL";
                        pOLICIES_DOL.FINANCIAL_DATE = DateTime.Now;
                        pOLICIES_DOL.IS_PRINTED = 0;
                        pOLICIES_DOL.IS_POSTED = 0;
                        pOLICIES_DOL.IS_CALCULATED = 1;
                        pOLICIES_DOL.IS_REINS = 0;
                        pOLICIES_DOL.EXRATE = 1m;
                        pOLICIES_DOL.TPA_CONTRACT = Policy.CreatedBy;
                        pOLICIES_DOL.MST_PYM_ID = 1L;
                        pOLICIES_DOL.MST_NDT_ID = 1L;
                        pOLICIES_DOL.MPD_PLN_ID = Convert.ToInt64(Policy.PlanId);
                        pOLICIES_DOL.FCS_CST_ID = FCS_CUSTOMER_ID2;
                        pOLICIES_DOL.CRG_CUR_CODE = "SAR";
                        pOLICIES_DOL.CRG_COM_ID = 1;
                        pOLICIES_DOL.CRG_BRN_ID = 9;
                        pOLICIES_DOL.CAPITAION_PREMIUM = default(decimal);
                        pOLICIES_DOL.CAPITAION_PREMIUM_LC = default(decimal);
                        pOLICIES_DOL.TPA_TYPE = 2L;
                        pOLICIES_DOL.IS_COST_PLUS = 0;
                        pOLICIES_DOL.PROFIT_SHARE_PER = default(decimal);
                        pOLICIES_DOL.BUSINESS_CHANNEL = 33633L;
                        pOLICIES_DOL.IS_PROFIT_SHARE = 0;
                        pOLICIES_DOL.IS_CONVERTED = 0;
                        pOLICIES_DOL.CRG_CNT_CODE = "SA";
                        pOLICIES_DOL.QUOTATION_STATUS = 2;
                        pOLICIES_DOL.TOTAL_CLAIMS = 0;
                        pOLICIES_DOL.VALIDATION_DAYS = Policy.Validity;
                        pOLICIES_DOL.IBNR = 0m;
                        pOLICIES_DOL.OUTSTANDING = 0m;
                        pOLICIES_DOL.LOSS_RATIO = 0m;
                        pOLICIES_DOL.TOTAL_MEMBERS = 0;
                        pOLICIES_DOL.IBNR_FACTOR = 0m;
                        pOLICIES_DOL.POLICY_STATUS = 0;
                        pOLICIES_DOL.APPROVAL_STATUS = 1;
                        pOLICIES_DOL.SOURCE = Policy.CreatedBy;
                        //policyInsertRequest.oPOLICIES_DOL = pOLICIES_DOL;
                        policyOutput = clientPolicy3.InsertPolicy(pOLICIES_DOL);
                        //policyOutput = policyInsertResponse.InsertPolicyResult;
                        if (policyOutput == null || policyOutput.Status.StatusCode != 1)
                        {
                            continue;
                        }
                        try
                        {
                            //insertAgentCommissionRequest insertAgentCommissionRequest2 = new insertAgentCommissionRequest();
                            //insertAgentCommissionResponse insertAgentCommissionResponse2 = new insertAgentCommissionResponse();
                            PLC_SHARES_DOL pLC_SHARES_DOL2 = new PLC_SHARES_DOL();
                            clientPolicy3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            pLC_SHARES_DOL2.CREATED_BY = "ECHANNEL";
                            pLC_SHARES_DOL2.COMM_SHARE = 100;
                            pLC_SHARES_DOL2.COMM_PER = UserType.Commission;
                            pLC_SHARES_DOL2.IS_CANCELLED = 0;
                            pLC_SHARES_DOL2.CREATION_DATE = DateTime.Now;
                            pLC_SHARES_DOL2.AMOUNT = 0m;
                            pLC_SHARES_DOL2.AMOUNT_LC = 0m;
                            pLC_SHARES_DOL2.COLLECTION_TYPE = 1;
                            pLC_SHARES_DOL2.MPD_PLC_ID = policyOutput.oPolicy.ID;
                            pLC_SHARES_DOL2.FGL_COA_ID = UserType.ChartOfAccount.Value;
                            pLC_SHARES_DOL2.FCS_CST_ID = UserInfo.EskaId.Value;
                            pLC_SHARES_DOL2.ROLE_TYPE = UserType.MedicalId;
                            //insertAgentCommissionRequest2.oPLC_SHARES_DOL = new PLC_SHARES_DOL();
                            //insertAgentCommissionRequest2.oPLC_SHARES_DOL = pLC_SHARES_DOL2;
                            bool insertAgentCommissionResponse2 = clientPolicy3.insertAgentCommission(pLC_SHARES_DOL2);
                        }
                        catch (Exception e)
                        {
                            Response.Item1 = false;
                            Response.Item2 = e.Message;
                        }
                        try
                        {
                            //InsertPolicySponorsRequest insertPolicySponorsRequest = new InsertPolicySponorsRequest();
                            //InsertPolicySponorsResponse insertPolicySponorsResponse = new InsertPolicySponorsResponse();
                            PolicySponsorOutput policySponsorOutput = new PolicySponsorOutput();
                            POLICY_SPONSORS_DOL insertPolicySponsorSDOL = new POLICY_SPONSORS_DOL();
                            clientPolicy3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            insertPolicySponsorSDOL.IS_CANCELLED = 0;
                            insertPolicySponsorSDOL.CREATED_BY = "ECHANNEL";
                            insertPolicySponsorSDOL.NAME = PolicyHolder.Name;
                            insertPolicySponsorSDOL.CRG_CTY_CODE = 1;
                            insertPolicySponsorSDOL.CREATION_DATE = DateTime.Now;
                            insertPolicySponsorSDOL.MPD_PLC_ID = policyOutput.oPolicy.ID;
                            insertPolicySponsorSDOL.NATIONALITY_CODE = "SA";
                            insertPolicySponsorSDOL.REGISTRY_NO = "2";
                            insertPolicySponsorSDOL.REGISTRY_TYPE = 1;
                            insertPolicySponsorSDOL.MOBILE_NO = PolicyHolder.MobileNo;
                            insertPolicySponsorSDOL.IS_DEFAULT = 1L;
                            insertPolicySponsorSDOL.SPONSOR_NO = PolicyHolder.CommercialNo;
                            //insertPolicySponorsRequest.oPOLICY_SPONSORS_DOL = new POLICY_SPONSORS_DOL();
                            //insertPolicySponorsRequest.oPOLICY_SPONSORS_DOL = insertPolicySponsorSDOL;
                            policySponsorOutput = clientPolicy3.InsertPolicySponors(insertPolicySponsorSDOL);
                            //policySponsorOutput.oPOLICY_SPONSORS_DOL = insertPolicySponorsResponse.InsertPolicySponorsResult.oPOLICY_SPONSORS_DOL;
                            //policySponsorOutput.Status = insertPolicySponorsResponse.InsertPolicySponorsResult.Status;
                        }
                        catch (Exception ex2)
                        {
                            Response.Item1 = false;
                            Response.Item2 = ex2.Message;
                            DeletePolicy deletePolicy4 = new DeletePolicy();
                            EskaPolicies.POLICYClient client4 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            //DeletePolicyDataRequest request4 = new DeletePolicyDataRequest();
                            DeletePolicy response5 = new DeletePolicy();
                            //request4.PolicyID = policyOutput.oPolicy.ID;
                            response5 = client4.DeletePolicyData(policyOutput.oPolicy.ID);
                        }
                        try
                        {
                            //InsertTPARequest insertTPARequest = new InsertTPARequest();
                            TpaOutput insertTPAResponse = new TpaOutput();
                            clientPolicy3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            TPA_DOL TPA = new TPA_DOL();
                            TPA.SHARE_AMOUNT = 0m;
                            TPA.SHARE_AMOUNT_LC = 0m;
                            TPA.MST_CAR_ID = Policy.TPAId.Value;
                            TPA.SHARE_PER = Policy.TpaShare.Value;
                            TPA.GROSS_AMOUNT = default(decimal);
                            TPA.GROSS_AMOUNT_LC = default(decimal);
                            TPA.MIN_SHARE_AMOUNT = 0m;
                            TPA.MIN_SHARE_AMOUNT_LC = 0m;
                            TPA.MPD_PLC_ID = policyOutput.oPolicy.ID;
                            TPA.IS_TPA_CLASS = 0;
                            TPA.TPA_LEVEL = 1;
                            TPA.TPA_TYPE = 2;
                            //insertTPARequest.oTPA_DOL = new TPA_DOL();
                            //insertTPARequest.oTPA_DOL = TPA;
                            insertTPAResponse = clientPolicy3.InsertTPA(TPA);
                        }
                        catch (Exception exc)
                        {
                            Response.Item1 = false;
                            Response.Item2 = exc.Message;
                            DeletePolicy deletePolicy3 = new DeletePolicy();
                            EskaPolicies.POLICYClient client3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            //DeletePolicyDataRequest request3 = new DeletePolicyDataRequest();
                            DeletePolicy response3 = new DeletePolicy();
                            //request3.PolicyID = policyOutput.oPolicy.ID;
                            response3 = client3.DeletePolicyData(policyOutput.oPolicy.ID);
                        }
                        try
                        {
                            List<Subjects> Members = _Business.LoadMemberBusiness(Policy.Id, null);
                            foreach (Subjects member in Members)
                            {
                                MembersDeclarations declaration = _Business.LoadDeclarationByMember(member.Id);
                                decimal LoadingAmt = default(decimal);
                                if (declaration != null && declaration.Id > 0 && declaration.AdditionalPremium.HasValue)
                                {
                                    LoadingAmt = declaration.AdditionalPremium.Value;
                                }
                                long? memberRelation = null;
                                if (member.Relation != 1)
                                {
                                    memberRelation = Productions.LoadMemberRelation(member.Princible, EskaIGeneralConnection);
                                }
                                DateTime ExpiryIdentity = DateTime.Now.AddYears(1);
                                if (member.IdentityExpiryDate != null)
                                {
                                    ExpiryIdentity = Utilities.ConvertDate(member.IdentityExpiryDate);
                                }
                                Productions.InsertMembers(Convert.ToInt64(policyOutput.oPolicy.ID), member.DiscountAmount.HasValue ? member.DiscountAmount : null, (LoadingAmt > 0m) ? new decimal?(LoadingAmt) : null, member.NationalId, member.Name, Convert.ToInt32(member.Occupation), Convert.ToInt32(member.MartialStatus), Convert.ToInt32(member.Gender), member.NationalityCode, Convert.ToInt32(member.Relation), ExpiryIdentity, ExpiryIdentity.AddYears(-1), member.DateOfBirth.Value, member.Princible, member.Princible, Convert.ToInt32(member.Age), memberRelation, Convert.ToInt32(member.ClassId), Convert.ToInt64(policyOutput.oPolicy.ID), connection, Convert.ToInt64(Policy.PlanId));
                            }
                            EskaPolicies.CalculatePolicyRequest calculatePolicyRequest = new EskaPolicies.CalculatePolicyRequest();
                            CalculatePolicyOutput calculatePolicyOutput = new CalculatePolicyOutput();
                            EskaPolicies.CalculatePolicyOutput calculatePolicyResponse = new EskaPolicies.CalculatePolicyOutput();
                            EskaPolicies.ArrayOfXElement dsPolicyAgent1 = new ArrayOfXElement();
                            calculatePolicyRequest.CREATED_BY = "Admin";
                            calculatePolicyRequest.PolicySegment = policyOutput.oPolicy.SEGMENT_CODE;
                            calculatePolicyRequest.ID = policyOutput.oPolicy.ID;
                            calculatePolicyResponse = clientPolicy3.CalculatePolicy(calculatePolicyRequest.ID, calculatePolicyRequest.lcFeesID, calculatePolicyRequest.lcFeesPercentage, calculatePolicyRequest.lcFeesAmount, calculatePolicyRequest.CREATED_BY, ref calculatePolicyRequest.colPOLICY_FEES_DOL, calculatePolicyRequest.dsPolicyAgent, ref calculatePolicyRequest.PolicyPremium, ref calculatePolicyRequest.PolicySegment, ref calculatePolicyRequest.strErrorMessage, out dsPolicyAgent1);
                            if (calculatePolicyResponse != null && calculatePolicyResponse.Status.StatusCode == 1)
                            {
                                Policy.PushToEska = 1;
                                Policy.EskaId = policyOutput.oPolicy.ID;
                                Policy.EskaSegment = policyOutput.oPolicy.SEGMENT_CODE;
                                _Business.InsertUpdateProduction(Policy);
                                Response.Item1 = true;
                                Response.Item2 = string.Empty;
                            }
                            else
                            {
                                Response.Item1 = false;
                                Response.Item2 = calculatePolicyResponse.Status.Reason;
                                DeletePolicy deletePolicy2 = new DeletePolicy();
                                EskaPolicies.POLICYClient client2 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                                //DeletePolicyDataRequest request2 = new DeletePolicyDataRequest();
                                DeletePolicy response2 = new DeletePolicy();
                                //request2.PolicyID = policyOutput.oPolicy.ID;
                                response2 = client2.DeletePolicyData(policyOutput.oPolicy.ID);
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Item1 = false;
                            Response.Item2 = ex.Message;
                            DeletePolicy deletePolicy = new DeletePolicy();
                            EskaPolicies.POLICYClient client = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            //DeletePolicyDataRequest request = new DeletePolicyDataRequest();
                            DeletePolicy response = new DeletePolicy();
                            //request.PolicyID = policyOutput.oPolicy.ID;
                            response = client.DeletePolicyData(policyOutput.oPolicy.ID);
                        }
                        continue;
                    }
                    Production orginal = _Business.LoadDocument(null, Convert.ToInt32(Policy.PolicyId.Value), 1);
                    List<long> lsData = EndorsementPending.PendingEndorments(orginal.EskaId.Value, connection);
                    if (deletependingEnd)
                    {
                        lsData.ForEach(delegate (long x)
                        {
                            DeletePolicy deletePolicy9 = new DeletePolicy();
                            EskaPolicies.POLICYClient pOLICYClient = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            //DeletePolicyDataRequest deletePolicyDataRequest = new DeletePolicyDataRequest();
                            DeletePolicy deletePolicyDataResponse = new DeletePolicy();
                            //deletePolicyDataRequest.PolicyID = x;
                            deletePolicyDataResponse = pOLICYClient.DeletePolicyData(x);
                        });
                    }
                    long FCS_CUSTOMER_ID = Customer.insertCustomer(18, PolicyHolder.Name, PolicyHolder.CommercialNo, PolicyHolder.MobileNo, PolicyHolder.Email, 1, null, null, PolicyHolder.VatNumber, null, null, FinanceConnection);
                    PolicyHolder.EskaId = FCS_CUSTOMER_ID;
                    _Business.InsertUpdatePolicyHolder(PolicyHolder);
                    EndpointAddress endpointAddressendo = new EndpointAddress(ESKAServiceEndoURL);
                    //EndorsementInsertRequest end = new EndorsementInsertRequest();
                    ENDORSEMENTClient clientEnd = new ENDORSEMENTClient(ENDORSEMENTClient.EndpointConfiguration.BasicHttpBinding_IENDORSEMENT, endpointAddressendo);
                    Endoresement.POLICIES_DOL oPOLICIES_INPUT = new Endoresement.POLICIES_DOL();
                    //PolicyID = Convert.ToInt32(orginal.EskaId.Value);
                    oPOLICIES_INPUT.CreatedBy = "ECHANNEL";
                    oPOLICIES_INPUT.ModifiedBy = "ECHANNEL";
                    oPOLICIES_INPUT.CreationDate = DateTime.Now;
                    oPOLICIES_INPUT.ModificationDate = DateTime.Now;
                    oPOLICIES_INPUT.DocumentType = 2;
                    oPOLICIES_INPUT.PolicyType = 2;
                    oPOLICIES_INPUT.RenewalNo = 0;
                    oPOLICIES_INPUT.EndorsementNo = 0;
                    oPOLICIES_INPUT.APPLICANT_TYPE = 0;
                    oPOLICIES_INPUT.UWYear = DateTime.Now.Year;
                    oPOLICIES_INPUT.ReferenceDate = DateTime.Today.Date;
                    oPOLICIES_INPUT.IssueDate = DateTime.Today.Date;
                    oPOLICIES_INPUT.EffectiveDate = Policy.EffectiveDate;
                    oPOLICIES_INPUT.ExpiryDate = Policy.ExpiryDate;
                    oPOLICIES_INPUT.DURATION = (Policy.ExpiryDate - Policy.EffectiveDate).Days;
                    oPOLICIES_INPUT.DURATION_UNIT = 1;
                    oPOLICIES_INPUT.BusinessType = UserType.BusinessType.Value;
                    oPOLICIES_INPUT.CalculationType = 1;
                    oPOLICIES_INPUT.AccountedFor = Policy.AccountedFor;
                    oPOLICIES_INPUT.RenewalNo = 0;
                    oPOLICIES_INPUT.Notes = "";
                    oPOLICIES_INPUT.IS_POSTED = 0;
                    oPOLICIES_INPUT.Exrate = 1m;
                    oPOLICIES_INPUT.PaymentID = 1L;
                    oPOLICIES_INPUT.EndorsementID = Policy.EndosmentType.Value;
                    oPOLICIES_INPUT.PlanID = Convert.ToInt64(Policy.PlanId);
                    oPOLICIES_INPUT.PolicyHolderID = PolicyHolder.EskaId;
                    oPOLICIES_INPUT.CurrencyCode = "SAR";
                    oPOLICIES_INPUT.CompanyID = 1;
                    oPOLICIES_INPUT.BranchID = 9;
                    oPOLICIES_INPUT.TpaType = 2L;
                    oPOLICIES_INPUT.BusinessChannel = 33633L;
                    oPOLICIES_INPUT.IS_CONVERTED = 0;
                    oPOLICIES_INPUT.APPROVAL_STATUS = 1;
                    oPOLICIES_INPUT.PolicyID = Convert.ToInt32(orginal.EskaId);
                    EndorsementOutput response4 = new EndorsementOutput();
                    response4 = clientEnd.EndorsementInsert(Convert.ToInt32(orginal.EskaId), oPOLICIES_INPUT);
                    if (response4 != null && response4.Status._StatusCode == 1)
                    {
                        try
                        {
                            //insertAgentCommissionRequest insertAgentCommissionRequest = new insertAgentCommissionRequest();
                            //insertAgentCommissionResponse insertAgentCommissionResponse = new insertAgentCommissionResponse();
                            PLC_SHARES_DOL pLC_SHARES_DOL = new PLC_SHARES_DOL();
                            EskaPolicies.POLICYClient clientPolicy = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            pLC_SHARES_DOL.CREATED_BY = "ECHANNEL";
                            pLC_SHARES_DOL.COMM_SHARE = 100;
                            pLC_SHARES_DOL.COMM_PER = UserType.Commission;
                            pLC_SHARES_DOL.IS_CANCELLED = 0;
                            pLC_SHARES_DOL.CREATION_DATE = DateTime.Now;
                            pLC_SHARES_DOL.AMOUNT = 0m;
                            pLC_SHARES_DOL.AMOUNT_LC = 0m;
                            pLC_SHARES_DOL.COLLECTION_TYPE = 1;
                            pLC_SHARES_DOL.MPD_PLC_ID = response4.oPolicy.PolicyID;
                            pLC_SHARES_DOL.FGL_COA_ID = UserType.ChartOfAccount.Value;
                            pLC_SHARES_DOL.FCS_CST_ID = UserInfo.EskaId.Value;
                            pLC_SHARES_DOL.ROLE_TYPE = UserType.MedicalId;
                            //insertAgentCommissionRequest.oPLC_SHARES_DOL = new PLC_SHARES_DOL();
                            //insertAgentCommissionRequest.oPLC_SHARES_DOL = pLC_SHARES_DOL;
                            bool insertAgentCommissionResponse = clientPolicy.insertAgentCommission(pLC_SHARES_DOL);
                        }
                        catch (Exception e2)
                        {
                            Response.Item1 = false;
                            Response.Item2 = e2.Message;
                        }
                        try
                        {
                            //InsertPolicySponorsRequest insertPolicySponorsRequest2 = new InsertPolicySponorsRequest();
                            PolicySponsorOutput insertPolicySponorsResponse2 = new PolicySponsorOutput();
                            PolicySponsorOutput policySponsorOutput2 = new PolicySponsorOutput();
                            POLICY_SPONSORS_DOL insertPolicySponsorSDOL2 = new POLICY_SPONSORS_DOL();
                            EskaPolicies.POLICYClient clientPolicy2 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            insertPolicySponsorSDOL2.IS_CANCELLED = 0;
                            insertPolicySponsorSDOL2.CREATED_BY = "ECHANNEL";
                            insertPolicySponsorSDOL2.NAME = PolicyHolder.Name;
                            insertPolicySponsorSDOL2.CRG_CTY_CODE = 1;
                            insertPolicySponsorSDOL2.CREATION_DATE = DateTime.Now;
                            insertPolicySponsorSDOL2.MPD_PLC_ID = response4.oPolicy.PolicyID;
                            insertPolicySponsorSDOL2.NATIONALITY_CODE = "SA";
                            insertPolicySponsorSDOL2.REGISTRY_NO = "2";
                            insertPolicySponsorSDOL2.REGISTRY_TYPE = 1;
                            insertPolicySponsorSDOL2.MOBILE_NO = PolicyHolder.MobileNo;
                            insertPolicySponsorSDOL2.IS_DEFAULT = 1L;
                            insertPolicySponsorSDOL2.SPONSOR_NO = PolicyHolder.CommercialNo;
                            //insertPolicySponorsRequest2.oPOLICY_SPONSORS_DOL = new POLICY_SPONSORS_DOL();
                            //insertPolicySponorsRequest2.oPOLICY_SPONSORS_DOL = insertPolicySponsorSDOL2;
                            insertPolicySponorsResponse2 = clientPolicy2.InsertPolicySponors(insertPolicySponsorSDOL2);
                            //policySponsorOutput2.oPOLICY_SPONSORS_DOL = insertPolicySponorsResponse2.InsertPolicySponorsResult.oPOLICY_SPONSORS_DOL;
                            //policySponsorOutput2.Status = insertPolicySponorsResponse2.InsertPolicySponorsResult.Status;
                        }
                        catch (Exception ex3)
                        {
                            Response.Item1 = false;
                            Response.Item2 = ex3.Message;
                            DeletePolicy deletePolicy7 = new DeletePolicy();
                            EskaPolicies.POLICYClient client7 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            //DeletePolicyDataRequest request7 = new DeletePolicyDataRequest();
                            DeletePolicy responsedelete3 = new DeletePolicy();
                            //request7.PolicyID = response4.oPolicy.PolicyID;
                            responsedelete3 = client7.DeletePolicyData(response4.oPolicy.PolicyID);
                        }
                        try
                        {
                            //InsertTPARequest insertTPARequest2 = new InsertTPARequest();
                            TpaOutput insertTPAResponse2 = new TpaOutput();
                            EskaPolicies.POLICYClient clientPolicy5 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            TPA_DOL TPA2 = new TPA_DOL();
                            TPA2.SHARE_AMOUNT = 0m;
                            TPA2.SHARE_AMOUNT_LC = 0m;
                            TPA2.MST_CAR_ID = Policy.TPAId.Value;
                            TPA2.SHARE_PER = Policy.TpaShare.Value;
                            TPA2.GROSS_AMOUNT = default(decimal);
                            TPA2.GROSS_AMOUNT_LC = default(decimal);
                            TPA2.MIN_SHARE_AMOUNT = 0m;
                            TPA2.MIN_SHARE_AMOUNT_LC = 0m;
                            TPA2.MPD_PLC_ID = response4.oPolicy.PolicyID;
                            TPA2.IS_TPA_CLASS = 0;
                            TPA2.TPA_LEVEL = 1;
                            TPA2.TPA_TYPE = 2;
                            //insertTPARequest2.oTPA_DOL = new TPA_DOL();
                            //insertTPARequest2.oTPA_DOL = TPA2;
                            insertTPAResponse2 = clientPolicy5.InsertTPA(TPA2);
                        }
                        catch (Exception exc2)
                        {
                            Response.Item1 = false;
                            Response.Item2 = exc2.Message;
                            DeletePolicy deletePolicy8 = new DeletePolicy();
                            EskaPolicies.POLICYClient client8 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            //DeletePolicyDataRequest request8 = new DeletePolicyDataRequest();
                            DeletePolicy responsedelete4 = new DeletePolicy();
                            //request8.PolicyID = response4.oPolicy.PolicyID;
                            responsedelete4 = client8.DeletePolicyData(response4.oPolicy.PolicyID);
                        }
                        try
                        {
                            List<Subjects> Members2 = _Business.LoadMemberBusiness(Policy.Id, null);
                            foreach (Subjects member2 in Members2)
                            {
                                long? memberRelation2 = null;
                                if (member2.Relation != 1)
                                {
                                    memberRelation2 = Productions.LoadMemberRelation(member2.Princible, EskaIGeneralConnection);
                                }
                                DateTime ExpiryIdentity2 = DateTime.Now.AddYears(1);
                                if (member2.IdentityExpiryDate != null)
                                {
                                    ExpiryIdentity2 = Utilities.ConvertDate(member2.IdentityExpiryDate);
                                }
                                Productions.InsertMembers(Convert.ToInt64(response4.oPolicy.PolicyID), member2.DiscountAmount.HasValue ? member2.DiscountAmount : null, null, member2.NationalId, member2.Name, Convert.ToInt32(member2.Occupation), Convert.ToInt32(member2.MartialStatus), Convert.ToInt32(member2.Gender), member2.NationalityCode, Convert.ToInt32(member2.Relation), ExpiryIdentity2, ExpiryIdentity2.AddYears(-1), member2.DateOfBirth.Value, member2.Princible, member2.Princible, Convert.ToInt32(member2.Age), memberRelation2, Convert.ToInt32(member2.ClassId), Convert.ToInt64(response4.oPolicy.PolicyID), connection, Convert.ToInt64(Policy.PlanId));
                            }
                            EskaPolicies.CalculatePolicyRequest calculatePolicyRequest2 = new EskaPolicies.CalculatePolicyRequest();
                            CalculatePolicyOutput calculatePolicyOutput2 = new CalculatePolicyOutput();
                            CalculatePolicyOutput calculatePolicyResponse2 = new CalculatePolicyOutput();
                            EskaPolicies.POLICYClient clientPolicy4 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            calculatePolicyRequest2.CREATED_BY = "Admin";
                            calculatePolicyRequest2.PolicySegment = response4.oPolicy.SegmentCode;
                            calculatePolicyRequest2.ID = response4.oPolicy.PolicyID;
                            ArrayOfXElement dsPolicyAgent1 = new ArrayOfXElement();
                            calculatePolicyResponse2 = clientPolicy4.CalculatePolicy(calculatePolicyRequest2.ID, calculatePolicyRequest2.lcFeesID, calculatePolicyRequest2.lcFeesPercentage, calculatePolicyRequest2.lcFeesAmount, calculatePolicyRequest2.CREATED_BY, ref calculatePolicyRequest2.colPOLICY_FEES_DOL, calculatePolicyRequest2.dsPolicyAgent, ref calculatePolicyRequest2.PolicyPremium, ref calculatePolicyRequest2.PolicySegment, ref calculatePolicyRequest2.strErrorMessage, out dsPolicyAgent1);
                            if (calculatePolicyResponse2 != null && calculatePolicyResponse2.Status.StatusCode == 1)
                            {
                                Policy.EndtSerial = response4.oPolicy.EndorsementNo;
                                Policy.EskaId = response4.oPolicy.PolicyID;
                                Policy.EskaSegment = response4.oPolicy.SegmentCode;
                                (Production, string) InsertProd = _Business.InsertUpdateProduction(Policy);
                                Response.Item1 = true;
                                Response.Item2 = string.Empty;
                            }
                            else
                            {
                                Response.Item1 = false;
                                Response.Item2 = calculatePolicyResponse2.Status.Reason;
                                DeletePolicy deletePolicy6 = new DeletePolicy();
                                EskaPolicies.POLICYClient client6 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                                //DeletePolicyDataRequest request6 = new DeletePolicyDataRequest();
                                DeletePolicy responsedelete2 = new DeletePolicy();
                                //request6.PolicyID = response4.oPolicy.PolicyID;
                                responsedelete2 = client6.DeletePolicyData(response4.oPolicy.PolicyID);
                            }
                        }
                        catch (Exception e3)
                        {
                            Response.Item1 = false;
                            Response.Item2 = e3.Message;
                            DeletePolicy deletePolicy5 = new DeletePolicy();
                            EskaPolicies.POLICYClient client5 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                            //DeletePolicyDataRequest request5 = new DeletePolicyDataRequest();
                            DeletePolicy responsedelete = new DeletePolicy();
                            //request5.PolicyID = response4.oPolicy.PolicyID;
                            responsedelete = client5.DeletePolicyData(response4.oPolicy.PolicyID);
                        }
                    }
                    else
                    {
                        Response.Item1 = false;
                        Response.Item2 = response4.Status._Reason.ToString();
                    }
                }
            }
            return Response;
        }

        public PostPolicyResponse PushPolicyToPost(long Id, string CreatedBy, string policySegment, string ServiceURL)
        {
            EndpointAddress endpointAddressPolicy = new EndpointAddress(ServiceURL);
            POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            PostPolicyResponse postPolicyResponse = new PostPolicyResponse();
            PostPolicyRequest postPolicyRequest = new PostPolicyRequest();
            PostPolicyOutput postPolicyOutput = new PostPolicyOutput();
            postPolicyRequest.ID = Id;
            postPolicyRequest.CREATED_BY = CreatedBy;
            postPolicyRequest.PolicySegment = policySegment;
            //postPolicyRequest.lcFeesAmount = 0;
            //postPolicyRequest.lcFeesPercentage = 0;
            //postPolicyRequest.lcFeesID = 0;
            //postPolicyRequest.PolicyPremium = 0;
            //postPolicyRequest.strErrorMessage = "";
            //postPolicyRequest.colINS_TRANSACTIONS_DOL = iNS_TRANSACTIONS_DOLs;
            //postPolicyRequest.colPOLICY_FEES_DOL = pOLICY_FEES_DOLs;               
            ArrayOfXElement dsPolicyAgent1 = new ArrayOfXElement();
            postPolicyOutput = client.PostPolicy(postPolicyRequest.ID, postPolicyRequest.lcFeesID, postPolicyRequest.lcFeesPercentage, postPolicyRequest.lcFeesAmount, postPolicyRequest.CREATED_BY,ref postPolicyRequest.colPOLICY_FEES_DOL, postPolicyRequest.dsPolicyAgent,ref postPolicyRequest.colINS_TRANSACTIONS_DOL,ref postPolicyRequest.PolicyPremium, ref postPolicyRequest.PolicySegment, ref postPolicyRequest.strErrorMessage, out dsPolicyAgent1);
            postPolicyResponse.PostPolicyResult = postPolicyOutput;
            return postPolicyResponse;
        }
        //public (bool, string?) PushGeneralWrapperCore(int? Id, string? connection, string? FinanceConnection, bool deletependingEnd)
        //{
        //	(bool, string) Response = (false, null);
        //	List<Production> Policies = new List<Production>();
        //	Policies = ((!Id.HasValue) ? _Business.LoadPendingForSyncProduction() : _Business.LoadProductionById(Id.Value, Eska: true));
        //	if (Policies != null && Policies.Count > 0)
        //	{
        //		foreach (Production Policy in Policies)
        //		{
        //			PolicyHolders PolicyHolder = _Business.LoadPolicyHolders(Convert.ToInt32(Policy.CustomerId));
        //			Types UserType = _User.getTypeUser(Convert.ToInt32(Policy.CreatedBy));
        //			Users UserInfo = _User.GetUser(Convert.ToInt32(Policy.CreatedBy));
        //			if (PolicyHolder != null)
        //			{
        //				long FCS_CUSTOMER_ID = Customer.insertCustomer(18, PolicyHolder.Name, PolicyHolder.CommercialNo, PolicyHolder.MobileNo, PolicyHolder.Email, 1, null, null, PolicyHolder.VatNumber, null, null, FinanceConnection);
        //				PolicyHolder.EskaId = FCS_CUSTOMER_ID;
        //				_Business.InsertUpdatePolicyHolder(PolicyHolder);
        //				if (FCS_CUSTOMER_ID > 0)
        //				{
        //					EskaGeneralPolicy.POLICYClient clientPolicy = new EskaGeneralPolicy.POLICYClient();
        //					EskaGeneralPolicy.InsertPolicyRequest policyInsertRequest = new EskaGeneralPolicy.InsertPolicyRequest();
        //					EskaGeneralPolicy.InsertPolicyResponse policyInsertResponse = new EskaGeneralPolicy.InsertPolicyResponse();
        //					InsertPolicyInput insertPolicyInput = new InsertPolicyInput();
        //					GeneralPolicy generalPolicy = new GeneralPolicy
        //					{
        //						DocumentType = 1,
        //						IssueDate = DateTime.Now,
        //						EffectiveDate = DateTime.Now,
        //						ExpiryDate = DateTime.Now.AddYears(1),
        //						OurSharePercentage = 100,
        //						ExchangeRate = 1m,
        //						Notes = "POS MMP",
        //						AccountedFor = UtilitiesBLLAccountedFor.Insured,
        //						GrossPremium = 100m,
        //						TotalFees = 0m,
        //						NetPremium = 100m,
        //						IsPosted = 0,
        //						CreatedBy = "MOHAMED.MUHIT",
        //						Insured = Convert.ToInt32(FCS_CUSTOMER_ID),
        //						PaymentMethod = 1,
        //						ClassID = 6,
        //						BusinessType = UtilitiesBLLBusinessTypes.Inward,
        //						PolicyType = 7006,
        //						BranchID = 9,
        //						CompanyID = 1,
        //						FiscalYear = DateTime.Now.Year,
        //						CurrencyCode = "SAR",
        //						VoucherDate = DateTime.Now,
        //						AggLiabilityLimit = default(decimal),
        //						BranchCurrency = "SAR",
        //						IsPrinted = 0,
        //						PrintCount = 0,
        //						IsReinsured = 1,
        //						IsCalculated = 1,
        //						InwardCompanyID = 1,
        //						CommissionAmount = 0m,
        //						InwardCompanySharePercentage = 100,
        //						AccountedAccountID = 12801,
        //						AccountedCustomerSegmentCode = "123",
        //						AgentType = UtilitiesBLLAgentType.Direct,
        //						Beneficiary = Convert.ToInt32(FCS_CUSTOMER_ID),
        //						BranchExrate = 1m,
        //						CalculationBase = UtilitiesBLLCalculationBase.Prorata,
        //						OpenCoverType = UtilitiesBLLOpenCoverTypes.NotOpenCover
        //					};
        //					insertPolicyInput.GeneralPolicy = generalPolicy;
        //					policyInsertRequest.oInsertPolicyInput = insertPolicyInput;
        //					policyInsertResponse = clientPolicy.InsertPolicy(policyInsertRequest);
        //					int t = 1;
        //				}
        //			}
        //		}
        //	}
        //	return Response;
        //}


        public (bool, string?) SME_PushToPolicyWrapperCore(int? Id, string? connection, string? FinanceConnection, bool deletependingEnd, string ESKAServiceURL, string ESKAServiceEndoURL, string? EskaIGeneralConnection)
        {
            (bool, string) Response = (false, null);
            //List<Production> Policies = new List<Production>();
            //EndpointAddress endpointAddressPolicy = new EndpointAddress(ESKAServiceURL);
            //Policies = ((!Id.HasValue) ? _Business.LoadPendingForSyncProduction() : _Business.LoadProductionById(Id.Value, Eska: true));
            //if (Policies != null && Policies.Count > 0)
            //{
            //    foreach (Production Policy in Policies)
            //    {
            //        if (Policy.ProductId == 2)
            //        {
            //            return (false, null);//PushGeneralWrapperCore(Id, connection, FinanceConnection, deletependingEnd);
            //        }
            //        PolicyHolders PolicyHolder = _Business.LoadPolicyHolders(Convert.ToInt32(Policy.CustomerId));
            //        Types UserType = _User.getTypeUser(Convert.ToInt32(Policy.CreatedBy));
            //        Users UserInfo = _User.GetUser(Convert.ToInt32(Policy.CreatedBy));
            //        if (PolicyHolder == null)
            //        {
            //            continue;
            //        }
            //        if (!Policy.EndosmentType.HasValue)
            //        {
            //            long FCS_CUSTOMER_ID2 = Customer.insertCustomer(18, PolicyHolder.Name, PolicyHolder.CommercialNo, PolicyHolder.MobileNo, PolicyHolder.Email, 1, null, null, PolicyHolder.VatNumber, null, null, FinanceConnection);
            //            PolicyHolder.EskaId = FCS_CUSTOMER_ID2;
            //            _Business.InsertUpdatePolicyHolder(PolicyHolder);
            //            if (FCS_CUSTOMER_ID2 <= 0)
            //            {
            //                continue;
            //            }
            //            EskaPolicies.POLICIES_DOL pOLICIES_DOL = new EskaPolicies.POLICIES_DOL();
            //            PolicyOutput policyOutput = new PolicyOutput();
            //            EskaPolicies.POLICYClient clientPolicy3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //            //EskaPolicies.InsertPolicyRequest policyInsertRequest = new EskaPolicies.InsertPolicyRequest();
            //            //EskaPolicies.InsertPolicyResponse policyInsertResponse = new EskaPolicies.InsertPolicyResponse();
            //            pOLICIES_DOL.CREATED_BY = "Admin";
            //            pOLICIES_DOL.MODIFIED_BY = "Admin";
            //            pOLICIES_DOL.CREATION_DATE = DateTime.Now;
            //            pOLICIES_DOL.MODIFICATION_DATE = DateTime.Now;
            //            pOLICIES_DOL.DOCUMENT_TYPE = 1;
            //            pOLICIES_DOL.POLICY_TYPE = 2;
            //            pOLICIES_DOL.RENEWAL_NO = 0;
            //            pOLICIES_DOL.ENDT_NO = 0;
            //            pOLICIES_DOL.VERSION_NO = 0;
            //            pOLICIES_DOL.APPLICANT_TYPE = 0;
            //            pOLICIES_DOL.UW_YEAR = DateTime.Now.Year;
            //            pOLICIES_DOL.REFERENCE_DATE = DateTime.Now;
            //            pOLICIES_DOL.ISSUE_DATE = DateTime.Now;
            //            pOLICIES_DOL.EFFECTIVE_DATE = Policy.EffectiveDate;
            //            pOLICIES_DOL.EXPIRY_DATE = Policy.ExpiryDate;
            //            pOLICIES_DOL.DURATION = 365;
            //            pOLICIES_DOL.DURATION_UNIT = 1;
            //            pOLICIES_DOL.BUSINESS_TYPE = UserType.BusinessType.Value;
            //            pOLICIES_DOL.CALCULATION_TYPE = 1;
            //            pOLICIES_DOL.ACCOUNTED_FOR = Policy.AccountedFor;
            //            pOLICIES_DOL.IS_FAMILY_PRM = 0;
            //            pOLICIES_DOL.FAMILY_CLASS_FLAG = 1;
            //            pOLICIES_DOL.RENEWAL_STATUS = 0;
            //            pOLICIES_DOL.EXTRA_NRP_AMT = default(decimal);
            //            pOLICIES_DOL.EXTRA_NRP_AMT_LC = default(decimal);
            //            pOLICIES_DOL.NOTES = "ONLINE Production BY POS PORTAL";
            //            pOLICIES_DOL.FINANCIAL_DATE = DateTime.Now;
            //            pOLICIES_DOL.IS_PRINTED = 0;
            //            pOLICIES_DOL.IS_POSTED = 0;
            //            pOLICIES_DOL.IS_CALCULATED = 1;
            //            pOLICIES_DOL.IS_REINS = 0;
            //            pOLICIES_DOL.EXRATE = 1m;
            //            pOLICIES_DOL.TPA_CONTRACT = Policy.CreatedBy;
            //            pOLICIES_DOL.MST_PYM_ID = 1L;
            //            pOLICIES_DOL.MST_NDT_ID = 1L;
            //            pOLICIES_DOL.MPD_PLN_ID = Convert.ToInt64(Policy.PlanId);
            //            pOLICIES_DOL.FCS_CST_ID = FCS_CUSTOMER_ID2;
            //            pOLICIES_DOL.CRG_CUR_CODE = "SAR";
            //            pOLICIES_DOL.CRG_COM_ID = 1;
            //            pOLICIES_DOL.CRG_BRN_ID = 9;
            //            pOLICIES_DOL.CAPITAION_PREMIUM = default(decimal);
            //            pOLICIES_DOL.CAPITAION_PREMIUM_LC = default(decimal);
            //            pOLICIES_DOL.TPA_TYPE = 2L;
            //            pOLICIES_DOL.IS_COST_PLUS = 0;
            //            pOLICIES_DOL.PROFIT_SHARE_PER = default(decimal);
            //            pOLICIES_DOL.BUSINESS_CHANNEL = 33633L;
            //            pOLICIES_DOL.IS_PROFIT_SHARE = 0;
            //            pOLICIES_DOL.IS_CONVERTED = 0;
            //            pOLICIES_DOL.CRG_CNT_CODE = "SA";
            //            pOLICIES_DOL.QUOTATION_STATUS = 2;
            //            pOLICIES_DOL.TOTAL_CLAIMS = 0;
            //            pOLICIES_DOL.VALIDATION_DAYS = Policy.Validity;
            //            pOLICIES_DOL.IBNR = 0m;
            //            pOLICIES_DOL.OUTSTANDING = 0m;
            //            pOLICIES_DOL.LOSS_RATIO = 0m;
            //            pOLICIES_DOL.TOTAL_MEMBERS = 0;
            //            pOLICIES_DOL.IBNR_FACTOR = 0m;
            //            pOLICIES_DOL.POLICY_STATUS = 0;
            //            pOLICIES_DOL.APPROVAL_STATUS = 1;
            //            pOLICIES_DOL.SOURCE = Policy.CreatedBy;
            //            //policyInsertRequest.oPOLICIES_DOL = pOLICIES_DOL;
            //            policyOutput = clientPolicy3.InsertPolicy(pOLICIES_DOL);
            //            //policyOutput = policyInsertResponse.InsertPolicyResult;
            //            if (policyOutput == null || policyOutput.Status.StatusCode != 1)
            //            {
            //                continue;
            //            }
            //            try
            //            {
            //                //insertAgentCommissionRequest insertAgentCommissionRequest2 = new insertAgentCommissionRequest();
            //                //insertAgentCommissionResponse insertAgentCommissionResponse2 = new insertAgentCommissionResponse();
            //                PLC_SHARES_DOL pLC_SHARES_DOL2 = new PLC_SHARES_DOL();
            //                clientPolicy3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                pLC_SHARES_DOL2.CREATED_BY = "ECHANNEL";
            //                pLC_SHARES_DOL2.COMM_SHARE = 100;
            //                pLC_SHARES_DOL2.COMM_PER = UserType.Commission;
            //                pLC_SHARES_DOL2.IS_CANCELLED = 0;
            //                pLC_SHARES_DOL2.CREATION_DATE = DateTime.Now;
            //                pLC_SHARES_DOL2.AMOUNT = 0m;
            //                pLC_SHARES_DOL2.AMOUNT_LC = 0m;
            //                pLC_SHARES_DOL2.COLLECTION_TYPE = 1;
            //                pLC_SHARES_DOL2.MPD_PLC_ID = policyOutput.oPolicy.ID;
            //                pLC_SHARES_DOL2.FGL_COA_ID = UserType.ChartOfAccount.Value;
            //                pLC_SHARES_DOL2.FCS_CST_ID = UserInfo.EskaId.Value;
            //                pLC_SHARES_DOL2.ROLE_TYPE = UserType.MedicalId;
            //                //insertAgentCommissionRequest2.oPLC_SHARES_DOL = new PLC_SHARES_DOL();
            //                //insertAgentCommissionRequest2.oPLC_SHARES_DOL = pLC_SHARES_DOL2;
            //                bool insertAgentCommissionResponse2 = clientPolicy3.insertAgentCommission(pLC_SHARES_DOL2);
            //            }
            //            catch (Exception e)
            //            {
            //                Response.Item1 = false;
            //                Response.Item2 = e.Message;
            //            }
            //            try
            //            {
            //                //InsertPolicySponorsRequest insertPolicySponorsRequest = new InsertPolicySponorsRequest();
            //                //InsertPolicySponorsResponse insertPolicySponorsResponse = new InsertPolicySponorsResponse();
            //                PolicySponsorOutput policySponsorOutput = new PolicySponsorOutput();
            //                POLICY_SPONSORS_DOL insertPolicySponsorSDOL = new POLICY_SPONSORS_DOL();
            //                clientPolicy3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                insertPolicySponsorSDOL.IS_CANCELLED = 0;
            //                insertPolicySponsorSDOL.CREATED_BY = "ECHANNEL";
            //                insertPolicySponsorSDOL.NAME = PolicyHolder.Name;
            //                insertPolicySponsorSDOL.CRG_CTY_CODE = 1;
            //                insertPolicySponsorSDOL.CREATION_DATE = DateTime.Now;
            //                insertPolicySponsorSDOL.MPD_PLC_ID = policyOutput.oPolicy.ID;
            //                insertPolicySponsorSDOL.NATIONALITY_CODE = "SA";
            //                insertPolicySponsorSDOL.REGISTRY_NO = "2";
            //                insertPolicySponsorSDOL.REGISTRY_TYPE = 1;
            //                insertPolicySponsorSDOL.MOBILE_NO = PolicyHolder.MobileNo;
            //                insertPolicySponsorSDOL.IS_DEFAULT = 1L;
            //                insertPolicySponsorSDOL.SPONSOR_NO = PolicyHolder.CommercialNo;
            //                //insertPolicySponorsRequest.oPOLICY_SPONSORS_DOL = new POLICY_SPONSORS_DOL();
            //                //insertPolicySponorsRequest.oPOLICY_SPONSORS_DOL = insertPolicySponsorSDOL;
            //                policySponsorOutput = clientPolicy3.InsertPolicySponors(insertPolicySponsorSDOL);
            //                //policySponsorOutput.oPOLICY_SPONSORS_DOL = insertPolicySponorsResponse.InsertPolicySponorsResult.oPOLICY_SPONSORS_DOL;
            //                //policySponsorOutput.Status = insertPolicySponorsResponse.InsertPolicySponorsResult.Status;
            //            }
            //            catch (Exception ex2)
            //            {
            //                Response.Item1 = false;
            //                Response.Item2 = ex2.Message;
            //                DeletePolicy deletePolicy4 = new DeletePolicy();
            //                EskaPolicies.POLICYClient client4 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                //DeletePolicyDataRequest request4 = new DeletePolicyDataRequest();
            //                DeletePolicy response5 = new DeletePolicy();
            //                //request4.PolicyID = policyOutput.oPolicy.ID;
            //                response5 = client4.DeletePolicyData(policyOutput.oPolicy.ID);
            //            }
            //            try
            //            {
            //                //InsertTPARequest insertTPARequest = new InsertTPARequest();
            //                TpaOutput insertTPAResponse = new TpaOutput();
            //                clientPolicy3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                TPA_DOL TPA = new TPA_DOL();
            //                TPA.SHARE_AMOUNT = 0m;
            //                TPA.SHARE_AMOUNT_LC = 0m;
            //                TPA.MST_CAR_ID = Policy.TPAId.Value;
            //                TPA.SHARE_PER = Policy.TpaShare.Value;
            //                TPA.GROSS_AMOUNT = default(decimal);
            //                TPA.GROSS_AMOUNT_LC = default(decimal);
            //                TPA.MIN_SHARE_AMOUNT = 0m;
            //                TPA.MIN_SHARE_AMOUNT_LC = 0m;
            //                TPA.MPD_PLC_ID = policyOutput.oPolicy.ID;
            //                TPA.IS_TPA_CLASS = 0;
            //                TPA.TPA_LEVEL = 1;
            //                TPA.TPA_TYPE = 2;
            //                //insertTPARequest.oTPA_DOL = new TPA_DOL();
            //                //insertTPARequest.oTPA_DOL = TPA;
            //                insertTPAResponse = clientPolicy3.InsertTPA(TPA);
            //            }
            //            catch (Exception exc)
            //            {
            //                Response.Item1 = false;
            //                Response.Item2 = exc.Message;
            //                DeletePolicy deletePolicy3 = new DeletePolicy();
            //                EskaPolicies.POLICYClient client3 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                //DeletePolicyDataRequest request3 = new DeletePolicyDataRequest();
            //                DeletePolicy response3 = new DeletePolicy();
            //                //request3.PolicyID = policyOutput.oPolicy.ID;
            //                response3 = client3.DeletePolicyData(policyOutput.oPolicy.ID);
            //            }
            //            try
            //            {
            //                List<Subjects> Members = _Business.LoadMemberBusiness(Policy.Id, null);
            //                foreach (Subjects member in Members)
            //                {
            //                    MembersDeclarations declaration = _Business.LoadDeclarationByMember(member.Id);
            //                    decimal LoadingAmt = default(decimal);
            //                    if (declaration != null && declaration.Id > 0 && declaration.AdditionalPremium.HasValue)
            //                    {
            //                        LoadingAmt = declaration.AdditionalPremium.Value;
            //                    }
            //                    long? memberRelation = null;
            //                    if (member.Relation != 1)
            //                    {
            //                        memberRelation = Productions.LoadMemberRelation(member.Princible, EskaIGeneralConnection);
            //                    }
            //                    DateTime ExpiryIdentity = DateTime.Now.AddYears(1);
            //                    if (member.IdentityExpiryDate != null)
            //                    {
            //                        ExpiryIdentity = Utilities.ConvertDate(member.IdentityExpiryDate);
            //                    }
            //                    Productions.InsertMembers(Convert.ToInt64(policyOutput.oPolicy.ID), member.DiscountAmount.HasValue ? member.DiscountAmount : null, (LoadingAmt > 0m) ? new decimal?(LoadingAmt) : null, member.NationalId, member.Name, Convert.ToInt32(member.Occupation), Convert.ToInt32(member.MartialStatus), Convert.ToInt32(member.Gender), member.NationalityCode, Convert.ToInt32(member.Relation), ExpiryIdentity, ExpiryIdentity.AddYears(-1), member.DateOfBirth.Value, member.Princible, member.Princible, Convert.ToInt32(member.Age), memberRelation, Convert.ToInt32(member.ClassId), Convert.ToInt64(policyOutput.oPolicy.ID), connection, Convert.ToInt64(Policy.PlanId));
            //                }
            //                EskaPolicies.CalculatePolicyRequest calculatePolicyRequest = new EskaPolicies.CalculatePolicyRequest();
            //                CalculatePolicyOutput calculatePolicyOutput = new CalculatePolicyOutput();
            //                EskaPolicies.CalculatePolicyOutput calculatePolicyResponse = new EskaPolicies.CalculatePolicyOutput();
            //                EskaPolicies.ArrayOfXElement dsPolicyAgent1 = new ArrayOfXElement();
            //                calculatePolicyRequest.CREATED_BY = "Admin";
            //                calculatePolicyRequest.PolicySegment = policyOutput.oPolicy.SEGMENT_CODE;
            //                calculatePolicyRequest.ID = policyOutput.oPolicy.ID;
            //                calculatePolicyResponse = clientPolicy3.CalculatePolicy(calculatePolicyRequest.ID, calculatePolicyRequest.lcFeesID, calculatePolicyRequest.lcFeesPercentage, calculatePolicyRequest.lcFeesAmount, calculatePolicyRequest.CREATED_BY, ref calculatePolicyRequest.colPOLICY_FEES_DOL, calculatePolicyRequest.dsPolicyAgent, ref calculatePolicyRequest.PolicyPremium, ref calculatePolicyRequest.PolicySegment, ref calculatePolicyRequest.strErrorMessage, out dsPolicyAgent1);
            //                if (calculatePolicyResponse != null && calculatePolicyResponse.Status.StatusCode == 1)
            //                {
            //                    Policy.PushToEska = 1;
            //                    Policy.EskaId = policyOutput.oPolicy.ID;
            //                    Policy.EskaSegment = policyOutput.oPolicy.SEGMENT_CODE;
            //                    _Business.InsertUpdateProduction(Policy);
            //                    Response.Item1 = true;
            //                    Response.Item2 = string.Empty;
            //                }
            //                else
            //                {
            //                    Response.Item1 = false;
            //                    Response.Item2 = calculatePolicyResponse.Status.Reason;
            //                    DeletePolicy deletePolicy2 = new DeletePolicy();
            //                    EskaPolicies.POLICYClient client2 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                    //DeletePolicyDataRequest request2 = new DeletePolicyDataRequest();
            //                    DeletePolicy response2 = new DeletePolicy();
            //                    //request2.PolicyID = policyOutput.oPolicy.ID;
            //                    response2 = client2.DeletePolicyData(policyOutput.oPolicy.ID);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Response.Item1 = false;
            //                Response.Item2 = ex.Message;
            //                DeletePolicy deletePolicy = new DeletePolicy();
            //                EskaPolicies.POLICYClient client = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                //DeletePolicyDataRequest request = new DeletePolicyDataRequest();
            //                DeletePolicy response = new DeletePolicy();
            //                //request.PolicyID = policyOutput.oPolicy.ID;
            //                response = client.DeletePolicyData(policyOutput.oPolicy.ID);
            //            }
            //            continue;
            //        }
            //        Production orginal = _Business.LoadDocument(null, Convert.ToInt32(Policy.PolicyId.Value), 1);
            //        List<long> lsData = EndorsementPending.PendingEndorments(orginal.EskaId.Value, connection);
            //        if (deletependingEnd)
            //        {
            //            lsData.ForEach(delegate (long x)
            //            {
            //                DeletePolicy deletePolicy9 = new DeletePolicy();
            //                EskaPolicies.POLICYClient pOLICYClient = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                //DeletePolicyDataRequest deletePolicyDataRequest = new DeletePolicyDataRequest();
            //                DeletePolicy deletePolicyDataResponse = new DeletePolicy();
            //                //deletePolicyDataRequest.PolicyID = x;
            //                deletePolicyDataResponse = pOLICYClient.DeletePolicyData(x);
            //            });
            //        }
            //        long FCS_CUSTOMER_ID = Customer.insertCustomer(18, PolicyHolder.Name, PolicyHolder.CommercialNo, PolicyHolder.MobileNo, PolicyHolder.Email, 1, null, null, PolicyHolder.VatNumber, null, null, FinanceConnection);
            //        PolicyHolder.EskaId = FCS_CUSTOMER_ID;
            //        _Business.InsertUpdatePolicyHolder(PolicyHolder);
            //        EndpointAddress endpointAddressendo = new EndpointAddress(ESKAServiceEndoURL);
            //        //EndorsementInsertRequest end = new EndorsementInsertRequest();
            //        ENDORSEMENTClient clientEnd = new ENDORSEMENTClient(ENDORSEMENTClient.EndpointConfiguration.BasicHttpBinding_IENDORSEMENT, endpointAddressendo);
            //        Endoresement.POLICIES_DOL oPOLICIES_INPUT = new Endoresement.POLICIES_DOL();
            //        //PolicyID = Convert.ToInt32(orginal.EskaId.Value);
            //        oPOLICIES_INPUT.CreatedBy = "ECHANNEL";
            //        oPOLICIES_INPUT.ModifiedBy = "ECHANNEL";
            //        oPOLICIES_INPUT.CreationDate = DateTime.Now;
            //        oPOLICIES_INPUT.ModificationDate = DateTime.Now;
            //        oPOLICIES_INPUT.DocumentType = 2;
            //        oPOLICIES_INPUT.PolicyType = 2;
            //        oPOLICIES_INPUT.RenewalNo = 0;
            //        oPOLICIES_INPUT.EndorsementNo = 0;
            //        oPOLICIES_INPUT.APPLICANT_TYPE = 0;
            //        oPOLICIES_INPUT.UWYear = DateTime.Now.Year;
            //        oPOLICIES_INPUT.ReferenceDate = DateTime.Today.Date;
            //        oPOLICIES_INPUT.IssueDate = DateTime.Today.Date;
            //        oPOLICIES_INPUT.EffectiveDate = Policy.EffectiveDate;
            //        oPOLICIES_INPUT.ExpiryDate = Policy.ExpiryDate;
            //        oPOLICIES_INPUT.DURATION = (Policy.ExpiryDate - Policy.EffectiveDate).Days;
            //        oPOLICIES_INPUT.DURATION_UNIT = 1;
            //        oPOLICIES_INPUT.BusinessType = UserType.BusinessType.Value;
            //        oPOLICIES_INPUT.CalculationType = 1;
            //        oPOLICIES_INPUT.AccountedFor = Policy.AccountedFor;
            //        oPOLICIES_INPUT.RenewalNo = 0;
            //        oPOLICIES_INPUT.Notes = "";
            //        oPOLICIES_INPUT.IS_POSTED = 0;
            //        oPOLICIES_INPUT.Exrate = 1m;
            //        oPOLICIES_INPUT.PaymentID = 1L;
            //        oPOLICIES_INPUT.EndorsementID = Policy.EndosmentType.Value;
            //        oPOLICIES_INPUT.PlanID = Convert.ToInt64(Policy.PlanId);
            //        oPOLICIES_INPUT.PolicyHolderID = PolicyHolder.EskaId;
            //        oPOLICIES_INPUT.CurrencyCode = "SAR";
            //        oPOLICIES_INPUT.CompanyID = 1;
            //        oPOLICIES_INPUT.BranchID = 9;
            //        oPOLICIES_INPUT.TpaType = 2L;
            //        oPOLICIES_INPUT.BusinessChannel = 33633L;
            //        oPOLICIES_INPUT.IS_CONVERTED = 0;
            //        oPOLICIES_INPUT.APPROVAL_STATUS = 1;
            //        oPOLICIES_INPUT.PolicyID = Convert.ToInt32(orginal.EskaId);
            //        EndorsementOutput response4 = new EndorsementOutput();
            //        response4 = clientEnd.EndorsementInsert(Convert.ToInt32(orginal.EskaId), oPOLICIES_INPUT);
            //        if (response4 != null && response4.Status._StatusCode == 1)
            //        {
            //            try
            //            {
            //                //insertAgentCommissionRequest insertAgentCommissionRequest = new insertAgentCommissionRequest();
            //                //insertAgentCommissionResponse insertAgentCommissionResponse = new insertAgentCommissionResponse();
            //                PLC_SHARES_DOL pLC_SHARES_DOL = new PLC_SHARES_DOL();
            //                EskaPolicies.POLICYClient clientPolicy = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                pLC_SHARES_DOL.CREATED_BY = "ECHANNEL";
            //                pLC_SHARES_DOL.COMM_SHARE = 100;
            //                pLC_SHARES_DOL.COMM_PER = UserType.Commission;
            //                pLC_SHARES_DOL.IS_CANCELLED = 0;
            //                pLC_SHARES_DOL.CREATION_DATE = DateTime.Now;
            //                pLC_SHARES_DOL.AMOUNT = 0m;
            //                pLC_SHARES_DOL.AMOUNT_LC = 0m;
            //                pLC_SHARES_DOL.COLLECTION_TYPE = 1;
            //                pLC_SHARES_DOL.MPD_PLC_ID = response4.oPolicy.PolicyID;
            //                pLC_SHARES_DOL.FGL_COA_ID = UserType.ChartOfAccount.Value;
            //                pLC_SHARES_DOL.FCS_CST_ID = UserInfo.EskaId.Value;
            //                pLC_SHARES_DOL.ROLE_TYPE = UserType.MedicalId;
            //                //insertAgentCommissionRequest.oPLC_SHARES_DOL = new PLC_SHARES_DOL();
            //                //insertAgentCommissionRequest.oPLC_SHARES_DOL = pLC_SHARES_DOL;
            //                bool insertAgentCommissionResponse = clientPolicy.insertAgentCommission(pLC_SHARES_DOL);
            //            }
            //            catch (Exception e2)
            //            {
            //                Response.Item1 = false;
            //                Response.Item2 = e2.Message;
            //            }
            //            try
            //            {
            //                //InsertPolicySponorsRequest insertPolicySponorsRequest2 = new InsertPolicySponorsRequest();
            //                PolicySponsorOutput insertPolicySponorsResponse2 = new PolicySponsorOutput();
            //                PolicySponsorOutput policySponsorOutput2 = new PolicySponsorOutput();
            //                POLICY_SPONSORS_DOL insertPolicySponsorSDOL2 = new POLICY_SPONSORS_DOL();
            //                EskaPolicies.POLICYClient clientPolicy2 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                insertPolicySponsorSDOL2.IS_CANCELLED = 0;
            //                insertPolicySponsorSDOL2.CREATED_BY = "ECHANNEL";
            //                insertPolicySponsorSDOL2.NAME = PolicyHolder.Name;
            //                insertPolicySponsorSDOL2.CRG_CTY_CODE = 1;
            //                insertPolicySponsorSDOL2.CREATION_DATE = DateTime.Now;
            //                insertPolicySponsorSDOL2.MPD_PLC_ID = response4.oPolicy.PolicyID;
            //                insertPolicySponsorSDOL2.NATIONALITY_CODE = "SA";
            //                insertPolicySponsorSDOL2.REGISTRY_NO = "2";
            //                insertPolicySponsorSDOL2.REGISTRY_TYPE = 1;
            //                insertPolicySponsorSDOL2.MOBILE_NO = PolicyHolder.MobileNo;
            //                insertPolicySponsorSDOL2.IS_DEFAULT = 1L;
            //                insertPolicySponsorSDOL2.SPONSOR_NO = PolicyHolder.CommercialNo;
            //                //insertPolicySponorsRequest2.oPOLICY_SPONSORS_DOL = new POLICY_SPONSORS_DOL();
            //                //insertPolicySponorsRequest2.oPOLICY_SPONSORS_DOL = insertPolicySponsorSDOL2;
            //                insertPolicySponorsResponse2 = clientPolicy2.InsertPolicySponors(insertPolicySponsorSDOL2);
            //                //policySponsorOutput2.oPOLICY_SPONSORS_DOL = insertPolicySponorsResponse2.InsertPolicySponorsResult.oPOLICY_SPONSORS_DOL;
            //                //policySponsorOutput2.Status = insertPolicySponorsResponse2.InsertPolicySponorsResult.Status;
            //            }
            //            catch (Exception ex3)
            //            {
            //                Response.Item1 = false;
            //                Response.Item2 = ex3.Message;
            //                DeletePolicy deletePolicy7 = new DeletePolicy();
            //                EskaPolicies.POLICYClient client7 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                //DeletePolicyDataRequest request7 = new DeletePolicyDataRequest();
            //                DeletePolicy responsedelete3 = new DeletePolicy();
            //                //request7.PolicyID = response4.oPolicy.PolicyID;
            //                responsedelete3 = client7.DeletePolicyData(response4.oPolicy.PolicyID);
            //            }
            //            try
            //            {
            //                //InsertTPARequest insertTPARequest2 = new InsertTPARequest();
            //                TpaOutput insertTPAResponse2 = new TpaOutput();
            //                EskaPolicies.POLICYClient clientPolicy5 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                TPA_DOL TPA2 = new TPA_DOL();
            //                TPA2.SHARE_AMOUNT = 0m;
            //                TPA2.SHARE_AMOUNT_LC = 0m;
            //                TPA2.MST_CAR_ID = Policy.TPAId.Value;
            //                TPA2.SHARE_PER = Policy.TpaShare.Value;
            //                TPA2.GROSS_AMOUNT = default(decimal);
            //                TPA2.GROSS_AMOUNT_LC = default(decimal);
            //                TPA2.MIN_SHARE_AMOUNT = 0m;
            //                TPA2.MIN_SHARE_AMOUNT_LC = 0m;
            //                TPA2.MPD_PLC_ID = response4.oPolicy.PolicyID;
            //                TPA2.IS_TPA_CLASS = 0;
            //                TPA2.TPA_LEVEL = 1;
            //                TPA2.TPA_TYPE = 2;
            //                //insertTPARequest2.oTPA_DOL = new TPA_DOL();
            //                //insertTPARequest2.oTPA_DOL = TPA2;
            //                insertTPAResponse2 = clientPolicy5.InsertTPA(TPA2);
            //            }
            //            catch (Exception exc2)
            //            {
            //                Response.Item1 = false;
            //                Response.Item2 = exc2.Message;
            //                DeletePolicy deletePolicy8 = new DeletePolicy();
            //                EskaPolicies.POLICYClient client8 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                //DeletePolicyDataRequest request8 = new DeletePolicyDataRequest();
            //                DeletePolicy responsedelete4 = new DeletePolicy();
            //                //request8.PolicyID = response4.oPolicy.PolicyID;
            //                responsedelete4 = client8.DeletePolicyData(response4.oPolicy.PolicyID);
            //            }
            //            try
            //            {
            //                List<Subjects> Members2 = _Business.LoadMemberBusiness(Policy.Id, null);
            //                foreach (Subjects member2 in Members2)
            //                {
            //                    long? memberRelation2 = null;
            //                    if (member2.Relation != 1)
            //                    {
            //                        memberRelation2 = Productions.LoadMemberRelation(member2.Princible, EskaIGeneralConnection);
            //                    }
            //                    DateTime ExpiryIdentity2 = DateTime.Now.AddYears(1);
            //                    if (member2.IdentityExpiryDate != null)
            //                    {
            //                        ExpiryIdentity2 = Utilities.ConvertDate(member2.IdentityExpiryDate);
            //                    }
            //                    Productions.InsertMembers(Convert.ToInt64(response4.oPolicy.PolicyID), member2.DiscountAmount.HasValue ? member2.DiscountAmount : null, null, member2.NationalId, member2.Name, Convert.ToInt32(member2.Occupation), Convert.ToInt32(member2.MartialStatus), Convert.ToInt32(member2.Gender), member2.NationalityCode, Convert.ToInt32(member2.Relation), ExpiryIdentity2, ExpiryIdentity2.AddYears(-1), member2.DateOfBirth.Value, member2.Princible, member2.Princible, Convert.ToInt32(member2.Age), memberRelation2, Convert.ToInt32(member2.ClassId), Convert.ToInt64(response4.oPolicy.PolicyID), connection, Convert.ToInt64(Policy.PlanId));
            //                }
            //                EskaPolicies.CalculatePolicyRequest calculatePolicyRequest2 = new EskaPolicies.CalculatePolicyRequest();
            //                CalculatePolicyOutput calculatePolicyOutput2 = new CalculatePolicyOutput();
            //                CalculatePolicyOutput calculatePolicyResponse2 = new CalculatePolicyOutput();
            //                EskaPolicies.POLICYClient clientPolicy4 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                calculatePolicyRequest2.CREATED_BY = "Admin";
            //                calculatePolicyRequest2.PolicySegment = response4.oPolicy.SegmentCode;
            //                calculatePolicyRequest2.ID = response4.oPolicy.PolicyID;
            //                ArrayOfXElement dsPolicyAgent1 = new ArrayOfXElement();
            //                calculatePolicyResponse2 = clientPolicy4.CalculatePolicy(calculatePolicyRequest2.ID, calculatePolicyRequest2.lcFeesID, calculatePolicyRequest2.lcFeesPercentage, calculatePolicyRequest2.lcFeesAmount, calculatePolicyRequest2.CREATED_BY, ref calculatePolicyRequest2.colPOLICY_FEES_DOL, calculatePolicyRequest2.dsPolicyAgent, ref calculatePolicyRequest2.PolicyPremium, ref calculatePolicyRequest2.PolicySegment, ref calculatePolicyRequest2.strErrorMessage, out dsPolicyAgent1);
            //                if (calculatePolicyResponse2 != null && calculatePolicyResponse2.Status.StatusCode == 1)
            //                {
            //                    Policy.EndtSerial = response4.oPolicy.EndorsementNo;
            //                    Policy.EskaId = response4.oPolicy.PolicyID;
            //                    Policy.EskaSegment = response4.oPolicy.SegmentCode;
            //                    (Production, string) InsertProd = _Business.InsertUpdateProduction(Policy);
            //                    Response.Item1 = true;
            //                    Response.Item2 = string.Empty;
            //                }
            //                else
            //                {
            //                    Response.Item1 = false;
            //                    Response.Item2 = calculatePolicyResponse2.Status.Reason;
            //                    DeletePolicy deletePolicy6 = new DeletePolicy();
            //                    EskaPolicies.POLICYClient client6 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                    //DeletePolicyDataRequest request6 = new DeletePolicyDataRequest();
            //                    DeletePolicy responsedelete2 = new DeletePolicy();
            //                    //request6.PolicyID = response4.oPolicy.PolicyID;
            //                    responsedelete2 = client6.DeletePolicyData(response4.oPolicy.PolicyID);
            //                }
            //            }
            //            catch (Exception e3)
            //            {
            //                Response.Item1 = false;
            //                Response.Item2 = e3.Message;
            //                DeletePolicy deletePolicy5 = new DeletePolicy();
            //                EskaPolicies.POLICYClient client5 = new EskaPolicies.POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            //                //DeletePolicyDataRequest request5 = new DeletePolicyDataRequest();
            //                DeletePolicy responsedelete = new DeletePolicy();
            //                //request5.PolicyID = response4.oPolicy.PolicyID;
            //                responsedelete = client5.DeletePolicyData(response4.oPolicy.PolicyID);
            //            }
            //        }
            //        else
            //        {
            //            Response.Item1 = false;
            //            Response.Item2 = response4.Status._Reason.ToString();
            //        }
            //    }
            //}
            return Response;
        }


    }
}
