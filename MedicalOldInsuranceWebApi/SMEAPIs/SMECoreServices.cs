using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.Protocols;
using System.Net.Http.Headers;
using System.Text;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process.Approvals;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.Authentications;
using CORE.DTOs.Business;
using CORE.Interfaces;
using CORE.TablesObjects;
using DataAccessLayer;
using DataAccessLayer.Oracle.StaticDetails;
using Domain.Models;
using EskaPolicies;
using InsuranceAPIs.API;
using InsuranceAPIs.Logger;
using InsuranceAPIs.Models;
using InsuranceAPIs.Models.Configuration_Objects;
using InsuranceAPIs.Models.SMEAPIs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using Service.Common;
using Service.Interfaces;
using ServiceReference1;
using static ServiceReference1.SponsorDetails;

namespace InsuranceAPIs.SMEAPIs
{
    public class SMECoreServices
    {
        private readonly IBusiness _Business;
        private readonly IUserManagment _User;

        private readonly AppSettings _appSettings;

        public static IWebHostEnvironment? _environment;
        private readonly ITracker _tracker;

        private readonly IWSCoreService _CoreServices;

        private readonly IProcess _process;

        public readonly IConfiguration configuration;

        public SMECoreServices(AppSettings appSettings, IWebHostEnvironment environment, IBusiness svcBus, ITracker tracker, IWSCoreService wSCoreService, IProcess process, IUserManagment user, IConfiguration configuration)
        {
            _environment = environment;
            _appSettings = appSettings;
            _Business = svcBus;
            _tracker = tracker;
            _CoreServices = wSCoreService;
            _process = process;
            _User = user;
            this.configuration = configuration;
        }
        public PolicyHeaderResponse CreatePolicyHeader(int Id)
        {

            List<PolicyHeaderResponse> policyHeaderResponses = new List<PolicyHeaderResponse>();
            PolicyHeaderResponse policyHeaderResponse = new PolicyHeaderResponse();
            InsuranceAPIs.Models.SMEAPIs.StatusCT statusCT = new InsuranceAPIs.Models.SMEAPIs.StatusCT();
            CRDetails check = new CRDetails();
            try
            {
                List<Production> Policies = new List<Production>();
                //Policies = ((!Id.HasValue) ? _Business.LoadPendingForSyncProduction() : _Business.LoadProductionById(Id.Value, Eska: true));
                Policies = _Business.LoadProductionById(Id, Eska: true);
                if (Policies != null && Policies.Count > 0)
                {
                    PolicyHolders PolicyHolder = _Business.LoadPolicyHolders(Convert.ToInt32(Policies[0].CustomerId));
                    Types UserType = _User.getTypeUser(Convert.ToInt32(Policies[0].CreatedBy));
                    Users UserInfo = _User.GetUser(Convert.ToInt32(Policies[0].CreatedBy));
                    check = _Business.LoadCRInfo(PolicyHolder.CommercialNo);
                    t_Yakeen_AddressInfo yakeen_AddressInfo = _Business.GetYakeen_AddressInfo(Convert.ToInt64(PolicyHolder.CommercialNo));
                    if (PolicyHolder != null)
                    {
                        string token = "Bearer " + GenerateToken();
                        if (!Policies[0].EndosmentType.HasValue)
                        {
                            PolicyHeaderRequest policyHeaderRequest = new PolicyHeaderRequest();
                            //new Case                            
                            policyHeaderRequest = PrepPolicyHeaderPayload(Id, Policies[0], PolicyHolder, UserType, UserInfo, check, yakeen_AddressInfo);
                            policyHeaderResponses = ApiCall.ExcutePostAPI<List<PolicyHeaderResponse>>(policyHeaderRequest, "PolicyHeaderCreation", _appSettings.SMEAPIConfig.URL, token, "Authorization");
                        }
                        else
                        {

                            //Endorsment case

                            Production orginal = _Business.LoadDocument(null, Convert.ToInt32(Policies[0].PolicyId.Value), 1);

                            PolicyEndoHeaderRequest policyEndoHeaderRequest = new PolicyEndoHeaderRequest();
                            policyEndoHeaderRequest = PrepPolicyEndoHeaderPayload(Id, Policies[0], PolicyHolder, UserType, UserInfo, orginal);
                            policyHeaderResponses = ApiCall.ExcutePostAPI<List<PolicyHeaderResponse>>(policyEndoHeaderRequest, "PolicyEndoHeaderCreation", _appSettings.SMEAPIConfig.URL, token, "Authorization");

                        }
                        if (policyHeaderResponses != null && policyHeaderResponses.Count > 0 && policyHeaderResponses[0].statusCT != null)
                        {
                            if (policyHeaderResponses[0].statusCT.statusCode == 200)
                            {
                                policyHeaderResponse = policyHeaderResponses[0];
                                PolicyHolder.EskaId = !Policies[0].EndosmentType.HasValue ? policyHeaderResponses[0].policyInfo.policyId : policyHeaderResponses[0].policyEndoInfo.policyId;
                                _Business.InsertUpdatePolicyHolder(PolicyHolder);

                                Policies[0].PushToEska = 1;
                                Policies[0].EskaId = !Policies[0].EndosmentType.HasValue ? policyHeaderResponses[0].policyInfo.policyId : policyHeaderResponses[0].policyEndoInfo.policyId;
                                Policies[0].EskaSegment = !Policies[0].EndosmentType.HasValue ? policyHeaderResponses[0].policyInfo.sEGMENT_CODE : policyHeaderResponses[0].policyEndoInfo.sEGMENT_CODE;
                                _Business.InsertUpdateProduction(Policies[0]);
                            }
                            else
                            {
                                policyHeaderResponse = policyHeaderResponses[0];
                                Policies[0].EskaId = !Policies[0].EndosmentType.HasValue ? policyHeaderResponses[0].policyInfo.policyId : policyHeaderResponses[0].policyEndoInfo.policyId;
                                Policies[0].EskaSegment = !Policies[0].EndosmentType.HasValue ? policyHeaderResponses[0].policyInfo.sEGMENT_CODE : policyHeaderResponses[0].policyEndoInfo.sEGMENT_CODE;
                                _Business.InsertUpdateProduction(Policies[0]);
                            }
                            //else
                            //{
                            //statusCT.statusCode = policyHeaderResponses[0].statusCT.statusCode;
                            //statusCT.reason = policyHeaderResponses[0].statusCT.reason;
                            //statusCT.reasonDate = policyHeaderResponses[0].statusCT.reasonDate;
                            //policyHeaderResponse.statusCT = statusCT;
                            //}
                        }
                        else
                        {
                            statusCT.statusCode = 500;
                            statusCT.reason = "SME PHC: No Response from service";
                            statusCT.reasonDate = DateTime.Now;
                            policyHeaderResponse.statusCT = statusCT;
                        }
                    }
                }
                else
                {
                    statusCT.statusCode = 500;
                    statusCT.reasonDate = DateTime.Now;
                    statusCT.reason = "SME PHC: Error Occured";
                    policyHeaderResponse.statusCT = statusCT;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, Id.ToString(), string.Empty, "CreatePolicyHeader");
                statusCT.statusCode = 500;
                statusCT.reason = "SME PHC: " + ex.Message;
                statusCT.reasonDate = DateTime.Now;
                policyHeaderResponse.statusCT = statusCT;
            }
            return policyHeaderResponse;
        }

