using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.SearchCriteria;
using SharedDomain.DTO.New_Financial_Model;
using SharedDomain.Models;
using SharedDomain.Models.SearchCriteria;
using SharedSetup.Domain.DTO.Core;
using SharedSetup.Domain.DTO.Financial;
using SharedSetup.Domain.DTO.SharedSetup;
using SharedSetup.Domain.Models;

namespace Service.Interfaces
{
	public interface ITPIntegrationService
	{
		string AuthToken { get; set; }

		Task<List<SelectItem>> GetInsuranceSystems(int companyId);

		Task<IResponseResult<IEnumerable<SstSystems>>> GetSystems(int companyId);

		Task<List<SelectItem>> GetAllInsuranceClasses(string query, int companyId);

		Task<List<SelectItem>> GetInsuranceClassesByAppId(int systemId, int companyId);

		Task<List<SelectItem>> GetInsuranceClassesByLobCode(int systemId, int companyId, int lobCode);

		Task<List<SelectItem>> GetInsuranceClassesByCompanyId(int companyId);

		Task<IResponseResult<IEnumerable<SstClasses>>> GetAllClasses(int companyId);

		Task<List<SelectItem>> GetInsuranceClassesSuggest(string query, int systemId, int companyId);

		Task<List<SelectItem>> GetSubLOBByClassId(int classId, int companyId);

		Task<List<SelectItem>> GetSubLOBByCompanyId(int companyId);

		Task<IResponseResult<IEnumerable<SstPolicyTypes>>> GetAllSubLOB(int companyId);

		Task<List<SelectItem>> GetSubLOBSuggest(string query, int classId, int companyId);

		Task<List<SelectItem>> GetDomainValues(int domainCode, int systemId, int companyId);

		Task<List<SelectItem>> GetDomainSuggest(string query, int systemId, string moduleCode, int companyId);

		Task<List<SelectItem>> GetModulesBySysId(int systemId, int companyId);

		Task<List<SelectItem>> GetModuleById(int id, int companyId);

		Task<List<SstEndorsements>> GetAllEndorsementsType(int companyId);

		Task<List<SelectItem>> GetCoversBySystemClassesSUBLOB(int companyId, string SystemId, string ClassId, string SubLOB);

		Task<List<SstCustomerTypes>> GetAllCustomerTypes();

		Task<List<SelectItem>> GetCompanies();

		Task<List<SelectItem>> GetCountries();

		Task<List<SelectItem>> GetCities(string countyCode);

		Task<List<SelectItem>> GetAreas(int city, string countyCode);

		Task<List<SelectItem>> GetBranches(int companyID);

		Task<List<SelectItem>> GetCurrencies();

		Task<List<SstCodes>> GetByMajorCodeAndMinorCode(int majorCode, int companyId, int systemId, int minorCode);

		Task<List<SelectItem>> GetCodesByMajor(long majorCode, long companyId, long systemId, string moduleCode);

		Task<List<SelectItem>> GetCodesByCriteria(long majorCode, long companyId, long systemId, long minorCode, string moduleCode);

		Task<List<SelectItem>> GetCodesSuggestByCriteria(long majorCode, long companyId, long systemId, long minorCode, string query);

		Task<List<SstPaymentCycles>> GetPaymentCycles();

		Task<List<SstPaymentCycles>> GetPaymentCyclesFrequencies(long systemId);

		Task<SstDocumentGroups> GetDocumentGroupsById(long Id, long companyId);

		Task<SstDocuments> GetDocumentById(long Id, long companyId);

		Task<List<SstDocumentGroups>> GetAllDocumentGroups();

		Task<List<SstDocuments>> GetAllDocuments();

		Task<List<SstEntities>> GetEntities(int companyId, int[] entityTypes, string query);

		Task<SstEntities> GetEntityById(long id, int companyId);

		Task<List<string>> GetEntitiesNames(int companyId, int[] entityTypes, string query);

		Task<string> GetEntityNameById(long id, int companyId);

		Task<List<SelectItem>> GetDomains(string ModuleCode, int? systemId, int companyId);

		Task<List<SelectItem>> GetCodes(long companyId, long systemId, string moduleCode);

		Task<List<SelectItem>> GetSectors();

		Task<List<SstClauses>> GetClauses(long companyId, long classId, long policyType);

