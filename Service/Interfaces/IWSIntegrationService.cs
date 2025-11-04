using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.DTOs;
//using ProviderCCHI;
//using WISDL_Policy;

namespace Service.Interfaces
{
	public interface IWSIntegrationService
	{
		//Task<ResponseResult<HRSDResponse>> GetSponsorsDetailsFromCCHIV3(string NationalID);

		//Task<ResponseResult<bool>> CancelProviders(int CompanyId, List<Provider> dtProviders, string UserName);

		//Task<ResponseResult<CHPNReuslt>> CancelNetwork(long NetworkID, string CCHI_REFERENCE_NO, string NetworkName, string username);

		//Task<ResponseResult<UploadReuslt>> UploadNetwork(long NetworkNo, string NetworkName, string username);

		//Task<ResponseResult<UploadHPReuslt>> UploadProviders(int CompanyId, List<Provider> dtProviders, string CchiRefNo, long NetworkID, string username);

		//Task<ResponseResult<XMLReturnResult>> UploadPolicyNew(byte[] arrUploadPolicyNew, MpdPoliciesCchi UplodedPolicies, long? SeqNo);

		//Task<ResponseResult<XMLReturnResult>> PolicyCancel(byte[] arrUploadPolicyNew, MpdPoliciesCchi UplodedPolicies, long? SeqNo);

		//Task<ResponseResult<XMLReturnResult>> ReNewPolicy(byte[] arrUploadPolicyNew, MpdPoliciesCchi UplodedPolicies, long? SeqNo);

		//Task<ResponseResult<XMLReturnResult>> UpdatePolicy(byte[] arrUploadPolicyNew, MpdPoliciesCchi UplodedPolicies, long? SeqNo);

		//Task<string> HandleClassActionType(string AccessKey, string PolicyNo, string CCHIClassNo);

		//bool StartCCHIService();

		//bool GenerateMemberStatus();

		//bool StartCCHIGetClassInfoService(int Flag = 0);

		//ResponseResult<List<CCHIGetClassInfoResponse>> CCHIGetClassInfoByPolicyNo(string PolicyNumber);

		//bool StartCCHIUploadStandardClasses();

		//bool StartCCHIUploadNonStandardBenefits();

		//IResponseResult<bool> CCHIReuploadNonStandardBenefitsPerClass(CCHIUploadNonStandardBenefitsRequest oCCHIUploadNonStandardBenefitsRequest);

		//IResponseResult<ClassBenefitClassDeductibleResponse> GetClassBenefitts(int classID, int benefitID);

		//IResponseResult<string> UpdateClassBenefit(ClassBenefitClassDeductibleResponse oClassBenefitClassDeductibleResponse);

		//Task<ResponseResult<PolicyTransactionStatusWithResult>> UpdateMemberStatusCCHI(long MpdPlcCchiId, string CchiPolicyNo, string TransactionName);
	}
}
