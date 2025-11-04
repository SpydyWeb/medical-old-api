using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;
using Newtonsoft.Json;
using Service.Interfaces;
using SharedDomain.DTO.New_Financial_Model;
using SharedDomain.Models;
using SharedDomain.Models.SearchCriteria;
using SharedSetup.Domain.DTO.Core;
using SharedSetup.Domain.DTO.Financial;
using SharedSetup.Domain.DTO.SharedSetup;
using SharedSetup.Domain.Extension;
using SharedSetup.Domain.Models;

namespace Service.Services
{
	public class TPIntegrationService : BaseTPService, ITPIntegrationService
	{
		private string authToken;

		public string AuthToken
		{
			get
			{
				return authToken;
			}
			set
			{
				authToken = value;
			}
		}

		public TPIntegrationService(HttpClient client)
			: base(client)
		{
		}

		public async Task<List<SelectItem>> GetInsuranceSystems(int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetInsuranceSystems/", authToken)).ToList();
		}

		public async Task<IResponseResult<IEnumerable<SstSystems>>> GetSystems(int companyId)
		{
			return await GetFrom<IResponseResult<IEnumerable<SstSystems>>>(SharedSettings.SharedSetupUrl, "TPIntegration/GetSystems?companyId=" + companyId, authToken);
		}