        private PolicyHeaderRequest PrepPolicyHeaderPayload(int Id, Production policy, PolicyHolders PolicyHolder, Types UserType, Users UserInfo, CRDetails cRDetails, t_Yakeen_AddressInfo yakeen_AddressInfo)
        {
            PolicyHeaderRequest policyHeaderRequest = new PolicyHeaderRequest();
            policyHeaderRequest.memberSaveDatas = new List<MemberSaveData>();
            //policyHeaderRequest.iSICActivities = new List<ISICActivity>();
            List<ISICActivity> iSICActivities = new List<ISICActivity>();
            //List<DeclarationQuestion> declarationQuestions = new List<DeclarationQuestion>();
            //List<Production> Policies = new List<Production>();
            AddressDetails addressDetails = new AddressDetails();
            try
            {
                policyHeaderRequest.referenceId = policy.Id;
                policyHeaderRequest.channelID = 1;
                policyHeaderRequest.policyEffectiveDate = policy.EffectiveDate.ToString("yyyy-MM-dd");
                policyHeaderRequest.agentId = (int)UserInfo.EskaId;
                policyHeaderRequest.agentBusinesType = (int)UserType.UserBusinessType;
                policyHeaderRequest.policyHolderNameAr = PolicyHolder.Name;
                policyHeaderRequest.policyHolderNameEn = PolicyHolder.Name;
                policyHeaderRequest.policyHolderNationality = "SA";
                policyHeaderRequest.policyHolderMobileNumber = PolicyHolder.MobileNo;
                policyHeaderRequest.policyHolderId = PolicyHolder.CommercialNo;
                policyHeaderRequest.createdBy = policy.CreatedBy;
                policyHeaderRequest.entityType = 1;
                //policyHeaderRequest.entityBusinessType = Convert.ToInt32(cRDetails.BUSINESSTYPE_ID);
                if (cRDetails != null)
                {
                    if (!string.IsNullOrEmpty(cRDetails.BUSINESSTYPE_ID))
                    {
                        policyHeaderRequest.entityBusinessType = Convert.ToInt32(cRDetails.BUSINESSTYPE_ID);
                    }
                    if (!string.IsNullOrEmpty(cRDetails.ISSUEDATE))
                    {
                        policyHeaderRequest.entityCRIssueDate = Convert.ToDateTime(cRDetails.ISSUEDATE).ToString("yyyy-MM-dd");
                    }
                    //if (!string.IsNullOrEmpty(cRDetails.EXPIRYDATE))
                    //{
                    //    policyHeaderRequest.entityCRExpiryDate = Convert.ToDateTime(cRDetails.EXPIRYDATE).ToString("yyyy-MM-dd");
                    //}
                    if (!string.IsNullOrEmpty(cRDetails.LOCATION_NAME))
                    {
                        policyHeaderRequest.entityCRCity = cRDetails.LOCATION_NAME; //"الجبيل";
                    }
                }
                policyHeaderRequest.entityClassification = 1;
                policyHeaderRequest.entityRevenue = 0;
                //policyHeaderRequest.entityCRIssueDate = DateTime.Now.ToString("yyyy-MM-dd");
                //policyHeaderRequest.entityCRExpiryDate = policy.ExpiryDate.ToString("yyyy-MM-dd");
                //policyHeaderRequest.entityCRIssueDate = Convert.ToDateTime(cRDetails.ISSUEDATE).ToString("yyyy-MM-dd");
                //policyHeaderRequest.entityCRExpiryDate = Convert.ToDateTime(cRDetails.EXPIRYDATE).ToString("yyyy-MM-dd");
                //policyHeaderRequest.entityCRCity = cRDetails.LOCATION_NAME; //"الجبيل";

                //cRDetails
                if (cRDetails != null)
                {
                    iSICActivities.Add(new ISICActivity
                    {
                        isicCode = Convert.ToInt32(cRDetails.ACTIVITY_ISIC_ID), // 492300,
                        isicName = cRDetails.ACTIVITY_ISIC_NAME,//"النقل البري للبضائع",
                        isicNameEN = cRDetails.ACTIVITY_ISIC_NAME_EN //"Freight transport by road"
                    });
                }
                if (yakeen_AddressInfo != null)
                {
                    addressDetails.buildingNumber = yakeen_AddressInfo.BUILDING_NUMBER.ToString();
                    addressDetails.street = yakeen_AddressInfo.STREET_NAME;
                    addressDetails.city = yakeen_AddressInfo.CITY;
                    addressDetails.postCode = yakeen_AddressInfo.POST_CODE.ToString();
                    addressDetails.additionalNumber = yakeen_AddressInfo.ADDITIONAL_NUMBER.ToString();
                }
                else
                {
                    addressDetails.buildingNumber = "1234";
                    addressDetails.street = "1234";
                    addressDetails.city = "Jeddah";
                    addressDetails.postCode = "1234";
                    addressDetails.additionalNumber = "1234";
                }

                policyHeaderRequest.iSICActivities = iSICActivities;
                policyHeaderRequest.addressDetails = addressDetails;

                List<Subjects> Members = _Business.LoadMemberBusiness(policy.Id, null);

                foreach (Subjects member in Members)
                {
                    MemberSaveData memberSaveData = new MemberSaveData();
                    MemberDeclaration memberDeclaration = new MemberDeclaration();
                    NationalityMapping nationalityMapping = new NationalityMapping();

                    nationalityMapping = _Business.GetEskaNationalityByEska(member.NationalityCode);

                    memberSaveData.nationalId = member.NationalId;
                    memberSaveData.relationTypeId = (int)member.Relation;
                    memberSaveData.sponsorCRNo = member.Princible;
                    memberSaveData.memberName = member.Name;
                    memberSaveData.nationalityCode = nationalityMapping.Id.ToString();
                    memberSaveData.dateOfBirth = Convert.ToDateTime(member.DateOfBirth).ToString("yyyy-MM-dd"); // "1972-01-01";
                    memberSaveData.maritalStatus = (int)member.MartialStatus;
                    memberSaveData.occupation = !string.IsNullOrEmpty(member.Occupation) ? Convert.ToInt32(member.Occupation) : 0;
                    memberSaveData.genderCode = (int)member.Gender;
                    memberSaveData.additionalPremium = member.AdditionalPremium != null ? (double)member.AdditionalPremium : 0;
                    switch ((int)member.InsuranceClassCode)
                    {
                        case 2:
                            memberSaveData.memberInsuranceClass = 1;
                            break;
                        case 3:
                            memberSaveData.memberInsuranceClass = 2;
                            break;
                        case 4:
                            memberSaveData.memberInsuranceClass = 3;
                            break;
                        default:
                            break;
                    }
                    //(int)member.InsuranceClassCode;
                    DateTime ExpiryIdentity = DateTime.Now.AddYears(1);
                    if (member.IdentityExpiryDate != null)
                    {
                        ExpiryIdentity = Utilities.ConvertDate(member.IdentityExpiryDate);
                    }
                    memberSaveData.identityExpiry = ExpiryIdentity.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"); //"2025-02-07T13:36:22.840Z",
                    MembersDeclarations declaration = _Business.LoadDeclarationByMember(member.Id);
                    decimal LoadingAmt = default(decimal);
                    if (declaration != null && declaration.Id > 0)
                    {
                        memberSaveData.isDeclaration = true;
                        memberDeclaration.Height = !string.IsNullOrEmpty(declaration.Height) ? Convert.ToInt32(declaration.Height) : 0;
                        memberDeclaration.Weight = !string.IsNullOrEmpty(declaration.Weight) ? Convert.ToInt32(declaration.Weight) : 0;
                        memberDeclaration.PregnantStatus = null;
                        memberDeclaration.ExpectedDeliveryDate = null;
                        List<DeclarationQuestion> declarationQuestions = new List<DeclarationQuestion>();

                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 1,
                            QuestionAnswer = declaration.QuestionOne
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 2,
                            QuestionAnswer = declaration.QuestionTwo,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 3,
                            QuestionAnswer = declaration.QuestionThree,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 4,
                            QuestionAnswer = declaration.QuestionFour,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 5,
                            QuestionAnswer = declaration.QuestionFive,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 6,
                            QuestionAnswer = declaration.QuestionSix,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 7,
                            QuestionAnswer = (bool)declaration.QuestionSeven,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 8,
                            QuestionAnswer = (bool)declaration.QuestionEight,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 9,
                            QuestionAnswer = (bool)declaration.QuestionNine
                        });

                        memberDeclaration.DeclarationQuestions = declarationQuestions;
                        memberSaveData.memberDeclaration = memberDeclaration;
                    }
                    else
                    {
                        memberSaveData.isDeclaration = false;
                    }
                    policyHeaderRequest.memberSaveDatas.Add(memberSaveData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return policyHeaderRequest;
        }
        private string GenerateToken()
        {
            GenerateTokenResponse generateTokenResponse = new GenerateTokenResponse();
            try
            {
                string GenerateTokenRequest = _appSettings.SMEAPIConfig.ApiKey;

                generateTokenResponse = ApiCall.ExcuteGetAPISME<GenerateTokenResponse>(GenerateTokenRequest, _appSettings.SMEAPIConfig.URL, "GenerateToken", null, null);
                return generateTokenResponse.token;
            }
            catch (Exception ex)
            {
                return "";
                //throw;
            }
        }

        private PolicyEndoHeaderRequest PrepPolicyEndoHeaderPayload(int Id, Production policy, PolicyHolders PolicyHolder, Types UserType, Users UserInfo, Production original)
        {
            PolicyEndoHeaderRequest policyEndoHeaderRequest = new PolicyEndoHeaderRequest();
            policyEndoHeaderRequest.memberSaveDatas = new List<MemberSaveData>();
            try
            {
                policyEndoHeaderRequest.referenceId = policy.Id;
                policyEndoHeaderRequest.endorsementEffectiveDate = policy.EffectiveDate.ToString("yyyy-MM-dd");
                policyEndoHeaderRequest.agentId = (int)UserInfo.EskaId;
                policyEndoHeaderRequest.agentBusinesType = (int)UserType.UserBusinessType;
                policyEndoHeaderRequest.policyId = (int)original.EskaId;
                policyEndoHeaderRequest.segmentCode = original.EskaSegment;
                policyEndoHeaderRequest.createdBy = policy.CreatedBy;

                List<Subjects> Members = _Business.LoadMemberBusiness(policy.Id, null);
                foreach (Subjects member in Members)
                {
                    MemberSaveData memberSaveData = new MemberSaveData();
                    MemberDeclaration memberDeclaration = new MemberDeclaration();
                    NationalityMapping nationalityMapping = new NationalityMapping();

                    nationalityMapping = _Business.GetEskaNationalityByEska(member.NationalityCode);

                    memberSaveData.nationalId = member.NationalId;
                    memberSaveData.relationTypeId = (int)member.Relation;
                    memberSaveData.sponsorCRNo = member.Princible;
                    memberSaveData.memberName = member.Name;
                    memberSaveData.nationalityCode = nationalityMapping.Id.ToString();
                    memberSaveData.dateOfBirth = Convert.ToDateTime(member.DateOfBirth).ToString("yyyy-MM-dd"); // "1972-01-01";
                    memberSaveData.maritalStatus = (int)member.MartialStatus;
                    memberSaveData.occupation = !string.IsNullOrEmpty(member.Occupation) ? Convert.ToInt32(member.Occupation) : 0;
                    memberSaveData.genderCode = (int)member.Gender;
                    //memberSaveData.memberInsuranceClass = (int)member.InsuranceClassCode;
                    memberSaveData.additionalPremium = member.AdditionalPremium != null ? (double)member.AdditionalPremium : 0;
                    switch ((int)member.InsuranceClassCode)
                    {
                        case 2:
                            memberSaveData.memberInsuranceClass = 1;
                            break;
                        case 3:
                            memberSaveData.memberInsuranceClass = 2;
                            break;
                        case 4:
                            memberSaveData.memberInsuranceClass = 3;
                            break;
                        default:
                            break;
                    }

                    DateTime ExpiryIdentity = DateTime.Now.AddYears(1);
                    if (member.IdentityExpiryDate != null)
                    {
                        ExpiryIdentity = Utilities.ConvertDate(member.IdentityExpiryDate);
                    }
                    memberSaveData.identityExpiry = ExpiryIdentity.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"); //"2025-02-07T13:36:22.840Z",
                    MembersDeclarations declaration = _Business.LoadDeclarationByMember(member.Id);
                    decimal LoadingAmt = default(decimal);
                    if (declaration != null && declaration.Id > 0)
                    {
                        memberSaveData.isDeclaration = true;
                        memberDeclaration.Height = !string.IsNullOrEmpty(declaration.Height) ? Convert.ToInt32(declaration.Height) : 0;
                        memberDeclaration.Weight = !string.IsNullOrEmpty(declaration.Weight) ? Convert.ToInt32(declaration.Weight) : 0;
                        memberDeclaration.PregnantStatus = null;
                        memberDeclaration.ExpectedDeliveryDate = null;
                        List<DeclarationQuestion> declarationQuestions = new List<DeclarationQuestion>();
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 1,
                            QuestionAnswer = declaration.QuestionOne
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 2,
                            QuestionAnswer = declaration.QuestionTwo,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 3,
                            QuestionAnswer = declaration.QuestionThree,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 4,
                            QuestionAnswer = declaration.QuestionFour,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 5,
                            QuestionAnswer = declaration.QuestionFive,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 6,
                            QuestionAnswer = declaration.QuestionSix,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 7,
                            QuestionAnswer = (bool)declaration.QuestionSeven,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 8,
                            QuestionAnswer = (bool)declaration.QuestionEight,
                        });
                        declarationQuestions.Add(new DeclarationQuestion
                        {
                            QuestionID = 9,
                            QuestionAnswer = (bool)declaration.QuestionNine
                        });

                        memberDeclaration.DeclarationQuestions = declarationQuestions;
                        memberSaveData.memberDeclaration = memberDeclaration;
                    }
                    else
                    {
                        memberSaveData.isDeclaration = false;
                    }
                    policyEndoHeaderRequest.memberSaveDatas.Add(memberSaveData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return policyEndoHeaderRequest;
        }

        public FinalSaveResponse Post(Production production, PolicyPaymentInput policyPaymentInput)
        {
            List<FinalSaveResponse> finalSaveResponses = new List<FinalSaveResponse>();
            FinalSaveRequest finalSaveRequest = new FinalSaveRequest();
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            try
            {
                finalSaveRequest.referenceId = production.Id.ToString();
                finalSaveRequest.policyId = Convert.ToInt32(production.EskaId);
                finalSaveRequest.policySegment = production.EskaSegment;
                finalSaveRequest.paymentMethod = policyPaymentInput.PaymentMethod;
                finalSaveRequest.paymentBody = policyPaymentInput.PaymentBody;
                finalSaveRequest.vatNumber = policyPaymentInput.VatNumber;
                //finalSaveRequest.idType = Convert.ToInt32(Enum.GetValues(IdType.TINNumber));

                string token = "Bearer " + GenerateToken();
                finalSaveResponses = ApiCall.ExcutePostAPI<List<FinalSaveResponse>>(finalSaveRequest, "FinalSave", _appSettings.SMEAPIConfig.URL, token, "Authorization");
                if (finalSaveResponses != null && finalSaveResponses.Count > 0)
                {
                    finalSaveResponse = finalSaveResponses[0];
                }
                else
                {
                    finalSaveResponse.status = false;
                    finalSaveResponse.errorMessage = "No Response from service";
                }
            }
            catch (Exception ex)
            {
                finalSaveResponse.status = false;
                finalSaveResponse.errorMessage = ex.Message;
            }
            return finalSaveResponse;
        }
        public FinalSaveResponse PostToBank(Production production, PolicyBankPaymentInput policyPaymentInput)
        {
            List<FinalSaveResponse> finalSaveResponses = new List<FinalSaveResponse>();
            FinalSaveRequest finalSaveRequest = new FinalSaveRequest();
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            var policyholder = _Business.LoadPolicyHolders(Convert.ToInt32(production.CustomerId));
            try
            {
                PaymentBankBody bankBody = new PaymentBankBody()
                {
                    amount = (production.NetPremium * 100).ToString(),
                    merchant_reference = policyPaymentInput.ReferenceNo,
                    order_description = production.EskaSegment,
                    token_name = "Bank Transfer"
                };

                finalSaveRequest.referenceId = production.Id.ToString();
                finalSaveRequest.policyId = Convert.ToInt32(production.EskaId);
                finalSaveRequest.policySegment = production.EskaSegment;
                finalSaveRequest.paymentMethod = "3";
                finalSaveRequest.paymentBody = JsonConvert.SerializeObject(bankBody);
                finalSaveRequest.vatNumber = policyholder.VatNumber;
                //finalSaveRequest.idType = Convert.ToInt32(Enum.GetValues(IdType.TINNumber));

                string token = "Bearer " + GenerateToken();
                finalSaveResponses = ApiCall.ExcutePostAPI<List<FinalSaveResponse>>(finalSaveRequest, "FinalSave", _appSettings.SMEAPIConfig.URL, token, "Authorization");
                if (finalSaveResponses != null && finalSaveResponses.Count > 0)
                {
                    finalSaveResponse = finalSaveResponses[0];
                    if (finalSaveResponse.status == true)
                    {
                        AddToApprovals approvals = new AddToApprovals()
                        {
                            approvalHistory = new ApprovalHistory()
                            {
                                isSMSSent = true,
                                ApprovalUserId = 1,
                                Attachments = "",
                                Comments = "Bank Transfer",
                                isEmail = true,
                                PolicyId = production.Id,
                                RecievedDate = DateTime.Now,
                                RejectionReason = "",
                                Status = 9,
                                UpdateDate = DateTime.Now,
                                UpdatedBy = 1
                            },
                        };
                        _process.SetApprovalStatus(approvals);
                    }
                }
                else
                {
                    finalSaveResponse.status = false;
                    finalSaveResponse.errorMessage = "No Response from service";
                }
            }
            catch (Exception ex)
            {
                finalSaveResponse.status = false;
                finalSaveResponse.errorMessage = ex.Message;
            }
            return finalSaveResponse;
        }
        public FinalSaveResponse PostToPayfort(Production production, PolicyBankPaymentInput policyPaymentInput)
        {
            List<FinalSaveResponse> finalSaveResponses = new List<FinalSaveResponse>();
            FinalSaveRequest finalSaveRequest = new FinalSaveRequest();
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            var policyholder = _Business.LoadPolicyHolders(Convert.ToInt32(production.CustomerId));
            try
            {
                var response = ApiCall.ExecuteGetApi<PayfortPaymentStatusResponse>("merchantreferene=" + policyPaymentInput.ReferenceNo, _appSettings.PayfortWebhookurl + "ValidateMerchantRef");
                if (response.transaction_status == null)
                {
                    finalSaveResponse.status = false;
                    finalSaveResponse.errorMessage = response.transactionStatus;
                    return finalSaveResponse;
                }
                else if (response.transaction_status == "14")
                {
                    var json = JsonConvert.SerializeObject(response);
                    var jsonObj = JObject.Parse(json);
                    jsonObj["order_description"] = production.EskaSegment;
                    finalSaveRequest.referenceId = production.Id.ToString();
                    finalSaveRequest.policyId = Convert.ToInt32(production.EskaId);
                    finalSaveRequest.policySegment = production.EskaSegment;
                    finalSaveRequest.paymentMethod = "1";
                    finalSaveRequest.paymentBody = json.ToString();
                    finalSaveRequest.vatNumber = policyholder.VatNumber;
                    //finalSaveRequest.idType = Convert.ToInt32(Enum.GetValues(IdType.TINNumber));

                    string token = "Bearer " + GenerateToken();
                    finalSaveResponses = ApiCall.ExcutePostAPI<List<FinalSaveResponse>>(finalSaveRequest, "FinalSave", _appSettings.SMEAPIConfig.URL, token, "Authorization");
                    if (finalSaveResponses != null && finalSaveResponses.Count > 0)
                    {
                        finalSaveResponse = finalSaveResponses[0];
                        if (finalSaveResponse.status == true)
                        {
                            AddToApprovals approvals = new AddToApprovals()
                            {
                                approvalHistory = new ApprovalHistory()
                                {
                                    isSMSSent = true,
                                    ApprovalUserId = 1,
                                    Attachments = "",
                                    Comments = "Card Payment",
                                    isEmail = true,
                                    PolicyId = production.Id,
                                    RecievedDate = DateTime.Now,
                                    RejectionReason = "",
                                    Status = 9,
                                    UpdateDate = DateTime.Now,
                                    UpdatedBy = 1
                                },
                            };
                            _process.SetApprovalStatus(approvals);
                            PaymentLog log = new PaymentLog()
                            {
                                CardDetails = response.authorized_amount,
                                CardType = "MADA",
                                MerchantReference = response.merchant_reference,
                                PayfortId = response.fort_id,
                                PayfortStatus = "Success , 14000",
                                PolicyId = production.Id,
                                PolicyNo = production.EskaSegment,
                                ProductName = "Medical",
                                Status = true,
                                TransactionDate = DateTime.Now,
                                TransactionType = 1
                            };
                            _process.SavePaymentLog(log);
                        }
                    }
                    else
                    {
                        finalSaveResponse.status = false;
                        finalSaveResponse.errorMessage = "No Response from service";
                    }
                }
            }
            catch (Exception ex)
            {
                finalSaveResponse.status = false;
                finalSaveResponse.errorMessage = ex.Message;
            }
            return finalSaveResponse;
        }

        public DeletePolicyResponse DeletePolicy(string Id)
        {
            DeletePolicyResponse deletePolicyResponse = new DeletePolicyResponse();
            try
            {
                string token = "Bearer " + GenerateToken();
                //string GenerateTokenRequest = _appSettings.SMEAPIConfig.ApiKey;

                deletePolicyResponse = ApiCall.ExcuteGetAPISME<DeletePolicyResponse>("/" + Id, _appSettings.SMEAPIConfig.URL, "Policy/Delete", token, "Authorization");
                return deletePolicyResponse;
            }
            catch (Exception ex)
            {
                return null;
                //throw;
            }
        }


        public PentaCreateQuotationRes CreatePentaQuotation(int Id)
        {

            List<PolicyHeaderResponse> policyHeaderResponses = new List<PolicyHeaderResponse>();
            PolicyHeaderResponse policyHeaderResponse = new PolicyHeaderResponse();
            InsuranceAPIs.Models.SMEAPIs.StatusCT statusCT = new InsuranceAPIs.Models.SMEAPIs.StatusCT();
            CRDetails check = new CRDetails();
            PentaCreateQuotationReq pentaCreateQuotationReq = new PentaCreateQuotationReq();
            PentaCreateQuotationRes pentaCreateQuotationRes = new PentaCreateQuotationRes();
            CreateProposalRequest createProposalRequest = new CreateProposalRequest();
            CreateProposalResp objCreateProposalResp = new CreateProposalResp();
            IssuePolicyResponse issuePolicyResponse = new IssuePolicyResponse();
            try
            {
                List<Production> Policies = new List<Production>();
                Policies = _Business.LoadProductionById(Id, Eska: true);
                if (Policies != null && Policies.Count > 0)
                {
                    PolicyHolders PolicyHolder = _Business.LoadPolicyHolders(Convert.ToInt32(Policies[0].CustomerId));
                    Types UserType = _User.getTypeUser(Convert.ToInt32(Policies[0].CreatedBy));
                    Users UserInfo = _User.GetUser(Convert.ToInt32(Policies[0].CreatedBy));
                    check = _Business.LoadCRInfo(PolicyHolder.CommercialNo);
                    t_Yakeen_AddressInfo yakeen_AddressInfo = _Business.GetYakeen_AddressInfo(Convert.ToInt64(PolicyHolder.CommercialNo));
                    if (PolicyHolder != null)
                    {

                        if (!Policies[0].EndosmentType.HasValue)
                        {


                            pentaCreateQuotationReq = PrepQuotationPayload(Id, Policies[0], PolicyHolder, UserType, UserInfo, check, yakeen_AddressInfo);
                            string quotationrequest = JsonConvert.SerializeObject(pentaCreateQuotationReq);
                            pentaCreateQuotationRes = ApiCall.ExcutePentaAPI<PentaCreateQuotationRes>(pentaCreateQuotationReq, "create-quotation", _appSettings.pentadetails.pentaApiUrl, _appSettings.pentadetails.PentaTokenUrl, _appSettings.pentadetails.Username, _appSettings.pentadetails.Password);
                            string Pentaresp = JsonConvert.SerializeObject(pentaCreateQuotationRes);
                            ErrorHandler.WriteLog("Penta Quotation Request : ", "Log1", "SMECoreServices", "CreatePentaQuotation");
                            //if (pentaCreateQuotationRes != null && pentaCreateQuotationRes.status == true && pentaCreateQuotationRes.errors == null)
                            //{

                            Production production = new Production()
                            {
                                Id = Id

                            };
                            if (pentaCreateQuotationRes != null && pentaCreateQuotationRes.status == true)
                            {

                                _Business.UpdateEskaid(Id, pentaCreateQuotationRes.returnValue.referenceQuotationNo);
                            }

                            string status = (pentaCreateQuotationRes != null
                                     && pentaCreateQuotationRes.status == true)
                                     ? "QuoteCreated"
                                     : "QuoteFailed";

                            string quotationNo = pentaCreateQuotationRes?.returnValue?.quotationNo ?? null;
                            string QuotationNumber = pentaCreateQuotationRes?.returnValue?.referenceQuotationNo ?? null;
                            PentaDetail PentaDetails = new PentaDetail()
                            {
                                QuoteId = PolicyHolder.Id.ToString(),
                                IdNumber = PolicyHolder.CommercialNo,
                                SegmentCode = "",
                                CreateQuotationReq = quotationrequest,
                                CreateQuotationResp = Pentaresp,
                                Status = status,
                                CreatedBy = Policies[0].CreatedBy,
                                CreatedDate = DateTime.Now,
                                UpdatedDate = DateTime.Now,
                                QuotationNumber = QuotationNumber,
                                QuoteNo = quotationNo


                            };
                            //_Business.PentaDeatilsGet(PentaDetails);
                            using (var context = new testDBContext())
                            {
                                var quoteId = PentaDetails.QuoteId;
                                var idNumber = PentaDetails.QuotationNumber;

                                var existing = context.PentaDetails
                                                      .FirstOrDefault(p => p.QuoteId == quoteId
                                                                        && p.QuotationNumber == idNumber);

                                if (existing != null)
                                {
                                    // Record exists → update the fields
                                    existing.SegmentCode = "";
                                    existing.CreateQuotationReq = PentaDetails.CreateQuotationReq;
                                    existing.CreateQuotationResp = PentaDetails.CreateQuotationResp;
                                    existing.IssuePolicyReq = PentaDetails.IssuePolicyReq;
                                    existing.IssuePolicyResp = PentaDetails.IssuePolicyResp;
                                    existing.Status = PentaDetails.Status;
                                    existing.UpdatedDate = DateTime.Now;
                                    existing.CreatedBy = PentaDetails.CreatedBy; // if you want to update
                                    existing.QuotationNumber = PentaDetails.QuotationNumber;
                                    context.PentaDetails.Update(existing);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    // Record does not exist → insert
                                    context.PentaDetails.Add(PentaDetails);
                                    context.SaveChanges();
                                }

                            }


                            ErrorHandler.WriteLog("Penta Quotation Request : ", "Log2", "SMECoreServices", "CreatePentaQuotation");
                            //context.SaveChanges(); // Save changes to DB                   // Save to DB
                            // }

                        }

                    }
                }
                else
                {
                    statusCT.statusCode = 500;
                    statusCT.reasonDate = DateTime.Now;
                    statusCT.reason = "SME PHC: Error Occured";
                    policyHeaderResponse.statusCT = statusCT;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, Id.ToString(), string.Empty, "CreatePentaQuotation");
                statusCT.statusCode = 500;
                statusCT.reason = "SME PHC: " + ex.Message;
                statusCT.reasonDate = DateTime.Now;
                policyHeaderResponse.statusCT = statusCT;
            }
            return pentaCreateQuotationRes;
        }
        private PentaCreateQuotationReq PrepQuotationPayload(int Id, Production policy, PolicyHolders PolicyHolder, Types UserType, Users UserInfo, CRDetails cRDetails, t_Yakeen_AddressInfo yakeen_AddressInfo)
        {
            PolicyHeaderRequest policyHeaderRequest = new PolicyHeaderRequest();
            policyHeaderRequest.memberSaveDatas = new List<MemberSaveData>();
            List<ISICActivity> iSICActivities = new List<ISICActivity>();
            AddressDetails addressDetails = new AddressDetails();
            PentaCreateQuotationReq pentaCreateQuotationReq = new PentaCreateQuotationReq();
            try
            {
                DataTable dtStaticDetails = GetStaticDetails.GetStaticDetail(1, _appSettings.EskaConnection);

                if (dtStaticDetails != null && dtStaticDetails.Rows.Count > 0)
                {
                    pentaCreateQuotationReq.quotationNo = "";
                    pentaCreateQuotationReq.planCode = dtStaticDetails.Rows[0]["planCode"].ToString();
                    pentaCreateQuotationReq.changePlanFlag = dtStaticDetails.Rows[0]["changePlanFlag"].ToString();
                    pentaCreateQuotationReq.cashBeforeCover = dtStaticDetails.Rows[0]["cashBeforeCover"].ToString();
                    pentaCreateQuotationReq.confirmFlag = dtStaticDetails.Rows[0]["confirmFlag"].ToString();
                    pentaCreateQuotationReq.proposerType = dtStaticDetails.Rows[0]["proposerType"].ToString();
                    pentaCreateQuotationReq.crNumber = PolicyHolder.CommercialNo;
                    pentaCreateQuotationReq.crRegNo = PolicyHolder.CommercialNo;
                    pentaCreateQuotationReq.crName = PolicyHolder.Name;
                    var addressList = new List<CrAddress>();
                    var address = new CrAddress();

                    if (yakeen_AddressInfo != null)
                    {
                        address.addressType = dtStaticDetails.Rows[0]["addressType"].ToString();
                        address.buildingNo = yakeen_AddressInfo.BUILDING_NUMBER;
                        address.street = yakeen_AddressInfo.STREET_NAME;
                        address.district = yakeen_AddressInfo.DISTRICT;
                        address.country = "";
                        address.postCode = yakeen_AddressInfo.POST_CODE.ToString();
                        address.additionalNo = yakeen_AddressInfo.ADDITIONAL_NUMBER;
                        address.isPrimaryAddress = yakeen_AddressInfo.IsPrimaryAddress.ToString();
                        address.yakeenCity = "";
                        address.yakeenDetails = "";

                    }
                    else
                    {
                        address.addressType = dtStaticDetails.Rows[0]["addressType"].ToString();
                        address.buildingNo = Convert.ToInt32(dtStaticDetails.Rows[0]["buildingNo"]);
                        address.street = dtStaticDetails.Rows[0]["street"].ToString();
                        address.district = "";
                        address.country = "";
                        address.city = dtStaticDetails.Rows[0]["city"].ToString();
                        address.postCode = dtStaticDetails.Rows[0]["postCode"].ToString();
                        address.additionalNo = Convert.ToInt32(dtStaticDetails.Rows[0]["additionalNo"]);
                        address.isPrimaryAddress = dtStaticDetails.Rows[0]["isPrimaryAddress"].ToString();
                        address.yakeenCity = "";
                        address.yakeenDetails = "";
                    }
                    addressList.Add(address);
                    pentaCreateQuotationReq.crAddress = addressList;
                    pentaCreateQuotationReq.businessType = "0";
                    pentaCreateQuotationReq.businessDesc = "Testing";
                    pentaCreateQuotationReq.activityId = "";
                    pentaCreateQuotationReq.activityDescEn = "";
                    pentaCreateQuotationReq.activityDescAr = "";
                    pentaCreateQuotationReq.crIssueDate = Convert.ToDateTime(DateTime.Today).ToString("yyyy-MM-dd");
                    pentaCreateQuotationReq.crExpiryDate = Convert.ToDateTime(DateTime.Today.AddYears(1).AddDays(-1)).ToString("yyyy-MM-dd");
                    pentaCreateQuotationReq.companyCode = PolicyHolder.CommercialNo; //doubt
                    pentaCreateQuotationReq.companyBranch = dtStaticDetails.Rows[0]["tpaCompanyBranch"].ToString();
                    pentaCreateQuotationReq.participatingEmployees = 0;
                    pentaCreateQuotationReq.totalEmployees = 0;
                    pentaCreateQuotationReq.introducerCode = "";
                    pentaCreateQuotationReq.tpaCompCode = dtStaticDetails.Rows[0]["tpaCompanyCode"].ToString();
                    pentaCreateQuotationReq.tpaCompBranch = dtStaticDetails.Rows[0]["tpaCompanyBranch"].ToString();
                    pentaCreateQuotationReq.correspondingLanguage = dtStaticDetails.Rows[0]["correspondingLanguage"].ToString();
                    pentaCreateQuotationReq.paymentFrequency = dtStaticDetails.Rows[0]["paymentFrequency"].ToString();
                    pentaCreateQuotationReq.paymentMethod = dtStaticDetails.Rows[0]["paymentMethod"].ToString();
                    pentaCreateQuotationReq.currency = dtStaticDetails.Rows[0]["currency"].ToString();
                    pentaCreateQuotationReq.policyTerm = dtStaticDetails.Rows[0]["policyTerm"].ToString();
                    //pentaCreateQuotationReq.policyEffectiveDate = policy.EffectiveDate.ToString("yyyy-MM-dd");//doubt
                    pentaCreateQuotationReq.policyEffectiveDate = "2025-01-01";//doubt
                    pentaCreateQuotationReq.policyExpiryDate = policy.ExpiryDate.ToString("yyyy-MM-dd");//doubt
                    pentaCreateQuotationReq.backDatedFlag = dtStaticDetails.Rows[0]["backDatedFlag"].ToString();
                    pentaCreateQuotationReq.backDatedReason = "";
                    pentaCreateQuotationReq.headCount = dtStaticDetails.Rows[0]["headCount"].ToString();
                    pentaCreateQuotationReq.experienceSurplus = dtStaticDetails.Rows[0]["experienceSurplus"].ToString();
                    pentaCreateQuotationReq.riskCategory = dtStaticDetails.Rows[0]["riskCategory"].ToString();
                    pentaCreateQuotationReq.policyBranch = dtStaticDetails.Rows[0]["policyBranch"].ToString();
                    pentaCreateQuotationReq.serviceBranch = dtStaticDetails.Rows[0]["policyBranch"].ToString();
                    pentaCreateQuotationReq.ageDefinition = dtStaticDetails.Rows[0]["ageDefinition"].ToString();
                    pentaCreateQuotationReq.multiCompany = dtStaticDetails.Rows[0]["multiCompany"].ToString();
                    pentaCreateQuotationReq.masterCompanyControl = dtStaticDetails.Rows[0]["masterCompanyControl"].ToString();
                    pentaCreateQuotationReq.serviceTaxApplicable = dtStaticDetails.Rows[0]["serviceTaxApplicable"].ToString();
                    pentaCreateQuotationReq.portalUserId = dtStaticDetails.Rows[0]["portalUserId"].ToString();
                    pentaCreateQuotationReq.sourceType = dtStaticDetails.Rows[0]["sourceType"].ToString();
                    pentaCreateQuotationReq.sourceOfBusiness = dtStaticDetails.Rows[0]["sourceOfBusiness"].ToString();

                    var agentDetails = new List<AgentDetails>();
                    var agentDetail = new AgentDetails();
                    //agentDetail.agentNo = dtStaticDetails.Rows[0]["agentCode"].ToString();//need to change the logic 
                    agentDetail.agentNo = "5148";//UserInfo.EskaId.ToString();
                                                 //agentDetail.rank = dtStaticDetails.Rows[0]["rank"].ToString();
                    agentDetail.rank = "50";
                    agentDetail.percent = Convert.ToInt32(dtStaticDetails.Rows[0]["percent"]);
                    agentDetail.commissionType = dtStaticDetails.Rows[0]["commissionType"].ToString();//check what are we passing currently
                    agentDetail.commissionPercent = "8";// dtStaticDetails.Rows[0]["commissionPercent"].ToString();
                    agentDetails.Add(agentDetail);
                    pentaCreateQuotationReq.agentDetails = agentDetails;
                    pentaCreateQuotationReq.sponsorDetails = Preparesponserdetails(policy, PolicyHolder, cRDetails, yakeen_AddressInfo, dtStaticDetails);

                    List<Subjects> Members = _Business.LoadMemberBusiness(policy.Id, null);
                    List<MemberDetails> objMembers = new List<MemberDetails>();
                    foreach (Subjects member in Members)
                    {
                        MemberDetails memberdetails = new MemberDetails();
                        memberdetails.idenCode = "IQA";
                        memberdetails.idenNo = member.NationalId;
                        memberdetails.dateOfBirth = Convert.ToDateTime(member.DateOfBirth).ToString("yyyy-MM-dd");
                        memberdetails.gender = member.Gender.ToString() == "1" ? "M" : "F";
                        memberdetails.name = member.Name;
                        memberdetails.maritalStatus = member.MartialStatus.ToString() == "1" ? "S" : "M";
                        //memberdetails.subPlanCode = dtStaticDetails.Rows[0]["subPlanCode"].ToString();//need to chnage here logic
                        DataTable Nationality = GetStaticDetails.GetTransformData(34, "01", member.NationalityCode, "P_T_NATIONALITY", string.Empty, _appSettings.EskaConnection);
                        if (Nationality != null && Nationality.Rows.Count > 0)
                        {
                            string levelCode = Nationality.Rows[0]["MDM_LVL1_CODE"].ToString();
                        }

                        DataTable dtsubplancod = GetStaticDetails.GetTransformData(33, dtStaticDetails.Rows[0]["planCode"].ToString(), member.InsuranceClassCode.ToString(), "TAMEENI", Nationality.Rows[0]["MDM_LVL1_CODE"].ToString(), _appSettings.EskaConnection);

                        if (dtsubplancod != null && dtsubplancod.Rows.Count > 0)
                        {
                            memberdetails.subPlanCode = dtsubplancod.Rows[0]["MDM_CORE_CODE"].ToString();
                        }
                        else
                        {
                            memberdetails.subPlanCode = dtStaticDetails.Rows[0]["subPlanCode"].ToString();
                        }

                        //memberdetails.subPlanCode = "10121";//need to chnage here logic
                        memberdetails.annualLimitCriteria = "";
                        memberdetails.occupationClass = member.Occupation;
                        //memberdetails.memberEffectiveDate = policy.EffectiveDate.ToString("yyyy-MM-dd");
                        memberdetails.memberEffectiveDate = "2025-01-01";
                        memberdetails.memberExpiryDate = policy.ExpiryDate.ToString("yyyy-MM-dd");
                        memberdetails.employeeId = "0";
                        memberdetails.relation = GetRelation(Convert.ToInt32(member.Relation));

                        DataTable occupation = GetStaticDetails.GetTransformData(5, "01", member.Occupation, "P_TM_OCCUPATION", string.Empty, _appSettings.EskaConnection);
                        if (occupation != null && occupation.Rows.Count > 0)
                        {
                            memberdetails.occupation = occupation.Rows[0]["MDM_CORE_CODE"].ToString();

                        }
                        memberdetails.city = dtStaticDetails.Rows[0]["city"].ToString();//transformation need to use
                        memberdetails.nationality = member.NationalityCode;
                        memberdetails.memberSponsorNo = member.Princible;
                        memberdetails.loadingType = member.AdditionalPremium != 0 ? "P" : "";

                        memberdetails.loading = member.AdditionalPremium != 0 ? Convert.ToInt32(member.AdditionalPremium) : 0;
                        memberdetails.discountType = "";
                        memberdetails.uwQuestions = new UwQuestions[0];
                        memberdetails.documentDetails = new documentDetails[0];

                        var memAddressList = new List<MemberAddressDetails>();
                        var memAddress = new MemberAddressDetails();
                        if (yakeen_AddressInfo != null)
                        {
                            memAddress.addressType = dtStaticDetails.Rows[0]["addressType"].ToString();
                            memAddress.buildingNo = yakeen_AddressInfo.BUILDING_NUMBER;
                            memAddress.street = yakeen_AddressInfo.STREET_NAME;
                            memAddress.district = yakeen_AddressInfo.DISTRICT;
                            DataTable city = GetStaticDetails.GetTransformData(5, "01", yakeen_AddressInfo.CITY, "P_T_CITY", string.Empty, _appSettings.EskaConnection);
                            if (Nationality != null && Nationality.Rows.Count > 0)
                            {
                                memAddress.city = Nationality.Rows[0]["MDM_CORE_CODE"].ToString();
                            }
                            memAddress.country = "";
                            memAddress.postCode = yakeen_AddressInfo.POST_CODE.ToString();
                            memAddress.additionalNo = yakeen_AddressInfo.ADDITIONAL_NUMBER;
                            memAddress.isPrimaryAddress = dtStaticDetails.Rows[0]["isPrimaryAddress"].ToString();
                            memAddress.yakeenCity = "";
                            memAddress.yakeenDetails = "";
                        }
                        else
                        {
                            memAddress.addressType = dtStaticDetails.Rows[0]["addressType"].ToString();
                            memAddress.buildingNo = Convert.ToInt32(dtStaticDetails.Rows[0]["buildingNo"]);
                            memAddress.street = dtStaticDetails.Rows[0]["street"].ToString();
                            memAddress.district = "";
                            memAddress.country = "";
                            memAddress.city = dtStaticDetails.Rows[0]["city"].ToString();
                            memAddress.postCode = dtStaticDetails.Rows[0]["postCode"].ToString();
                            memAddress.additionalNo = Convert.ToInt32(dtStaticDetails.Rows[0]["additionalNo"]);
                            memAddress.isPrimaryAddress = dtStaticDetails.Rows[0]["isPrimaryAddress"].ToString();
                            memAddress.yakeenCity = "";
                            memAddress.yakeenDetails = "";
                        }

                        memAddressList.Add(memAddress);
                        memberdetails.memberAddressDetails = memAddressList;
                        objMembers.Add(memberdetails);

                    }
                    pentaCreateQuotationReq.memberDetails = objMembers;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, "", "", "PrepQuotationPayload");
            }
            return pentaCreateQuotationReq;
        }
        public List<SponsorDetail> Preparesponserdetails(Production policy, PolicyHolders PolicyHolder, CRDetails cRDetails, t_Yakeen_AddressInfo yakeen_AddressInfo, DataTable dtStaticDetails)
        {
            List<SponsorDetail> sponsorDetailList = new List<SponsorDetail>();
            try
            {
                var sponsorDetail = new SponsorDetail();
                //sponsorDetail.crNumber = PolicyHolder.CommercialNo;
                sponsorDetail.crNumber = "1116011191";
                sponsorDetail.crRegNo = PolicyHolder.CommercialNo;
                sponsorDetail.crName = PolicyHolder.Name;
                sponsorDetail.crAddress = new List<CrAddress>();
                var address = new CrAddress();
                if (yakeen_AddressInfo != null)
                {
                    address.addressType = dtStaticDetails.Rows[0]["addressType"].ToString();
                    address.buildingNo = yakeen_AddressInfo.BUILDING_NUMBER;
                    address.street = yakeen_AddressInfo.STREET_NAME;
                    address.district = yakeen_AddressInfo.DISTRICT;
                    address.city = yakeen_AddressInfo.CITY;
                    address.country = "";
                    address.postCode = yakeen_AddressInfo.POST_CODE.ToString();
                    address.additionalNo = yakeen_AddressInfo.ADDITIONAL_NUMBER;
                    address.isPrimaryAddress = yakeen_AddressInfo.IsPrimaryAddress.ToString();
                    address.yakeenCity = "";
                    address.yakeenDetails = "";
                }
                else
                {
                    address.addressType = dtStaticDetails.Rows[0]["addressType"].ToString();
                    address.buildingNo = Convert.ToInt32(dtStaticDetails.Rows[0]["buildingNo"]);
                    address.street = dtStaticDetails.Rows[0]["street"].ToString();
                    address.district = "";
                    address.country = "";
                    address.city = dtStaticDetails.Rows[0]["city"].ToString();
                    address.postCode = dtStaticDetails.Rows[0]["postCode"].ToString();
                    address.additionalNo = Convert.ToInt32(dtStaticDetails.Rows[0]["additionalNo"]);
                    address.isPrimaryAddress = dtStaticDetails.Rows[0]["isPrimaryAddress"].ToString();
                    address.yakeenCity = "";
                    address.yakeenDetails = "";
                }

                sponsorDetail.crAddress.Add(address);
                sponsorDetail.businessType = "0";
                sponsorDetail.businessDesc = "Testing";//need to check
                sponsorDetail.activityId = "";
                sponsorDetail.activityDescEn = "";
                sponsorDetail.activityDescAr = "";
                sponsorDetail.crIssueDate = Convert.ToDateTime(policy.IssueDate).ToString("yyyy-MM-dd");
                sponsorDetail.crExpiryDate = Convert.ToDateTime(policy.ExpiryDate).ToString("yyyy-MM-dd");
                sponsorDetail.sponsorCompanyCode = PolicyHolder.CommercialNo;
                // sponsorDetail.sponsorCompanyBranch = dtStaticDetails.Rows[0]["tpaCompanyBranch"].ToString();
                sponsorDetail.sponsorCompanyBranch = PolicyHolder.CommercialNo;
                sponsorDetail.sponsorServiceTaxApplicable = dtStaticDetails.Rows[0]["serviceTaxApplicable"].ToString();
                sponsorDetail.serviceTaxPercentage = dtStaticDetails.Rows[0]["serviceTaxPercentage"].ToString();
                sponsorDetail.isMasterCompany = dtStaticDetails.Rows[0]["isMasterCompany"].ToString();

                sponsorDetailList.Add(sponsorDetail);

            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, "", "", "Preparesponserdetails");

            }
            return sponsorDetailList;
        }



        public FinalSaveResponse PrepareIssuePolicyRequest(Production policy, PolicyPaymentInput input)
        {
            List<FinalSaveResponse> finalSaveResponses = new List<FinalSaveResponse>();
            FinalSaveRequest finalSaveRequest = new FinalSaveRequest();
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            IssuePolicyRequest issuePolicyRequest = new IssuePolicyRequest();
            IssuePolicyResponse issuePolicyResponse = new IssuePolicyResponse();
            ReceiptDetails receiptDetails = new ReceiptDetails();
            ReturnValue objreturnValue = new ReturnValue();

            try
            {
                using (var context = new testDBContext())
                {

                    //var existing = context.PentaDetails
                    //                      .FirstOrDefault(p =>  p.QuotationNumber == policy.SeqmentCode);

                    string quoteNo = context.PentaDetails
    .Where(p => p.QuotationNumber == policy.SeqmentCode)
    .Select(p => p.QuoteNo)
    .FirstOrDefault();
                    issuePolicyRequest.quotationNo = quoteNo;
                    receiptDetails.proposalNo = "P02050987";
                    //receiptDetails.instrumentType = CallLookuptableAsync("NLINSTRUMENT_LOV", "NLINSTRUMENT_LOV", "IssuePolicy", _appSettings.pentadetails.PentaTokenUrl, _appSettings.pentadetails.Username, _appSettings.pentadetails.Password, _appSettings.pentadetails.lookupUrl).GetAwaiter().GetResult(); ;
                    receiptDetails.instrumentType = "NL_OPG";
                    receiptDetails.instrumentBank = "";
                    receiptDetails.instrumentBankBranch = "";
                    receiptDetails.instrumentNo = "77777899999977";
                    receiptDetails.creditCardType = "";
                    receiptDetails.creditCardNo = "";
                    receiptDetails.creditCardValidFrom = "";
                    receiptDetails.creditCardValidTo = "";
                    //receiptDetails.receiptCode = dtStaticDetails.Rows[0]["receiptCode"].ToString();
                    receiptDetails.receiptCode = "RCT001";
                    issuePolicyRequest.receiptDetails = receiptDetails;
                    string Request = JsonConvert.SerializeObject(issuePolicyRequest);
                    if (receiptDetails != null)
                    {
                        issuePolicyResponse = ApiCall.ExcutePentaAPI<IssuePolicyResponse>(issuePolicyRequest, "issue-policy", _appSettings.pentadetails.pentaApiUrl, _appSettings.pentadetails.PentaTokenUrl, _appSettings.pentadetails.Username, _appSettings.pentadetails.Password);
                        string segment = issuePolicyResponse?.returnValue?.policyNo ?? null;
                        if (issuePolicyResponse != null && issuePolicyResponse.status == true)
                        {

                            _Business.UpdateEskaSegmentCode(policy.SeqmentCode, segment);
                            finalSaveResponse.status = true;
                            finalSaveResponse.errorMessage = JsonConvert.SerializeObject(issuePolicyResponse);
                        }

                        if (issuePolicyResponse != null)
                        {
                            var pentaRecord = context.PentaDetails
                                 .FirstOrDefault(p => p.QuoteNo == issuePolicyRequest.quotationNo);
                            if (pentaRecord != null)
                            {
                                pentaRecord.SegmentCode = segment;   // or your segment source
                                pentaRecord.IssuePolicyReq = JsonConvert.SerializeObject(issuePolicyRequest);
                                pentaRecord.IssuePolicyResp = JsonConvert.SerializeObject(issuePolicyResponse);
                                pentaRecord.UpdatedDate = DateTime.Now;
                                pentaRecord.Status = (issuePolicyResponse?.status == true)
                                                        ? "Policy Issued"
                                                        : "Policy Issue Failed";

                                context.PentaDetails.Update(pentaRecord);
                                context.SaveChanges();
                            }
                            else
                            {
                                context.PentaDetails.Update(pentaRecord);
                                context.SaveChanges();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                finalSaveResponse.status = false;
                finalSaveResponse.errorMessage = ex.Message;
            }
            return finalSaveResponse;
        }

        public DataTable SavePentaQuoteDetails(string Pentarequest, string Pentaresp, string status, int flag, string segmentcode)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = SavePentaQuoteDetails(Pentarequest, Pentaresp, "QuoteCreate", flag, "");
            }
            catch (Exception)
            {

                throw;
            }

            return dataTable;
        }

        public static async Task<string> CallLookuptableAsync(string sourceType, string lookupCode, string methodName, string tokenUrl, string username, string password, string lookupUrl)
        {
            string response = null;
            LookupResponse lookupResponse = new LookupResponse();
            LookupTable lookupTable = new LookupTable();
            InputValues inputValues = new InputValues();
            List<Item> objListItems = new List<Item>();

            try
            {
                // Prepare token request payload
                var tokenRequest = new
                {
                    username = username,
                    password = password
                };

                // Step 1: Get Token
                using (var tokenClient = new HttpClient())
                {
                    var tokenJson = JsonConvert.SerializeObject(tokenRequest);
                    var tokenContent = new StringContent(tokenJson, Encoding.UTF8, "application/json");

                    var tokenResponse = await tokenClient.PostAsync(tokenUrl, tokenContent);
                    var tokenBody = await tokenResponse.Content.ReadAsStringAsync();

                    if (!tokenResponse.IsSuccessStatusCode)
                    {
                        throw new Exception("Token request failed: " + tokenBody);
                    }

                    var tokenData = JsonConvert.DeserializeObject<PentatokenResponse>(tokenBody);
                    string token = tokenData?.access_token;

                    if (string.IsNullOrEmpty(token))
                    {
                        //dataAccessLayer.SavePentaAPI(1, policyNo, "", "", "", "Token is empty", "Lookup");
                        //dataAccessLayer.SaveErrorDetails(string.Empty, policyNo, "", "", null, "Lookup", "PentaAPI", "VisitVisa");
                        return null;
                    }

                    // Step 2: Prepare Lookup Request
                    inputValues.procedureName = sourceType;
                    inputValues.lookupCode = lookupCode;
                    lookupTable.inputValues = inputValues;
                    string requestJson = JsonConvert.SerializeObject(lookupTable);



                    // Step 3: Call Lookup API
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(lookupUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        HttpContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                        var lookupResponseMsg = await client.PostAsync(lookupUrl, content);
                        string responseContent = await lookupResponseMsg.Content.ReadAsStringAsync();

                        if (lookupResponseMsg.IsSuccessStatusCode)
                        {
                            lookupResponse = JsonConvert.DeserializeObject<LookupResponse>(responseContent);
                            objListItems = lookupResponse?.ReturnValue?.Items?.ToList() ?? new List<Item>();

                            // Pick first value safely
                            response = objListItems?.SelectMany(x => x.Lookup_Values).FirstOrDefault(v => v.V_Ins_Code == "NL_SADAD")?.V_Ins_Code;

                        }
                        else
                        {
                            //dataAccessLayer.SavePentaAPI(1, policyNo, "", "", "", "Lookup API failed: " + responseContent, "Lookup");
                            //dataAccessLayer.SaveErrorDetails(string.Empty, policyNo, "", responseContent, "Lookup API Error", "Lookup", "PentaAPI", "VisitVisa");
                            response = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //dataAccessLayer.SavePentaAPI(1, policyNo, "", "", "", JsonConvert.SerializeObject(ex), "Lookup");
                //dataAccessLayer.SaveErrorDetails(string.Empty, policyNo, "", JsonConvert.SerializeObject(ex), Convert.ToString(ex), "Lookup", "PentaAPI", "VisitVisa");
                //response = null;
            }

            return response;
        }


        public static string GetRelation(int value)
        {
            string relation = "Unknown";
            switch (value)
            {
                case 4:
                    relation = "PARENTS";
                    break;
                case 5:
                    relation = "OTHERS";
                    break;
                case 3:
                    relation = "CHILD";
                    break;
                case 2:
                    relation = "SPOUSE";
                    break;
                case 1:
                    relation = "SELF";
                    break;
            }
            return relation;
        }
        public static int GetMartialStatus(string martialStatus)
        {
            int value = 0;
            switch (martialStatus)
            {
                case "Single/اعزب":
                    value = 1;
                    break;
                case "Married/متزوج":
                    value = 2;
                    break;
                case "Widow/ارمل":
                    value = 5;
                    break;
                case "Divorced/مطلق":
                    value = 4;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;

        }


        public FinalSaveResponse PrepareAdditionalRequest(int id)
        {
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            FinalSaveRequest finalSaveRequest = new FinalSaveRequest();
            CRDetails check = new CRDetails();
            List<Error> errors = new List<Error>();
            try
            {
                List<Production> Policies = new List<Production>();
                Policies = _Business.LoadProductionAddiId(id, Eska: true);
                if (Policies != null && Policies.Count > 0)
                {
                    PolicyHolders PolicyHolder = _Business.LoadPolicyHolders(Convert.ToInt32(Policies[0].CustomerId));
                    Types UserType = _User.getTypeUser(Convert.ToInt32(Policies[0].CreatedBy));
                    Users UserInfo = _User.GetUser(Convert.ToInt32(Policies[0].CreatedBy));
                    check = _Business.LoadCRInfo(PolicyHolder.CommercialNo);
                    t_Yakeen_AddressInfo yakeen_AddressInfo = _Business.GetYakeen_AddressInfo(Convert.ToInt64(PolicyHolder.CommercialNo));
                    if (PolicyHolder != null)
                    {
                        memberAdditionRequest memberAdditionRequest = PrepareendorsementRequest(Policies);
                        if (memberAdditionRequest != null)
                        {
                            string Request = JsonConvert.SerializeObject(memberAdditionRequest);
                            ErrorHandler.WriteLog(Request, "Log1", "", "Request1");
                            memberAdditionApiResponse memberAdditionApiResponse = ApiCall.ExcutePentaAPI<memberAdditionApiResponse>(memberAdditionRequest, "", _appSettings.pentadetails.endorsmentUrl, _appSettings.pentadetails.PentaTokenUrl, _appSettings.pentadetails.Username, _appSettings.pentadetails.Password);
                            ErrorHandler.WriteLog(JsonConvert.SerializeObject(memberAdditionApiResponse), "Log2", "", _appSettings.pentadetails.endorsmentUrl);
                            using (var context = new testDBContext())
                            {
                                ErrorHandler.WriteLog(JsonConvert.SerializeObject(memberAdditionApiResponse), "Log6", "insideContext", _appSettings.pentadetails.endorsmentUrl);
                                if (memberAdditionApiResponse != null && memberAdditionApiResponse.errors.Count<=0)
                                {
                                    finalSaveResponse.status = true;
                                    finalSaveResponse.errorMessage = memberAdditionApiResponse.returnValue.memberAdditionDetails.referenceQuotationNo;
                                    ErrorHandler.WriteLog("", "Lo3", "", "Request2");
                                    var pentaRecord = context.PentaDetails
                                                    .Where(p => Convert.ToInt16(p.QuoteId) == Policies[0].CustomerId)
                                                    .OrderByDescending(p => p.CreatedDate)
                                                    .FirstOrDefault();
                                    ErrorHandler.WriteLog("pentaRecord", "Lo8", "", "Request2");
                                    if (pentaRecord != null)
                                    {

                                        pentaRecord.CalPremiumReq = JsonConvert.SerializeObject(memberAdditionRequest);
                                        pentaRecord.CalPremiumResp = JsonConvert.SerializeObject(memberAdditionApiResponse);
                                        pentaRecord.UpdatedDate = DateTime.Now;
                                        pentaRecord.Status = (memberAdditionApiResponse?.status == true)
                                                                ? "EndorsmentSuccess"
                                                                : "EndorsmentFailed";

                                        context.PentaDetails.Update(pentaRecord);
                                        context.SaveChanges();
                                    }
                                    else
                                    {
                                        context.PentaDetails.Update(pentaRecord);
                                        context.SaveChanges();
                                    }
                                    ErrorHandler.WriteLog("", "Lo4", "", "Request3");
                                }
                                else
                                {
                                    errors=memberAdditionApiResponse.errors;
                                    finalSaveResponse.status = false;
                                    finalSaveResponse.errorMessage = errors.Count>0? errors[0].Message:"";
                                    ErrorHandler.WriteLog("", "Lo5", "", "Request4");
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                finalSaveResponse.status = false;
                finalSaveResponse.errorMessage = Convert.ToString(ex);
            }
            return finalSaveResponse;
        }
        public memberAdditionRequest PrepareendorsementRequest(List<Production> Policies)
        {
            memberAdditionRequest memberAdditionRequest = new memberAdditionRequest();


            try
            {
                using (var context = new testDBContext())
                {
                    var segmentCode = context.PentaDetails
                                     .Where(p => Convert.ToInt16(p.QuoteId) == Policies[0].CustomerId)
                                     .OrderByDescending(p => p.CreatedDate)
                                     .Select(p => p.SegmentCode)
                                     .FirstOrDefault();

                    memberAdditionRequest.processCode = "MEMBER_ADDITION";
                    memberAdditionRequest.alterationEffectiveDate = Policies[0].EffectiveDate.ToString("yyyy-MM-dd");
                    memberAdditionRequest.policyNo = segmentCode;
                    memberAdditionRequest.refundType = "";
                    memberCorrection[] objlistmemberCorrection = new memberCorrection[0];
                    memberAdditionRequest.memberCorrection = objlistmemberCorrection;
                    DataTable dtStaticDetails = GetStaticDetails.GetStaticDetail(1, _appSettings.EskaConnection);

                    List<Subjects> Members = _Business.LoadMemberBusiness(Policies[0].Id, null);
                    List<MemberDetails> objMembers = new List<MemberDetails>();
                    memberAddition objmember = new memberAddition();
                    List<memberAddition> objlistmembers = new List<memberAddition>();
                    if (dtStaticDetails != null && dtStaticDetails.Rows.Count > 0)
                    {
                        foreach (Subjects member in Members)
                        {
                            objmember.idenCode = dtStaticDetails.Rows[0]["idenCode"].ToString();
                            objmember.idenNo = member.NationalId;
                            objmember.name = !string.IsNullOrEmpty(Convert.ToString(member.Name)) ? Convert.ToString(member.Name) : Convert.ToString(member.Name);
                            string fullName = member.Name;
                            string[] names = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            objmember.firstName = names.Length > 0 ? names[0] : "";
                            objmember.middleName = (names != null && names.Length > 1) ? names[1] : "";
                            objmember.lastName = names.Length > 0 && names.Length >= 3 ? names[2] : "";
                            objmember.fourthName = "";


                            objmember.maritalStatus = member.MartialStatus.ToString() == "1" ? "S" : "M";
                            objmember.gender = member.Gender.ToString() == "1" ? "M" : "F";

                            objmember.dob = Convert.ToDateTime(member.DateOfBirth).ToString("yyyy-MM-dd");

                            objmember.relation = GetRelation(Convert.ToInt32(member.Relation));

                            objmember.sponsorNumber = "";//doubt
                            DataTable occupation = GetStaticDetails.GetTransformData(5, "01", member.Occupation, "P_TM_OCCUPATION", string.Empty, _appSettings.EskaConnection);
                            if (occupation != null && occupation.Rows.Count > 0)
                            {
                                objmember.occupation = occupation.Rows[0]["MDM_CORE_CODE"].ToString();

                            }
                            objmember.nationality = member.NationalityCode; ;//doubt

                            //objmember.memberEffectiveDate = policy.EffectiveDate.ToString("yyyy-MM-dd");
                            objmember.memberEffectiveDate = "2025-01-01";


                            objmember.expiryDate = Policies[0].ExpiryDate.ToString("yyyy-MM-dd");
                            objmember.idIssueDate = "";
                            objmember.idExpiryDate = "";



                            objmember.memberEffectiveDate = Policies[0].EffectiveDate.ToString("yyyy-MM-dd");
                            objmember.memberExpiryDate = Policies[0].EffectiveDate.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd");

                            objmember.subPlanCode = dtStaticDetails.Rows[0]["subPlanCode"].ToString();
                            //dtTransformVal = dataAccessLayer.GetTransformData(5, source, quoteVerificationRequest.CompanyAddressList[0].City.ToString(), "P_T_CITY", quoteRequest.QuoteRequestReferenceNo.ToString(), string.Empty);
                            objmember.city = dtStaticDetails.Rows[0]["city"].ToString();

                            objmember.consumeAlcohol = "";
                            objmember.alcoholPerDay = 0;


                            objmember.pregnantFlag = "";
                            objmember.pregnancyMonths = 0;
                            objmember.smokerFlag = "";
                            objmember.noOfSticksPerDay = 0;

                            objmember.loadingType = member.AdditionalPremium != 0 ? "" : dtStaticDetails.Rows[0]["loadingType"].ToString(); //need to check logic
                            objmember.loadingAmount = member.AdditionalPremium != 0 ? 0 : Convert.ToInt32(dtStaticDetails.Rows[0]["loadingAmount"]);

                            objmember.discountType = null;
                            objmember.discountAmount = 0;
                            objmember.companyCode = "";
                            objmember.companyBranch = "";
                            objmember.employeeId = "0";
                            List<addressDetails> objlistmemaddressdetails = new List<addressDetails>()
                                    {
                                        new addressDetails
                                        {
                                            addressType=dtStaticDetails.Rows[0]["addressType"].ToString(),
                                             additionalNo = Convert.ToInt32(dtStaticDetails.Rows[0]["additionalNo"]),
                                            buildingNo=Convert.ToInt32(dtStaticDetails.Rows[0]["buildingNo"]),
                                            street =  dtStaticDetails.Rows[0]["street"].ToString(),
                                              postCode =  Convert.ToString( dtStaticDetails.Rows[0]["postCode"].ToString()),
                                            city =  dtStaticDetails.Rows[0]["city"].ToString(),
                                            district ="",

                                            isPrimaryAddress = dtStaticDetails.Rows[0]["isPrimaryAddress"].ToString(),
                                            yakeenAddress="",
                                            yakeenCity = "",


                                        }
                                    };
                            objmember.addressDetails = objlistmemaddressdetails;
                            uwQuestion[] objuwQuestions = new uwQuestion[0];//doubt
                            objmember.uwQuestions = objuwQuestions;

                            documentDetails[] documentDetails = new documentDetails[0];
                            objmember.documentDetails = documentDetails;
                            List<agentDetails> objListAgenta = new List<agentDetails>
                                      {
                                          new agentDetails
                                         {
                                             agentNumber = "5529",
                                             rank ="OSE",
                                             agentSharePercent=dtStaticDetails.Rows[0]["percent"].ToString(),
                                             commissionType= dtStaticDetails.Rows[0]["commissionType"].ToString(),
                                             commissionPercent= dtStaticDetails.Rows[0]["commissionPercent"].ToString()//we need to check current logic
                                         }
                                      };
                            objmember.agentDetails = objListAgenta;
                            objlistmembers.Add(objmember);
                        }

                        memberAdditionRequest.memberAddition = objlistmembers;
                        memberDeletion[] objlistmemberdeletion = new memberDeletion[0];
                        memberAdditionRequest.memberDeletion = objlistmemberdeletion;
                    }


                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            return memberAdditionRequest;
        }
    }
}
