using CORE.DTOs.APIs;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process;
using CORE.DTOs.APIs.Process.Approvals;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.APIs.TPServices;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Authentications;
using CORE.DTOs.Business;
using CORE.DTOs.Setups;
using CORE.Interfaces;
using CORE.TablesObjects;
using DataAccessLayer.Oracle.Eskadenia.Issuance;
using DataAccessLayer.Oracle.Eskadenia.Setups;
using Endoresement;
using EskaPolicies;
using InsuranceAPIs.Extension;
using InsuranceAPIs.GovernmentAPIs.CCHI;
using InsuranceAPIs.Logger;
using InsuranceAPIs.Models.Configuration_Objects;
using InsuranceAPIs.Models.SMEAPIs;
using InsuranceAPIs.SMEAPIs;
using MicroAPIs.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Service.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.ServiceModel;

namespace InsuranceAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalController : ControllerBase
    {
        private static HttpClient client = new HttpClient();

        private readonly AppSettings _appSettings;

        public static IWebHostEnvironment? _environment;

        private readonly IBusiness _svcBusiness;

        private readonly ITracker _tracker;

        private readonly IWSCoreService _CoreServices;

        private readonly IProcess _process;
        private readonly IUserManagment _User;

        public MedicalController(IOptions<AppSettings> appSettings, IWebHostEnvironment environment, IBusiness svcBus, ITracker tracker, IWSCoreService wSCoreService, IProcess process, IUserManagment user)
        {
            _environment = environment;
            _appSettings = appSettings.Value;
            _svcBusiness = svcBus;
            _tracker = tracker;
            _CoreServices = wSCoreService;
            _process = process;
            _User = user;
        }

        [HttpGet]
        [Route("LoadPolicies")]
        public LoadPolicyBusiness LoadPolicies([FromQuery] string obj)
        {
            LoadPolicyBusiness loadPolicyBusiness = new LoadPolicyBusiness();
            loadPolicyBusiness.Subjects = new List<Subjects>();
            loadPolicyBusiness.Headers = new List<Production>
            {
                new Production()
            };
            try
            {
                string User = Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV);
                Users oUser = new Users();
                oUser = JsonConvert.DeserializeObject<Users>(User);
                loadPolicyBusiness = _svcBusiness.LoadProductionBusiness(oUser.Id.ToString());
                if (loadPolicyBusiness == null && loadPolicyBusiness.Headers.Count > 0)
                {
                    loadPolicyBusiness.status = true;
                    loadPolicyBusiness.ResponseDate = DateTime.Now;
                    loadPolicyBusiness.httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    loadPolicyBusiness.status = false;
                    loadPolicyBusiness.ResponseDate = DateTime.Now;
                    loadPolicyBusiness.httpStatusCode = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception)
            {
                loadPolicyBusiness.status = false;
                loadPolicyBusiness.ResponseDate = DateTime.Now;
                loadPolicyBusiness.httpStatusCode = HttpStatusCode.NoContent;
            }
            return loadPolicyBusiness;
        }

        [HttpGet]
        [Route("LoadPoliciesTeam")]
        public DocumentTree LoadDocumentTreeLoadPoliciesTeam([FromQuery] string obj)
        {
            DocumentTree Tree = new DocumentTree();
            LoadDocumentTreeInput loadDocumentTreeInput = new LoadDocumentTreeInput();
            Tree.Policies = new List<Policy>();
            Tree.Quotations = new List<Policy>();
            try
            {
                string User = Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV);
                loadDocumentTreeInput = JsonConvert.DeserializeObject<LoadDocumentTreeInput>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
                Tree = _svcBusiness.documentTreeTeamLeader(loadDocumentTreeInput);
                if (Tree != null && Tree.Policies.Count > 0)
                {
                    Tree.status = true;
                    Tree.ResponseDate = DateTime.Now;
                    Tree.httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Tree.status = false;
                    Tree.ResponseDate = DateTime.Now;
                    Tree.httpStatusCode = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception)
            {
                Tree.status = false;
                Tree.ResponseDate = DateTime.Now;
                Tree.httpStatusCode = HttpStatusCode.NoContent;
            }
            return Tree;
        }

        [HttpGet]
        [Route("LoadDocumentTree")]
        public DocumentTree LoadDocumentTree([FromQuery] string obj)
        {
            DocumentTree Tree = new DocumentTree();
            LoadDocumentTreeInput loadDocumentTreeInput = new LoadDocumentTreeInput();
            Tree.Policies = new List<Policy>();
            Tree.Quotations = new List<Policy>();
            try
            {
                string User = Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV);
                loadDocumentTreeInput = JsonConvert.DeserializeObject<LoadDocumentTreeInput>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
                Tree = _svcBusiness.documentTree(loadDocumentTreeInput);
                //if (Tree != null && Tree.Policies.Count > 0) -- Removed condition because cases will show only if policies count > 0 which is wrong
                if (Tree != null && Tree.Policies.Count >= 0)
                {
                    Tree.status = true;
                    Tree.ResponseDate = DateTime.Now;
                    Tree.httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Tree = new DocumentTree();
                    Tree.status = false;
                    Tree.ResponseDate = DateTime.Now;
                    Tree.httpStatusCode = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception)
            {
                Tree.status = false;
                Tree.ResponseDate = DateTime.Now;
                Tree.httpStatusCode = HttpStatusCode.NoContent;
            }
            return Tree;
        }

        [HttpGet]
        [Route("LoadDocument")]
        public Document LoadDocument(string obj)
        {
            Document document = new Document();
            FilterDocument objFilter = new FilterDocument();
            objFilter = JsonConvert.DeserializeObject<FilterDocument>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
            string policyNo = ((!string.IsNullOrEmpty(objFilter.DocumentNo)) ? objFilter.DocumentNo : string.Empty);
            int policyId = (objFilter.Id.HasValue ? objFilter.Id.Value : 0);
            Production Documents = _svcBusiness.LoadDocument(policyNo, policyId, objFilter.DocumentType);
            document.Headers = new List<Production>();
            if (Documents != null)
            {
                document.Headers.Add(Documents);
                document.status = true;
                document.ResponseDate = DateTime.Now;
                document.httpStatusCode = HttpStatusCode.OK;
                document.message = "";
            }
            else
            {
                document.status = false;
                document.ResponseDate = DateTime.Now;
                document.httpStatusCode = HttpStatusCode.NoContent;
                document.message = "No Content";
            }
            return document;
        }

        [HttpGet]
        [Route("LoadMemberTree")]
        public MembersInformations LoadMemberTree([FromQuery] string obj)
        {
            MembersInformations loadMemberTrees = new MembersInformations();
            loadMemberTrees.Members = new List<MembersList>();
            string DecryptedObject = Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV);
            MemberLoadIput memberLoadIput = new MemberLoadIput();
            memberLoadIput = JsonConvert.DeserializeObject<MemberLoadIput>(DecryptedObject);
            List<MembersList> Members = _svcBusiness.LoadMemberTree(memberLoadIput.Policy, memberLoadIput.Princible, memberLoadIput.NationalId);
            if (Members != null && Members.Count > 0)
            {
                loadMemberTrees.Members = Members;
                loadMemberTrees.status = true;
                loadMemberTrees.ResponseDate = DateTime.Now;
                loadMemberTrees.httpStatusCode = HttpStatusCode.OK;
                loadMemberTrees.message = "";
            }
            else
            {
                loadMemberTrees.status = false;
                loadMemberTrees.ResponseDate = DateTime.Now;
                loadMemberTrees.httpStatusCode = HttpStatusCode.NoContent;
                loadMemberTrees.message = "No Content";
            }
            return loadMemberTrees;
        }

        [HttpPost]
        [Route("LoadMemberTreeByCRno")]
        public MembersInformations LoadMemberTreeByCRno(CheckSponsorInput checkSponsorInput)
        {
            MembersInformations loadMemberTrees = new MembersInformations();
            List<MembersList> Members = _svcBusiness.LoadMemberTreeByCRno(checkSponsorInput.Sponsor);
            if (Members != null && Members.Count > 0)
            {
                loadMemberTrees.Members = Members;
                loadMemberTrees.status = true;
                loadMemberTrees.ResponseDate = DateTime.Now;
                loadMemberTrees.httpStatusCode = HttpStatusCode.OK;
                loadMemberTrees.message = "";
            }
            else
            {
                loadMemberTrees.status = false;
                loadMemberTrees.ResponseDate = DateTime.Now;
                loadMemberTrees.httpStatusCode = HttpStatusCode.NoContent;
                loadMemberTrees.message = "No Content";
            }
            return loadMemberTrees;
        }

        [HttpPost]
        [Route("LoadMemberTreeByPolicyid")]
        public MembersInformations LoadMemberTreeByPolicyid(PolicyIdInput policyIdInput)
        {
            MembersInformations loadMemberTrees = new MembersInformations();
            List<MembersList> Members = _svcBusiness.LoadMemberTreeByPolicyid(policyIdInput.PolicyId);
            if (Members != null && Members.Count > 0)
            {
                loadMemberTrees.Members = Members;
                loadMemberTrees.status = true;
                loadMemberTrees.ResponseDate = DateTime.Now;
                loadMemberTrees.httpStatusCode = HttpStatusCode.OK;
                loadMemberTrees.message = "";
            }
            else
            {
                loadMemberTrees.status = false;
                loadMemberTrees.ResponseDate = DateTime.Now;
                loadMemberTrees.httpStatusCode = HttpStatusCode.NoContent;
                loadMemberTrees.message = "No Content";
            }
            return loadMemberTrees;
        }

        [HttpGet]
        [Route("SearchMemberTree")]
        public MembersInformations SearchMemberTree([FromQuery] string obj)
        {
            MembersInformations loadMemberTrees = new MembersInformations();
            loadMemberTrees.Members = new List<MembersList>();
            string DecryptedObject = Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV);
            MemberSearch memberLoadIput = new MemberSearch();
            memberLoadIput = JsonConvert.DeserializeObject<MemberSearch>(DecryptedObject);
            List<MembersList> Members = _svcBusiness.LoadMemberTreeSearch(null, memberLoadIput.NationalId, memberLoadIput.PolicyId);
            if (Members != null && Members.Count > 0)
            {
                loadMemberTrees.Members = Members;
                loadMemberTrees.status = true;
                loadMemberTrees.ResponseDate = DateTime.Now;
                loadMemberTrees.httpStatusCode = HttpStatusCode.OK;
                loadMemberTrees.message = "";
            }
            else
            {
                loadMemberTrees.status = false;
                loadMemberTrees.ResponseDate = DateTime.Now;
                loadMemberTrees.httpStatusCode = HttpStatusCode.NoContent;
                loadMemberTrees.message = "No Content";
            }
            return loadMemberTrees;
        }

        [HttpPost]
        [Route("YakeenValidation")]
        public ValidationMembers lsValidateMembers(List<ExcelMembers> obj)
        {
            ValidationMembers validation = new ValidationMembers();
            validation.lsError = new List<ErrorMembers>();
            validation.LsSuccessMembers = new List<Members>();
            List<ExcelMembers> excelMembers = new List<ExcelMembers>();
            excelMembers = obj;
            if (excelMembers != null && excelMembers.Count > 0)
            {
                validation = YakeenCall.CheckYakeenMembers(excelMembers, _appSettings, _svcBusiness, _process);
                if (validation != null && validation.LsSuccessMembers.Count > 0)
                {
                    validation.status = true;
                    validation.message = "";
                    validation.ResponseDate = DateTime.Now;
                    validation.httpStatusCode = HttpStatusCode.OK;
                }
                else if (validation != null && validation.lsError.Count > 0)
                {
                    validation.status = true;
                    validation.message = "";
                    validation.ResponseDate = DateTime.Now;
                    validation.httpStatusCode = HttpStatusCode.OK;
                }
                else if (validation != null && validation.LsSuccessMembers.Count > 0)
                {
                    validation.status = false;
                    validation.message = "Yakeen Call Error";
                    validation.ResponseDate = DateTime.Now;
                    validation.httpStatusCode = HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                validation.status = false;
                validation.message = "Yakeen Call Error";
                validation.ResponseDate = DateTime.Now;
                validation.httpStatusCode = HttpStatusCode.NoContent;
            }
            return validation;
        }

        [HttpPost]
        [Route("FillYakeenTemplate")]
        public ValidationMembers FillYakeenTemplate(List<ExcelMembers> obj)
        {
            ValidationMembers validation = new ValidationMembers();
            validation.lsError = new List<ErrorMembers>();
            validation.LsSuccessMembers = new List<Members>();
            List<ExcelMembers> excelMembers = new List<ExcelMembers>();
            excelMembers = obj;
            if (excelMembers != null && excelMembers.Count > 0)
            {
                validation = YakeenCall.FillYakeenTemplate(excelMembers, _appSettings, _svcBusiness);
                if (validation != null && validation.LsSuccessMembers.Count > 0)
                {
                    validation.status = true;
                    validation.message = "";
                    validation.ResponseDate = DateTime.Now;
                    validation.httpStatusCode = HttpStatusCode.OK;
                }
                else if (validation != null && validation.lsError.Count > 0)
                {
                    validation.status = true;
                    validation.message = "";
                    validation.ResponseDate = DateTime.Now;
                    validation.httpStatusCode = HttpStatusCode.OK;
                }
                else if (validation != null && validation.LsSuccessMembers.Count > 0)
                {
                    validation.status = false;
                    validation.message = "Yakeen Call Error";
                    validation.ResponseDate = DateTime.Now;
                    validation.httpStatusCode = HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                validation.status = false;
                validation.message = "Yakeen Call Error";
                validation.ResponseDate = DateTime.Now;
                validation.httpStatusCode = HttpStatusCode.NoContent;
            }
            return validation;
        }

        [HttpPost]
        [Route("CheckCCHISponsor")]
        public SponsorV3 CheckCCHISponsor(CheckSponsorInput checkSponsorInput)
        {
            SponsorV3 Sponsor = new SponsorV3();
            if (checkSponsorInput != null)
            {
                try
                {
                    Sponsor = GetSponsor.GetSponsorV3(checkSponsorInput.Sponsor, _appSettings.CCHIKey).Result;
                    if (Sponsor != null)
                    {
                        Sponsor.status = true;
                        Sponsor.message = "";
                        Sponsor.ResponseDate = DateTime.Now;
                        Sponsor.httpStatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        Sponsor.status = false;
                        Sponsor.message = " 700's not able to get data from CCHI";
                        Sponsor.ResponseDate = DateTime.Now;
                        Sponsor.httpStatusCode = HttpStatusCode.NoContent;
                    }
                }
                catch (Exception)
                {
                    Sponsor.status = false;
                    Sponsor.message = "cchi IS UNAVAILABLE !!";
                    Sponsor.ResponseDate = DateTime.Now;
                    Sponsor.httpStatusCode = HttpStatusCode.NoContent;
                }
            }
            else
            {
                Sponsor.status = true;
                Sponsor.message = "Object is null or Encryption is not correct";
                Sponsor.ResponseDate = DateTime.Now;
                Sponsor.httpStatusCode = HttpStatusCode.NotFound;
            }
            return Sponsor;
        }

        [HttpGet]
        [Route("LoadMembers")]
        public LoadMemberBusiness LoadMembers(string obj)
        {
            LoadMemberBusiness loadMemberBusiness = new LoadMemberBusiness();
            LoadMemberInput loadMember = new LoadMemberInput();
            loadMember = JsonConvert.DeserializeObject<LoadMemberInput>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
            string Princibles = ((!string.IsNullOrEmpty(loadMember.Princible)) ? loadMember.Princible : string.Empty);
            int policyId = loadMember.PolicyId;
            List<Subjects> Members = _svcBusiness.LoadMemberBusiness(policyId, Princibles);
            loadMemberBusiness.Production = new Production();
            loadMemberBusiness.Production = _svcBusiness.LoadDocument(null, loadMember.PolicyId, 1);
            loadMemberBusiness.Subjects = new List<Subjects>();
            if (Members != null && Members.Count > 0)
            {
                loadMemberBusiness.Subjects = Members;
                loadMemberBusiness.status = true;
                loadMemberBusiness.ResponseDate = DateTime.Now;
                loadMemberBusiness.httpStatusCode = HttpStatusCode.OK;
                loadMemberBusiness.message = "";
            }
            else
            {
                loadMemberBusiness.status = false;
                loadMemberBusiness.ResponseDate = DateTime.Now;
                loadMemberBusiness.httpStatusCode = HttpStatusCode.NoContent;
                loadMemberBusiness.message = "No Content";
            }
            return loadMemberBusiness;
        }

        [HttpGet]
        [Route("FilterDocument")]
        public DocumentTree FilterDocument([FromQuery] string obj)
        {
            FilterDocumentInput filter = new FilterDocumentInput();
            string enc = Utilities.Encrypt(JsonConvert.SerializeObject(obj), _appSettings.BCKey, _appSettings.BCIV);
            DocumentTree Documents = new DocumentTree();
            FilterDocumentInput filterDocumentInput = new FilterDocumentInput();
            filterDocumentInput = JsonConvert.DeserializeObject<FilterDocumentInput>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
            string PolicyCharacter = ((!string.IsNullOrEmpty(filterDocumentInput.PolicyChar)) ? filterDocumentInput.PolicyChar : string.Empty);
            int? StatusPolicy = (filterDocumentInput.Status.HasValue ? new int?(filterDocumentInput.Status.Value) : null);
            int? DocumentTypes = (filterDocumentInput.DocumentType.HasValue ? new int?(filterDocumentInput.DocumentType.Value) : null);
            Documents = _svcBusiness.FilterDocument(PolicyCharacter, filterDocumentInput.FromEffectiveDate, filterDocumentInput.ToEffectiveDate, filterDocumentInput.FromIssueDate, filterDocumentInput.ToIssueDate, StatusPolicy, DocumentTypes, filterDocumentInput.UserId, filterDocumentInput.IsPaid);
            Documents.status = true;
            Documents.ResponseDate = DateTime.Now;
            Documents.httpStatusCode = HttpStatusCode.OK;
            Documents.message = "";
            return Documents;
        }

        [HttpPost]
        [Route("InsertDocument")]
        public Document InsertDocument([FromBody] Production obj)
        {
            Document Documents = new Document();
            Production production = new Production();
            production = obj;
            (Production, string) Policy = _svcBusiness.InsertUpdateProduction(production);
            Documents.Headers = new List<Production>();
            if (Policy.Item1 != null && Policy.Item1.Id > 0)
            {
                Documents.Headers.Add(Policy.Item1);
                Documents.status = true;
                Documents.ResponseDate = DateTime.Now;
                Documents.httpStatusCode = HttpStatusCode.OK;
                Documents.message = "";
            }
            else
            {
                Documents.status = false;
                Documents.ResponseDate = DateTime.Now;
                Documents.httpStatusCode = HttpStatusCode.NoContent;
                Documents.message = Policy.Item2;
            }
            return Documents;
        }

        [HttpPost]
        [Route("InsertBulkMembers")]
        public LoadMemberBusiness InsertBulkMembers([FromBody] List<Subjects> obj)
        {
            LoadMemberBusiness memberBusiness = new LoadMemberBusiness();
            List<Subjects> production = new List<Subjects>();
            production = obj;
            (List<Subjects>, string) lstMembers = _svcBusiness.InsertUpdateMembers(production, _appSettings.EskaConnection);
            memberBusiness.Subjects = new List<Subjects>();
            if (lstMembers.Item1 != null && lstMembers.Item1.Count > 0)
            {
                memberBusiness.Subjects = lstMembers.Item1;
                memberBusiness.status = true;
                memberBusiness.ResponseDate = DateTime.Now;
                memberBusiness.httpStatusCode = HttpStatusCode.OK;
                memberBusiness.message = lstMembers.Item2;
            }
            else
            {
                memberBusiness.status = false;
                memberBusiness.ResponseDate = DateTime.Now;
                memberBusiness.httpStatusCode = HttpStatusCode.NoContent;
                memberBusiness.message = "No Content";
            }
            return memberBusiness;
        }

        [HttpPost]
        [Route("ValidateMembers")]
        public List<MemberValidation> ValidateMembers([FromBody] List<Subjects> obj)
        {
            LoadMemberBusiness memberBusiness = new LoadMemberBusiness();
            List<Subjects> subjects = new List<Subjects>();
            subjects = obj;
            List<MemberValidation> lstMembers = _svcBusiness.memberValidations(subjects, _appSettings.EskaConnection);
            memberBusiness.Subjects = new List<Subjects>();
            if (lstMembers != null && lstMembers.Count > 0)
            {
                memberBusiness.Subjects = subjects;
                memberBusiness.status = true;
                memberBusiness.ResponseDate = DateTime.Now;
                memberBusiness.httpStatusCode = HttpStatusCode.OK;
                memberBusiness.message = "";
            }
            else
            {
                memberBusiness.status = false;
                memberBusiness.ResponseDate = DateTime.Now;
                memberBusiness.httpStatusCode = HttpStatusCode.NoContent;
                memberBusiness.message = "No Content";
            }
            return lstMembers;
        }

        [HttpPost]
        [Route("CalculateMembers")]
        public ValidationMembers CalculateMembers([FromBody] List<CalculationRequest> obj)
        {
            ValidationMembers validation = new ValidationMembers();
            PlanHistory planHistory = new PlanHistory();
            validation.LsSuccessMembers = new List<Members>();
            validation.lsError = new List<ErrorMembers>();
            LoadMemberBusiness memberBusiness = new LoadMemberBusiness();
            List<MemberPremiums> subjects = new List<MemberPremiums>();
            NationalityMapping nationalityMapping;
            Subjects sub = new Subjects();
            List<Subjects> subs = new List<Subjects>();

            try
            {

                var productions = _svcBusiness.getDocumentByCrnumber(obj[0].Member.membersData.MainMember.Princible);
                foreach (CalculationRequest Person in obj)
                {
                    CalculationRequest Person2 = Person;
                    subs = new List<Subjects>();
                    planHistory = new PlanHistory();
                    MembersDeclarations declaration = _svcBusiness.LoadDeclarationByMember(Person2.Member.membersData.MainMember.Id);
                    Members premiums = new Members();
                    premiums.membersData = new MembersData();
                    premiums.membersData.MainMember = new Subjects();
                    premiums.dependMember = new List<MembersData>();
                    sub = new Subjects();
                    int planId = _svcBusiness.GetPlanId(Person2.Member.membersData.MainMember.PolicyId);
                    sub = _svcBusiness.LoadMembersubject(Person2.Member.membersData.MainMember.Id);
                    nationalityMapping = new NationalityMapping();
                    nationalityMapping = _svcBusiness.GetEskaNationalityByEska(sub.NationalityCode);

                    //Changes by Kunal Class Implementation Start 09-07-2024
                    MemberPrices memberPrices = new MemberPrices();
                    if (planId != Convert.ToInt32(_appSettings.PlanCode) && (productions != null && productions.DocumentType == 2))
                    {
                        planHistory = _svcBusiness.LoadPlanHistory(planId, nationalityMapping.ClassId.Value, sub.InsuranceClassCode != null ? (int)sub.InsuranceClassCode : 0);
                        sub.ClassId = planHistory.ClassId;
                        subs.Add(sub);
                        subs = _svcBusiness.InsertUpdateMembers(subs, _appSettings.Connection).Item1;
                        if (sub != null)
                            sub.ClassId = planHistory.ClassId;
                        memberPrices = PricingClass.MemberPrice((sub != null) ? sub : Person2.Member.membersData.MainMember, planId, _appSettings.EskaConnection);
                        if (memberPrices.NetPremium == 0)
                        {
                            validation.lsError.Add(new ErrorMembers
                            {
                                membersData = new Princible
                                {
                                    NationalId = Person2.Member.membersData.MainMember.NationalId,
                                    DateOfBirth = Person2.Member.membersData.MainMember.DateOfBirth.ToString(),
                                    Error = "Member Premium is not found",
                                    IsSuccess = false,
                                    Sponsor = Person2.Member.membersData.MainMember.Princible,
                                }
                            });
                            continue;
                        }
                        premiums.membersData.MainMember = Person2.Member.membersData.MainMember;
                    }
                    else
                    {
                        memberPrices = PricingClass.MemberPriceClass((sub != null) ? sub : Person2.Member.membersData.MainMember, planId, (int)Person2.Member.membersData.MainMember.InsuranceClassCode, nationalityMapping.Id, _appSettings.PlanCode, _appSettings.EskaConnection,
                            obj[obj.Count - 1].P_NOOFNONSAUDIPRINCMEM, obj[obj.Count - 1].P_NOOFSAUDIPRINCMEM, obj[obj.Count - 1].P_NOOFSAUDIDEPMEM, obj[obj.Count - 1].P_NOOFNONSAUDIDEPMEM);
                        if (memberPrices.NetPremium == 0)
                        {
                            validation.lsError.Add(new ErrorMembers
                            {
                                membersData = new Princible
                                {
                                    NationalId = Person2.Member.membersData.MainMember.NationalId,
                                    DateOfBirth = Person2.Member.membersData.MainMember.DateOfBirth.ToString(),
                                    Error = "Member Premium is not found",
                                    IsSuccess = false,
                                    Sponsor = Person2.Member.membersData.MainMember.Princible,
                                }
                            });
                            continue;
                        }

                        sub.ClassId = memberPrices.Subjects.ClassId;
                        decimal AdditionalPremium = (productions != null && productions.DocumentType == 2) ? (decimal)0 : (decimal)memberPrices.Subjects.AdditionalPremium;
                        sub.AdditionalPremium = AdditionalPremium;
                        subs.Add(sub);
                        subs = _svcBusiness.InsertUpdateMembers(subs, _appSettings.Connection).Item1;
                        premiums.membersData.MainMember = Person2.Member.membersData.MainMember;
                        premiums.membersData.MainMember.ClassId = memberPrices.Subjects.ClassId;
                        premiums.membersData.MainMember.AdditionalPremium = AdditionalPremium;

                    }

                    //Changes by Kunal Class Implementation End 09-07-2024


                    decimal DiscountPercent = default(decimal);
                    decimal num = default(decimal);
                    Discount Discount = _svcBusiness.Discount(null);
                    //Changes by Kunal Endorsment Prem Issue Start 10-04-2024
                    //decimal num2 = (Person2.Member.membersData.MainMember.ExpiryDate - premiums.membersData.MainMember.EffectiveDate).Days;
                    //decimal num2 = (Person2.Member.membersData.MainMember.ExpiryDate - premiums.membersData.MainMember.EffectiveDate).Days + 1;
                    //num2 = num2 > 365 ? 365 : num2;
                    decimal num2 = 365;
                    //Changes by Kunal Endorsment Prem Issue End
                    decimal num3 = num2 / 365;
                    if (Discount != null)
                    {
                        premiums.membersData.Discount = ((Discount.ApplyOn == 1) ? Discount.DiscountPercent : ((Person2.DiscountType == 2) ? Discount.EndorsementDiscount : ((Person2.Member.membersData.MainMember.ClassId == Convert.ToInt32(_appSettings.ClassC)) ? Discount.DiscountPercentC : ((Person2.Member.membersData.MainMember.ClassId == Convert.ToInt32(_appSettings.ClassCBasic)) ? Discount.DiscountPercentCBasic : Discount.DiscountPercentCPlus))));
                        DiscountPercent = premiums.membersData.Discount.Value * 100;
                    }
                    if (declaration != null && declaration.Id > 0)
                    {
                        decimal num4 = memberPrices.NetPremium * num3;
                        decimal value = 1;
                        decimal? obj2 = ((Discount == null) ? new decimal?(default(decimal)) : premiums.membersData.Discount);
                        decimal value2 = num4 * Convert.ToDecimal((decimal?)value - obj2);
                        premiums.membersData.GrossPremium = value2;
                        if (Discount != null && Discount.Id > 0)
                        {
                            _svcBusiness.UpdateDiscountMember(Person2.Member.membersData.MainMember.Id, premiums.membersData.Discount.Value * 100m);
                        }
                    }
                    else
                    {
                        decimal num5 = memberPrices.NetPremium * num3;
                        decimal value = 1;
                        decimal? obj3 = ((Discount == null) ? new decimal?(default(decimal)) : premiums.membersData.Discount);
                        decimal value3 = num5 * Convert.ToDecimal((decimal?)value - obj3);
                        premiums.membersData.GrossPremium = value3;
                        if (Discount != null && Discount.Id > 0)
                        {
                            _svcBusiness.UpdateDiscountMember(Person2.Member.membersData.MainMember.Id, premiums.membersData.Discount.Value * 100m);
                        }
                    }
                    premiums.membersData.Vat = premiums.membersData.GrossPremium * (decimal?)0.15;
                    foreach (MembersData dependent in Person2.Member.dependMember)
                    {
                        sub = new Subjects();
                        subs = new List<Subjects>();
                        planHistory = new PlanHistory();
                        decimal num6 = 1m;
                        int planId2 = _svcBusiness.GetPlanId(dependent.MainMember.PolicyId);
                        MembersData membersData = new MembersData();
                        nationalityMapping = new NationalityMapping();
                        nationalityMapping = _svcBusiness.GetEskaNationalityByEska(dependent.MainMember.NationalityCode);

                        sub = _svcBusiness.LoadMembersubject(dependent.MainMember.Id);

                        MemberPrices memberPrices2 = new MemberPrices();
                        if (planId != Convert.ToInt32(_appSettings.PlanCode) && (productions != null && productions.DocumentType == 2))
                        {
                            planHistory = _svcBusiness.LoadPlanHistory(planId2, nationalityMapping.ClassId.Value, sub.InsuranceClassCode != null ? (int)sub.InsuranceClassCode : 0);
                            sub.ClassId = planHistory.ClassId;
                            subs.Add(sub);
                            dependent.MainMember.ClassId = planHistory.ClassId;
                            subs = _svcBusiness.InsertUpdateMembers(subs, _appSettings.Connection).Item1;

                            memberPrices2 = PricingClass.MemberPrice(sub, planId2, _appSettings.EskaConnection);
                            if (memberPrices2.NetPremium == 0)
                            {
                                validation.lsError.Add(new ErrorMembers
                                {
                                    membersData = new Princible
                                    {
                                        NationalId = dependent.MainMember.NationalId,
                                        DateOfBirth = dependent.MainMember.DateOfBirth.ToString(),
                                        Error = "Member Premium is not found",
                                        IsSuccess = false,
                                        Sponsor = dependent.MainMember.Princible,
                                    }
                                });
                                continue;
                            }

                        }
                        else
                        {
                            memberPrices2 = PricingClass.MemberPriceClass(sub, planId2, (int)Person2.Member.membersData.MainMember.InsuranceClassCode, nationalityMapping.Id, _appSettings.PlanCode, _appSettings.EskaConnection,
                                 obj[obj.Count - 1].P_NOOFNONSAUDIPRINCMEM, obj[obj.Count - 1].P_NOOFSAUDIPRINCMEM, obj[obj.Count - 1].P_NOOFSAUDIDEPMEM, obj[obj.Count - 1].P_NOOFNONSAUDIDEPMEM);
                            if (memberPrices2.NetPremium == 0)
                            {
                                validation.lsError.Add(new ErrorMembers
                                {
                                    membersData = new Princible
                                    {
                                        NationalId = dependent.MainMember.NationalId,
                                        DateOfBirth = dependent.MainMember.DateOfBirth.ToString(),
                                        Error = "Member Premium is not found",
                                        IsSuccess = false,
                                        Sponsor = dependent.MainMember.Princible,
                                    }
                                });
                                continue;
                            }
                            sub.ClassId = memberPrices2.Subjects.ClassId;
                            decimal AdditionalPremium = (productions != null && productions.DocumentType == 2) ? (decimal)0 : (decimal)memberPrices2.Subjects.AdditionalPremium;
                            sub.AdditionalPremium = AdditionalPremium;
                            subs.Add(sub);
                            dependent.MainMember.ClassId = memberPrices2.Subjects.ClassId;
                            dependent.MainMember.AdditionalPremium = AdditionalPremium;
                            subs = _svcBusiness.InsertUpdateMembers(subs, _appSettings.Connection).Item1;

                        }

                        //Changes by Kunal Class Implementation End 09-07-2024
                        membersData.MainMember = dependent.MainMember;
                        if (Discount != null)
                        {
                            membersData.Discount = ((Discount.ApplyOn == 1) ? Discount.DiscountPercent : ((Person2.DiscountType == 2) ? Discount.EndorsementDiscount : ((dependent.MainMember.ClassId == Convert.ToInt32(_appSettings.ClassC)) ? Discount.DiscountPercentC : ((dependent.MainMember.ClassId == Convert.ToInt32(_appSettings.ClassCBasic)) ? Discount.DiscountPercentCBasic : Discount.DiscountPercentCPlus))));
                            DiscountPercent = membersData.Discount.Value * 100;
                        }
                        if (declaration != null && declaration.Id > 0)
                        {
                            string text = Person2.Member.membersData.MainMember.ClassId.Value.ToString();
                            decimal netPremium = memberPrices2.NetPremium;
                            decimal value4 = 1;
                            decimal? obj4 = ((Discount == null) ? new decimal?(default(decimal)) : membersData.Discount);
                            decimal value5 = netPremium * Convert.ToDecimal((decimal?)value4 - obj4);
                            membersData.GrossPremium = value5;
                            if (Discount != null && Discount.Id > 0)
                            {
                                _svcBusiness.UpdateDiscountMember(dependent.MainMember.Id, membersData.Discount.Value * 100);
                            }
                        }
                        else
                        {
                            decimal netPremium2 = memberPrices2.NetPremium;
                            decimal value4 = 1;
                            decimal? obj5 = ((Discount == null) ? new decimal?(default(decimal)) : membersData.Discount);
                            decimal value6 = netPremium2 * Convert.ToDecimal((decimal?)value4 - obj5);
                            membersData.GrossPremium = value6;
                            if (Discount != null && Discount.Id > 0)
                            {
                                _svcBusiness.UpdateDiscountMember(dependent.MainMember.Id, membersData.Discount.Value * 100);
                            }
                        }
                        membersData.Vat = membersData.GrossPremium * (decimal?)0.15m;
                        premiums.dependMember.Add(membersData);
                    }
                    validation.LsSuccessMembers.Add(premiums);
                }
            }
            catch (Exception ex)
            {
                validation.status = false;
                validation.ResponseDate = DateTime.Now;
                validation.httpStatusCode = HttpStatusCode.InternalServerError;
                validation.message = ex.Message;
            }
            return validation;
        }

        [HttpPost]
        [Route("InsertPolicyHolder")]
        public PolicyHolderOutput InsertPolicyHolder([FromBody] PolicyHolders Holder)
        {
            PolicyHolderOutput holderOutput = new PolicyHolderOutput();
            if (Holder != null && !string.IsNullOrEmpty(Holder.CommercialNo))
            {
                try
                {
                    CRClaims cRClaims = new CRClaims();
                    cRClaims = GETCRClaim.ValidateRenewal(Holder.CommercialNo, _appSettings.EskaConnection);
                    if (cRClaims != null && !string.IsNullOrEmpty(cRClaims.CLAIMS))
                    {
                        decimal amount = Convert.ToDecimal(cRClaims.CLAIMS);
                        decimal premium = Convert.ToDecimal(cRClaims.TOTAL);
                        decimal Ratio = default(decimal);
                        Ratio = amount / premium * 100m;
                        DateTime expirydate = Convert.ToDateTime(cRClaims.EXPIRY);
                        if (Ratio >= Convert.ToDecimal(_appSettings.LossRatio))
                        {
                            //holderOutput.message = "Loss Ratio Exceeded or equal " + _appSettings.LossRatio + " , Kindly contact UW team of AJT";
                            holderOutput.message = "Loss Ratio is <" + Ratio + "%>. Please connect with Medical Underwriting Team/يوجد معدل خسائر بنسبة <" + Ratio + "%>.  يرجى مراجعة القسم الطبي";
                            holderOutput.ResponseDate = expirydate;
                            holderOutput.httpStatusCode = HttpStatusCode.Forbidden;
                            holderOutput.status = false;
                            return holderOutput;
                        }
                    }
                    PolicyHolders holder = _svcBusiness.InsertUpdatePolicyHolder(Holder);
                    if (holder != null && holder.Id > 0)
                    {
                        holderOutput.policyHolders = new PolicyHolders();
                        holderOutput.policyHolders = holder;
                        holderOutput.httpStatusCode = HttpStatusCode.OK;
                        holderOutput.status = true;
                        holderOutput.ResponseDate = DateTime.Now;
                        holderOutput.message = "";
                    }
                }
                catch (Exception ex)
                {
                    holderOutput.httpStatusCode = HttpStatusCode.InternalServerError;
                    holderOutput.status = false;
                    holderOutput.ResponseDate = DateTime.Now;
                    holderOutput.message = ex.Message;
                }
            }
            else
            {
                holderOutput.httpStatusCode = HttpStatusCode.NoContent;
                holderOutput.status = false;
                holderOutput.ResponseDate = DateTime.Now;
                holderOutput.message = "Object is null";
            }
            return holderOutput;
        }

        [HttpPost]
        [Route("CheckPolicyHolderValidation")]
        public CORE.DTOs.APIs.Unified_Response.Results CheckPolicyHolderValidation([FromBody] CheckHolderValidation checkHolder)
        {
            string error = string.Empty;
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            CRClaims cRClaims = new CRClaims();
            cRClaims = GETCRClaim.ValidateRenewal(checkHolder.CRNational, _appSettings.EskaConnection);
            if (cRClaims != null && !string.IsNullOrEmpty(cRClaims.CLAIMS))
            {
                decimal amount = Convert.ToDecimal(cRClaims.CLAIMS);
                decimal premium = Convert.ToDecimal(cRClaims.TOTAL);
                decimal Ratio = default(decimal);
                Ratio = amount / premium * 100m;
                DateTime expirydate = Convert.ToDateTime(cRClaims.EXPIRY);
                if (Ratio >= Convert.ToDecimal(_appSettings.LossRatio))
                {
                    //results.message = "Loss Ratio Exceeded or equal " + _appSettings.LossRatio + " , Kindly contact UW team of AJT";
                    results.message = "Loss Ratio is <" + Ratio + "%>. Please connect with Medical Underwriting Team/يوجد معدل خسائر بنسبة <" + Ratio + "%>.  يرجى مراجعة القسم الطبي";
                    results.ResponseDate = DateTime.Now;
                    results.httpStatusCode = HttpStatusCode.Forbidden;
                    results.status = false;
                    return results;
                }
                //if (Math.Abs((expirydate - DateTime.Now).TotalDays) > 60) -- logic changed by Abhijit sir on 26012025
                if ((expirydate - DateTime.Now).TotalDays > 60)
                {
                    results.message = "There is an active Policy";
                    results.ResponseDate = DateTime.Now;
                    results.httpStatusCode = HttpStatusCode.Forbidden;
                    results.status = false;
                    return results;
                }
                results.message = "";
                results.ResponseDate = DateTime.Now;
                results.httpStatusCode = HttpStatusCode.OK;
                results.status = true;
                return results;
            }
            if (checkHolder.UserId.HasValue)
            {
                (bool, string) checkHolders = _svcBusiness.ValidatePolicyHolder(checkHolder.CRNational, checkHolder.UserId.Value);
                if (!checkHolders.Item1)
                {
                    results.message = checkHolders.Item2;
                    results.ResponseDate = DateTime.Now;
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.status = false;
                }
                else
                {
                    results.message = "";
                    results.ResponseDate = DateTime.Now;
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.status = true;
                }
            }
            else
            {
                results.message = "";
                results.ResponseDate = DateTime.Now;
                results.httpStatusCode = HttpStatusCode.OK;
                results.status = true;
            }
            return results;
        }

        [HttpPost]
        [Route("AddDeclarations")]
        public CORE.DTOs.APIs.Unified_Response.Results AddDeclarations([FromBody] MembersDeclarations declarations)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            try
            {
                if (_svcBusiness.AddDeclarations(declarations))
                {
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.status = true;
                    results.ResponseDate = DateTime.Now;
                    results.message = "";
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.NotFound;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = "Declaration Faild";
                }
            }
            catch (Exception ex)
            {
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.status = false;
                results.ResponseDate = DateTime.Now;
                results.message = ex.Message;
            }
            return results;
        }

        [HttpPost]
        [Route("LoadDecleration")]
        public LoadDeclerationOutput LoadDecleration([FromBody] LoadDecleration loadDecleration)
        {
            LoadDeclerationOutput loadDeclerationOutput = new LoadDeclerationOutput();
            loadDeclerationOutput.MembersDeclarations = new List<MembersDeclarations>();
            loadDeclerationOutput.MembersDeclarations = _svcBusiness.LoadDecleration(loadDecleration);
            if (loadDeclerationOutput.MembersDeclarations != null && loadDeclerationOutput.MembersDeclarations.Count > 0)
            {
                loadDeclerationOutput.status = true;
                loadDeclerationOutput.httpStatusCode = HttpStatusCode.OK;
                loadDeclerationOutput.ResponseDate = DateTime.Now;
            }
            else
            {
                loadDeclerationOutput.status = false;
                loadDeclerationOutput.httpStatusCode = HttpStatusCode.InternalServerError;
                loadDeclerationOutput.ResponseDate = DateTime.Now;
            }
            return loadDeclerationOutput;
        }

        [HttpDelete]
        [Route("RemoveDeclarations")]
        public CORE.DTOs.APIs.Unified_Response.Results RemoveDeclarations([FromBody] LoadDecleration loadDecleration)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            try
            {
                if (_svcBusiness.RemoveDeclarations(loadDecleration.MemberId.Value))
                {
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.status = true;
                    results.ResponseDate = DateTime.Now;
                    results.message = "";
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.NotFound;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = "Deleting Faild";
                }
            }
            catch (Exception ex)
            {
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.status = false;
                results.ResponseDate = DateTime.Now;
                results.message = ex.Message;
            }
            return results;
        }

        [HttpDelete]
        [Route("RemoveDraftMember")]
        public CORE.DTOs.APIs.Unified_Response.Results RemoveDraftMember([FromBody] int MemberId)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            try
            {
                if (_svcBusiness.RemoveDraftMember(MemberId, _appSettings.EskaConnection))
                {
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.status = true;
                    results.ResponseDate = DateTime.Now;
                    results.message = "";
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.NotFound;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = "Deleting Faild";
                }
            }
            catch (Exception ex)
            {
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.status = false;
                results.ResponseDate = DateTime.Now;
                results.message = ex.Message;
            }
            return results;
        }

        [HttpDelete]
        [Route("RemoveMember")]
        public CORE.DTOs.APIs.Unified_Response.Results RemoveMember([FromBody] int MemberId)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            try
            {
                if (_svcBusiness.RemoveMember(MemberId))
                {
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.status = true;
                    results.ResponseDate = DateTime.Now;
                    results.message = "";
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.NotFound;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = "Deleting Faild";
                }
            }
            catch (Exception ex)
            {
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.status = false;
                results.ResponseDate = DateTime.Now;
                results.message = ex.Message;
            }
            return results;
        }

        [HttpPost]
        [Route("Watheq")]
        public HolderInfos Watheq([FromBody] WatheqFilter obj)
        {
            HolderInfos holderInfos = new HolderInfos();
            CRDetails check = new CRDetails();
            bool checkHolder = _svcBusiness.CheckPolicyHolder(obj.CR, obj.Product, 0);
            if (Productions.validateHolder(obj.CR, obj.Product, _appSettings.EskaConnection) == 0)
            {
                if (checkHolder)
                {
                    check = _svcBusiness.LoadCRInfo(obj.CR);
                    if (check != null && check.ID > 0)
                    {
                        holderInfos.CRDetails = check;
                        holderInfos.status = true;
                        holderInfos.httpStatusCode = HttpStatusCode.OK;
                        holderInfos.ResponseDate = DateTime.Now;
                    }
                    else
                    {
                        using HttpClient client = new HttpClient();
                        client.DefaultRequestHeaders.Add("APIKey", _appSettings.WathqKey);
                        client.BaseAddress = new Uri(_appSettings.WathqBaseURL);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        Task<HttpResponseMessage> responseTask = client.GetAsync("info/" + obj.CR);
                        responseTask.Wait();
                        HttpResponseMessage responsePost = responseTask.Result;
                        if (responsePost.IsSuccessStatusCode)
                        {
                            CRDetailsResponse crDetails = new CRDetailsResponse();
                            crDetails = JsonConvert.DeserializeObject<CRDetailsResponse>(responsePost.Content.ReadAsStringAsync().Result);
                            CRDetails crDetailsLog = new CRDetails();
                            crDetailsLog.CRNUMBER = crDetails.crNumber;
                            crDetailsLog.CRNAME = crDetails.crName;
                            crDetailsLog.CRENTITYNO = crDetails.crEntityNumber;
                            crDetailsLog.ISSUEDATE = crDetails.issueDate;
                            crDetailsLog.EXPIRYDATE = crDetails.expiryDate;
                            crDetailsLog.CRMAINNUMBER = crDetails.crMainNumber;
                            crDetailsLog.BUSINESSTYPE_ID = crDetails.businessType.id;
                            crDetailsLog.BUSINESSTYP_NAME = crDetails.businessType.name;
                            crDetailsLog.FISCALYEAR_MONTH = ((crDetails.fiscalYear == null) ? null : Convert.ToString(crDetails.fiscalYear.month));
                            crDetailsLog.FISCALYEAR_DAY = ((crDetails.fiscalYear == null) ? null : Convert.ToString(crDetails.fiscalYear.day));
                            crDetailsLog.STATUS_ID = ((crDetails.status == null) ? null : crDetails.status.id);
                            crDetailsLog.STATUS_NAME = ((crDetails.status == null) ? null : crDetails.status.name);
                            crDetailsLog.STATUS_NAME_EN = ((crDetails.status == null) ? null : crDetails.status.nameEn);
                            crDetailsLog.LOCATION_ID = ((crDetails.location == null) ? null : crDetails.location.id);
                            crDetailsLog.LOCATION_NAME = ((crDetails.location == null) ? null : crDetails.location.name);
                            crDetailsLog.ACTIVITY_DESC = ((crDetails.activities == null) ? null : crDetails.activities.description);
                            crDetailsLog.COMPANY_PERIOD = ((crDetails.company == null) ? null : crDetails.company.period);
                            crDetailsLog.COMPANY_START_DATE = ((crDetails.company == null) ? null : crDetails.company.startDate);
                            crDetailsLog.COMPANY_END_DATE = ((crDetails.company == null) ? null : crDetails.company.endDate);
                            crDetailsLog.CANCELLATION_DATE = ((crDetails.cancellation == null) ? null : crDetails.cancellation.date);
                            crDetailsLog.CONCELLATION_REASON = ((crDetails.cancellation == null) ? null : crDetails.cancellation.reason);
                            if (crDetails.activities != null && crDetails.activities.isic.Count > 0)
                            {
                                crDetailsLog.ACTIVITY_ISIC_ID = crDetails.activities.isic[0].id;
                                crDetailsLog.ACTIVITY_ISIC_NAME = crDetails.activities.isic[0].name;
                                crDetailsLog.ACTIVITY_ISIC_NAME_EN = crDetails.activities.isic[0].nameEn;
                            }
                            if (crDetails.activities != null && crDetails.activities.isic.Count > 1)
                            {
                                crDetailsLog.ACTIVITY_ISIC_ID2 = crDetails.activities.isic[1].id;
                                crDetailsLog.ACTIVITY_ISIC_NAME2 = crDetails.activities.isic[1].name;
                                crDetailsLog.ACTIVITY_ISIC_NAME_EN2 = crDetails.activities.isic[1].nameEn;
                            }
                            crDetailsLog.CREATEDBY = "SME";
                            crDetailsLog.CREATED_DATE = DateTime.Now;
                            crDetailsLog.IS_REUSED = Convert.ToBoolean(_appSettings.CRNumReUse);
                            _svcBusiness.insertCRInfo(crDetailsLog);
                            holderInfos.CRDetails = crDetailsLog;
                            holderInfos.status = true;
                            holderInfos.httpStatusCode = HttpStatusCode.OK;
                            holderInfos.ResponseDate = DateTime.Now;
                        }
                        else
                        {
                            holderInfos.status = true;
                            holderInfos.httpStatusCode = HttpStatusCode.OK;
                            holderInfos.ResponseDate = DateTime.Now;
                            holderInfos.message = "Watheq Error";
                        }
                    }
                }
                else
                {
                    holderInfos.status = false;
                    holderInfos.message = "Institution is already has active Quotation or Policy by user : " + _svcBusiness.GetUserNameByCR(obj.CR);
                    holderInfos.httpStatusCode = HttpStatusCode.InternalServerError;
                    holderInfos.ResponseDate = DateTime.Now;
                }
            }
            else
            {
                holderInfos.status = false;
                holderInfos.message = "Institution is already has active Quotation or Policy by user : " + _svcBusiness.GetUserNameByCR(obj.CR);
                holderInfos.httpStatusCode = HttpStatusCode.InternalServerError;
                holderInfos.ResponseDate = DateTime.Now;
            }
            return holderInfos;
        }

        [HttpPost]
        [Route("Watheq1")]
        public HolderInfos Watheq1([FromBody] WatheqFilter obj)
        {
            HolderInfos holderInfos = new HolderInfos();
            CRDetails check = new CRDetails();
            bool checkHolder = _svcBusiness.CheckPolicyHolder(obj.CR, obj.Product, obj.Id);
            if (Productions.validateHolder(obj.CR, obj.Product, _appSettings.EskaConnection) == 0)
            {
                if (!checkHolder)
                {
                    holderInfos.status = false;
                    holderInfos.message = "Institution is already has active Quotation or Policy by user : " + _svcBusiness.GetUserNameByCR(obj.CR);
                    holderInfos.httpStatusCode = HttpStatusCode.InternalServerError;
                    holderInfos.ResponseDate = DateTime.Now;
                }
            }
            else
            {
                holderInfos.status = false;
                holderInfos.message = "Institution is already has active Quotation or Policy by user : " + _svcBusiness.GetUserNameByCR(obj.CR);
                holderInfos.httpStatusCode = HttpStatusCode.InternalServerError;
                holderInfos.ResponseDate = DateTime.Now;
            }
            return holderInfos;
        }

        [HttpPost]
        [Route("PosToFinance")]
        public CORE.DTOs.APIs.Unified_Response.Results PosToFinance(PolicyPaymentInput input)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            SMECoreServices sMECoreServices = new SMECoreServices(_appSettings, _environment, _svcBusiness, _tracker, _CoreServices, _process, _User);
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            try
            {

                Production policy = _svcBusiness.getDocumentByKey(input.Key);

                EndpointAddress endpointAddress = new EndpointAddress(_appSettings.ESKAProduction);
                //ESKAMedicalProduction.PRODUCTIONClient pRODUCTION = new ESKAMedicalProduction.PRODUCTIONClient(ESKAMedicalProduction.PRODUCTIONClient.EndpointConfiguration.BasicHttpBinding_IPRODUCTION, endpointAddress);
                ESKAMedicalProduction.PRODUCTIONClient pRODUCTION = new ESKAMedicalProduction.PRODUCTIONClient(ESKAMedicalProduction.PRODUCTIONClient.EndpointConfiguration.BasicHttpBinding_IPRODUCTION);
                ESKAMedicalProduction.LoadPolicyInstallmentsRequest loadPolicyInstallmentsRequest = new ESKAMedicalProduction.LoadPolicyInstallmentsRequest();
                //ESKAMedicalProduction.LoadPolicyInstallmentsResponse loadPolicyInstallmentsResponse = new ESKAMedicalProduction.LoadPolicyInstallmentsResponse();

                loadPolicyInstallmentsRequest.PolicyID = policy.EskaId.Value;

                Task<ESKAMedicalProduction.LoadPolicyInstallmentsResponse> loadPolicyInstallmentsResponse = pRODUCTION.LoadPolicyInstallmentsAsync(policy.EskaId.Value);

                if (loadPolicyInstallmentsResponse != null && loadPolicyInstallmentsResponse.Result.LoadPolicyInstallmentsResult.Installments.Length > 0)
                {
                    ESKAMedicalProduction.INSTALLMENTS_DOL iNSTALLMENTS_DOL = new ESKAMedicalProduction.INSTALLMENTS_DOL();
                    iNSTALLMENTS_DOL = loadPolicyInstallmentsResponse.Result.LoadPolicyInstallmentsResult.Installments[0];

                    ESKAMedicalProduction.InsertPaymentMethodRequest insertpaymentRequest = new ESKAMedicalProduction.InsertPaymentMethodRequest();
                    //ESKAMedicalProduction.InsertPaymentMethodResponse insertPaymentResponse = new ESKAMedicalProduction.InsertPaymentMethodResponse();

                    insertpaymentRequest.InstallmentID = iNSTALLMENTS_DOL.ID;
                    insertpaymentRequest.PolicyID = policy.EskaId.Value;
                    insertpaymentRequest.MerchantNumber = "0";
                    insertpaymentRequest.PaymentMethod = 1;

                    Task<ESKAMedicalProduction.InsertPaymentMethodResponse> insertPaymentResponse = pRODUCTION.InsertPaymentMethodAsync(insertpaymentRequest.PolicyID, insertpaymentRequest.InstallmentID, insertpaymentRequest.PaymentMethod, insertpaymentRequest.MerchantNumber);
                    if (insertPaymentResponse != null && insertPaymentResponse.Result.InsertPaymentMethodResult.status._StatusCode == 1)
                    {
                        EndpointAddress endpointAddressPolicy = new EndpointAddress(_appSettings.ESKAPolicies);
                        POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                        CreateVoucherAndPostToFinancialRequest toFinancialRequest = new CreateVoucherAndPostToFinancialRequest();
                        //CreateVoucherAndPostToFinancialResponse toFinancialResponse = new CreateVoucherAndPostToFinancialResponse();
                        toFinancialRequest.ID = policy.EskaId.Value;
                        toFinancialRequest.CREATED_BY = "APIHub";
                        Task<EskaPolicies.CreateVoucherAndPostToFinancialResponse> toFinancialResponse = client.CreateVoucherAndPostToFinancialAsync(toFinancialRequest);

                        if (toFinancialResponse.Result.CreateVoucherAndPostToFinancialResult.Status.StatusCode == 1)
                        {
                            results.httpStatusCode = HttpStatusCode.OK;
                            results.ResponseDate = DateTime.Now;
                            results.status = true;
                        }
                        else
                        {
                            results.httpStatusCode = HttpStatusCode.InternalServerError;
                            results.ResponseDate = DateTime.Now;
                            results.status = false;
                            results.message = toFinancialResponse.Result.CreateVoucherAndPostToFinancialResult.Status.Reason;
                        }

                        //PostPolicyRequest postPolicyRequest = new PostPolicyRequest();
                        //PostPolicyResponse postPolicyResponse = new PostPolicyResponse();
                        //PostPolicyOutput postPolicyOutput = new PostPolicyOutput();
                        //INS_TRANSACTIONS_DOL[] iNS_TRANSACTIONS_DOLs = null;
                        //POLICY_FEES_DOL[] pOLICY_FEES_DOLs = null;
                        //POLICYClient.CacheSetting = CacheSetting.AlwaysOn;

                        //postPolicyRequest.ID = policy.EskaId.Value;
                        //postPolicyRequest.CREATED_BY = "APIHub";
                        //postPolicyRequest.PolicySegment = policy.EskaSegment;
                        ////postPolicyRequest.lcFeesAmount = 0;
                        ////postPolicyRequest.lcFeesPercentage = 0;
                        ////postPolicyRequest.lcFeesID = 0;
                        ////postPolicyRequest.PolicyPremium = 0;

                        //postPolicyResponse = client.PostPolicy(postPolicyRequest);

                        //if (postPolicyResponse.PostPolicyResult.Status.StatusCode == 1)
                        //{
                        //    results.httpStatusCode = HttpStatusCode.OK;
                        //    results.ResponseDate = DateTime.Now;
                        //    results.status = true;
                        //}
                        //else
                        //{
                        //    results.httpStatusCode = HttpStatusCode.InternalServerError;
                        //    results.ResponseDate = DateTime.Now;
                        //    results.status = false;
                        //    results.message = postPolicyResponse.PostPolicyResult.Status.Reason;
                        //}
                    }
                    else
                    {
                        results.httpStatusCode = HttpStatusCode.InternalServerError;
                        results.ResponseDate = DateTime.Now;
                        results.status = false;
                        results.message = insertPaymentResponse.Result.InsertPaymentMethodResult.status._Reason;
                    }
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.ResponseDate = DateTime.Now;
                    results.status = false;
                    results.message = "Payment method Update Error";

                }
                ErrorHandler.WriteLog("PosToFinance", "Execution Completed", string.Empty, string.Empty);

            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, string.Empty, string.Empty, "WriteLog");
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.ResponseDate = DateTime.Now;
                results.status = false;
                results.message = "Payment method Update Error";
            }
            return results;
        }

        [HttpPost]
        [Route("PosToFinanceSME")]
        public CORE.DTOs.APIs.Unified_Response.Results PosToFinanceSME(PolicyPaymentInput input)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            SMECoreServices sMECoreServices = new SMECoreServices(_appSettings, _environment, _svcBusiness, _tracker, _CoreServices, _process, _User);
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            try
            {

                Production policy = _svcBusiness.getDocumentByKey(input.Key);
                finalSaveResponse = sMECoreServices.Post(policy, input);
                if (finalSaveResponse != null && finalSaveResponse.status)
                {
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.ResponseDate = DateTime.Now;
                    results.status = true;
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.ResponseDate = DateTime.Now;
                    results.status = false;
                    results.message = finalSaveResponse.errorMessage;

                }
                ErrorHandler.WriteLog("PosToFinance", "Execution Completed", JsonConvert.SerializeObject(input), JsonConvert.SerializeObject(finalSaveResponse));
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, string.Empty, string.Empty, "WriteLog");
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.ResponseDate = DateTime.Now;
                results.status = false;
                results.message = "Payment method Update Error";
            }
            return results;
        }
        [HttpPost]
        [Route("PosToFinanceBankSME")]
        public CORE.DTOs.APIs.Unified_Response.Results PosToFinanceBankSME(PolicyBankPaymentInput input)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            SMECoreServices sMECoreServices = new SMECoreServices(_appSettings, _environment, _svcBusiness, _tracker, _CoreServices, _process, _User);
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            try
            {

                Production policy = _svcBusiness.getDocumentByKey(input.Key);
                if (policy.Status == 9)
                {
                    results.httpStatusCode = HttpStatusCode.Forbidden;
                    results.ResponseDate = DateTime.Now;
                    results.status = false;
                    results.message = "Policy is already posted to Finance";
                    return results;
                }
                finalSaveResponse = sMECoreServices.PostToBank(policy, input);
                if (finalSaveResponse != null && finalSaveResponse.status)
                {
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.ResponseDate = DateTime.Now;
                    results.status = true;
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.ResponseDate = DateTime.Now;
                    results.status = false;
                    results.message = finalSaveResponse.errorMessage;

                }
                ErrorHandler.WriteLog("PosToFinance", "Execution Completed", JsonConvert.SerializeObject(input), JsonConvert.SerializeObject(finalSaveResponse));
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, string.Empty, string.Empty, "WriteLog");
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.ResponseDate = DateTime.Now;
                results.status = false;
                results.message = "Payment method Update Error";
            }
            return results;
        }
        [HttpPost]
        [Route("PosToFinancePayfortSME")]
        public CORE.DTOs.APIs.Unified_Response.Results PosToFinancePayfortSME(PolicyBankPaymentInput input)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            SMECoreServices sMECoreServices = new SMECoreServices(_appSettings, _environment, _svcBusiness, _tracker, _CoreServices, _process, _User);
            FinalSaveResponse finalSaveResponse = new FinalSaveResponse();
            try
            {
                Production policy = _svcBusiness.getDocumentByKey(input.Key);
                // Production policy = _svcBusiness.getDocumentByPolicyNo(input.Policyno);
                if (policy.Status == 9)
                {
                    results.httpStatusCode = HttpStatusCode.Forbidden;
                    results.ResponseDate = DateTime.Now;
                    results.status = false;
                    results.message = "Policy is already posted to Finance";
                    return results;
                }
                finalSaveResponse = sMECoreServices.PostToPayfort(policy, input);
                if (finalSaveResponse != null && finalSaveResponse.status)
                {
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.ResponseDate = DateTime.Now;
                    results.status = true;
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.ResponseDate = DateTime.Now;
                    results.status = false;
                    results.message = finalSaveResponse.errorMessage;

                }
                ErrorHandler.WriteLog("PosToFinancePayfortSME", "Execution Completed", JsonConvert.SerializeObject(input), JsonConvert.SerializeObject(finalSaveResponse));
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, string.Empty, string.Empty, "WriteLog");
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.ResponseDate = DateTime.Now;
                results.status = false;
                results.message = "Payment method Update Error";
            }
            return results;
        }
        [HttpGet]
        [Route("GetPolicyByPolicyno")]
        public List<Production> GetPolicyByPolicyno([FromQuery] string policyno)
        {
            List<Production> policy = _svcBusiness.getDocumentByPolicyNo(policyno);
            return policy;
        }

        [HttpPost]
        [Route("PosToFinanceById")]
        public CORE.DTOs.APIs.Unified_Response.Results PosToFinanceById(PolicyPaymentByIdInput input)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            try
            {
                Production policy = _svcBusiness.getDocumentByKey(input.Key);
                EndpointAddress endpointAddress = new EndpointAddress(_appSettings.ESKAProduction);
                //ESKAMedicalProduction.PRODUCTIONClient pRODUCTION = new ESKAMedicalProduction.PRODUCTIONClient(ESKAMedicalProduction.PRODUCTIONClient.EndpointConfiguration.BasicHttpBinding_IPRODUCTION, endpointAddress);
                ESKAMedicalProduction.PRODUCTIONClient pRODUCTION = new ESKAMedicalProduction.PRODUCTIONClient(ESKAMedicalProduction.PRODUCTIONClient.EndpointConfiguration.BasicHttpBinding_IPRODUCTION);
                //ESKAMedicalProduction.LoadPolicyInstallmentsRequest loadPolicyInstallmentsRequest = new ESKAMedicalProduction.LoadPolicyInstallmentsRequest();
                //ESKAMedicalProduction.LoadPolicyInstallmentsResponse loadPolicyInstallmentsResponse = new ESKAMedicalProduction.LoadPolicyInstallmentsResponse();

                //loadPolicyInstallmentsRequest.PolicyID = policy.EskaId.Value;

                Task<ESKAMedicalProduction.LoadPolicyInstallmentsResponse> loadPolicyInstallmentsResponse = pRODUCTION.LoadPolicyInstallmentsAsync(policy.EskaId.Value);

                if (loadPolicyInstallmentsResponse != null && loadPolicyInstallmentsResponse.Result.LoadPolicyInstallmentsResult.Installments.Length > 0)
                {
                    ESKAMedicalProduction.INSTALLMENTS_DOL iNSTALLMENTS_DOL = new ESKAMedicalProduction.INSTALLMENTS_DOL();
                    iNSTALLMENTS_DOL = loadPolicyInstallmentsResponse.Result.LoadPolicyInstallmentsResult.Installments[0];

                    ESKAMedicalProduction.InsertPaymentMethodRequest insertpaymentRequest = new ESKAMedicalProduction.InsertPaymentMethodRequest();
                    //ESKAMedicalProduction.InsertPaymentMethodResponse insertPaymentResponse = new ESKAMedicalProduction.InsertPaymentMethodResponse();

                    insertpaymentRequest.InstallmentID = iNSTALLMENTS_DOL.ID;
                    insertpaymentRequest.PolicyID = policy.EskaId.Value;
                    insertpaymentRequest.MerchantNumber = "0";
                    insertpaymentRequest.PaymentMethod = 1;

                    Task<ESKAMedicalProduction.InsertPaymentMethodResponse> insertPaymentResponse = pRODUCTION.InsertPaymentMethodAsync(insertpaymentRequest.PolicyID, insertpaymentRequest.InstallmentID, insertpaymentRequest.PaymentMethod, insertpaymentRequest.MerchantNumber);
                    if (insertPaymentResponse != null && insertPaymentResponse.Result.InsertPaymentMethodResult.status._StatusCode == 1)
                    {
                        EndpointAddress endpointAddressPolicy = new EndpointAddress(_appSettings.ESKAPolicies);
                        POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                        CreateVoucherAndPostToFinancialRequest toFinancialRequest = new CreateVoucherAndPostToFinancialRequest();
                        //CreateVoucherAndPostToFinancialResponse toFinancialResponse = new CreateVoucherAndPostToFinancialResponse();
                        toFinancialRequest.ID = policy.EskaId.Value;
                        toFinancialRequest.CREATED_BY = "APIHub";
                        Task<EskaPolicies.CreateVoucherAndPostToFinancialResponse> toFinancialResponse = client.CreateVoucherAndPostToFinancialAsync(toFinancialRequest);

                        if (toFinancialResponse.Result.CreateVoucherAndPostToFinancialResult.Status.StatusCode == 1)
                        {
                            results.httpStatusCode = HttpStatusCode.OK;
                            results.ResponseDate = DateTime.Now;
                            results.status = true;
                        }
                        else
                        {
                            results.httpStatusCode = HttpStatusCode.InternalServerError;
                            results.ResponseDate = DateTime.Now;
                            results.status = false;
                            results.message = toFinancialResponse.Result.CreateVoucherAndPostToFinancialResult.Status.Reason;
                        }

                        //PostPolicyRequest postPolicyRequest = new PostPolicyRequest();
                        //PostPolicyResponse postPolicyResponse = new PostPolicyResponse();
                        //PostPolicyOutput postPolicyOutput = new PostPolicyOutput();
                        //INS_TRANSACTIONS_DOL[] iNS_TRANSACTIONS_DOLs = null;
                        //POLICY_FEES_DOL[] pOLICY_FEES_DOLs = null;
                        //POLICYClient.CacheSetting = CacheSetting.AlwaysOn;

                        //postPolicyRequest.ID = policy.EskaId.Value;
                        //postPolicyRequest.CREATED_BY = "APIHub";
                        //postPolicyRequest.PolicySegment = policy.EskaSegment;
                        ////postPolicyRequest.lcFeesAmount = 0;
                        ////postPolicyRequest.lcFeesPercentage = 0;
                        ////postPolicyRequest.lcFeesID = 0;
                        ////postPolicyRequest.PolicyPremium = 0;

                        //postPolicyResponse = client.PostPolicy(postPolicyRequest);

                        //if (postPolicyResponse.PostPolicyResult.Status.StatusCode == 1)
                        //{
                        //    results.httpStatusCode = HttpStatusCode.OK;
                        //    results.ResponseDate = DateTime.Now;
                        //    results.status = true;
                        //}
                        //else
                        //{
                        //    results.httpStatusCode = HttpStatusCode.InternalServerError;
                        //    results.ResponseDate = DateTime.Now;
                        //    results.status = false;
                        //    results.message = postPolicyResponse.PostPolicyResult.Status.Reason;
                        //}
                    }
                    else
                    {
                        results.httpStatusCode = HttpStatusCode.InternalServerError;
                        results.ResponseDate = DateTime.Now;
                        results.status = false;
                        results.message = insertPaymentResponse.Result.InsertPaymentMethodResult.status._Reason;
                    }
                }
                else
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.ResponseDate = DateTime.Now;
                    results.status = false;
                    results.message = "Payment method Update Error";
                }
            }
            catch (Exception ex)
            {
                results = new CORE.DTOs.APIs.Unified_Response.Results();
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.ResponseDate = DateTime.Now;
                results.status = false;
                results.message = "Financial Posting Error";
            }
            return results;
        }

        [HttpPost]
        [Route("GenerateEskaQuotation")]
        public CORE.DTOs.APIs.Unified_Response.Results GenerateEskaQuotation(PolicyPaymentInput input)
        {
            bool status = _svcBusiness.MarkasPushToEska(input.Key);
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            if (status)
            {
                results.httpStatusCode = HttpStatusCode.OK;
                results.ResponseDate = DateTime.Now;
                results.status = true;
            }
            else
            {
                results.httpStatusCode = HttpStatusCode.InternalServerError;
                results.ResponseDate = DateTime.Now;
                results.status = false;
                results.message = "Internal Error";
            }
            return results;
        }

        [HttpPost]
        [Route("BorderToIqama")]
        public CORE.DTOs.APIs.Unified_Response.Results BorderToIqama([FromBody] CorrectionInput input)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            //EndorsementInsertRequest policyInsertRequest = new EndorsementInsertRequest();
            //EndorsementInsertResponse policyInsertResponse = new EndorsementInsertResponse();

            Endoresement.POLICIES_DOL pOLICIES_DOL = new Endoresement.POLICIES_DOL();
            EndorsementOutput policyENDOutput = new EndorsementOutput();
            ENDORSEMENTClient clientEndorsment = new ENDORSEMENTClient(ENDORSEMENTClient.EndpointConfiguration.BasicHttpBinding_IENDORSEMENT);
            try
            {
                Production policyInfo = _svcBusiness.LoadProductionBySegment(input.PolicyNo).FirstOrDefault();
                if (policyInfo != null && policyInfo.PlanId > 0)
                {
                    pOLICIES_DOL.CreatedBy = "ECHANNEL";
                    pOLICIES_DOL.ModifiedBy = "ECHANNEL";
                    pOLICIES_DOL.CreationDate = DateTime.Now;
                    pOLICIES_DOL.ModificationDate = DateTime.Now;
                    pOLICIES_DOL.DocumentType = 1;
                    pOLICIES_DOL.PolicyType = 2;
                    pOLICIES_DOL.RenewalNo = 0;
                    pOLICIES_DOL.EndorsementNo = 0;
                    pOLICIES_DOL.APPLICANT_TYPE = 0;
                    pOLICIES_DOL.UWYear = DateTime.Now.Year;
                    pOLICIES_DOL.ReferenceDate = DateTime.Today.Date;
                    pOLICIES_DOL.IssueDate = DateTime.Today.Date;
                    pOLICIES_DOL.EffectiveDate = DateTime.Today.Date;
                    pOLICIES_DOL.ExpiryDate = policyInfo.ExpiryDate;
                    pOLICIES_DOL.DURATION = policyInfo.ExpiryDate.Year - pOLICIES_DOL.EffectiveDate.Year;
                    pOLICIES_DOL.DURATION_UNIT = 1;
                    pOLICIES_DOL.BusinessType = 2;
                    pOLICIES_DOL.CalculationType = 1;
                    pOLICIES_DOL.AccountedFor = 1;
                    pOLICIES_DOL.RenewalNo = 0;
                    pOLICIES_DOL.Notes = "ONLINE TAMEENI CORRCTION";
                    pOLICIES_DOL.IS_POSTED = 0;
                    pOLICIES_DOL.Exrate = 1m;
                    pOLICIES_DOL.PaymentID = 1L;
                    pOLICIES_DOL.EndorsementID = 4L;
                    pOLICIES_DOL.PlanID = policyInfo.PlanId.Value;
                    pOLICIES_DOL.PolicyHolderID = policyInfo.CustomerId;
                    pOLICIES_DOL.CurrencyCode = "SAR";
                    pOLICIES_DOL.CompanyID = 1;
                    pOLICIES_DOL.BranchID = 9;
                    pOLICIES_DOL.TpaType = 2L;
                    pOLICIES_DOL.BusinessChannel = 33633L;
                    pOLICIES_DOL.IS_CONVERTED = 0;
                    pOLICIES_DOL.APPROVAL_STATUS = 1;
                    pOLICIES_DOL.OriginalPolicyID = policyInfo.EskaId;
                    //policyInsertRequest.oPOLICIES_INPUT = pOLICIES_DOL;
                    //policyInsertRequest.PolicyID = Convert.ToInt32(policyInfo.EskaId);
                    Task<Endoresement.EndorsementOutput> policyInsertResponse = clientEndorsment.EndorsementInsertAsync(Convert.ToInt32(policyInfo.EskaId), pOLICIES_DOL);
                    policyENDOutput = policyInsertResponse.Result;
                    if (policyENDOutput.Status._Reason == "There's unposted endorsement, can't add new endorsement.")
                    {
                        results.status = false;
                        results.ResponseDate = DateTime.Now;
                        results.message = policyENDOutput.Status._Reason;
                        results.httpStatusCode = HttpStatusCode.NotAcceptable;
                    }
                    else if (policyENDOutput.Status._StatusCode == 1)
                    {
                        Endoresement.POLICIES_DOL policyOutputInfo = new Endoresement.POLICIES_DOL();
                        policyOutputInfo = policyENDOutput.oPolicy;
                        long endorsIds = policyOutputInfo.PolicyID;
                        List<long> ids = new List<long>();
                        long memberId = Productions.InsertEndoresement(policyInfo.EskaId.Value, endorsIds, input.BorderNo, input.members.NationalId, _appSettings.EskaIGeneralConnection);
                        ids.Add(memberId);
                        if (memberId > 0)
                        {
                            List<Subjects> subjects = new List<Subjects>();
                            subjects.Add(input.members);
                            _svcBusiness.InsertUpdateMembers(subjects, _appSettings.EskaConnection);
                            results.httpStatusCode = HttpStatusCode.OK;
                            results.status = true;
                            results.ResponseDate = DateTime.Now;
                            results.message = "";
                        }
                        else
                        {

                            //DeletePolicyDataRequest deletePolicyData = new DeletePolicyDataRequest();
                            //DeletePolicyDataResponse deletePolicyDataResponse = new DeletePolicyDataResponse();
                            DeletePolicy deletePolicy = new DeletePolicy();
                            EndpointAddress endpointAddressPolicy = new EndpointAddress(_appSettings.ESKAPolicies);
                            using (POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy))
                            {
                                //deletePolicyData.PolicyID = endorsIds;
                                Task<EskaPolicies.DeletePolicy> deletePolicyDataResponse = client.DeletePolicyDataAsync(endorsIds);
                                deletePolicy = deletePolicyDataResponse.Result;

                            }
                            results.httpStatusCode = HttpStatusCode.NoContent;
                            results.status = false;
                            results.ResponseDate = DateTime.Now;
                            results.message = "Border not exists";
                        }
                    }
                    return results;
                }
                results.status = false;
                results.ResponseDate = DateTime.Now;
                results.message = "policy number not exists";
                results.httpStatusCode = HttpStatusCode.NoContent;
                return results;
            }
            catch (Exception)
            {
                results.status = true;
                results.ResponseDate = DateTime.Now;
                results.message = "policy number not exists";
                results.httpStatusCode = HttpStatusCode.NoContent;
                return results;
            }
        }

        [HttpPost]
        [Route("SyncEskaData")]
        public CORE.DTOs.APIs.Unified_Response.Results SyncEskaData([FromBody] SyncEskaInfo obj)
        {
            CORE.DTOs.APIs.Unified_Response.Results result = new CORE.DTOs.APIs.Unified_Response.Results();
            (bool, string) Resp = (false, null);
            Resp = _CoreServices.PushToPolicyWrapperCore(obj.Id, _appSettings.EskaConnection, _appSettings.EskaFinancialConnection, _appSettings.DeletePendingEnd, _appSettings.ESKAPolicies, _appSettings.ESKAEndorsement, _appSettings.EskaIGeneralConnection);
            if (Resp.Item1)
            {
                result.httpStatusCode = HttpStatusCode.OK;
                result.status = true;
                result.message = ((!string.IsNullOrEmpty(Resp.Item2)) ? Resp.Item2 : string.Empty);
                result.ResponseDate = DateTime.Now;
            }
            else
            {
                result.httpStatusCode = HttpStatusCode.InternalServerError;
                result.status = false;
                result.message = ((!string.IsNullOrEmpty(Resp.Item2)) ? Resp.Item2 : "Error Occured");
                result.ResponseDate = DateTime.Now;
            }
            return result;
        }

        [HttpPost]
        [Route("SyncEskaDataSME")]
        public CORE.DTOs.APIs.Unified_Response.Results SyncEskaDataSME([FromBody] SyncEskaInfo obj)
        {
            CORE.DTOs.APIs.Unified_Response.Results result = new CORE.DTOs.APIs.Unified_Response.Results();
            PolicyHeaderResponse policyHeaderResponse = new PolicyHeaderResponse();
            try
            {
                SMECoreServices sMECoreServices = new SMECoreServices(_appSettings, _environment, _svcBusiness, _tracker, _CoreServices, _process, _User);
                policyHeaderResponse = sMECoreServices.CreatePolicyHeader(obj.Id);
                if (policyHeaderResponse != null && policyHeaderResponse.statusCT.statusCode == 200)
                {
                    result.httpStatusCode = HttpStatusCode.OK;
                    result.status = true;
                    result.message = policyHeaderResponse.statusCT.reason;
                    result.ResponseDate = DateTime.Now;
                }
                else
                {
                    string errorMsg = policyHeaderResponse.statusCT.reason;
                    if (errorMsg == "Please check member Error")
                    {
                        errorMsg = string.Empty;
                        foreach (var item in policyHeaderResponse.memberInfo)
                        {
                            if (item.errorMessage != null)
                            {
                                errorMsg += item.nationalId + " " + item.errorMessage + ", ";
                            }
                        }
                    }
                    result.httpStatusCode = HttpStatusCode.InternalServerError;
                    result.status = false;
                    result.message = "SME Error:" + errorMsg;
                    result.ResponseDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex, obj.Id.ToString(), string.Empty, "SyncEskaData");
                result.httpStatusCode = HttpStatusCode.InternalServerError;
                result.ResponseDate = DateTime.Now;
                result.status = false;
                result.message = "failed: " + ex.Message;
            }

            return result;
        }

        [HttpPost]
        [Route("Calculate")]
        public void Calculate([FromBody] SyncEskaInfo obj)
        {
            Production policy = _svcBusiness.getDocumentByKey(obj.Id);
            EndpointAddress endpointAddressPolicy = new EndpointAddress(_appSettings.ESKAPolicies);
            POLICYClient clientPolicy = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
            CalculatePolicyRequest calculatePolicyRequest = new CalculatePolicyRequest();
            CalculatePolicyOutput calculatePolicyOutput = new CalculatePolicyOutput();
            //CalculatePolicyResponse calculatePolicyResponse = new CalculatePolicyResponse();
            calculatePolicyRequest.CREATED_BY = "Admin";
            calculatePolicyRequest.PolicySegment = policy.EskaSegment;
            calculatePolicyRequest.ID = policy.EskaId.Value;
            Task<EskaPolicies.CalculatePolicyResponse> calculatePolicyResponse = clientPolicy.CalculatePolicyAsync(calculatePolicyRequest);
        }

        [HttpGet]
        [Route("MaxAgePlan")]
        public PlanAgeOutput MaxAgePlan([FromQuery] string obj)
        {
            PlanAgeOutput ageOutput = new PlanAgeOutput();
            PlanAge plan = new PlanAge();
            plan = JsonConvert.DeserializeObject<PlanAge>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
            int Age = PlanSetups.MaxPlanAge(plan.PlanId, _appSettings.EskaConnection);
            if (Age > 0)
            {
                ageOutput.Age = Age;
                ageOutput.httpStatusCode = HttpStatusCode.OK;
                ageOutput.status = true;
                ageOutput.ResponseDate = DateTime.Now;
            }
            else
            {
                ageOutput.httpStatusCode = HttpStatusCode.InternalServerError;
                ageOutput.status = false;
                ageOutput.ResponseDate = DateTime.Now;
                ageOutput.message = "Procedure GET_MAX_AGE_PLAN has Exception";
            }
            return ageOutput;
        }

        [HttpPost]
        [Route("LoadHolderById")]
        public HolderResponse LoadHolderById([FromBody] PolicyHolderLoadByID obj)
        {
            HolderResponse holderResponse = new HolderResponse();
            holderResponse.PolicyHolders = new PolicyHolders();
            holderResponse.PolicyHolders = _svcBusiness.LoadPolicyHolders(obj.CustomerId);
            if (holderResponse.PolicyHolders != null)
            {
                holderResponse.status = true;
                holderResponse.httpStatusCode = HttpStatusCode.OK;
                holderResponse.ResponseDate = DateTime.Now;
                holderResponse.message = "";
            }
            else
            {
                holderResponse.status = false;
                holderResponse.httpStatusCode = HttpStatusCode.InternalServerError;
                holderResponse.ResponseDate = DateTime.Now;
                holderResponse.message = "Internal Server Error";
            }
            return holderResponse;
        }

        [HttpPost]
        [Route("InsertEndorsmentCancellation")]
        public Document InsertEndorsmentCancellation([FromBody] InsertCancellation insertCancellation)
        {
            Document document = new Document();
            (Production, string) production = (new Production(), string.Empty);
            production = _svcBusiness.CancellationMember(insertCancellation.MemberId, insertCancellation.PolicyId, insertCancellation.Cancellation, insertCancellation.CreatedBy);
            AddToApprovals addToApprovals = new AddToApprovals();
            document.Headers = new List<Production>();
            if (production.Item1 != null && production.Item1.Id > 0)
            {
                addToApprovals.approvalHistory = new ApprovalHistory();
                addToApprovals.approvalHistory.Attachments = insertCancellation.Attachments + "\\ApprovalsDocuments\\" + production.Item1.UniqueGuid + ".pdf";
                addToApprovals.approvalHistory.PolicyId = production.Item1.Id;
                addToApprovals.approvalHistory.Status = 2;
                addToApprovals.approvalHistory.RecievedDate = DateTime.Now;
                _process.SetApprovalStatus(addToApprovals);
                document.Headers.Add(production.Item1);
                document.status = true;
                document.httpStatusCode = HttpStatusCode.OK;
                document.message = "";
                document.ResponseDate = DateTime.Now;
            }
            else
            {
                document.status = false;
                document.httpStatusCode = HttpStatusCode.InternalServerError;
                document.message = production.Item2;
                document.ResponseDate = DateTime.Now;
            }
            return document;
        }

        [HttpDelete]
        [Route("RemovePolicy")]
        public CORE.DTOs.APIs.Unified_Response.Results RemovePolicy([FromBody] PolicyIdInput input)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            CORE.DTOs.APIs.Unified_Response.Results Results = new CORE.DTOs.APIs.Unified_Response.Results();
            Results.status = _svcBusiness.DeletePolicyBusiness(input.PolicyId);
            if (input.EskaId > 0)
            {
                DeletePolicy deletePolicy = new DeletePolicy();
                EndpointAddress endpointAddressPolicy = new EndpointAddress(_appSettings.ESKAPolicies);
                POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                //DeletePolicyDataRequest request = new DeletePolicyDataRequest();
                //DeletePolicyDataResponse response = new DeletePolicyDataResponse();
                //request.PolicyID = input.EskaId;
                Task<EskaPolicies.DeletePolicy> response = client.DeletePolicyDataAsync(input.EskaId);
                deletePolicy = response.Result;

                results.status = deletePolicy.Status.StatusCode == 1;
            }
            if (Results.status)
            {
                Results.ResponseDate = DateTime.Now;
                Results.message = string.Empty;
                Results.httpStatusCode = HttpStatusCode.OK;
            }
            else
            {
                Results.ResponseDate = DateTime.Now;
                Results.message = "Internal Server Error";
                Results.httpStatusCode = HttpStatusCode.InternalServerError;
            }
            return Results;
        }

        [HttpDelete]
        [Route("RemovePolicySME")]
        public CORE.DTOs.APIs.Unified_Response.Results RemovePolicySME([FromBody] PolicyIdInput input)
        {
            SMECoreServices sMECoreServices = new SMECoreServices(_appSettings, _environment, _svcBusiness, _tracker, _CoreServices, _process, _User);
            CORE.DTOs.APIs.Unified_Response.Results Results = new CORE.DTOs.APIs.Unified_Response.Results();
            try
            {
                if (input.EskaId > 0)
                {
                    DeletePolicyResponse deletePolicyResponse = new DeletePolicyResponse();
                    deletePolicyResponse = sMECoreServices.DeletePolicy(input.EskaId.ToString());
                    if (deletePolicyResponse != null && deletePolicyResponse.deletePolicyDataResult != null && deletePolicyResponse.deletePolicyDataResult.status != null)
                    {
                        Results.status = deletePolicyResponse.deletePolicyDataResult.status.statusCode == 1;
                        Results.message = deletePolicyResponse.deletePolicyDataResult.status.statusCode == 1 ? "" : deletePolicyResponse.deletePolicyDataResult.status.reason;
                        if (deletePolicyResponse.deletePolicyDataResult.status.statusCode == 1)
                        {
                            Results.status = _svcBusiness.DeletePolicyBusiness(input.PolicyId);

                        }
                    }
                }
                else
                {
                    Results.status = _svcBusiness.DeletePolicyBusiness(input.PolicyId);
                }
                if (Results.status)
                {
                    Results.ResponseDate = DateTime.Now;
                    Results.message = string.Empty;
                    Results.httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    Results.ResponseDate = DateTime.Now;
                    Results.message = String.IsNullOrEmpty(Results.message) ? "Internal Server Error" : Results.message;
                    Results.httpStatusCode = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception ex)
            {
                Results.ResponseDate = DateTime.Now;
                Results.message = "Internal Server Error";
                Results.httpStatusCode = HttpStatusCode.InternalServerError;
            }
            return Results;
        }

        [HttpDelete]
        [Route("RemoveEskaPolicy")]
        public CORE.DTOs.APIs.Unified_Response.Results RemoveEskaPolicy([FromBody] PolicyIdInput input)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            if (input.EskaId > 0)
            {
                DeletePolicy deletePolicy = new DeletePolicy();
                EndpointAddress endpointAddressPolicy = new EndpointAddress(_appSettings.ESKAPolicies);
                POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY, endpointAddressPolicy);
                //DeletePolicyDataRequest request = new DeletePolicyDataRequest();
                //DeletePolicyDataResponse response = new DeletePolicyDataResponse();
                //request.PolicyID = input.EskaId;
                Task<EskaPolicies.DeletePolicy> response = client.DeletePolicyDataAsync(input.EskaId);
                deletePolicy = response.Result;

                results.status = deletePolicy.Status.StatusCode == 1;
            }
            return results;
        }

        [HttpPost]
        [Route("LoadDocumentBusiness")]
        public LoadDocsBusiness LoadDocumentBusiness([FromBody] LoadDocumentList obj)
        {
            LoadDocsBusiness loadDocsBusiness = new LoadDocsBusiness();
            loadDocsBusiness.productions = new List<Production>();
            loadDocsBusiness = _svcBusiness.LoadPolicyBusiness(obj.RoleId, obj.CreatedBy, obj.PolicyNo, obj.IssueDate, obj.Status, obj.Count, obj.ClientName, obj.SponserNo);
            if (loadDocsBusiness != null && loadDocsBusiness.productions != null && loadDocsBusiness.productions.Count > 0)
            {
                loadDocsBusiness.status = true;
                loadDocsBusiness.ResponseDate = DateTime.Now;
                loadDocsBusiness.message = "";
                loadDocsBusiness.httpStatusCode = HttpStatusCode.OK;
            }
            else
            {
                loadDocsBusiness.status = false;
                loadDocsBusiness.ResponseDate = DateTime.Now;
                loadDocsBusiness.message = "No Documents There !";
                loadDocsBusiness.httpStatusCode = HttpStatusCode.InternalServerError;
            }
            return loadDocsBusiness;
        }

        [HttpPost]
        [Route("SingleYakeen")]
        public YakeenProccess SingleYakeen([FromBody] MainMemberInfo obj)
        {
            YakeenProccess yakeenProccess = new YakeenProccess();
            return YakeenCall.InsertYakeen(obj, _svcBusiness, _appSettings);
        }

        [HttpGet]
        [Route("LoadOriginalPolicy")]
        public Document LoadOriginalPolicy(string obj)
        {
            Document document = new Document();
            FilterDocument objFilter = new FilterDocument();
            objFilter = JsonConvert.DeserializeObject<FilterDocument>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
            Production Documents = _svcBusiness.LoadOriginalPolicy((int)objFilter.CustomerId);
            document.Headers = new List<Production>();
            if (Documents != null)
            {
                document.Headers.Add(Documents);
                document.status = true;
                document.ResponseDate = DateTime.Now;
                document.httpStatusCode = HttpStatusCode.OK;
                document.message = "";
            }
            else
            {
                document.status = false;
                document.ResponseDate = DateTime.Now;
                document.httpStatusCode = HttpStatusCode.NoContent;
                document.message = "No Content";
            }
            return document;
        }
    }
}