		public async Task<List<SelectItem>> GetAllInsuranceClasses(string query, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetAllInsuranceClasses/" + query + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetInsuranceClassesByAppId(int systemId, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetInsuranceClassesBySysId/" + systemId + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetInsuranceClassesByLobCode(int systemId, int companyId, int lobCode)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetInsuranceClassesByLobCode/" + systemId + "/" + companyId + "/" + lobCode, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetInsuranceClassesByCompanyId(int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetInsuranceClassesByCompanyId/" + companyId, authToken)).ToList();
		}

		public async Task<IResponseResult<IEnumerable<SstClasses>>> GetAllClasses(int companyId)
		{
			return await GetFrom<IResponseResult<IEnumerable<SstClasses>>>(SharedSettings.SharedSetupUrl, "TPIntegration/GetAllClasses?companyId=" + companyId, authToken);
		}

		public async Task<List<SelectItem>> GetInsuranceClassesSuggest(string query, int systemId, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetInsuranceClassesSuggest/" + query + "/" + systemId + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetSubLOBByClassId(int classId, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetSubLOBByClassId/" + classId + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetSubLOBByCompanyId(int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetSubLOBByCompanyId/" + companyId, authToken)).ToList();
		}

		public async Task<IResponseResult<IEnumerable<SstPolicyTypes>>> GetAllSubLOB(int companyId)
		{
			return await GetFrom<IResponseResult<IEnumerable<SstPolicyTypes>>>(SharedSettings.SharedSetupUrl, "TPIntegration/GetAllSubLOB?companyId=" + companyId, authToken);
		}

		public async Task<List<SelectItem>> GetSubLOBSuggest(string query, int classId, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetSubLOBSuggest/" + query + "/" + classId + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetDomainValues(int domainCode, int systemId, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetDomainValues/" + domainCode + "/" + systemId + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetDomainSuggest(string query, int systemId, string moduleCode, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetDomainSuggest/" + query + "/" + systemId + "/" + moduleCode + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetModulesBySysId(int systemId, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetModulesBySysId/" + systemId + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetModuleById(int id, int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetModuleById/" + id + "/" + companyId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCoversBySystemClassesSUBLOB(int companyId, string SystemId, string ClassId, string SubLOB)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCoversBySystemClassesSUBLOB/" + companyId + "/" + SystemId + "/" + ClassId + "/" + SubLOB, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCoversBySysId(int companyId, long systemId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCoversBySysId/" + companyId + "/" + systemId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCompanies()
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetAccountById", authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCountries()
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCountries", authToken)).ToList();
		}

		public async Task<CoreResponseDTO<IEnumerable<CountriesDTO>>> GetCountriesDTO()
		{
			return await GetFrom<CoreResponseDTO<IEnumerable<CountriesDTO>>>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCoreCountries", authToken);
		}

		public async Task<List<SelectItem>> GetCities(string countyCode)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCities/" + countyCode, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetAreas(int city, string countyCode)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetAreas/" + city + "/" + countyCode, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetBranches(int companyID)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetBranches/" + companyID, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCurrencies()
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/getCurrencies", authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetAllPaymentCycle()
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetAllPaymentCycle", authToken)).ToList();
		}

		public async Task<List<SstCodes>> GetByMajorCodeAndMinorCode(int majorCode, int companyId, int systemId, int minorCode)
		{
			return (await GetListFrom<SstCodes>(SharedSettings.SharedSetupUrl, "SstCodes/GetByMajorCodeAndMinorCode/" + majorCode + "/" + companyId + "/" + systemId + "/" + minorCode, authToken)).ToList();
		}

		public async Task<List<SstEndorsements>> GetAllEndorsementsType(int companyId)
		{
			return await GetFromResponseResult<List<SstEndorsements>>(SharedSettings.SharedSetupUrl, "SstEndorsements/GetAll/" + companyId, authToken);
		}

		public async Task<List<SstPaymentCycles>> GetPaymentCycles()
		{
			return (await GetListFrom<SstPaymentCycles>(SharedSettings.SharedSetupUrl, "SstPaymentCycles/GetAll/", authToken)).ToList();
		}

		public async Task<List<SstPaymentCycles>> GetPaymentCyclesFrequencies(long systemId)
		{
			return (await GetListFrom<SstPaymentCycles>(SharedSettings.SharedSetupUrl, "SstPaymentCycles/GetbySystemId/" + systemId, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCodesByCriteria(long majorCode, long companyId, long systemId, long minorCode, string moduleCode)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCodesByCriteria/" + companyId + "/" + majorCode + "/" + minorCode + "/" + systemId + "/" + moduleCode, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCodesSuggestByCriteria(long majorCode, long companyId, long systemId, long minorCode, string query)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCodesSuggestByCriteria", authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCodesByMajor(long majorCode, long companyId, long systemId, string moduleCode)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCodesByMajor/" + companyId + "/" + majorCode + "/" + systemId + "/" + moduleCode, authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCodesByCodeId(long companyId, long majorCode, long systemId, string moduleCode, long codeId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCodesByCodeId/" + companyId + "/" + majorCode + "/" + systemId + "/" + moduleCode + "/" + codeId, authToken)).ToList();
		}

		public async Task<SstDocumentGroups> GetDocumentGroupsById(long Id, long companyId)
		{
			return await GetFrom<SstDocumentGroups>(SharedSettings.SharedSetupUrl, "DocumentGroups/Get?id=" + Id + "&companyId=" + companyId, authToken);
		}

		public async Task<SstDocuments> GetDocumentById(long Id, long companyId)
		{
			return await GetFrom<SstDocuments>(SharedSettings.SharedSetupUrl, "Documents/GetBy?id=" + Id + "&companyId=" + companyId, authToken);
		}

		public async Task<List<SstDocumentGroups>> GetAllDocumentGroups()
		{
			return (await GetListFrom<SstDocumentGroups>(SharedSettings.SharedSetupUrl, "DocumentGroups/GetAll", authToken)).ToList();
		}

		public async Task<List<SstDocuments>> GetAllDocuments()
		{
			return (await GetListFrom<SstDocuments>(SharedSettings.SharedSetupUrl, "Documents/GetAll", authToken)).ToList();
		}

		public async Task<List<SstEntities>> GetEntities(int companyId, int[] entityTypes, string query)
		{
			string URL = "Entities/GetByCriteria?CompanyId=1&SegmentCode=" + query;
			foreach (int i in entityTypes)
			{
				URL = URL + "&EntityType=" + i;
			}
			return await GetFromResponseResult<List<SstEntities>>(SharedSettings.SharedSetupUrl, URL, authToken);
		}

		public async Task<SstEntities> GetEntityById(long id, int companyId)
		{
			return await GetFromResponseResult<SstEntities>(SharedSettings.SharedSetupUrl, "Entities/Get/" + id + "/" + companyId, authToken);
		}

		public async Task<List<string>> GetEntitiesNames(int companyId, int[] entityTypes, string query)
		{
			return (await GetEntities(companyId, entityTypes, query)).Select((SstEntities e) => e.SegmentCode + "-" + e.Name).ToList();
		}

		public async Task<string> GetEntityNameById(long id, int companyId)
		{
			SstEntities result = await GetEntityById(id, companyId);
			return result.SegmentCode + "-" + result.Name;
		}

		public async Task<List<SelectItem>> GetSectors()
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetSectors", authToken)).ToList();
		}

		public async Task<List<SstClauses>> GetClauses(long companyId, long classId, long policyType)
		{
			return (await GetListFrom<SstClauses>(SharedSettings.SharedSetupUrl, "TPIntegration/GetClauses/{companyId}/{classId}/{policyType}", authToken)).ToList();
		}

		public async Task<List<SstClausesDetails>> GetClausesDetails(long companyId, long clausessId)
		{
			return (await GetListFrom<SstClausesDetails>(SharedSettings.SharedSetupUrl, "TPIntegration/GetClausesDetails/{companyId}/{clausessId}", authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetDomains(string ModuleCode, int? systemId, int companyId)
		{
			if (ModuleCode == null)
			{
				ModuleCode = "null";
			}
			TPIntegrationService tPIntegrationService = this;
			string sharedSetupUrl = SharedSettings.SharedSetupUrl;
			string[] obj = new string[6] { "TPIntegration/GetDomains/", ModuleCode, "/", null, null, null };
			int? num = systemId;
			obj[3] = num.ToString();
			obj[4] = "/";
			obj[5] = companyId.ToString();
			return (await tPIntegrationService.GetListFrom<SelectItem>(sharedSetupUrl, string.Concat(obj), authToken)).ToList();
		}

		public async Task<List<SelectItem>> GetCodes(long companyId, long systemId, string moduleCode)
		{
			if (moduleCode == null)
			{
				moduleCode = "null";
			}
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCodes/" + companyId + "/" + systemId + "/" + moduleCode, authToken)).ToList();
		}

		public async Task<List<SstPolicyTypes>> GetPolicyTypesByCriteriaINT(long? systemId = null, long? classId = null, long? policyTypeId = null, long? ProductId = null)
		{
			return await GetFromResponseResult<List<SstPolicyTypes>>(url: "SstPolicyTypes/GetByCriteriaINT?InsuranceClassId=" + classId + "&PolicyTypeId=" + policyTypeId + "&ProductId=" + ProductId + "&SystemId=" + systemId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SstClasses>> GetClassesByCriteriaINT(long companyId, long? systemId = null, long? lobCode = null, long? businessChannel = null)
		{
			return await GetFromResponseResult<List<SstClasses>>(url: "SstClasses/GetByCriteriaINT?CompanyId=" + companyId + "&SystemId=" + systemId + "&LobCode=" + lobCode + "&BusinessChannel=" + businessChannel, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SelectItem>> GetCompanyGroups(int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCompanyGroups?companyId=" + companyId, authToken)).ToList();
		}

		public async Task<List<SstValuesRelation>> GetValuesRelaionByCriteriaINT(long CompanyId, long? RelationType = null, string MajorValue = null, long? SystemId = null)
		{
			return await GetFromResponseResult<List<SstValuesRelation>>(url: "SstValuesRelation/GetValuesRelaionByCriteriaINT?RelationType=" + RelationType + "&MajorValue=" + MajorValue + "&SystemId=" + SystemId + "&CompanyId=" + CompanyId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SstCodes>> GetCodesByCriteriaINT(long companyId, long? systemId = null, long? MajorCode = null, long? MinorCode = null, long? ParentMajorCode = null, long? ParentMinorCode = null, string ModuleCode = null)
		{
			return await GetFromResponseResult<List<SstCodes>>(url: "SstCodes/GetByCriteriaINT?CompanyId=" + companyId + (systemId.HasValue ? ("&SystemId=" + systemId) : string.Empty) + (MajorCode.HasValue ? ("&MajorCode=" + MajorCode) : string.Empty) + (MinorCode.HasValue ? ("&MinorCode=" + MinorCode) : string.Empty) + (ParentMajorCode.HasValue ? ("&ParentMajorCode=" + ParentMajorCode) : string.Empty) + (ParentMinorCode.HasValue ? ("&ParentMinorCode=" + systemId) : string.Empty) + ((!string.IsNullOrEmpty(ModuleCode)) ? ("&ModuleCode=" + ModuleCode.ToString()) : string.Empty), baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SstCodes>> GetParentCodes(long companyId, long? systemId = null, string ModuleCode = null)
		{
			string[] obj = new string[6]
			{
				"TPIntegration/GetParentCodes/",
				companyId.ToString(),
				"/",
				null,
				null,
				null
			};
			long? num = systemId;
			obj[3] = num.ToString();
			obj[4] = "/";
			obj[5] = ModuleCode;
			return await GetFromResponseResult<List<SstCodes>>(url: string.Concat(obj), baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SstCoverTypes>> GetCoverTypesByCriteriaINT(long companyId, long? systemId = null, long? PolicyTypeId = null, long? InsuranceClassId = null, string Name = null)
		{
			return await GetFromResponseResult<List<SstCoverTypes>>(url: "CoverTypes/GetByCriteriaINT?CompanyId=" + companyId + "&InsuranceSystemId=" + systemId + "&InsuranceClassId=" + InsuranceClassId + "&PolicyTypeId=" + PolicyTypeId + ((!string.IsNullOrEmpty(Name)) ? ("&Name=" + Name) : ""), baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<SstDiscounts> GetDiscountById(long Id, long companyId)
		{
			ResponseResult<SstDiscounts> result = await GetFrom<ResponseResult<SstDiscounts>>(url: "Discount/Get/" + Id + "/" + companyId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
			return (result.Data == null) ? new SstDiscounts() : result.Data;
		}

		public async Task<IEnumerable<SstFees>> GetAllFees(long CompanyId)
		{
			return await GetListFrom<SstFees>(url: "SstFees/GetAll/" + CompanyId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<IResponseResult<List<SstFeesTiers>>> GetFeeTiers(long CompanyId, long SystemId, long classId, long? subLobId, int? ApplyOn, int? ApplyReinsurance, int? ApplyClaims)
		{
			ResultStatus resultStatus = ResultStatus.Failed;
			TPIntegrationService tPIntegrationService = this;
			string sharedSetupUrl = SharedSettings.SharedSetupUrl;
			string[] obj = new string[14]
			{
				"TPIntegration/GetFeeTiers?CompanyId=",
				CompanyId.ToString(),
				"&SystemId=",
				SystemId.ToString(),
				"&ClassId=",
				classId.ToString(),
				"&SubLobId=",
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			long? num = subLobId;
			obj[7] = num.ToString();
			obj[8] = "&ApplyOn=";
			int? num2 = ApplyOn;
			obj[9] = num2.ToString();
			obj[10] = "&ApplyReinsurance=";
			num2 = ApplyReinsurance;
			obj[11] = num2.ToString();
			obj[12] = "&ApplyClaims=";
			num2 = ApplyClaims;
			obj[13] = num2.ToString();
			ResponseResult<IEnumerable<SstFeesTiers>> feeTiers = await tPIntegrationService.GetFrom<ResponseResult<IEnumerable<SstFeesTiers>>>(sharedSetupUrl, string.Concat(obj), authToken);
			List<SstFeesTiers> result = new List<SstFeesTiers>();
			if (feeTiers.Status == ResultStatus.Success)
			{
				result = feeTiers.Data.ToList();
				resultStatus = ResultStatus.Success;
			}
			return new ResponseResult<List<SstFeesTiers>>
			{
				Data = result,
				Errors = feeTiers.Errors,
				Status = resultStatus
			};
		}

		public async Task<List<SstBusinessChannels>> GetBusinessChannelsByCriteriaINT(long companyId, long? systemId = null, long? PolicyTypeId = null, long? ClassId = null)
		{
			return await GetFromResponseResult<List<SstBusinessChannels>>(url: "SstBusinessChannels/GetByCriteriaINT?CompanyId=" + companyId + "&SystemId=" + systemId + "&ClassId=" + ClassId + "&PolicyType=" + PolicyTypeId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SelectItem>> GetBusinessTypesByCriteriaINT(long companyId, long? systemId = null, long? PolicyTypeId = null, long? ClassId = null, long? businessTypeId = null, string currency = null, long? paymentCycleId = null, int? policyRelation = null)
		{
			return await GetFromResponseResult<List<SelectItem>>(url: "SstRelations/GetMatchingBusinessTypes?CompanyId=" + companyId + "&insuranceSystemId=" + systemId + "&insuranceClassId=" + ClassId + "&policyTypeId=" + PolicyTypeId + "&businessType=" + businessTypeId + "&currency=" + currency + "&paymentCycleId=" + paymentCycleId + "&policyRelation=" + policyRelation, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SstCoverRatingTypes>> GetCoverRatingTypesByCriteriaINT(long companyId, long CoverTypeId, long? PolicyTypeId = null)
		{
			return await GetFromResponseResult<List<SstCoverRatingTypes>>(url: "SstCoverRatingTypes/GetByCriteriaINT?CompanyId=" + companyId + "&CoverTypeId=" + CoverTypeId + "&PolicyTypeId=" + PolicyTypeId.EmptyIfNull().ToString(), baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<CoreResponseDTO<LoginDTO>> IsAuthorizedLogin(LoginDTO loginDTO)
		{
			return await PostFrom<CoreResponseDTO<LoginDTO>>(requestbody: JsonConvert.SerializeObject(loginDTO), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/IsAuthorizedLogin", authToken: authToken);
		}

		public async Task<List<SstOffices>> GetOfficesByCriteria(long companyId, long systemId, string name = null, string name2 = null, string code = null)
		{
			return (await GetFrom<ResponseResult<List<SstOffices>>>(url: "TPIntegration/GetOfficesByCriteria?companyId=" + companyId + "&systemId=" + systemId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken)).Data;
		}

		public async Task<List<SstPreferences>> GetPreferencesByCriteriaINT(long systemId, long companyId, string code = null)
		{
			string URL = "SstPreferences/GetByCriteria";
			var obj = new { systemId, companyId, code };
			return (await PostFrom<ResponseResult<List<SstPreferences>>>(requestbody: JsonConvert.SerializeObject(obj), baseAddress: SharedSettings.SharedSetupUrl, url: URL, authToken: authToken)).Data;
		}

		public async Task<List<SstPreferences>> getPreferencesListOfValues(string[] Codes, long SystemId, long CompanyId)
		{
			string URL = "SstPreferences/getPreferencesListOfValues?CompanyId=" + CompanyId + "&SystemId=" + SystemId;
			foreach (string i in Codes)
			{
				URL = URL + "&Codes=" + i.ToString();
			}
			return (await GetFrom<ResponseResult<List<SstPreferences>>>(SharedSettings.SharedSetupUrl, URL, authToken)).Data;
		}

		public async Task<List<SstDataSecurity>> GetDataSecurityByCriteriaINT(long companyId, string userName = null)
		{
			return (await GetFrom<ResponseResult<List<SstDataSecurity>>>(url: "DataSecurity/GetByCriteria?CompanyId=" + companyId + "&UserName=" + userName.ToString(), baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken)).Data;
		}

		public async Task<CoreResponseDTO<object>> Logout(object loginDTO)
		{
			return await PostFrom<CoreResponseDTO<object>>(requestbody: JsonConvert.SerializeObject(loginDTO), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/Logout", authToken: authToken);
		}

		public async Task<ResponseResult<List<SstClauses>>> GetClausesWithClausesDetails(long InsuranceSystem, long? InsuranceClassId, long? PolicyTypeId, string ClausesName, long? ClausesType, long? Criterion, string Description, int CompanyId, string UserName)
		{
			TPIntegrationService tPIntegrationService = this;
			string sharedSetupUrl = SharedSettings.SharedSetupUrl;
			string[] obj = new string[18]
			{
				"TPIntegration/GetClausesWithClausesDetails?InsuranceSystem=",
				InsuranceSystem.ToString(),
				"&InsuranceClassId=",
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			long? num = InsuranceClassId;
			obj[3] = num.ToString();
			obj[4] = "&PolicyTypeId=";
			num = PolicyTypeId;
			obj[5] = num.ToString();
			obj[6] = "&ClausesName=";
			obj[7] = ClausesName;
			obj[8] = "&ClausesType=";
			num = ClausesType;
			obj[9] = num.ToString();
			obj[10] = "&Criterion=";
			num = Criterion;
			obj[11] = num.ToString();
			obj[12] = "&Description=";
			obj[13] = Description;
			obj[14] = "&CompanyId=";
			obj[15] = CompanyId.ToString();
			obj[16] = "&UserName=";
			obj[17] = UserName;
			return await tPIntegrationService.GetFrom<ResponseResult<List<SstClauses>>>(sharedSetupUrl, string.Concat(obj), authToken);
		}

		public async Task<ResponseResult<List<SstAgents>>> GetSstAgents(long? SystemId, long? AgentType, long? ChannelType, string FinAgentId, long CompanyId, long? ClassId, long? PolicyType)
		{
			TPIntegrationService tPIntegrationService = this;
			string sharedSetupUrl = SharedSettings.SharedSetupUrl;
			string[] obj = new string[14]
			{
				"SstAgents/GetByCriteriaINT?CompanyId=",
				CompanyId.ToString(),
				"&SystemId=",
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			long? num = SystemId;
			obj[3] = num.ToString();
			obj[4] = "&AgentType=";
			num = AgentType;
			obj[5] = num.ToString();
			obj[6] = "&ChannelType=";
			num = ChannelType;
			obj[7] = num.ToString();
			obj[8] = "&FinAgentId=";
			obj[9] = FinAgentId;
			obj[10] = "&ClassId=";
			num = ClassId;
			obj[11] = num.ToString();
			obj[12] = "&PolicyType=";
			num = PolicyType;
			obj[13] = num.ToString();
			return await tPIntegrationService.GetFrom<ResponseResult<List<SstAgents>>>(sharedSetupUrl, string.Concat(obj), authToken);
		}

		public async Task<List<SstPackagedPolicy>> GetPackagedPolicyByCriteriaINT(long companyId, long? systemId = null, long? ClassId = null, long? PolicyTypeId = null, string ShortName = null, string Name = null, long? Status = null, DateTime? EffectiveDate = null, DateTime? ExpiryDate = null, string UserName = null)
		{
			string URL = "SstPackagedPolicy/GetByCriteriaINT";
			var obj = new
			{
				CompanyId = companyId,
				SystemId = systemId,
				ClassId = ClassId,
				PolicyTypeId = PolicyTypeId,
				ShortName = ShortName,
				Name = Name,
				Status = Status,
				EEffectiveDate = EffectiveDate,
				ExpiryDate = ExpiryDate,
				UserName = UserName
			};
			return (await PostFrom<ResponseResult<List<SstPackagedPolicy>>>(requestbody: JsonConvert.SerializeObject(obj), baseAddress: SharedSettings.SharedSetupUrl, url: URL, authToken: authToken)).Data;
		}

		public async Task<List<SstClosingPeriods>> GetClosingPeriodsByCriteria(long companyId, long? systemId = null, long? classId = null, long? policyTypeId = null)
		{
			return (await GetFrom<ResponseResult<List<SstClosingPeriods>>>(url: "ClosingPeriod/GetByCriteria?CompanyId=" + companyId + "&ClassId=" + classId + "&PolicyType=" + policyTypeId + "&SystemId=" + systemId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken)).Data;
		}

		public async Task<List<SelectItem>> GetUsersByCompanyId(int companyId)
		{
			return (await GetListFrom<SelectItem>(SharedSettings.SharedSetupUrl, "TPIntegration/GetUsersByCompanyId/" + companyId, authToken)).ToList();
		}

		public async Task<List<SstCommissionTypes>> GetCommissionTypesByCriteria(long companyId, string Name, string UserName, long? systemId = null, long? CommissionType = null, long? BusinessChannel = null, long? Position = null, long? Broker = null, long? Branch = null, long? InsuranceClass = null, long? PolicyType = null, DateTime? ValidFrom = null, DateTime? ValidTo = null)
		{
			string[] obj = new string[26]
			{
				"TPIntegration/GetCommissionTypesByCriteria?companyId=",
				companyId.ToString(),
				"&Name=",
				Name,
				"&UserName=",
				UserName,
				"&systemId=",
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			long? num = systemId;
			obj[7] = num.ToString();
			obj[8] = "&CommissionType=";
			num = CommissionType;
			obj[9] = num.ToString();
			obj[10] = "&BusinessChannel=";
			num = BusinessChannel;
			obj[11] = num.ToString();
			obj[12] = "&Position=";
			num = Position;
			obj[13] = num.ToString();
			obj[14] = "&Broker=";
			num = Broker;
			obj[15] = num.ToString();
			obj[16] = "&Branch=";
			num = Branch;
			obj[17] = num.ToString();
			obj[18] = "&InsuranceClass=";
			num = InsuranceClass;
			obj[19] = num.ToString();
			obj[20] = "&PolicyType=";
			num = PolicyType;
			obj[21] = num.ToString();
			obj[22] = "&ValidFrom=";
			DateTime? dateTime = ValidFrom;
			obj[23] = dateTime.ToString();
			obj[24] = "&ValidTo=";
			dateTime = ValidTo;
			obj[25] = dateTime.ToString();
			return (await GetListFrom<SstCommissionTypes>(url: string.Concat(obj), baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken)).ToList();
		}

		public async Task<ResponseResult<List<SstCommissionStructure>>> GetSstCommissionStructure(long? companyId, long? systemId, short? category = null, long? commStructureId = null)
		{
			return await GetFrom<ResponseResult<List<SstCommissionStructure>>>(url: "SstCommissionStructure/GetByCriteria?CompanyId=" + companyId + "&SystemId=" + systemId + "&Category=" + category + "&CommStructureId=" + commStructureId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<ResponseResult<List<SstCommissionStructure>>> GetSstCommissionStructureByCriteriaINT(long CompanyId, int PageNo, short BusinessType, long? SystemId, string Name, string Categories, short? ClassId, short? PolicyType, byte? AutoAdd)
		{
			return await GetFrom<ResponseResult<List<SstCommissionStructure>>>(url: "SstCommissionStructure/GetByCriteriaINT?CompanyId=" + CompanyId + "&PageNo=" + PageNo + "&BusinessType=" + BusinessType + "&SystemId=" + SystemId + "&Name=" + Name + "&Categories=" + Categories + "&ClassId=" + ClassId + "&PolicyType=" + PolicyType + "&AutoAdd=" + AutoAdd, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<IResponseResult<IEnumerable<SstFinancialPolicies>>> LoadVouchers(VouchersBuilder vouchers)
		{
			return await PostFrom<ResponseResult<IEnumerable<SstFinancialPolicies>>>(requestbody: JsonConvert.SerializeObject(vouchers), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/LoadVouchers", authToken: authToken);
		}

		public async Task<IResponseResult<IEnumerable<SstFinancialDetails>>> LoadVoucherDetails(SstFinancialTransactions entities)
		{
			return await PostFrom<ResponseResult<IEnumerable<SstFinancialDetails>>>(requestbody: JsonConvert.SerializeObject(entities), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/LoadVoucherDetails", authToken: authToken);
		}

		public async Task<List<SstCommissionStructure>> GetCommissionTypesINTByCriteria(long classId, long BusinessType, long? PolicyType = null)
		{
			string[] obj = new string[6]
			{
				"TPIntegration/GetCommissionTypesINTByCriteria?&classId=",
				classId.ToString(),
				"&BusinessType=",
				BusinessType.ToString(),
				"&PolicyType=",
				null
			};
			long? num = PolicyType;
			obj[5] = num.ToString();
			return (await GetListFrom<SstCommissionStructure>(url: string.Concat(obj), baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken)).ToList();
		}

		public async Task<List<AgentSetupValues>> GetMatchingAgents(AgentCustomersSearchCriteria agentCustomersSearchCriteria)
		{
			return await PostFromResponseResult<List<AgentSetupValues>>(requestbody: JsonConvert.SerializeObject(agentCustomersSearchCriteria), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GetMatchingAgents", authToken: authToken);
		}

		public async Task<SstCoverTypes> GetCoverById(long id, long companyId)
		{
			SstCoverTypes result = await GetFrom<SstCoverTypes>(url: "CoverTypes/Get/" + id + "/" + companyId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
			return (result == null) ? new SstCoverTypes() : result;
		}

		public async Task<SstFees> GetFeeById(long id, long companyId)
		{
			SstFees result = await GetFrom<SstFees>(url: "SstFees/GetFeeById/" + id + "/" + companyId, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
			return (result == null) ? new SstFees() : result;
		}

		public async Task<CoreResponseDTO<List<ResourcesDTO>>> GetControlsResources(ResourcesRequestDTO search)
		{
			JsonConvert.SerializeObject(search);
			string querySTR = search.ToQueryString();
			return await GetFrom<CoreResponseDTO<List<ResourcesDTO>>>(url: "TPIntegration/GetControlsResources?" + querySTR, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public string GetResourceValue(long companyId, string resourceObject, string resourceName, string culture)
		{
			if (!string.IsNullOrEmpty(resourceName))
			{
				ResourcesRequestDTO search = new ResourcesRequestDTO();
				search.CAM_APP_ID = 334L;
				search.CRG_COM_ID = companyId;
				search.RESOURCE_NAME = resourceName;
				search.RESOURCE_OBJECT = resourceObject;
				search.CULTURE_NAME = culture;
				Task<CoreResponseDTO<List<ResourcesDTO>>> ResourcesDTOResult = Task.Run(async () => await GetControlsResources(search));
				if (ResourcesDTOResult.Result.data != null && ResourcesDTOResult.Result.data.Count() > 0)
				{
					return (ResourcesDTOResult.Result.data.FirstOrDefault() != null) ? ResourcesDTOResult.Result.data.FirstOrDefault().RESOURCE_VALUE : string.Empty;
				}
				return resourceName;
			}
			return string.Empty;
		}

		public List<string> GetResourceValuesList(long companyId, string resourceObject, string resourceNames, string culture, char seperator = '#')
		{
			List<string> resourceValues = new List<string>();
			if (!string.IsNullOrEmpty(resourceNames))
			{
				List<string> resourceNamesList = resourceNames.Split(seperator).ToList();
				foreach (string resourceName in resourceNamesList)
				{
					ResourcesRequestDTO search = new ResourcesRequestDTO();
					search.CAM_APP_ID = 334L;
					search.CRG_COM_ID = companyId;
					search.RESOURCE_NAME = resourceName;
					search.RESOURCE_OBJECT = resourceObject;
					search.CULTURE_NAME = culture;
					Task<CoreResponseDTO<List<ResourcesDTO>>> ResourcesDTOResult = Task.Run(async () => await GetControlsResources(search));
					if (ResourcesDTOResult.Result.data != null && ResourcesDTOResult.Result.data.Count() > 0)
					{
						string resourceValue = ((ResourcesDTOResult.Result.data.FirstOrDefault() != null) ? ResourcesDTOResult.Result.data.FirstOrDefault().RESOURCE_VALUE : string.Empty);
						resourceValues.Add(resourceValue);
					}
					else
					{
						resourceValues.Add(resourceName);
					}
				}
				return resourceValues;
			}
			return resourceValues;
		}

		public async Task<IResponseResult<SstAgentBookDetails>> UpdateAgentPageAsync(long? PageNo, DateTime IssueDate, long? oldPageNo)
		{
			string[] obj = new string[6] { "SstAgentBookDetails/UpdateAgentPage?PageNo=", null, null, null, null, null };
			long? num = PageNo;
			obj[1] = num.ToString();
			obj[2] = "&IssueDate=";
			obj[3] = IssueDate.ToString();
			obj[4] = "&oldPageNo=";
			num = oldPageNo;
			obj[5] = num.ToString();
			await GetFrom<ResponseResult<object>>(url: string.Concat(obj), baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
			return new ResponseResult<SstAgentBookDetails>
			{
				Data = null
			};
		}

		public async Task<ResponseResult<long>> GenerateSerial(GenerateSerialDTO serialDTO)
		{
			return await PostFrom<ResponseResult<long>>(requestbody: JsonConvert.SerializeObject(serialDTO), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GenerateSerial", authToken: authToken);
		}

		public async Task<ResponseResult<string>> GenerateSegment(GenerateSegmentDTO segmentDTO)
		{
			return await PostFrom<ResponseResult<string>>(requestbody: JsonConvert.SerializeObject(segmentDTO), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GenerateSegmentCode", authToken: authToken);
		}

		public async Task<List<SstClosingPeriods>> GetValidClosingPeriods(long companyId, long? systemId = null, long? classId = null, long? policyTypeId = null, long? branchId = null, string moduleCode = "")
		{
			string querySTR = new SstClosingPeriodsSearchCriteria
			{
				ClassId = classId,
				CompanyId = companyId,
				SystemId = systemId,
				PolicyType = policyTypeId,
				Module = moduleCode,
				BranchId = branchId
			}.ToQueryString();
			ResponseResult<List<SstClosingPeriods>> result = await GetFrom<ResponseResult<List<SstClosingPeriods>>>(url: "ClosingPeriod/GetValidClosingPeriods?" + querySTR, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
			return (result.Data != null) ? result.Data : new List<SstClosingPeriods>();
		}

		public async Task<ResponseResult<SstFeesTiers>> GetSstFeesTiersByCriteriaINT(SstFeesTiersSearchCriteria searchCriteria)
		{
			string query = searchCriteria.ToQueryString();
			return await GetFrom<ResponseResult<SstFeesTiers>>(url: "SstFeesTiers/GetByCriteriaINT?" + query, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<ResponseResult<IEnumerable<SstDiscounts>>> GetDiscountLoadingList(DiscountsSearchCriteria searchCriteria)
		{
			string querySTR = searchCriteria.ToQueryString();
			return await GetFrom<ResponseResult<IEnumerable<SstDiscounts>>>(url: "Discount/GetByCriteria?" + querySTR, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<ResponseResult<IEnumerable<SstFees>>> GetFeeTypesList(FeesSearchCriteria searchCriteria)
		{
			string querySTR = searchCriteria.ToQueryString();
			return await GetFrom<ResponseResult<IEnumerable<SstFees>>>(url: "SstFees/GetByCriteria?" + querySTR, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<UserDTO> GetUsersInfo(string username)
		{
			return await GetFrom<UserDTO>(SharedSettings.SharedSetupUrl, "TPIntegration/GetUserInfo?username=" + username, authToken);
		}

		public async Task<List<SstAgentCommissionTiers>> GetSstAgentCommissionTiersByCriteriaINT(SstAgentCommissionTiersSearchCriteria searchCriteria)
		{
			return await PostFromResponseResult<List<SstAgentCommissionTiers>>(requestbody: JsonConvert.SerializeObject(searchCriteria), baseAddress: SharedSettings.SharedSetupUrl, url: "SstAgentCommissionTiers/GetByCriteriaINT", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<List<CustomerOutput>>> GetCustomers(CustomerInput customerInput)
		{
			return await PostFrom<FinancialResponseDTO<List<CustomerOutput>>>(requestbody: JsonConvert.SerializeObject(customerInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GetCustomers", authToken: authToken);
		}

		public string GetCustomerName(CustomerInput customerInput)
		{
			FinancialResponseDTO<List<CustomerOutput>> financialResponseDTO = Task.Run(async () => await GetCustomers(customerInput)).Result;
			if (!financialResponseDTO.IsError && financialResponseDTO.Data != null && financialResponseDTO.Data.Count > 0)
			{
				return financialResponseDTO.Data.FirstOrDefault().Name;
			}
			return string.Empty;
		}

		public async Task<FinancialResponseDTO<IEnumerable<CustomerDTO>>> GetCustomersDTOOnPremise(int companyId, string query, string roles)
		{
			return await GetFrom<FinancialResponseDTO<IEnumerable<CustomerDTO>>>(SharedSettings.SharedSetupUrl, "TPIntegration/GetCustomersDTOOnPremise/" + companyId + "/" + query + "/" + roles, authToken);
		}

		public async Task<List<CustomerOutput>> GetCustomersOnPremise(int companyId, string query, string role)
		{
			List<CustomerOutput> customersOutputs = new List<CustomerOutput>();
			CustomerInput customerInput = new CustomerInput
			{
				CompanyId = companyId,
				Name = query,
				RoleIDs = role
			};
			FinancialResponseDTO<List<CustomerOutput>> financialResponseDTO = await GetCustomers(customerInput);
			if (financialResponseDTO != null && financialResponseDTO.Data != null && financialResponseDTO.Data.Count > 0)
			{
				customersOutputs = financialResponseDTO.Data;
			}
			return customersOutputs;
		}

		public async Task<List<SstCustomerTypes>> GetAllCustomerTypes()
		{
			return (await GetListFrom<SstCustomerTypes>(SharedSettings.SharedSetupUrl, "TPIntegration/GetAllCustomerTypes", authToken)).ToList();
		}

		public async Task<FinancialResponseDTO<List<CustomersOutput>>> InsertCustomer(CustomersInputObject customersInput)
		{
			return await PostFrom<FinancialResponseDTO<List<CustomersOutput>>>(requestbody: JsonConvert.SerializeObject(customersInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/InsertCustomer", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<List<CustomersOutput>>> UpdateCustomer(CustomersInputObject customersInput)
		{
			return await PostFrom<FinancialResponseDTO<List<CustomersOutput>>>(requestbody: JsonConvert.SerializeObject(customersInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/UpdateCustomer", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<List<ExchangeRateOutput>>> GetExchangeRate(ExchangeRateInput exchangeRateInput)
		{
			return await PostFrom<FinancialResponseDTO<List<ExchangeRateOutput>>>(requestbody: JsonConvert.SerializeObject(exchangeRateInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GetExchangeRate", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<List<FiscalYearOutput>>> GetFiscalYear(FiscalYearInput fiscalYearInput)
		{
			return await PostFrom<FinancialResponseDTO<List<FiscalYearOutput>>>(requestbody: JsonConvert.SerializeObject(fiscalYearInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GetFiscalYear", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<List<AccountOutput>>> GetAccounts(AccountInput accountInput)
		{
			return await PostFrom<FinancialResponseDTO<List<AccountOutput>>>(requestbody: JsonConvert.SerializeObject(accountInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GetAccounts", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<List<CostCenterOutput>>> GetCostCenter(CostCenterInput costCenterInput)
		{
			return await PostFrom<FinancialResponseDTO<List<CostCenterOutput>>>(requestbody: JsonConvert.SerializeObject(costCenterInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GetCostCenter", authToken: authToken);
		}

		public async Task<List<SelectItem>> GetCustomerAccountsList(CustomerAccountInput customerAccountInput)
		{
			return await PostFrom<List<SelectItem>>(requestbody: JsonConvert.SerializeObject(customerAccountInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GetCustomerAccountsList", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<string>> GetCustomerCurrency(long customerId, int companyId)
		{
			CustomerInput customerInput = new CustomerInput
			{
				ID = customerId,
				CompanyId = companyId
			};
			return await PostFrom<FinancialResponseDTO<string>>(requestbody: JsonConvert.SerializeObject(customerInput), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/GetCustomerCurrency", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<IEnumerable<TransPolicyOutput>>> PostVoucherTransactions(object obj)
		{
			return await PostFrom<FinancialResponseDTO<IEnumerable<TransPolicyOutput>>>(requestbody: JsonConvert.SerializeObject(obj), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/InsertTransactions", authToken: authToken);
		}

		public async Task<FinancialResponseDTO<UnpostTrans>> UnPostTransaction(UnpostTrans transaction)
		{
			return await PostFrom<FinancialResponseDTO<UnpostTrans>>(requestbody: JsonConvert.SerializeObject(transaction), baseAddress: SharedSettings.SharedSetupUrl, url: "TPIntegration/UnPostTransaction", authToken: authToken);
		}

		public async Task<List<SelectItem>> GetFeesByIdz(string Idz, int language)
		{
			return (await GetFromResponseResult<List<SelectItem>>(url: "SstFees/GetFeesByIdz?Idz=" + Idz.ToString() + "&language=" + language, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken)) ?? new List<SelectItem>();
		}

		public async Task<List<SelectItem>> GetCoverTypesByByIdz(string Idz)
		{
			return await GetFromResponseResult<List<SelectItem>>(url: "CoverTypes/GetCoverTypesByIdz?Idz=" + Idz, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SelectItem>> GetPolicyTypesByIdz(string Idz)
		{
			return await GetFromResponseResult<List<SelectItem>>(url: "SstPolicyTypes/GetPolicyTypesByIdz?Idz=" + Idz, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<SelectItem>> GetCommissionStructureByIdz(string Idz)
		{
			return await GetFromResponseResult<List<SelectItem>>(url: "SstCommissionStructure/GetCommissionStructureByIdz?Idz=" + Idz, baseAddress: SharedSettings.SharedSetupUrl, authToken: authToken);
		}

		public async Task<List<CustomerOutput>> GetCustomerByIdz(string customerIdz, int companyId)
		{
			CustomerInput customerInput = new CustomerInput
			{
				CompanyId = companyId,
				IDs = customerIdz
			};
			FinancialResponseDTO<List<CustomerOutput>> financialResponseDTO = await GetCustomers(customerInput);
			return (financialResponseDTO != null && financialResponseDTO.Data != null && financialResponseDTO.Data.Count > 0 && !financialResponseDTO.IsError) ? financialResponseDTO.Data : new List<CustomerOutput>();
		}

		public async Task<MntOldMIProvidersResponse<MntPrvNetOldMedical>> GetNetworkProviders(MntPrvNetSearchCriteria searchCriteria)
		{
			return await PostFrom<MntOldMIProvidersResponse<MntPrvNetOldMedical>>(requestbody: JsonConvert.SerializeObject(searchCriteria), baseAddress: SharedSettings.OldMedicalUrl, url: "NETWORK/LoadNetworkProviders", authToken: authToken);
		}
	}
}
