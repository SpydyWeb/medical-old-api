using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.ServiceModel.Security;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.TP_Services;
using CORE.Interfaces;
using CORE.TablesObjects;
using DataAccessLayer.Oracle.Eskadenia.Setups;
using Fluentx;
using InsuranceAPIs.API;
using InsuranceAPIs.Models.Configuration_Objects;
using InsuranceAPIs.Models.ExternalAPIs;
using MedicalCore.Helpers;
using MicroAPIs.Core.Extensions;
using Newtonsoft.Json;
using Yakeen;

namespace InsuranceAPIs.Extension
{
    public static class YakeenCall
    {
        public static ValidationMembers CheckYakeenMembers(List<ExcelMembers> lsMembers, AppSettings Configurations, IBusiness business, IProcess process)
        //public static ValidationMembers CheckYakeenMembers(List<ExcelMembers> lsMembers, AppSettings Configurations)
        {
            ValidationMembers validationMembers = new ValidationMembers();
            validationMembers.lsError = new List<ErrorMembers>();
            validationMembers.LsSuccessMembers = new List<Members>();
            YakeenProccess yakeenProccess = new YakeenProccess();
            int MaxAge = PlanSetups.MaxPlanAge(Convert.ToInt32(Configurations.PlanCode), Configurations.EskaConnection);
            foreach (ExcelMembers Member in lsMembers)
            {
                //YakeenMembers yakeenLocal = business.getYakeenMembers(Member.memberInfo.NationalID, Member.memberInfo.Sponsor);
                YakeenMembers yakeenLocal = null;
                Members ObjMem = new Members();
                ObjMem.membersData = new MembersData();
                ObjMem.membersData.MainMember = new Subjects();
                if (yakeenLocal != null && yakeenLocal.Members != null)
                {
                    if (MaxAge > 0 && Utilities.AgeCalculation(yakeenLocal.Members.DateOfBirth.Value) > MaxAge)
                    {
                        ErrorMembers errorMembers = new ErrorMembers();
                        errorMembers.dependMember = new List<ErrorsDependent>();
                        errorMembers.membersData = new Princible();
                        ErrorsDependent data = new ErrorsDependent();
                        errorMembers.membersData.NationalId = Member.memberInfo.NationalID;
                        errorMembers.membersData.IsSuccess = false;
                        errorMembers.membersData.DateOfBirth = Member.memberInfo.HijriDate;
                        errorMembers.membersData.Error = "Member Age Exceed Plan limit";
                        yakeenProccess.errorMembers = errorMembers;
                        yakeenProccess.Status = false;
                        foreach (MainMemberInfo item in Member.dependent)
                        {
                            data = new ErrorsDependent
                            {
                                DateOfBirth = item.HijriDate,
                                Error = "His Sponser was rejected",
                                NationalId = item.NationalID,
                                Sponsor = item.Sponsor
                            };
                            errorMembers.dependMember.Add(data);
                        }
                        validationMembers.lsError.Add(errorMembers);
                        continue;
                    }

                    NationalityMapping nationality = business.GetEskaNationalityByEska(yakeenLocal.Members.Nationality);
                    ObjMem.membersData.MainMember.Name = yakeenLocal.Members.Name;
                    ObjMem.membersData.MainMember.DateOfBirth = yakeenLocal.Members.DateOfBirth;
                    ObjMem.membersData.MainMember.Gender = yakeenLocal.Members.Gender;
                    ObjMem.membersData.MainMember.MartialStatus = Member.memberInfo.MartialStatus;
                    ObjMem.membersData.MainMember.Age = Utilities.AgeCalculation(yakeenLocal.Members.DateOfBirth.Value);
                    ObjMem.membersData.MainMember.Occupation = yakeenLocal.Members.Occupation.ToString();
                    ObjMem.membersData.MainMember.NationalityCode = yakeenLocal.Members.Nationality;
                    ObjMem.membersData.MainMember.PassportNo = Member.memberInfo.NationalID;
                    ObjMem.membersData.MainMember.NationalId = Member.memberInfo.NationalID;
                    ObjMem.membersData.MainMember.Princible = yakeenLocal.Members.Sponsor;
                    ObjMem.membersData.MainMember.Relation = Member.memberInfo.Relation;
                    ObjMem.membersData.OccupationName = yakeenLocal.Members.Occupation.ToString();
                    ObjMem.membersData.NationalityAr = nationality.NationalityNameAr;
                    ObjMem.membersData.NationalityEn = nationality.NationalityNameEn;
                    ObjMem.membersData.MainMember.ClassId = nationality.ClassId;
                    foreach (MainMemberInfo item2 in Member.dependent)
                    {
                        YakeenLogsMember dependent = yakeenLocal.Dependent.Where((YakeenLogsMember p) => p.NationalId == item2.NationalID && p.Sponsor == item2.Sponsor).FirstOrDefault();
                        if (dependent != null)
                        {
                            MembersData membersData = new MembersData();
                            membersData.MainMember = new Subjects();
                            nationality = business.GetEskaNationalityByEska(dependent.Nationality);
                            membersData.MainMember.Name = dependent.Name;
                            membersData.MainMember.DateOfBirth = dependent.DateOfBirth;
                            membersData.MainMember.Gender = dependent.Gender;
                            membersData.MainMember.MartialStatus = item2.MartialStatus;
                            membersData.MainMember.ClassId = nationality.ClassId;
                            membersData.MainMember.Age = Utilities.AgeCalculation(dependent.DateOfBirth.Value);
                            membersData.MainMember.Occupation = dependent.Occupation.ToString();
                            membersData.MainMember.NationalityCode = nationality.EskaCode;
                            membersData.MainMember.PassportNo = dependent.NationalId;
                            membersData.MainMember.NationalId = dependent.NationalId;
                            membersData.MainMember.Princible = dependent.Sponsor;
                            membersData.MainMember.Relation = item2.Relation;
                            membersData.OccupationName = yakeenLocal.Members.Occupation.ToString();
                            membersData.NationalityAr = nationality.EskaNameAr;
                            membersData.NationalityEn = nationality.EskaNameEn;
                            ObjMem.dependMember.Add(membersData);
                        }
                        else
                        {
                            yakeenProccess = new YakeenProccess();
                            yakeenProccess = (Member.YakeenPolicyLevel ? InsertYakeen(item2, business, Configurations) : OfflineYakeen(item2, business, Configurations));
                            if (yakeenProccess.Status)
                            {
                                ObjMem.dependMember.Add(yakeenProccess.membersData);
                                continue;
                            }
                            ObjMem.ErrDep.Add(yakeenProccess.errorMembers);
                            validationMembers.lsError.Add(yakeenProccess.errorMembers);
                        }
                    }
                    validationMembers.LsSuccessMembers.Add(ObjMem);
                    continue;
                }
                if (Member.memberInfo.NationalID.StartsWith("1") && string.IsNullOrEmpty(Member.memberInfo.HijriDate))
                {
                    ErrorMembers errorMembers = new ErrorMembers();
                    errorMembers.dependMember = new List<ErrorsDependent>();
                    errorMembers.membersData = new Princible();
                    ErrorsDependent data = new ErrorsDependent();
                    errorMembers.membersData.NationalId = Member.memberInfo.NationalID;
                    errorMembers.membersData.IsSuccess = false;
                    errorMembers.membersData.DateOfBirth = Member.memberInfo.HijriDate;
                    errorMembers.membersData.Error = "Please enter the hijri DOB";
                    yakeenProccess.errorMembers = errorMembers;
                    yakeenProccess.Status = false;
                    foreach (MainMemberInfo item in Member.dependent)
                    {
                        if (item.NationalID.StartsWith("1") && string.IsNullOrEmpty(item.HijriDate))
                            data = new ErrorsDependent
                            {
                                DateOfBirth = item.HijriDate,
                                Error = "Please enter the hijri DOB",
                                NationalId = item.NationalID,
                                Sponsor = item.Sponsor
                            };
                        errorMembers.dependMember.Add(data);
                    }
                    validationMembers.lsError.Add(errorMembers);
                    continue;
                }
                if (Member.dependent.Count > 0 && Member.memberInfo.MartialStatus == 1)
                {
                    ErrorMembers errorMembers = new ErrorMembers();
                    errorMembers.dependMember = new List<ErrorsDependent>();
                    errorMembers.membersData = new Princible();
                    ErrorsDependent data = new ErrorsDependent();
                    errorMembers.membersData.NationalId = Member.memberInfo.NationalID;
                    errorMembers.membersData.IsSuccess = false;
                    errorMembers.membersData.DateOfBirth = Member.memberInfo.HijriDate;
                    errorMembers.membersData.Error = "Please mark it as married because it has dependant";
                    yakeenProccess.errorMembers = errorMembers;
                    yakeenProccess.Status = false;
                    foreach (MainMemberInfo item in Member.dependent)
                    {
                        data = new ErrorsDependent
                        {
                            DateOfBirth = item.HijriDate,
                            Error = "",
                            NationalId = item.NationalID,
                            Sponsor = item.Sponsor
                        };
                        errorMembers.dependMember.Add(data);
                    }
                    validationMembers.lsError.Add(errorMembers);
                    continue;

                }
                var resu = process.CheckUserBlackList(Member.memberInfo.NationalID);
                if (resu.status)
                {
                    ErrorMembers errorMembers = new ErrorMembers();
                    errorMembers.dependMember = new List<ErrorsDependent>();
                    errorMembers.membersData = new Princible();
                    ErrorsDependent data = new ErrorsDependent();
                    errorMembers.membersData.NationalId = Member.memberInfo.NationalID;
                    errorMembers.membersData.IsSuccess = false;
                    errorMembers.membersData.DateOfBirth = Member.memberInfo.HijriDate;
                    errorMembers.membersData.Error = "This member is blacklist you can't add this member. Please contact underwriter team.";
                    yakeenProccess.errorMembers = errorMembers;
                    yakeenProccess.Status = false;
                    foreach (MainMemberInfo item in Member.dependent)
                    {
                        data = new ErrorsDependent
                        {
                            DateOfBirth = item.HijriDate,
                            Error = "This member is blacklist you can't add this member. Please contact underwriter team.",
                            NationalId = item.NationalID,
                            Sponsor = item.Sponsor
                        };
                        errorMembers.dependMember.Add(data);
                    }
                    validationMembers.lsError.Add(errorMembers);
                    continue;
                }

                yakeenProccess = new YakeenProccess();
                yakeenProccess = (Member.YakeenPolicyLevel ? InsertYakeen(Member.memberInfo, business, Configurations) : OfflineYakeen(Member.memberInfo, business, Configurations));
                if (yakeenProccess.Status)
                {
                    if (MaxAge > 0 && Utilities.AgeCalculation(yakeenProccess.membersData.MainMember.DateOfBirth.Value) > MaxAge)
                    {
                        ErrorMembers errorMembers2 = new ErrorMembers();
                        errorMembers2.dependMember = new List<ErrorsDependent>();
                        errorMembers2.membersData = new Princible();
                        ErrorsDependent data2 = new ErrorsDependent();
                        errorMembers2.membersData.NationalId = Member.memberInfo.NationalID;
                        errorMembers2.membersData.IsSuccess = false;
                        errorMembers2.membersData.DateOfBirth = Member.memberInfo.HijriDate;
                        errorMembers2.membersData.Error = "Member Age Exceed Plan limit";
                        yakeenProccess.errorMembers = errorMembers2;
                        yakeenProccess.Status = false;
                        foreach (MainMemberInfo item3 in Member.dependent)
                        {
                            data2 = new ErrorsDependent
                            {
                                DateOfBirth = item3.HijriDate,
                                Error = "His Sponser was rejected",
                                NationalId = item3.NationalID,
                                Sponsor = item3.Sponsor
                            };
                            errorMembers2.dependMember.Add(data2);
                        }
                        validationMembers.lsError.Add(errorMembers2);
                        continue;
                    }
                    ObjMem.membersData = yakeenProccess.membersData;
                    foreach (MainMemberInfo item4 in Member.dependent)
                    {
                        yakeenProccess = new YakeenProccess();
                        yakeenProccess = (Member.YakeenPolicyLevel ? InsertYakeen(item4, business, Configurations) : OfflineYakeen(item4, business, Configurations));
                        if (yakeenProccess.Status)
                        {
                            ObjMem.dependMember.Add(yakeenProccess.membersData);
                        }
                        else
                        {
                            validationMembers.lsError.Add(yakeenProccess.errorMembers);
                        }
                    }
                    validationMembers.LsSuccessMembers.Add(ObjMem);
                    continue;
                }
                ErrorMembers errorMembers3 = new ErrorMembers();
                errorMembers3 = yakeenProccess.errorMembers;
                foreach (MainMemberInfo item5 in Member.dependent)
                {
                    errorMembers3.dependMember.Add(new ErrorsDependent
                    {
                        Error = "Not Uploaded , Sponser Rejected",
                        NationalId = item5.NationalID,
                        DateOfBirth = item5.HijriDate,
                        Sponsor = item5.Sponsor
                    });
                }
                validationMembers.lsError.Add(errorMembers3);
            }
            return validationMembers;
        }

