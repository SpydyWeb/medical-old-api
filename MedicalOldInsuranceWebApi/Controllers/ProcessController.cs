using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CORE.DTOs.APIs;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process;
using CORE.DTOs.APIs.Process.Approvals;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.APIs.Process.Reports;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Business;
using CORE.DTOs.Setups;
using CORE.Extensions;
using CORE.Interfaces;
using CORE.TablesObjects;
using DataAccessLayer.Oracle.Eskadenia.Issuance;
using DataAccessLayer.Oracle.Eskadenia.Setups;
using EskaPolicies;
using EskaReports;
using InsuranceAPIs.Models.Configuration_Objects;
using MicroAPIs.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InsuranceAPIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProcessController : ControllerBase
	{
		private static HttpClient client = new HttpClient();

		private readonly AppSettings _appSettings;

		public static IWebHostEnvironment? _environment;

		private readonly IBusiness _svcBusiness;

		private readonly ITracker _tracker;

		private readonly IProcess _process;

		public ProcessController(IOptions<AppSettings> appSettings, IWebHostEnvironment environment, IBusiness svcBus, ITracker tracker, IProcess process)
		{
			_environment = environment;
			_appSettings = appSettings.Value;
			_svcBusiness = svcBus;
			_tracker = tracker;
			_process = process;
		}

		[HttpPost]
		[Route("SetApprovalStatus")]
		public CORE.DTOs.APIs.Unified_Response.Results SetApprovalStatus([FromBody] AddToApprovals approvals)
		{
			return _process.SetApprovalStatus(approvals);
		}
        [HttpPost]
        [Route("CheckUserBlackList")]
        public CORE.DTOs.APIs.Unified_Response.Results CheckUserBlackList([FromBody] CheckSponsorInput input)
        {
            return _process.CheckUserBlackList(input.Sponsor);
        }

        [HttpPost]
        [Route("InsertUserBlacklistMember")]
        public CORE.DTOs.APIs.Unified_Response.Results InsertUserBlacklistMember([FromBody] CheckSponsorInput input)
        {
            return _process.InsertUserBlacklistMember(input.Sponsor);
        }
        [HttpPost]
        [Route("RemoveUserBlacklistMember")]
        public CORE.DTOs.APIs.Unified_Response.Results RemoveUserBlacklistMember([FromBody] CheckSponsorInput input)
        {
            return _process.RemoveUserBlacklistMember(input.Sponsor);
        }

        [HttpPost]
		[Route("LoadApprovals")]
		public LoadApprovalOutPut LoadApprovals([FromBody] LoadApprovalsInput approvals)
		{
			LoadApprovalOutPut outPut = new LoadApprovalOutPut();
			outPut.approvalSets = new List<ApprovalSet>();
			outPut.approvalSets = _process.LoadApprovalsInput(approvals);
			if (outPut.approvalSets != null && outPut.approvalSets.Count > 0)
			{
				outPut.status = true;
				outPut.httpStatusCode = HttpStatusCode.OK;
				outPut.ResponseDate = DateTime.Now;
				outPut.message = "";
			}
			else
			{
				outPut.status = false;
				outPut.httpStatusCode = HttpStatusCode.InternalServerError;
				outPut.ResponseDate = DateTime.Now;
				outPut.message = "Internal Server Error";
			}
			return outPut;
		}

		[HttpPost]
		[Route("PaymentInfo")]
		public PolicyPaymentResponse PaymentInfo([FromBody] PolicyPaymentInput policyPayment)
		{
			PolicyPaymentResponse policyPaymentResponse = new PolicyPaymentResponse();
			if (policyPayment != null)
			{
				policyPaymentResponse = _process.LoadPaymentInfo(policyPayment);
			}
			else
			{
				policyPaymentResponse.message = "Object sent is null";
				policyPaymentResponse.status = false;
				policyPaymentResponse.httpStatusCode = HttpStatusCode.BadRequest;
				policyPaymentResponse.ResponseDate = DateTime.Now;
			}
			return policyPaymentResponse;
		}

		[HttpPost]
		[Route("PaymentLog")]
		public CORE.DTOs.APIs.Unified_Response.Results PaymentLog([FromBody] PaymentLog log)
		{
			CORE.DTOs.APIs.Unified_Response.Results Results = new CORE.DTOs.APIs.Unified_Response.Results();
			if (log != null)
			{
				Results = _process.SavePaymentLog(log);
			}
			else
			{
				Results.message = "Object sent is null";
				Results.status = false;
				Results.httpStatusCode = HttpStatusCode.BadRequest;
				Results.ResponseDate = DateTime.Now;
			}
			return Results;
		}

		[HttpPost]
		[Route("GenerateCoreReport")]
		public CORE.DTOs.APIs.Unified_Response.Results GenerateCoreReport([FromBody] ReportInput Report)
		{
			CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
			try
			{
				GenerateReportInput generateReportInput = new GenerateReportInput();
				GenerateReportResponse generateReportResponse = new GenerateReportResponse();
				GenerateReportRequest generateReportRequest = new GenerateReportRequest();
				GenerateReportOutput generateReportOutput = new GenerateReportOutput();
				REPORTClient client = new REPORTClient();
				generateReportInput.ApplicationID = ApplicationsEnum.MedicalInsurance;
				if (Report.reportType == ReportType.QuotationReport)
				{
					generateReportInput.ReportCode = ReportLibrary.Quotation.ToString();
				}
				else if (Report.reportType == ReportType.PolicyScheduleReport)
				{
					generateReportInput.ReportCode = ReportLibrary.Policy.ToString();
				}
				else if (Report.reportType == ReportType.InvoiceReport)
				{
					generateReportInput.ReportCode = ReportLibrary.Invoice.ToString();
				}
				else
				{
					generateReportInput.ReportCode = ReportLibrary.MemberListReport.ToString();
				}
				generateReportInput.UserName = "Admin";
				generateReportInput.Path = Report.Path;
				generateReportInput.Langauage = LangugesEnum.English;
				generateReportInput.OutputType = ReportExportTypesEnum.PDF;
				generateReportInput.FileName = Report.FileName;
				generateReportInput.oReportParameters = new ReportParameter[1];
				ReportParameter reportParameter = new ReportParameter();
				reportParameter.ParamFrom = "P_PLC_ID";
				reportParameter.ParamID = (int)Report.reportParams;
				reportParameter.ParamOrder = 1;
				reportParameter.ParamToRequired = true;
				reportParameter.ColumnType = UtilitiesBLLParameterType.LOV;
				reportParameter.FromValue = Report.EskaId.ToString();
				reportParameter.ParamToRequired = false;
				reportParameter.ReportCode = generateReportInput.ReportCode;
				generateReportInput.oReportParameters[0] = reportParameter;
				generateReportRequest.oGenerateReportInput = new GenerateReportInput();
				generateReportRequest.oGenerateReportInput = generateReportInput;
                generateReportResponse = client.GenerateReport(generateReportRequest);
				generateReportOutput = generateReportResponse.GenerateReportResult;
                if (generateReportOutput != null && generateReportOutput.oStatus.StatusCode == 1)
				{
					results.status = true;
					results.message = "";
					results.ResponseDate = DateTime.Now;
					results.httpStatusCode = HttpStatusCode.OK;
				}
				else
				{
					results.status = false;
					results.message = generateReportOutput.oStatus.Reason;
					results.ResponseDate = DateTime.Now;
					results.httpStatusCode = HttpStatusCode.InternalServerError;
				}
			}
			catch (Exception e)
			{
				results.status = false;
				results.message = e.Message;
				results.ResponseDate = DateTime.Now;
				results.httpStatusCode = HttpStatusCode.InternalServerError;
			}
			return results;
		}

		[HttpGet]
		[Route("LoadPolicyByKey")]
		public Document LoadPolicyByKey([FromQuery] string obj)
		{
			Document document = new Document();
			document.Headers = new List<Production>();
			Production policy = _process.LoadByKey(JsonConvert.DeserializeObject<string>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV)));
			document.Headers.Add(policy);
			document.status = true;
			document.httpStatusCode = HttpStatusCode.OK;
			document.ResponseDate = DateTime.Now;
			document.message = "";
			return document;
		}

		[HttpGet]
		[Route("LoadApprovalHistDeclaration")]
		public ApprovalHistDeclaration LoadApprovalHistDeclaration([FromQuery] string obj)
		{
			ApprovalHistDeclaration approvalHistDeclaration = new ApprovalHistDeclaration();
			approvalHistDeclaration.memberDeclares = new List<MemberDeclare>();
			try
			{
				ApprovalRequestDeclerationInput approvalRequestDeclerationInput = new ApprovalRequestDeclerationInput();
				string objserialize = Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV);
				approvalRequestDeclerationInput = JsonConvert.DeserializeObject<ApprovalRequestDeclerationInput>(objserialize);
				ApprovalHistory approval = _process.LoadApprovalsHist(approvalRequestDeclerationInput.ApprovalHistoryId);
				LoadDecleration loadDecleration = new LoadDecleration();
				loadDecleration.PolicyId = approval.PolicyId;
				List<MembersDeclarations> declarationsmembers = _svcBusiness.LoadDecleration(loadDecleration);
				declarationsmembers.ForEach(delegate(MembersDeclarations item)
				{
					MembersDeclarations item2 = item;
					Subjects subjects = _svcBusiness.LoadMemberBusiness(declarationsmembers.FirstOrDefault().PolicyId.Value, null).FirstOrDefault((Subjects x) => x.Id == item2.MemberId);
					MemberDeclare memberDeclare = new MemberDeclare();
					memberDeclare.HealthDeclarations = new MembersDeclarations();
					memberDeclare.Subjects = new Subjects();
					memberDeclare.ApprovalHistory = new ApprovalHistory();
					memberDeclare.declarationsAnswers = new List<DeclarationsAnswers>();
					List<HealthDeclarations> list = _process.LoadDeclerations();
					list.ForEach(delegate(HealthDeclarations quest)
					{
						DeclarationsAnswers declarationsAnswers = new DeclarationsAnswers
						{
							healthDeclarations = new HealthDeclarations()
						};
						if (quest.QuestionNo == 1 && item2.QuestionOne)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
						if (quest.QuestionNo == 2 && item2.QuestionTwo)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
						if (quest.QuestionNo == 3 && item2.QuestionThree)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
						if (quest.QuestionNo == 4 && item2.QuestionFour)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
						if (quest.QuestionNo == 5 && item2.QuestionFive)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
						if (quest.QuestionNo == 6 && item2.QuestionSix)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
						if (quest.QuestionNo == 7 && item2.QuestionSeven.HasValue && item2.QuestionSeven.Value)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
						if (quest.QuestionNo == 8 && item2.QuestionEight.HasValue && item2.QuestionEight.Value)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
						if (quest.QuestionNo == 9 && item2.QuestionNine.HasValue && item2.QuestionNine.Value)
						{
							declarationsAnswers.healthDeclarations = quest;
							declarationsAnswers.Answer = true;
							memberDeclare.declarationsAnswers.Add(declarationsAnswers);
						}
					});
					memberDeclare.HealthDeclarations = item2;
					memberDeclare.Subjects = subjects;
					memberDeclare.ApprovalHistory = approval;
					approvalHistDeclaration.memberDeclares.Add(memberDeclare);
				});
				approvalHistDeclaration.httpStatusCode = HttpStatusCode.OK;
				approvalHistDeclaration.status = true;
				approvalHistDeclaration.message = "";
				approvalHistDeclaration.ResponseDate = DateTime.Now;
			}
			catch (Exception)
			{
				approvalHistDeclaration.httpStatusCode = HttpStatusCode.OK;
				approvalHistDeclaration.status = true;
				approvalHistDeclaration.message = "";
				approvalHistDeclaration.ResponseDate = DateTime.Now;
			}
			return approvalHistDeclaration;
		}

		[HttpPost]
		[Route("UpdateFinancialPayment")]
		public CORE.DTOs.APIs.Unified_Response.Results UpdateFinancialPayment([FromBody] UpdateFinancialPayment updateFinancial)
		{
			//UpdateForPayment.GetpremiumDetails(_appSettings.EskaIGeneralConnection);


            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
			if (_svcBusiness.updateFinancialDate(updateFinancial))
			{
				if (UpdateForPayment.UpdatePayment(Convert.ToInt64(updateFinancial.EskaId), updateFinancial.EffectiveDate, updateFinancial.VAT, _appSettings.EskaConnection))
				{
					results.status = true;
					results.ResponseDate = DateTime.Now;
					results.message = "";
					results.httpStatusCode = HttpStatusCode.OK;
				}
				else
				{
					results.status = false;
					results.ResponseDate = DateTime.Now;
					results.message = "Faild During Sync with Eska";
					results.httpStatusCode = HttpStatusCode.InsufficientStorage;
				}
			}
			else
			{
				results.status = false;
				results.ResponseDate = DateTime.Now;
				results.message = "Faild During Update DB SQL";
				results.httpStatusCode = HttpStatusCode.InsufficientStorage;
			}
			return results;
		}

		[HttpGet]
		[Route("LoadCancellationReasons")]
		public CancellationReasonOutput LoadCancellationReasonsn()
		{
			CancellationReasonOutput cancellationReasonOutput = new CancellationReasonOutput();
			cancellationReasonOutput.cancellationReasons = new List<CancellationReason>();
			cancellationReasonOutput.cancellationReasons.AddRange(CancellationReasons.loadCancellation(_appSettings.EskaConnection));
			if (cancellationReasonOutput.cancellationReasons.Count > 0)
			{
				cancellationReasonOutput.httpStatusCode = HttpStatusCode.OK;
				cancellationReasonOutput.status = true;
				cancellationReasonOutput.ResponseDate = DateTime.Now;
			}
			else
			{
				cancellationReasonOutput.httpStatusCode = HttpStatusCode.InternalServerError;
				cancellationReasonOutput.status = false;
				cancellationReasonOutput.ResponseDate = DateTime.Now;
				cancellationReasonOutput.message = "Procedure Get CancellationReasons has Exception";
			}
			return cancellationReasonOutput;
		}

		[HttpGet]
		[Route("PrintReport")]
		public ReportOut PrintReport(string obj)
		{
			try
			{
				ReportOut reportOut = new ReportOut();
				PrintReportInput printReportInput = new PrintReportInput();
				printReportInput = JsonConvert.DeserializeObject<PrintReportInput>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
				HttpClient client = new HttpClient();
				string Params = "?ReportCode=" + printReportInput.ReportCode + "&Parameters=" + printReportInput.Parameters + "&reportOutputType=" + printReportInput.ReportOutputType;
				client.BaseAddress = new Uri(_appSettings.ReportAPIBase);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage responsePost = client.GetAsync(Params).Result;
				(int, string, bool) Response = JsonConvert.DeserializeObject<(int, string, bool)>(responsePost.Content.ReadAsStringAsync().Result);
				if (Response.Item1 > 0)
				{
					reportOut.HistoryId = Response.Item1;
					reportOut.Path = Response.Item2;
					reportOut.status = Response.Item3;
					reportOut.httpStatusCode = HttpStatusCode.OK;
					reportOut.ResponseDate = DateTime.Now;
				}
				else
				{
					reportOut.status = Response.Item3;
					reportOut.httpStatusCode = HttpStatusCode.OK;
					reportOut.ResponseDate = DateTime.Now;
					reportOut.message = Response.Item2;
				}
				return reportOut;
			}
			catch (WebException ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		[Route("LoadApprovalHistoryDetails")]
		public LoadHistoryDetails LoadApprovalHistoryDetails([FromBody] LoadApprovalHistDetails input)
		{
			try
			{
				LoadHistoryDetails loadHistory = new LoadHistoryDetails();
				loadHistory.LoadApprovalHistDetails = new List<approvalhistlist>();
				loadHistory.LoadApprovalHistDetails = _process.LoadHistoryApproval(input);
				if (loadHistory.LoadApprovalHistDetails != null && loadHistory.LoadApprovalHistDetails.Count > 0)
				{
					loadHistory.status = true;
					loadHistory.httpStatusCode = HttpStatusCode.OK;
					loadHistory.ResponseDate = DateTime.Now;
				}
				else
				{
					loadHistory.status = false;
					loadHistory.httpStatusCode = HttpStatusCode.InternalServerError;
					loadHistory.ResponseDate = DateTime.Now;
					loadHistory.message = "Internal Error";
				}
				return loadHistory;
			}
			catch (WebException ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		[Route("GenerateSadadNo")]
		public string GenerateSadadNo([FromBody] GenerateSadadReq input)
		{
			GenerateSadadToken sadadToken = new GenerateSadadToken();
			HttpClient httpClient = new HttpClient();
			SadadTokens StoredToken = _process.ValidateToken();
			if (StoredToken == null || StoredToken.Id == 0)
			{
				Dictionary<string, string> values = new Dictionary<string, string>
				{
					{ "grant_type", "password" },
					{ "username", "Aljaziratakaful" },
					{ "password", "Ajt@1234" }
				};
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				try
				{
					FormUrlEncodedContent content = new FormUrlEncodedContent(values);
					HttpResponseMessage response2 = client.PostAsync("https://api.edaaat.com/auth", content).Result;
					Task<string> result2 = response2.Content.ReadAsStringAsync();
					SadadTokenResponse sadad = new SadadTokenResponse();
					sadad = JsonConvert.DeserializeObject<SadadTokenResponse>(result2.Result);
					StoredToken = new SadadTokens();
					StoredToken.Token = sadad.access_token;
					StoredToken.CreationDate = DateTime.Now;
					StoredToken.Error = sadad.error;
					StoredToken.ValidationPeriod = sadad.expires_in;
					StoredToken.ExpiryDate = DateTime.Now.AddDays(6.0);
					_process.InsertToken(StoredToken);
				}
				catch (Exception)
				{
					throw;
				}
			}
			SadadTransactions sadadTransactions = new SadadTransactions();
			sadadTransactions = _process.ValidateSadad(input.PolicyId);
			if (string.IsNullOrEmpty(StoredToken.Error) && ((sadadTransactions != null && sadadTransactions.Id == 0) || sadadTransactions == null))
			{
				List<Production> policy = _svcBusiness.LoadProductionById(input.PolicyId, Eska: false);
				PolicyHolders customer = _svcBusiness.LoadPolicyHolders(policy.FirstOrDefault().CustomerId.Value);
				SinglePaymentRequest singlePaymentRequest = new SinglePaymentRequest();
				singlePaymentRequest.Company = new Company();
				singlePaymentRequest.Products = new List<CORE.DTOs.APIs.Process.Payments.Product>();
				singlePaymentRequest.Company.PreferedLanguage = "ar";
				singlePaymentRequest.Company.CanSendSMS = true;
				singlePaymentRequest.Company.NameAr = customer.Name;
				singlePaymentRequest.Company.CommissionerName = customer.Name;
				singlePaymentRequest.Company.RegistrationNo = customer.CommercialNo;
				singlePaymentRequest.Company.CommissionerEmail = customer.Email;
				singlePaymentRequest.Company.CommissionerMobileNo = customer.MobileNo;
				singlePaymentRequest.Company.CommissionerNationalId = customer.CommercialNo;
				singlePaymentRequest.Company.CustomerRefNumber = customer.CommercialNo.ToString();
				singlePaymentRequest.IsClientEnterpise = true;
				singlePaymentRequest.RegistrationNo = customer.CommercialNo;
				singlePaymentRequest.InternalCode = input.PolicyId.ToString();
				singlePaymentRequest.IssueDate = DateTime.Now.AddDays(-1.0);
				singlePaymentRequest.DueDate = DateTime.Now.AddDays(-1.0);
				singlePaymentRequest.ExpiryDate = DateTime.Now.AddDays(3.0);
				singlePaymentRequest.FromDurationTime = "10:00";
				singlePaymentRequest.ToDurationTime = "23:59";
				singlePaymentRequest.HasValidityPeriod = true;
				singlePaymentRequest.SubBillerShareAmount = Convert.ToDecimal(policy.FirstOrDefault().GrossAmount + policy.FirstOrDefault().TotalFees + policy.FirstOrDefault().VAT);
				singlePaymentRequest.SubBillerSharePercentage = 0m;
				CORE.DTOs.APIs.Process.Payments.Product product = new CORE.DTOs.APIs.Process.Payments.Product();
				product.ProductCode = "001";
				product.Price = Convert.ToDecimal(policy.FirstOrDefault()?.GrossAmount + policy.FirstOrDefault()?.TotalFees + policy.FirstOrDefault()?.VAT);
				product.Qty = 1m;
				product.TaxCode = null;
				singlePaymentRequest.Products.Add(product);
				singlePaymentRequest.TotalAmount = Convert.ToDecimal(policy.FirstOrDefault().GrossAmount + policy.FirstOrDefault().TotalFees + policy.FirstOrDefault().VAT);
				singlePaymentRequest.ExportToSadad = true;
				httpClient = new HttpClient();
				string myContent = JsonConvert.SerializeObject(singlePaymentRequest);
				HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Post, "https://api.edaaat.com/api/v2/Invoices/Single")
				{
					Content = new StringContent(myContent, Encoding.UTF8, "application/json")
				};
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StoredToken.Token);
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				HttpResponseMessage resultAll = client.Send(webRequest);
				StreamReader result = new StreamReader(resultAll.Content.ReadAsStream());
				string Info = result.ReadToEnd();
				GenerateSadadResponse response = new GenerateSadadResponse();
				response = JsonConvert.DeserializeObject<GenerateSadadResponse>(Info);
				string y = JsonConvert.SerializeObject(singlePaymentRequest);
				if (response.Status.Success)
				{
					sadadTransactions = new SadadTransactions
					{
						EffectiveDate = DateTime.Now,
						ExpiryDate = DateTime.Now.AddDays(3.0),
						PolicyId = input.PolicyId,
						Status = 0,
						InvoiceNo = response.Body.InvoiceNo,
						InternalCode = response.Body.InternalCode,
						PaymentAmount = Convert.ToDecimal(policy.FirstOrDefault().GrossAmount + policy.FirstOrDefault().TotalFees + policy.FirstOrDefault().VAT)
					};
					sadadTransactions = _process.InsertUpdateSadad(sadadTransactions);
					return "Sadad invoice has been generated under No :" + response.Body.InvoiceNo + " and valid until " + DateTime.Now.AddDays(2.0);
				}
				return response.Status.Message;
			}
			return "There already active SADAD No for this policy under No: " + sadadTransactions?.InvoiceNo;
		}

		[HttpPost]
		[Route("SADADPaymentNotification")]
		public CORE.DTOs.APIs.Process.Status SADADPaymentNotification([FromBody] List<SadadTransactions> input)
		{
			CORE.DTOs.APIs.Process.Status status = new CORE.DTOs.APIs.Process.Status();
			SadadTransactions sadadTransactions = new SadadTransactions();
			SadadTransactions SadadInput = new SadadTransactions();
			foreach (SadadTransactions item in input)
			{
				sadadTransactions = _process.ValidateSadad(null, item.InvoiceNo, item.InternalCode);
				if (sadadTransactions != null && sadadTransactions.Id > 0)
				{
					if (sadadTransactions.Status > 0)
					{
						return new CORE.DTOs.APIs.Process.Status
						{
							Code = "E002",
							Success = false,
							Message = "This invoice already Paid"
						};
					}
					SadadInput = item;
					if (!(sadadTransactions.PaymentAmount == SadadInput.PaymentAmount))
					{
						return new CORE.DTOs.APIs.Process.Status
						{
							Code = "E003",
							Success = false,
							Message = "Mismatch Premium Amount"
						};
					}
					sadadTransactions.PaymentDate = SadadInput.PaymentDate;
					sadadTransactions.Status = 1;
					sadadTransactions.EPTN = SadadInput.EPTN;
					sadadTransactions.BillNo = SadadInput.BillNo;
					sadadTransactions = _process.InsertUpdateSadad(sadadTransactions);
					PaymentLog paymentLog = new PaymentLog
					{
						TransactionDate = DateTime.Now,
						CardType = "SADAD",
						MerchantReference = sadadTransactions.BillNo,
						Status = true,
						PayfortId = sadadTransactions.Id.ToString(),
						TransactionType = 1,
						PayfortStatus = item.InvoiceNo,
						CardDetails = sadadTransactions.PaymentAmount.ToString(),
						PolicyId = sadadTransactions.PolicyId.Value
					};
					CORE.DTOs.APIs.Unified_Response.Results result = _process.SavePaymentLog(paymentLog);
					List<Production> policy = _svcBusiness.LoadProductionById(sadadTransactions.PolicyId.Value, Eska: false);
					CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
					PolicyPaymentInput policyPaymentInput = new PolicyPaymentInput
					{
						Key = policy.FirstOrDefault().UniqueGuid
					};
					try
					{
                        POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY);
                        //CreateVoucherAndPostToFinancialRequest toFinancialRequest = new CreateVoucherAndPostToFinancialRequest();
                        //CreateVoucherAndPostToFinancialResponse toFinancialResponse = new CreateVoucherAndPostToFinancialResponse();
                        //toFinancialRequest.ID = policy.FirstOrDefault().EskaId.Value;
                        //toFinancialRequest.CREATED_BY = "APIHub";
                        //toFinancialResponse = client.CreateVoucherAndPostToFinancial(toFinancialRequest);

                        EskaPolicies.PostPolicyRequest postPolicyRequest = new EskaPolicies.PostPolicyRequest();
                        //EskaPolicies.PostPolicyResponse postPolicyResponse = new EskaPolicies.PostPolicyResponse();
                        EskaPolicies.PostPolicyOutput postPolicyOutput = new EskaPolicies.PostPolicyOutput();
                        EskaPolicies.INS_TRANSACTIONS_DOL[] iNS_TRANSACTIONS_DOLs = null;
                        EskaPolicies.POLICY_FEES_DOL[] pOLICY_FEES_DOLs = null;

                        postPolicyRequest.ID = policy.FirstOrDefault().EskaId.Value;
                        postPolicyRequest.CREATED_BY = "APIHub";
                        postPolicyRequest.PolicySegment = policy.FirstOrDefault().EskaSegment;
                        Task<EskaPolicies.PostPolicyResponse> postPolicyResponse = client.PostPolicyAsync(postPolicyRequest);
                    }
					catch (Exception)
					{
					}
					continue;
				}
				return new CORE.DTOs.APIs.Process.Status
				{
					Code = "E001",
					Success = false,
					Message = "There are no invoice with this details or Invoice expired"
				};
			}
			return new CORE.DTOs.APIs.Process.Status
			{
				Code = string.Empty,
				Success = true,
				Message = string.Empty
			};
		}

		[HttpPost]
		[Route("DeleteEskaPolicy")]
		public CORE.DTOs.APIs.Unified_Response.Results DeleteEskaPolicy([FromBody] PolicyIdInput input)
		{
			CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
			DeletePolicy deletePolicy = new DeletePolicy();
			POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY);
            //DeletePolicyDataRequest request = new DeletePolicyDataRequest();
            //DeletePolicyDataResponse response = new DeletePolicyDataResponse();
            //request.PolicyID = input.EskaId;
            Task<EskaPolicies.DeletePolicy> response = client.DeletePolicyDataAsync(input.EskaId);
			deletePolicy = response.Result;

            results.status = deletePolicy.Status.StatusCode == 1;
			results.httpStatusCode = ((deletePolicy.Status.StatusCode == 1) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
			results.ResponseDate = DateTime.Now;
			results.message = deletePolicy.Status.Reason;
			_svcBusiness.DeleteEskaSQL(input.EskaId);
			return results;
		}

		[HttpPost]
		[Route("DeleteEskaMember")]
		public CORE.DTOs.APIs.Unified_Response.Results DeleteEskaMember([FromBody] MemberSearch input)
		{
			CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
			if (Productions.DeleteMember(input.NationalId, input.PolicyId, _appSettings.EskaConnection))
			{
				CalculatePolicyRequest calculatePolicy = new CalculatePolicyRequest();
				//CalculatePolicyResponse calculatePolicyResponse = new CalculatePolicyResponse();
				POLICYClient client = new POLICYClient(POLICYClient.EndpointConfiguration.BasicHttpBinding_IPOLICY);
				calculatePolicy.CREATED_BY = "Admin";
				calculatePolicy.ID = input.PolicyId;
                Task<EskaPolicies.CalculatePolicyResponse>  calculatePolicyResponse = client.CalculatePolicyAsync(calculatePolicy);
				results.status = calculatePolicyResponse.Result.CalculatePolicyResult.Status.StatusCode == 1;
				results.httpStatusCode = ((calculatePolicyResponse.Result.CalculatePolicyResult.Status.StatusCode == 1) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
				results.ResponseDate = DateTime.Now;
				results.message = calculatePolicyResponse.Result.CalculatePolicyResult.Status.Reason;
			}
			else
			{
				results.status = false;
				results.httpStatusCode = HttpStatusCode.InternalServerError;
				results.ResponseDate = DateTime.Now;
				results.message = "Internal Server Error";
			}
			return results;
		}

		[HttpPost]
		[Route("CheckExistMember")]
		public CORE.DTOs.APIs.Unified_Response.Results CheckExistMember([FromBody] MemberSearch input)
		{
			CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
			if (_svcBusiness.CheckExistMember(input.NationalId, input.PolicyId))
			{
				results.status = false;
				results.ResponseDate = DateTime.Now;
				results.httpStatusCode = HttpStatusCode.Conflict;
				results.message = "Member Exists on Different Endorsment";
			}
			else
			{
				results.status = true;
				results.ResponseDate = DateTime.Now;
				results.httpStatusCode = HttpStatusCode.OK;
				results.message = "";
			}
			return results;
		}

        [HttpPost]
        [Route("OnlineTransactionLog")]
        public CORE.DTOs.APIs.Unified_Response.Results OnlineTransactionLog([FromBody] OnlineTransactions onlineTransactions)
        {
            CORE.DTOs.APIs.Unified_Response.Results Results = new CORE.DTOs.APIs.Unified_Response.Results();
            if (onlineTransactions != null)
            {
                Results = _process.InsertUpdateOnline(onlineTransactions);
            }
            else
            {
                Results.message = "Transaction details not saved";
                Results.status = false;
                Results.httpStatusCode = HttpStatusCode.BadRequest;
                Results.ResponseDate = DateTime.Now;
            }
            return Results;
        }
    }
}
