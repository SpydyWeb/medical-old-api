using System.Collections.Generic;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.DTOs;

namespace Repository.Interfaces
{
	public interface IMpdClassesCchiRepository : IRepository<MpdClassesCchi>
	{
		List<MpdClassesCchi> LoadClasses(int PolicyCchiId);

		List<CCHIUploadStandardBenefitsRequest> CollectStandardClasses();

		List<PrepareNonStandardClassesRequest> PrepareNonStandardClasses();

		CCHIUploadNonStandardBenefitsRequest CollectNonStandardClasses(string CchiPolicyNo, string MpdCchiPclId);

		IResponseResult<string> UpdateClassesInfo(string CchiPolicyNo, string CchiClassId, string ClassId, string IsBenefit, string ClassStatus, string ClassStatusDesc, string ModificationUser);

		IResponseResult<string> UpdateStandardClasses(string CchiPolicyNo, string CchiClassId, string ReferenceNo, string Status, string StatusDesc, string ModificationUser);

		IResponseResult<string> UpdateNonStandardClasses(string CchiPolicyNo, string CchiClassId, long? CchiBenefitId, string ReferenceNo, string TransactionType, string Status, string StatusDesc, string ModificationUser);

		IResponseResult<ClassBenefitClassDeductibleResponse> GetClassBenefits(int classID, int benefitID);

		IResponseResult<string> UpdateClassBenefit(ClassBenefitClassDeductibleResponse oClassBenefitClassDeductibleResponse);
	}
}
