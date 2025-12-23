using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process.Approvals;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.Authentications;
using CORE.DTOs.Business;
using CORE.Interfaces;
using CORE.TablesObjects;
using InsuranceAPIs.API;
using InsuranceAPIs.Logger;
using InsuranceAPIs.Models.Configuration_Objects;
using InsuranceAPIs.Models.SMEAPIs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Service.Common;
using Service.Interfaces;

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

        public SMECoreServices(AppSettings appSettings, IWebHostEnvironment environment, IBusiness svcBus, ITracker tracker, IWSCoreService wSCoreService, IProcess process, IUserManagment user)
        {
            _environment = environment;
            _appSettings = appSettings;
            _Business = svcBus;
            _tracker = tracker;
            _CoreServices = wSCoreService;
            _process = process;
            _User = user;
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
                        if (Policies[0].PolicyId==null || Policies[0].PolicyId == 0)
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
                                Policies[0].EskaId = Policies[0].PolicyId == null || Policies[0].PolicyId == 0 ? policyHeaderResponse.policyInfo.policyId: policyHeaderResponses[0].policyEndoInfo.policyId;
                                Policies[0].EskaSegment = Policies[0].PolicyId == null || Policies[0].PolicyId == 0 ? policyHeaderResponse.policyInfo.sEGMENT_CODE : policyHeaderResponses[0].policyEndoInfo.sEGMENT_CODE;
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
                        PaymentLog log = new PaymentLog()
                        {
                            CardDetails = bankBody.amount,
                            CardType = "BANK",
                            MerchantReference = policyPaymentInput.ReferenceNo,
                            PayfortId = policyPaymentInput.ReferenceNo,
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
    }
}