		Task<List<SstClausesDetails>> GetClausesDetails(long companyId, long classId);

		Task<List<SstPolicyTypes>> GetPolicyTypesByCriteriaINT(long? systemId = null, long? classId = null, long? policyTypeId = null, long? ProductId = null);

		Task<List<SstClasses>> GetClassesByCriteriaINT(long companyId, long? systemId = null, long? lobCode = null, long? businessChannel = null);

		Task<List<SelectItem>> GetCompanyGroups(int companyId);

		Task<List<SstValuesRelation>> GetValuesRelaionByCriteriaINT(long CompanyId, long? RelationType = null, string MajorValue = null, long? SystemId = null);

		Task<List<SelectItem>> GetCoversBySysId(int companyId, long systemId);

		Task<List<SstCodes>> GetCodesByCriteriaINT(long companyId, long? systemId = null, long? MajorCode = null, long? MinorCode = null, long? ParentMajorCode = null, long? ParentMinorCode = null, string ModuleCode = null);

		Task<List<SstCoverTypes>> GetCoverTypesByCriteriaINT(long companyId, long? systemId = null, long? PolicyTypeId = null, long? InsuranceClassId = null, string Name = null);

		Task<SstDiscounts> GetDiscountById(long Id, long companyId);

		Task<IEnumerable<SstFees>> GetAllFees(long CompanyId);

		Task<IResponseResult<List<SstFeesTiers>>> GetFeeTiers(long CompanyId, long SystemId, long classId, long? subLobId, int? ApplyOn, int? ApplyReinsurance, int? ApplyClaims);

		Task<List<SstBusinessChannels>> GetBusinessChannelsByCriteriaINT(long companyId, long? systemId = null, long? PolicyTypeId = null, long? ClassId = null);

		Task<List<SelectItem>> GetBusinessTypesByCriteriaINT(long companyId, long? systemId = null, long? PolicyTypeId = null, long? ClassId = null, long? businessTypeId = null, string currency = null, long? paymentCycleId = null, int? policyRelation = null);

		Task<CoreResponseDTO<LoginDTO>> IsAuthorizedLogin(LoginDTO loginDTO);

		Task<List<SstCodes>> GetParentCodes(long companyId, long? systemId = null, string ModuleCode = null);

		Task<List<SstOffices>> GetOfficesByCriteria(long companyId, long systemId, string name = null, string name2 = null, string code = null);

		Task<List<SstPreferences>> GetPreferencesByCriteriaINT(long systemId, long companyId, string code = null);

		Task<List<SstDataSecurity>> GetDataSecurityByCriteriaINT(long companyId, string userName = null);

		Task<CoreResponseDTO<object>> Logout(object loginDTO);

		Task<ResponseResult<List<SstClauses>>> GetClausesWithClausesDetails(long InsuranceSystem, long? InsuranceClassId, long? PolicyTypeId, string ClausesName, long? ClausesType, long? Criterion, string Description, int CompanyId, string UserName);

		Task<ResponseResult<List<SstAgents>>> GetSstAgents(long? SystemId, long? AgentType, long? ChannelType, string FinAgentId, long CompanyId, long? ClassId, long? PolicyType);

		Task<List<SstPackagedPolicy>> GetPackagedPolicyByCriteriaINT(long CompanyId, long? systemId = null, long? ClassId = null, long? PolicyTypeId = null, string ShortName = null, string Name = null, long? Status = null, DateTime? EffectiveDate = null, DateTime? ExpiryDate = null, string UserName = null);

		Task<List<SstPreferences>> getPreferencesListOfValues(string[] Codes, long SystemId, long CompanyId);

		Task<List<SstClosingPeriods>> GetClosingPeriodsByCriteria(long companyId, long? systemId = null, long? classId = null, long? policyTypeId = null);

		Task<List<SelectItem>> GetUsersByCompanyId(int companyId);

		Task<FinancialResponseDTO<IEnumerable<CustomerDTO>>> GetCustomersDTOOnPremise(int companyId, string query, string roles);

		Task<ResponseResult<List<SstCommissionStructure>>> GetSstCommissionStructure(long? companyId, long? systemId, short? category = null, long? commStructureId = null);

		Task<IResponseResult<IEnumerable<SstFinancialPolicies>>> LoadVouchers(VouchersBuilder vouchers);

