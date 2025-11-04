using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CORE.DTOs.APIs.MotorClaim;
using CORE.DTOs.APIs.Setups.MMP;
using CORE.DTOs.MotorClaim;
using CORE.DTOs.MotorClaim.Claims;
using CORE.DTOs.MotorClaim.Frauds;
using CORE.DTOs.MotorClaim.Integrations.APIs;
using CORE.DTOs.MotorClaim.Productions;
using CORE.DTOs.MotorClaim.Survoyer;
using CORE.DTOs.MotorClaim.WorkFlow;
using CORE.Extensions;
using CORE.Interfaces;
using DataAccessLayer.Oracle.Eskadenia.Motor_Claim_Migration;
using InsuranceAPIs.Models.Configuration_Objects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InsuranceAPIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MotorClaimController : ControllerBase
	{
		private static HttpClient client = new HttpClient();

		private readonly AppSettings _appSettings;

		public static IWebHostEnvironment? _environment;

		private readonly IBusiness _svcBusiness;

		private readonly ITracker _tracker;

		private readonly IMotorClaims _mc;

		public MotorClaimController(IOptions<AppSettings> appSettings, IWebHostEnvironment environment, IBusiness svcBus, ITracker tracker, IMotorClaims MC)
		{
			_environment = environment;
			_appSettings = appSettings.Value;
			_svcBusiness = svcBus;
			_tracker = tracker;
			_mc = MC;
		}

		[HttpPost]
		[Route("SetupMotorClaim")]
		public object SetupMotorClaim([FromBody] SetupClaimsRequestcs obj)
		{
			string FinalResult = "";
			if (obj.TransactionType == ClaimTransactionType.InsertWorkFlowApprovers)
			{
				WorkFlowApprovers strawhat2 = JsonConvert.DeserializeObject<WorkFlowApprovers>(obj.Request.ToString());
				return _mc.InsertWorkFlowApprovers(strawhat2);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadWorkFlowApprovers)
			{
				MainSearchMC strawhat6 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadWorkFlowApprovers(strawhat6.Id, strawhat6.WorkFlowId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteWorkFlowApprovers)
			{
				MainSearchMC strawhat8 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result2 = _mc.DeleteWorkFlowApprovers(Convert.ToInt64(strawhat8.Id));
				return Result2;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertWorkFlowHistory)
			{
				WorkFlowHistory strawhat11 = JsonConvert.DeserializeObject<WorkFlowHistory>(obj.Request.ToString());
				return _mc.InsertWorkFlowHistory(strawhat11);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadWorkFlowHistory)
			{
				MainSearchMC strawhat15 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadWorkFlowHistory(strawhat15.Id, strawhat15.ClaimId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteWorkFlowApprovers)
			{
				MainSearchMC strawhat17 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result4 = _mc.DeleteWorkFlowHistory(Convert.ToInt64(strawhat17.Id));
				return Result4;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertFraudSetup)
			{
				FraudSetup strawhat19 = JsonConvert.DeserializeObject<FraudSetup>(obj.Request.ToString());
				return _mc.InsertUpdateFraudSetup(strawhat19);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadFraudSetup)
			{
				MainSearchMC strawhat22 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadFraudSetup(strawhat22.Id, strawhat22.ScoreFrom, strawhat22.ScoreTo);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteFraudSetup)
			{
				MainSearchMC strawhat23 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result7 = _mc.DeleteFraudSetup(Convert.ToInt64(strawhat23.Id));
				return Result7;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateFraudIndicator)
			{
				FraudIndicators strawhat25 = JsonConvert.DeserializeObject<FraudIndicators>(obj.Request.ToString());
				return _mc.InsertUpdateFraudIndicators(strawhat25);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadFraudIndicator)
			{
				MainSearchMC strawhat24 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadFraudIndicators(strawhat24.Id, strawhat24.Name, strawhat24.Status);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteFraudIndicator)
			{
				MainSearchMC strawhat21 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result6 = _mc.DeleteFraudIndicators(Convert.ToInt64(strawhat21.Id));
				return Result6;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateWorkFlowStage)
			{
				WorkFlowStages strawhat20 = JsonConvert.DeserializeObject<WorkFlowStages>(obj.Request.ToString());
				return _mc.InsertWorkFlowDelegation(strawhat20);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadWorkFlowStage)
			{
				MainSearchMC strawhat18 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadWorkFlowStages(strawhat18.Id, strawhat18.Name);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteWorkFlowStage)
			{
				MainSearchMC strawhat16 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result5 = _mc.DeleteWorkFlowStages(Convert.ToInt64(strawhat16.Id));
				return Result5;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateDelegation)
			{
				DelegationSetup strawhat14 = JsonConvert.DeserializeObject<DelegationSetup>(obj.Request.ToString());
				return _mc.InsertUpdateDelegation(strawhat14);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadDelegation)
			{
				MainSearchMC strawhat13 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadDelegation(strawhat13.Id, strawhat13.Status);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteDelegation)
			{
				MainSearchMC strawhat12 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result3 = _mc.DeleteDelegation(strawhat12.Id.Value);
				return Result3;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateDocuments)
			{
				DocumentInfo strawhat10 = JsonConvert.DeserializeObject<DocumentInfo>(obj.Request.ToString());
				return _mc.InsertUpdateDocuments(strawhat10);
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateAuthorityMatrix)
			{
				AuthorityMatrix strawhat9 = JsonConvert.DeserializeObject<AuthorityMatrix>(obj.Request.ToString());
				return _mc.InsertUpdateAuthorityMatrix(strawhat9);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadAuthorityMatrix)
			{
				MainSearchMC strawhat7 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadAuthorityMatrix(strawhat7.Id, strawhat7.ModuleId);
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateAttachment)
			{
				Attachments strawhat5 = JsonConvert.DeserializeObject<Attachments>(obj.Request.ToString());
				return _mc.InsertUpdateAttachments(strawhat5);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadDocuments)
			{
				MainSearchMC strawhat4 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadDocuments(strawhat4.Id, strawhat4.ModuleId);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadAttachment)
			{
				MainSearchMC strawhat3 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadAttachments(strawhat3.Id, strawhat3.ModuleId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteDocuments)
			{
				MainSearchMC strawhat = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result = _mc.DeleteDocument(strawhat.Id.Value);
				return Result;
			}
			return JsonConvert.DeserializeObject<object>(FinalResult);
		}

		[HttpPost]
		[Route("ClaimsTransactions")]
		public object ClaimsTransactions([FromBody] SetupClaimsRequestcs obj)
		{
			string FinalResult = "";
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateProductionInfo)
			{
				ProductionInfo strawhat = JsonConvert.DeserializeObject<ProductionInfo>(obj.Request.ToString());
				ProductionInfo Resullt = _mc.InsertUpdateProductionInfo(strawhat);
				FinalResult = JsonConvert.SerializeObject(Resullt);
				return Resullt;
			}
			if (obj.TransactionType == ClaimTransactionType.LoadProductionInfo)
			{
				MainSearchMC strawhat5 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadProductionInfo(strawhat5.Id, strawhat5.OwnerId, strawhat5.PolicyId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteProductionInfo)
			{
				MainSearchMC strawhat7 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result2 = _mc.DeleteProductionInfo(Convert.ToInt64(strawhat7.Id));
				return Result2;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateVehicleCovers)
			{
				VehileCovers strawhat9 = JsonConvert.DeserializeObject<VehileCovers>(obj.Request.ToString());
				VehileCovers Resullt2 = _mc.InsertUpdateVehileCovers(strawhat9);
				FinalResult = JsonConvert.SerializeObject(Resullt2);
				return Resullt2;
			}
			if (obj.TransactionType == ClaimTransactionType.LoadVehicleCovers)
			{
				MainSearchMC strawhat11 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadVehileCovers(strawhat11.Id, strawhat11.PolicyId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteProductionInfo)
			{
				MainSearchMC strawhat13 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result4 = _mc.DeleteVehileCovers(Convert.ToInt64(strawhat13.Id));
				return Result4;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateVehicleInfo)
			{
				VehiclesInfo strawhat15 = JsonConvert.DeserializeObject<VehiclesInfo>(obj.Request.ToString());
				VehiclesInfo Resullt4 = _mc.InsertUpdateVehicleInfo(strawhat15);
				FinalResult = JsonConvert.SerializeObject(Resullt4);
				return Resullt4;
			}
			if (obj.TransactionType == ClaimTransactionType.LoadVehicleInfo)
			{
				MainSearchMC strawhat17 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadVehicleInfo(strawhat17.Id, strawhat17.Sequence);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteVehicleInfo)
			{
				MainSearchMC strawhat19 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result6 = _mc.DeleteVehicleInfo(Convert.ToInt64(strawhat19.Id));
				return Result6;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateEclaim)
			{
				EClaims strawhat21 = JsonConvert.DeserializeObject<EClaims>(obj.Request.ToString());
				EClaims Resullt6 = _mc.InsertUpdateEClaims(strawhat21);
				FinalResult = JsonConvert.SerializeObject(Resullt6);
				return Resullt6;
			}
			if (obj.TransactionType == ClaimTransactionType.LoadEclaim)
			{
				MainSearchMC strawhat25 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadEclaims(strawhat25.Id, strawhat25.NationalID);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteEclaim)
			{
				MainSearchMC strawhat27 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result8 = _mc.DeleteEClaims(Convert.ToInt64(strawhat27.Id));
				return Result8;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateClaim)
			{
				Claims strawhat29 = JsonConvert.DeserializeObject<Claims>(obj.Request.ToString());
				Claims Resullt7 = _mc.InsertUpdateClaims(strawhat29);
				FinalResult = JsonConvert.SerializeObject(Resullt7);
				return Resullt7;
			}
			if (obj.TransactionType == ClaimTransactionType.LoadClaim)
			{
				MainSearchMC strawhat32 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadClaims(strawhat32.Id, strawhat32.PolicyId, strawhat32.AccidentNo);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadClaimsMaster)
			{
				MainSearchMC strawhat31 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadClaimsMaster(strawhat31.NationalID, strawhat31.Branch, strawhat31.chassis, strawhat31.claimno, strawhat31.mobile, strawhat31.policy, strawhat31.RegisteredFrom, strawhat31.RegisteredTo, strawhat31.ClaimStatus, strawhat31.Id);
			}
			if (obj.TransactionType == ClaimTransactionType.UpdateAssign)
			{
				MainSearchMC strawhat30 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.UpdateAssign(strawhat30.ClaimId.Value, strawhat30.UserId.Value);
			}
			if (obj.TransactionType == ClaimTransactionType.InsertClaimVehicle)
			{
				ClaimVehicle strawhat28 = JsonConvert.DeserializeObject<ClaimVehicle>(obj.Request.ToString());
				return _mc.InsertClaimVehicle(strawhat28);
			}
			if (obj.TransactionType == ClaimTransactionType.ReserveBalance)
			{
				MainSearchMC strawhat26 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.ReserveBalance(strawhat26.ClaimId.Value, strawhat26.ClaimantId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteClaim)
			{
				MainSearchMC strawhat24 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result7 = _mc.DeleteClaim(Convert.ToInt64(strawhat24.Id));
				return Result7;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateClaimTransaction)
			{
				ClaimTransactions strawhat23 = JsonConvert.DeserializeObject<ClaimTransactions>(obj.Request.ToString());
				return _mc.InsertUpdateClaimTrans(strawhat23);
			}
			if (obj.TransactionType == ClaimTransactionType.InsertReserve)
			{
				Reserve strawhat22 = JsonConvert.DeserializeObject<Reserve>(obj.Request.ToString());
				return _mc.InsertReserve(strawhat22);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadClaimTransactions)
			{
				MainSearchMC strawhat20 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadClaimTrans(strawhat20.TransactionType.Value, strawhat20.ClaimantId.Value);
			}
			if (obj.TransactionType == ClaimTransactionType.LoadReserve)
			{
				MainSearchMC strawhat18 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadReserve(strawhat18.Id, strawhat18.ClaimId, strawhat18.TransactionId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteClaimTransactions)
			{
				MainSearchMC strawhat16 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result5 = _mc.DeleteClaimTrans(Convert.ToInt64(strawhat16.Id));
				return Result5;
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateClaimants)
			{
				Claimants strawhat14 = JsonConvert.DeserializeObject<Claimants>(obj.Request.ToString());
				Claimants Resullt5 = _mc.InsertUpdateClaimants(strawhat14);
				FinalResult = JsonConvert.SerializeObject(Resullt5);
				return Resullt5;
			}
			if (obj.TransactionType == ClaimTransactionType.LoadClaimants)
			{
				MainSearchMC strawhat12 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadClaimants(strawhat12.Id, strawhat12.ClaimId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteClaimants)
			{
				MainSearchMC strawhat10 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result3 = _mc.Claimants(Convert.ToInt64(strawhat10.Id));
				return Result3;
			}
			if (obj.TransactionType == ClaimTransactionType.IsertUpdateCollection)
			{
				Collectors strawhat8 = JsonConvert.DeserializeObject<Collectors>(obj.Request.ToString());
				Collectors Resullt3 = _mc.InsertUpdateCollectorss(strawhat8);
				FinalResult = JsonConvert.SerializeObject(Resullt3);
				return Resullt3;
			}
			if (obj.TransactionType == ClaimTransactionType.LoadCollection)
			{
				MainSearchMC strawhat6 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadCollectors(strawhat6.Id, strawhat6.ClaimId);
			}
			if (obj.TransactionType == ClaimTransactionType.DeleteCollection)
			{
				MainSearchMC strawhat4 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				bool Result = _mc.DeleteCollectors(Convert.ToInt64(strawhat4.Id));
				return Result;
			}
			if (obj.TransactionType == ClaimTransactionType.LoadClaimVehicle)
			{
				MainSearchMC strawhat3 = JsonConvert.DeserializeObject<MainSearchMC>(obj.Request.ToString());
				return _mc.LoadClaimVehicle(Convert.ToInt64(strawhat3.ClaimId));
			}
			if (obj.TransactionType == ClaimTransactionType.InsertUpdateSurvoyerEntry)
			{
				Survoyer strawhat2 = JsonConvert.DeserializeObject<Survoyer>(obj.Request.ToString());
				return _mc.InsertUpdateSurvoyerEntry(strawhat2);
			}
			return null;
		}

		[HttpPost]
		[Route("SearchClaimInfo")]
		public object SearchClaimInfo([FromBody] SearchingObj obj)
		{
			ClaimSearchResult claimSearchResult = new ClaimSearchResult();
			return _mc.claimSearch(obj, _appSettings.Connection);
		}

		[HttpPost]
		[Route("UploadNaphies")]
		public void UploadNaphies([FromBody] List<int> naphies)
		{
			naphies.ForEach(delegate(int trx)
			{
				HttpClient httpClient = new HttpClient();
				string requestUri = trx.ToString();
				httpClient.BaseAddress = new Uri("http://172.16.1.22:81/AIMSNphies/respond_preAuth/");
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
			});
		}

		[HttpPost]
		[Route("Migration")]
		public void MigrationClaim([FromBody] string Policy)
		{
			_mc.MigrationClaim(_appSettings.EskaConnection, Policy, null);
		}

		[HttpPost]
		[Route("NajmDetails")]
		public NajmResponse NajmDetails([FromBody] string NajmReport)
		{
			NajmResponse najmResponse = new NajmResponse();
			return _mc.LoadNajmData(NajmReport);
		}

		[HttpPost]
		[Route("TaqdeerDetails")]
		public TaqdeerResponse TaqdeerDetails([FromBody] string NajmReport)
		{
			TaqdeerResponse najmResponse = new TaqdeerResponse();
			return _mc.LoadTaqdeer(NajmReport);
		}

		[HttpPost]
		[Route("Loadlookups")]
		public List<LookupTable> Loadlookups([FromBody] SearchLookUp obj)
		{
			List<LookupTable> lookupTables = new List<LookupTable>();
			return _mc.LoadLookUp(obj);
		}

		[HttpPost]
		[Route("LoadDomains")]
		public List<DDL> LoadDomains([FromBody] SearchLookUp obj)
		{
			List<DDL> ddl = new List<DDL>();
			return Setup.LoadDomains(_appSettings.EskaConnection, (int)obj.MajorCode.Value);
		}

		[HttpPost]
		[Route("AutoAssign")]
		public Claims AutoAssign([FromBody] AutoAssignObj obj)
		{
			return _mc.UpdateAutoAssign(obj, _appSettings.Connection);
		}

		[HttpPost]
		[Route("LoadeClaims")]
		public List<eClaims> LoadeClaims([FromBody] eClaimsObj obj)
		{
			List<eClaims> eClaims = new List<eClaims>();
			return _mc.LoadeClaims(obj, _appSettings.Connection);
		}

		[HttpPost]
		[Route("GetBasherInfo")]
		public void GetBasherInfo([FromBody] BasherFilter basherFilter)
		{
			using HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_appSettings.BasherSetup.URL);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Add("app-id", _appSettings.BasherSetup.appid);
			client.DefaultRequestHeaders.Add("app-key", _appSettings.BasherSetup.appkey);
			client.DefaultRequestHeaders.Add("Operator-ID", _appSettings.BasherSetup.OperatorID);
			client.DefaultRequestHeaders.Add("client-key", _appSettings.BasherSetup.clientkey);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string param = "accidents?accident-number=" + basherFilter.accidentnumber + "&vehicle-sequence=" + basherFilter.vehiclesequence;
			Task<HttpResponseMessage> responseTask = client.GetAsync(param);
			responseTask.Wait();
			HttpResponseMessage responsePost = responseTask.Result;
			if (responsePost.IsSuccessStatusCode)
			{
				BasherResponse crDetails = new BasherResponse();
				crDetails = JsonConvert.DeserializeObject<BasherResponse>(responsePost.Content.ReadAsStringAsync().Result);
			}
		}

		[HttpPost]
		[Route("GetBashermage")]
		public void GetBashermage([FromBody] string token)
		{
			using HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_appSettings.BasherSetup.URL);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Add("app-id", _appSettings.BasherSetup.appid);
			client.DefaultRequestHeaders.Add("app-key", _appSettings.BasherSetup.appkey);
			client.DefaultRequestHeaders.Add("Operator-ID", _appSettings.BasherSetup.OperatorID);
			client.DefaultRequestHeaders.Add("client-key", _appSettings.BasherSetup.clientkey);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string param = "accident-images?token=" + token;
			Task<HttpResponseMessage> responseTask = client.GetAsync(param);
			responseTask.Wait();
			HttpResponseMessage responsePost = responseTask.Result;
			if (!responsePost.IsSuccessStatusCode)
			{
				return;
			}
			string path = Path.Combine("D:\\", "test.jpge");
			byte[] image = responsePost.Content.ReadAsByteArrayAsync().Result;
			using MemoryStream ms = new MemoryStream(image);
			try
			{
				Bitmap patternImage = new Bitmap(ms);
				patternImage.Save(path, ImageFormat.Jpeg);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