        public static YakeenProccess InsertYakeen(MainMemberInfo mainMemberInfo, IBusiness business, AppSettings Configurations)
        {
            YakeenProccess yakeenProccess = new YakeenProccess();
            //Yakeen4SolidarityClient client = new Yakeen4SolidarityClient();
            if (mainMemberInfo.NationalID.Substring(0, 1) == "1")
            {
                Dates dates = new Dates();
                string Date = mainMemberInfo.HijriDate;
                if (Date.Length <= 6)
                {
                    Date = "0" + Date;
                }
                try
                {
                    string citizenReq = "nin=" + mainMemberInfo.NationalID + "&dateString=" + Date + "&Source=PROD";
                    List<SaudiByNinResponse> CitizenResp = new List<SaudiByNinResponse>();
                    CitizenResp = ApiCall.ExecuteGetApi<List<SaudiByNinResponse>>(citizenReq, Configurations.YakeenAPIConfig.URL + "SaudiByNin", Configurations.YakeenAPIConfig.ApiKey);
                    //citizenInfoByNINResult Result = new citizenInfoByNINResult();
                    //if (CitizenResp.CitizenInfoByNINResult != null && CitizenResp != null)
                    if (CitizenResp != null && CitizenResp.Count > 0 && CitizenResp[0].status)
                    {
                        YakeenLogsMember yakeenLogs = new YakeenLogsMember();
                        //Result = CitizenResp.CitizenInfoByNINResult;
                        Members ObjMem = new Members();
                        ObjMem.membersData = new MembersData();
                        ObjMem.membersData.MainMember = new Subjects();
                        NationalityMapping nationality = business.GetEskaNationality(0);
                        ObjMem.membersData.MainMember.Name = CitizenResp[0].personBasicInfo.firstName + " " + CitizenResp[0].personBasicInfo.fatherName + " " + CitizenResp[0].personBasicInfo.familyName;
                        ObjMem.membersData.MainMember.DateOfBirth = ConvertDate(CitizenResp[0].personBasicInfo.birthDateG);
                        ObjMem.membersData.MainMember.Gender = Convert.ToInt32(CitizenResp[0].personBasicInfo.sexCode);
                        ObjMem.membersData.MainMember.MartialStatus = mainMemberInfo.MartialStatus;
                        ObjMem.membersData.MainMember.Age = Utilities.AgeCalculation(ObjMem.membersData.MainMember.DateOfBirth.Value);
                        ObjMem.membersData.MainMember.Occupation = Configurations.SAUDIOCCUPATION;
                        ObjMem.membersData.MainMember.NationalityCode = Configurations.SAUDINATIONALITY;
                        ObjMem.membersData.MainMember.PassportNo = mainMemberInfo.NationalID;
                        ObjMem.membersData.MainMember.NationalId = mainMemberInfo.NationalID;
                        ObjMem.membersData.MainMember.ClassId = nationality.ClassId;
                        ObjMem.membersData.MainMember.Relation = mainMemberInfo.Relation;
                        ObjMem.membersData.MainMember.Princible = mainMemberInfo.Sponsor;
                        ObjMem.membersData.OccupationName = Configurations.SAUDIOCCUPATION;
                        ObjMem.membersData.NationalityAr = Configurations.SAUDINATIONALITY;
                        ObjMem.membersData.NationalityEn = Configurations.SAUDINATIONALITY;
                        yakeenLogs.Name = CitizenResp[0].personBasicInfo.firstName + " " + CitizenResp[0].personBasicInfo.fatherName + " " + CitizenResp[0].personBasicInfo.familyName;
                        yakeenLogs.DateOfBirth = ConvertDate(CitizenResp[0].personBasicInfo.birthDateG);
                        yakeenLogs.Gender = Convert.ToInt32(CitizenResp[0].personBasicInfo.sexCode);
                        yakeenLogs.MartialStatus = mainMemberInfo.MartialStatus;
                        yakeenLogs.Occupation = Convert.ToInt32(Configurations.SAUDIOCCUPATION);
                        yakeenLogs.Nationality = Configurations.SAUDINATIONALITY;
                        yakeenLogs.NationalId = mainMemberInfo.NationalID;
                        yakeenLogs.Sponsor = mainMemberInfo.Sponsor;
                        yakeenLogs.RecordDate = DateTime.Now;
                        yakeenLogs.Relation = mainMemberInfo.Relation;
                        business.AddUpdateYakeenMembers(yakeenLogs);
                        yakeenProccess.membersData = ObjMem.membersData;
                        yakeenProccess.Status = true;
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
                        ErrorMembers errorMembers2 = new ErrorMembers();
                        errorMembers2.dependMember = new List<ErrorsDependent>();
                        errorMembers2.membersData = new Princible();
                        ErrorsDependent data2 = new ErrorsDependent();
                        errorMembers2.membersData.NationalId = mainMemberInfo.NationalID;
                        errorMembers2.membersData.IsSuccess = false;
                        errorMembers2.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                        errorMembers2.membersData.Error = errorMessage;
                        yakeenProccess.errorMembers = errorMembers2;
                        yakeenProccess.Status = false;
                    }
                }
                catch (Exception e)
                {
                    ErrorMembers errorMembers = new ErrorMembers();
                    errorMembers.dependMember = new List<ErrorsDependent>();
                    errorMembers.membersData = new Princible();
                    ErrorsDependent data = new ErrorsDependent();
                    errorMembers.membersData.NationalId = mainMemberInfo.NationalID;
                    errorMembers.membersData.IsSuccess = false;
                    errorMembers.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                    errorMembers.membersData.Error = e.Message;
                    yakeenProccess.errorMembers = errorMembers;
                    yakeenProccess.Status = false;
                }
            }
            else if (mainMemberInfo.NationalID.Substring(0, 1) == "2")
            {
                residentInfoByIqamaNumberRequest alienInfo = new residentInfoByIqamaNumberRequest();
                residentInfoByIqamaNumberResult alienResult = new residentInfoByIqamaNumberResult();
                //getResidentInfoByIqamaNumber AlienInfoResp = new getResidentInfoByIqamaNumber();
                //getResidentInfoByIqamaNumberResponse ResidentResponse = new getResidentInfoByIqamaNumberResponse();
                //alienInfo.password = Utilities.YAKEENPWD();
                //alienInfo.userName = Utilities.YAKEENUSERNAME();
                //alienInfo.chargeCode = Utilities.YAKEENPROD();
                //alienInfo.iqamaNumber = mainMemberInfo.NationalID;
                //alienInfo.sponsorId = mainMemberInfo.Sponsor;
                //AlienInfoResp.ResidentInfoByIqamaNumberRequest = new residentInfoByIqamaNumberRequest();
                //AlienInfoResp.ResidentInfoByIqamaNumberRequest = alienInfo;
                try
                {
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    //ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                    //client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
                    //{
                    //    CertificateValidationMode = X509CertificateValidationMode.None,
                    //    RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                    //};
                    //ResidentResponse = client.getResidentInfoByIqamaNumberAsync(AlienInfoResp).Result;

                    string ResidentInfoByIqamaNumberRequest = "IQamaNumber=" + mainMemberInfo.NationalID + "&sponsorID=" + mainMemberInfo.Sponsor + "&Source=PROD";
                    List<ResidentInfoByIqamaNumberResponse> ResidentResponse = new List<ResidentInfoByIqamaNumberResponse>();
                    ResidentResponse = ApiCall.ExecuteGetApi<List<ResidentInfoByIqamaNumberResponse>>(ResidentInfoByIqamaNumberRequest, Configurations.YakeenAPIConfig.URL + "ResidentInfoByIqamaNumber", Configurations.YakeenAPIConfig.ApiKey);


                    //if (ResidentResponse != null && ResidentResponse.ResidentInfoByIqamaNumberResult != null)
                    if (ResidentResponse != null && ResidentResponse.Count > 0 && ResidentResponse[0].status)
                    {
                        var fullName = ResidentResponse[0].personBasicInfo.firstNameT + " " + ResidentResponse[0].personBasicInfo.fatherNameT + " " + ResidentResponse[0].personBasicInfo.familyNameT;
                        if (string.IsNullOrEmpty(fullName.Trim()))
                        {
                            fullName = ResidentResponse[0].personBasicInfo.firstName + " " + ResidentResponse[0].personBasicInfo.fatherName + " " + ResidentResponse[0].personBasicInfo.familyName;
                        }

                        YakeenLogsMember yakeenLogs2 = new YakeenLogsMember();
                        Members ObjMem2 = new Members();
                        ObjMem2.membersData = new MembersData();
                        ObjMem2.membersData.MainMember = new Subjects();
                        ObjMem2.membersData.MainMember.Name = fullName;
                        ObjMem2.membersData.MainMember.DateOfBirth = ConvertDate(ResidentResponse[0].personBasicInfo.birthDateG);
                        ObjMem2.membersData.MainMember.Gender = Convert.ToInt32(ResidentResponse[0].personBasicInfo.sexCode);
                        ObjMem2.membersData.MainMember.MartialStatus = mainMemberInfo.MartialStatus;
                        ObjMem2.membersData.MainMember.Age = Utilities.AgeCalculation(ObjMem2.membersData.MainMember.DateOfBirth.Value);
                        ObjMem2.membersData.MainMember.PassportNo = mainMemberInfo.NationalID;
                        ObjMem2.membersData.MainMember.NationalId = mainMemberInfo.NationalID;
                        ObjMem2.membersData.MainMember.Relation = mainMemberInfo.Relation;
                        ObjMem2.membersData.MainMember.Princible = mainMemberInfo.Sponsor;
                        try
                        {
                            try
                            {
                                yakeenLogs2.IdentityExpiryDate = DateTime.ParseExact(ResidentResponse[0].personIdInfo.idExpirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    yakeenLogs2.IdentityExpiryDate = Convert.ToDateTime(ResidentResponse[0].personIdInfo.idExpirationDate);
                                }
                                catch (Exception)
                                {
                                    yakeenLogs2.IdentityExpiryDate = DateTime.ParseExact(ResidentResponse[0].personIdInfo.idExpirationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            try
                            {
                                yakeenLogs2.IdentityExpiryDate = DateTime.ParseExact(ResidentResponse[0].personIdInfo.idExpirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                yakeenLogs2.IdentityExpiryDate = DateTime.ParseExact(ResidentResponse[0].personIdInfo.idExpirationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                        }
                        NationalityMapping nationality2 = business.GetEskaNationality(Convert.ToInt32(ResidentResponse[0].personBasicInfo.nationalityCode));
                        ObjMem2.membersData.MainMember.NationalityCode = nationality2.EskaCode;
                        ObjMem2.membersData.MainMember.ClassId = nationality2.ClassId;
                        ObjMem2.membersData.NationalityAr = nationality2.NationalityNameAr;
                        ObjMem2.membersData.NationalityEn = nationality2.NationalityNameEn;
                        string h = ResidentResponse[0].personBasicInfo.occupationCode.ToString();
                        ObjMem2.membersData.OccupationName = h;
                        ObjMem2.membersData.MainMember.Occupation = h;
                        yakeenLogs2.Name = ObjMem2.membersData.MainMember.Name;
                        yakeenLogs2.DateOfBirth = ObjMem2.membersData.MainMember.DateOfBirth;
                        yakeenLogs2.Gender = ObjMem2.membersData.MainMember.Gender.Value;
                        yakeenLogs2.MartialStatus = ObjMem2.membersData.MainMember.MartialStatus.Value;
                        yakeenLogs2.Occupation = Convert.ToInt32(ObjMem2.membersData.MainMember.Occupation);
                        yakeenLogs2.Nationality = nationality2.EskaCode;
                        yakeenLogs2.NationalId = mainMemberInfo.NationalID;
                        yakeenLogs2.Sponsor = mainMemberInfo.Sponsor;
                        yakeenLogs2.RecordDate = DateTime.Now;
                        yakeenLogs2.Relation = mainMemberInfo.Relation;
                        yakeenLogs2.IdentityExpiryDate = ConvertDate(ResidentResponse[0].personIdInfo.idExpirationDate);
                        business.AddUpdateYakeenMembers(yakeenLogs2);
                        yakeenProccess.membersData = ObjMem2.membersData;
                        yakeenProccess.Status = true;
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
                        ErrorMembers errorMembers2 = new ErrorMembers();
                        errorMembers2.dependMember = new List<ErrorsDependent>();
                        errorMembers2.membersData = new Princible();
                        ErrorsDependent data2 = new ErrorsDependent();
                        errorMembers2.membersData.NationalId = mainMemberInfo.NationalID;
                        errorMembers2.membersData.IsSuccess = false;
                        errorMembers2.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                        errorMembers2.membersData.Error = errorMessage;
                        yakeenProccess.errorMembers = errorMembers2;
                        yakeenProccess.Status = false;
                    }
                }
                catch (Exception e2)
                {
                    ErrorMembers errorMembers2 = new ErrorMembers();
                    errorMembers2.dependMember = new List<ErrorsDependent>();
                    errorMembers2.membersData = new Princible();
                    ErrorsDependent data2 = new ErrorsDependent();
                    errorMembers2.membersData.NationalId = mainMemberInfo.NationalID;
                    errorMembers2.membersData.IsSuccess = false;
                    errorMembers2.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                    errorMembers2.membersData.Error = e2.Message;
                    yakeenProccess.errorMembers = errorMembers2;
                    yakeenProccess.Status = false;
                }
            }
            else
            {
                //getResidentInfoByBorderNumber Request = new getResidentInfoByBorderNumber();
                //residentInfoByBorderNumberRequest CrRequest = new residentInfoByBorderNumberRequest();
                //residentInfoByBorderNumberResult CrResult = new residentInfoByBorderNumberResult();
                //getResidentInfoByBorderNumberResponse Response = new getResidentInfoByBorderNumberResponse();
                //Yakeen4SolidarityClient yakeenClient = new Yakeen4SolidarityClient();
                //CrRequest.borderNumber = mainMemberInfo.NationalID;
                //CrRequest.password = Utilities.YAKEENPWD();
                //CrRequest.userName = Utilities.YAKEENUSERNAME();
                //CrRequest.chargeCode = Utilities.YAKEENPROD();
                //CrRequest.sponsorId = mainMemberInfo.Sponsor;
                //Request.ResidentInfoByBorderNumberRequest = new residentInfoByBorderNumberRequest();
                //Request.ResidentInfoByBorderNumberRequest = CrRequest;
                try
                {
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    //ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                    //yakeenClient.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
                    //{
                    //    CertificateValidationMode = X509CertificateValidationMode.None,
                    //    RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                    //};
                    //Response = yakeenClient.getResidentInfoByBorderNumberAsync(Request).Result;

                    string NonSaudiByBorderRequest = "borderNo=" + mainMemberInfo.NationalID + "&sponsorID=" + mainMemberInfo.Sponsor + "&Source=PROD";
                    List<NonSaudiByBorderResponse> NonSaudiByBorderResponse = new List<NonSaudiByBorderResponse>();
                    NonSaudiByBorderResponse = ApiCall.ExecuteGetApi<List<NonSaudiByBorderResponse>>(NonSaudiByBorderRequest, Configurations.YakeenAPIConfig.URL + "NonSaudiByBorder", Configurations.YakeenAPIConfig.ApiKey);

                    if (NonSaudiByBorderResponse != null && NonSaudiByBorderResponse.Count > 0 && NonSaudiByBorderResponse[0].status)
                    {
                        var fullName = NonSaudiByBorderResponse[0].personBasicInfo.firstNameT + " " + NonSaudiByBorderResponse[0].personBasicInfo.fatherNameT + " " + NonSaudiByBorderResponse[0].personBasicInfo.familyNameT;
                        if (string.IsNullOrEmpty(fullName.Trim()))
                        {
                            fullName = NonSaudiByBorderResponse[0].personBasicInfo.firstName + " " + NonSaudiByBorderResponse[0].personBasicInfo.fatherName + " " + NonSaudiByBorderResponse[0].personBasicInfo.familyName;
                        }

                        YakeenLogsMember yakeenLogs3 = new YakeenLogsMember();
                        Members ObjMem3 = new Members();
                        ObjMem3.membersData = new MembersData();
                        ObjMem3.membersData.MainMember = new Subjects();
                        ObjMem3.ErrDep = new List<ErrorMembers>();
                        ObjMem3.membersData.MainMember.Name = fullName;
                        ObjMem3.membersData.MainMember.DateOfBirth = ConvertDate(NonSaudiByBorderResponse[0].personBasicInfo.birthDateG);
                        ObjMem3.membersData.MainMember.Gender = Convert.ToInt32(NonSaudiByBorderResponse[0].personBasicInfo.sexCode);
                        ObjMem3.membersData.MainMember.MartialStatus = mainMemberInfo.MartialStatus;
                        ObjMem3.membersData.MainMember.Age = Utilities.AgeCalculation(ObjMem3.membersData.MainMember.DateOfBirth.Value);
                        ObjMem3.membersData.MainMember.PassportNo = mainMemberInfo.NationalID;
                        ObjMem3.membersData.MainMember.NationalId = mainMemberInfo.NationalID;
                        ObjMem3.membersData.MainMember.Relation = mainMemberInfo.Relation;
                        ObjMem3.membersData.MainMember.Princible = mainMemberInfo.Sponsor;
                        ObjMem3.membersData.MainMember.IdentityExpiryDate = DateTime.Today.AddDays(90.0).ToShortDateString();
                        NationalityMapping Nationality = business.GetEskaNationality(Convert.ToInt32(NonSaudiByBorderResponse[0].personBasicInfo.nationalityCode));
                        ObjMem3.membersData.MainMember.NationalityCode = Nationality.EskaCode;
                        ObjMem3.membersData.MainMember.ClassId = Nationality.ClassId;
                        ObjMem3.membersData.NationalityEn = Nationality.NationalityNameEn;
                        ObjMem3.membersData.NationalityAr = Nationality.NationalityNameAr;
                        ObjMem3.membersData.OccupationName = NonSaudiByBorderResponse[0].personBasicInfo.occupationCode;
                        ObjMem3.membersData.MainMember.Occupation = NonSaudiByBorderResponse[0].personBasicInfo.occupationCode;
                        yakeenLogs3.Name = ObjMem3.membersData.MainMember.Name;
                        yakeenLogs3.DateOfBirth = ObjMem3.membersData.MainMember.DateOfBirth;
                        yakeenLogs3.Gender = ObjMem3.membersData.MainMember.Gender.Value;
                        yakeenLogs3.MartialStatus = ObjMem3.membersData.MainMember.MartialStatus.Value;
                        yakeenLogs3.Occupation = Convert.ToInt32(ObjMem3.membersData.MainMember.Occupation);
                        yakeenLogs3.Nationality = Nationality.EskaCode;
                        yakeenLogs3.NationalId = mainMemberInfo.NationalID;
                        yakeenLogs3.Sponsor = mainMemberInfo.Sponsor;
                        yakeenLogs3.RecordDate = DateTime.Now;
                        yakeenLogs3.Relation = mainMemberInfo.Relation;
                        business.AddUpdateYakeenMembers(yakeenLogs3);
                        yakeenProccess.membersData = ObjMem3.membersData;
                        yakeenProccess.Status = true;
                    }
                    else
                    {
                        string errorMessage = "";
                        if (NonSaudiByBorderResponse[0].errorDetail != null)
                        {
                            //errorMessage = JsonConvert.SerializeObject(ResidentResponse[0].errorDetail);
                            errorMessage = NonSaudiByBorderResponse[0].errorDetail.errorMessage;
                        }
                        else
                        {
                            errorMessage = NonSaudiByBorderResponse[0].errorMessage;
                        }
                        ErrorMembers errorMembers3 = new ErrorMembers();
                        errorMembers3.dependMember = new List<ErrorsDependent>();
                        errorMembers3.membersData = new Princible();
                        ErrorsDependent data3 = new ErrorsDependent();
                        errorMembers3.membersData.NationalId = mainMemberInfo.NationalID;
                        errorMembers3.membersData.IsSuccess = false;
                        errorMembers3.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                        errorMembers3.membersData.Error = errorMessage;
                        yakeenProccess.errorMembers = errorMembers3;
                        yakeenProccess.Status = false;
                    }

                }
                catch (Exception e3)
                {
                    ErrorMembers errorMembers3 = new ErrorMembers();
                    errorMembers3.dependMember = new List<ErrorsDependent>();
                    errorMembers3.membersData = new Princible();
                    ErrorsDependent data3 = new ErrorsDependent();
                    errorMembers3.membersData.NationalId = mainMemberInfo.NationalID;
                    errorMembers3.membersData.IsSuccess = false;
                    errorMembers3.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                    errorMembers3.membersData.Error = e3.Message;
                    yakeenProccess.errorMembers = errorMembers3;
                    yakeenProccess.Status = false;
                }
            }
            return yakeenProccess;
        }

        private static YakeenProccess OfflineYakeen(MainMemberInfo mainMemberInfo, IBusiness business, AppSettings Configurations)
        {
            YakeenProccess yakeenProccess = new YakeenProccess();
            Dates dates = new Dates();
            string Date = mainMemberInfo.HijriDate;
            if (Date.Length <= 6)
            {
                Date = "0" + Date;
            }
            try
            {
                Members ObjMem = new Members();
                ObjMem.membersData = new MembersData();
                ObjMem.membersData.MainMember = new Subjects();
                NationalityMapping nationality = business.GetEskaNationality(0);
                ObjMem.membersData.MainMember.Name = mainMemberInfo.NationalID;
                ObjMem.membersData.MainMember.DateOfBirth = ConvertDate(mainMemberInfo.HijriDate);
                ObjMem.membersData.MainMember.Gender = mainMemberInfo.Gender;
                ObjMem.membersData.MainMember.MartialStatus = mainMemberInfo.MartialStatus;
                ObjMem.membersData.MainMember.Age = Utilities.AgeCalculation(ObjMem.membersData.MainMember.DateOfBirth.Value);
                ObjMem.membersData.MainMember.Occupation = Configurations.SAUDIOCCUPATION;
                ObjMem.membersData.MainMember.NationalityCode = Configurations.SAUDINATIONALITY;
                ObjMem.membersData.MainMember.PassportNo = mainMemberInfo.NationalID;
                ObjMem.membersData.MainMember.NationalId = mainMemberInfo.NationalID;
                ObjMem.membersData.MainMember.ClassId = nationality.ClassId;
                ObjMem.membersData.MainMember.Relation = mainMemberInfo.Relation;
                ObjMem.membersData.MainMember.Princible = mainMemberInfo.Sponsor;
                ObjMem.membersData.OccupationName = Configurations.SAUDIOCCUPATION;
                ObjMem.membersData.NationalityAr = Configurations.SAUDINATIONALITY;
                ObjMem.membersData.NationalityEn = Configurations.SAUDINATIONALITY;
                yakeenProccess.membersData = ObjMem.membersData;
                yakeenProccess.Status = true;
            }
            catch (Exception e)
            {
                ErrorMembers errorMembers = new ErrorMembers();
                errorMembers.dependMember = new List<ErrorsDependent>();
                errorMembers.membersData = new Princible();
                ErrorsDependent data = new ErrorsDependent();
                errorMembers.membersData.NationalId = mainMemberInfo.NationalID;
                errorMembers.membersData.IsSuccess = false;
                errorMembers.membersData.DateOfBirth = mainMemberInfo.HijriDate;
                errorMembers.membersData.Error = e.Message;
                yakeenProccess.errorMembers = errorMembers;
                yakeenProccess.Status = false;
            }
            return yakeenProccess;
        }

        public static DateTime ConvertDate(string dr)
        {
            try
            {
                try
                {
                    return DateTime.ParseExact(dr, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    try
                    {
                        return Convert.ToDateTime(dr);
                    }
                    catch (Exception)
                    {
                        return DateTime.ParseExact(dr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    return DateTime.ParseExact(dr, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    return DateTime.ParseExact(dr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }

        public static ValidationMembers FillYakeenTemplate(List<ExcelMembers> lsMembers, AppSettings Configurations, IBusiness business)
        {
            ValidationMembers validationMembers = new ValidationMembers();
            validationMembers.lsError = new List<ErrorMembers>();
            validationMembers.LsSuccessMembers = new List<Members>();
            YakeenProccess yakeenProccess = new YakeenProccess();
            foreach (ExcelMembers Member in lsMembers)
            {
                YakeenMembers yakeenLocal = business.getYakeenMembers(Member.memberInfo.NationalID, Member.memberInfo.Sponsor);
                Members ObjMem = new Members();
                ObjMem.membersData = new MembersData();
                ObjMem.membersData.MainMember = new Subjects();
                if (yakeenLocal == null || yakeenLocal.Members == null)
                {
                    continue;
                }
                NationalityMapping nationality = business.GetEskaNationalityByEska(yakeenLocal.Members.Nationality);
                ObjMem.membersData.MainMember.Name = yakeenLocal.Members.Name;
                ObjMem.membersData.MainMember.DateOfBirth = yakeenLocal.Members.DateOfBirth;
                ObjMem.membersData.MainMember.Gender = yakeenLocal.Members.Gender;
                ObjMem.membersData.MainMember.MartialStatus = yakeenLocal.Members.MartialStatus;
                ObjMem.membersData.MainMember.Age = Utilities.AgeCalculation(yakeenLocal.Members.DateOfBirth.Value);
                ObjMem.membersData.MainMember.Occupation = yakeenLocal.Members.Occupation.ToString();
                ObjMem.membersData.MainMember.NationalityCode = yakeenLocal.Members.Nationality;
                ObjMem.membersData.MainMember.PassportNo = Member.memberInfo.NationalID;
                ObjMem.membersData.MainMember.NationalId = Member.memberInfo.NationalID;
                ObjMem.membersData.MainMember.Princible = Member.memberInfo.Sponsor;
                ObjMem.membersData.MainMember.Relation = Member.memberInfo.Relation;
                ObjMem.membersData.OccupationName = yakeenLocal.Members.Occupation.ToString();
                ObjMem.membersData.NationalityAr = nationality.NationalityNameAr;
                ObjMem.membersData.NationalityEn = nationality.NationalityNameEn;
                ObjMem.membersData.MainMember.ClassId = nationality.ClassId;
                foreach (MainMemberInfo item in Member.dependent)
                {
                    YakeenLogsMember dependent = yakeenLocal.Dependent.Where((YakeenLogsMember p) => p.NationalId == item.NationalID && p.Sponsor == item.Sponsor).FirstOrDefault();
                    if (dependent != null)
                    {
                        MembersData membersData = new MembersData();
                        membersData.MainMember = new Subjects();
                        nationality = business.GetEskaNationalityByEska(dependent.Nationality);
                        membersData.MainMember.Name = dependent.Name;
                        membersData.MainMember.DateOfBirth = dependent.DateOfBirth;
                        membersData.MainMember.Gender = dependent.Gender;
                        membersData.MainMember.MartialStatus = dependent.MartialStatus;
                        membersData.MainMember.ClassId = nationality.ClassId;
                        membersData.MainMember.Age = Utilities.AgeCalculation(dependent.DateOfBirth.Value);
                        membersData.MainMember.Occupation = dependent.Occupation.ToString();
                        membersData.MainMember.NationalityCode = Configurations.SAUDINATIONALITY;
                        membersData.MainMember.PassportNo = dependent.NationalId;
                        membersData.MainMember.NationalId = dependent.NationalId;
                        membersData.MainMember.Princible = dependent.Sponsor;
                        membersData.MainMember.Relation = dependent.Relation;
                        membersData.OccupationName = yakeenLocal.Members.Occupation.ToString();
                        membersData.NationalityAr = Configurations.SAUDINATIONALITY;
                        membersData.NationalityEn = Configurations.SAUDINATIONALITY;
                        ObjMem.dependMember.Add(membersData);
                    }
                }
                validationMembers.LsSuccessMembers.Add(ObjMem);
            }
            return validationMembers;
        }
    }
}