		Task<IResponseResult<IEnumerable<SstFinancialDetails>>> LoadVoucherDetails(SstFinancialTransactions entities);

		Task<SstCoverTypes> GetCoverById(long id, long companyId);

		Task<List<SstCoverRatingTypes>> GetCoverRatingTypesByCriteriaINT(long companyId, long CoverTypeId, long? PolicyTypeId = null);

		Task<SstFees> GetFeeById(long id, long companyId);

		Task<CoreResponseDTO<List<ResourcesDTO>>> GetControlsResources(ResourcesRequestDTO search);

		string GetResourceValue(long companyId, string resourceObject, string resourceName, string culture);

		List<string> GetResourceValuesList(long companyId, string resourceObject, string resourceNames, string culture, char seperator = '#');

		Task<IResponseResult<SstAgentBookDetails>> UpdateAgentPageAsync(long? PageNo, DateTime IssueDate, long? oldPageNo);

		Task<ResponseResult<long>> GenerateSerial(GenerateSerialDTO serialDTO);

		Task<ResponseResult<string>> GenerateSegment(GenerateSegmentDTO segmentDTO);

		Task<ResponseResult<IEnumerable<SstDiscounts>>> GetDiscountLoadingList(DiscountsSearchCriteria searchCriteria);

		Task<ResponseResult<IEnumerable<SstFees>>> GetFeeTypesList(FeesSearchCriteria searchCriteria);

		Task<List<SstClosingPeriods>> GetValidClosingPeriods(long companyId, long? systemId = null, long? classId = null, long? policyTypeId = null, long? branchId = null, string moduleCode = "");

		Task<ResponseResult<SstFeesTiers>> GetSstFeesTiersByCriteriaINT(SstFeesTiersSearchCriteria searchCriteria);

		Task<List<SelectItem>> GetFeesByIdz(string Idz, int language);

		Task<List<SelectItem>> GetCoverTypesByByIdz(string Idz);

		Task<List<SelectItem>> GetPolicyTypesByIdz(string Idz);

		Task<List<SelectItem>> GetCommissionStructureByIdz(string Idz);

		Task<ResponseResult<List<SstCommissionStructure>>> GetSstCommissionStructureByCriteriaINT(long CompanyId, int PageNo, short BusinessType, long? SystemId, string Name, string Categories, short? ClassId, short? PolicyType, byte? AutoAdd);

		Task<List<AgentSetupValues>> GetMatchingAgents(AgentCustomersSearchCriteria agentCustomersSearchCriteria);

		Task<List<SstAgentCommissionTiers>> GetSstAgentCommissionTiersByCriteriaINT(SstAgentCommissionTiersSearchCriteria searchCriteria);

		Task<MntOldMIProvidersResponse<MntPrvNetOldMedical>> GetNetworkProviders(MntPrvNetSearchCriteria searchCriteria);

		Task<FinancialResponseDTO<List<CustomerOutput>>> GetCustomers(CustomerInput customerInput);

		string GetCustomerName(CustomerInput customerInput);

		Task<FinancialResponseDTO<string>> GetCustomerCurrency(long customerId, int companyId);

		Task<FinancialResponseDTO<List<ExchangeRateOutput>>> GetExchangeRate(ExchangeRateInput exchangeRateInput);

		Task<FinancialResponseDTO<List<FiscalYearOutput>>> GetFiscalYear(FiscalYearInput fiscalYearInput);

		Task<FinancialResponseDTO<List<AccountOutput>>> GetAccounts(AccountInput accountInput);

		Task<FinancialResponseDTO<List<CostCenterOutput>>> GetCostCenter(CostCenterInput costCenterInput);

		Task<List<SelectItem>> GetCustomerAccountsList(CustomerAccountInput customerAccountInput);

		Task<List<CustomerOutput>> GetCustomersOnPremise(int companyId, string query, string role);

		Task<UserDTO> GetUsersInfo(string username);

		Task<FinancialResponseDTO<IEnumerable<TransPolicyOutput>>> PostVoucherTransactions(object obj);

		Task<FinancialResponseDTO<UnpostTrans>> UnPostTransaction(UnpostTrans transaction);

		Task<List<CustomerOutput>> GetCustomerByIdz(string customerIdz, int companyId);

		Task<CoreResponseDTO<IEnumerable<CountriesDTO>>> GetCountriesDTO();
	}
}
