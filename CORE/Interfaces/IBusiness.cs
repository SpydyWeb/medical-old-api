using System;
using System.Collections.Generic;
using CORE.DTOs.APIs;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.APIs.TP_Services;
using CORE.DTOs.Business;
using CORE.Services;
using CORE.TablesObjects;

namespace CORE.Interfaces
{
	public interface IBusiness : ISvc
	{
		bool InsertWatheqData(CRDetails details);

		List<MembersList> LoadMemberTreeSearch(string Name, string? NationalID, int PolicyId);

		CRDetails getCRDetails(string CR);

		(Production, string) InsertUpdateProduction(Production prod);

		decimal? GetMMPPrice(MMPPricing obj);

		List<Production> LoadProduction(string UserId);

		List<Production> LoadProductionBySegment(string Segment);

		List<Production> LoadProductionById(int Id, bool Eska);

		List<Production> LoadPendingForSyncProduction();

		List<Policy> LoadPendingForSyncSubject();

		LoadPolicyBusiness LoadProductionBusiness(string UserId);

		LoadPolicyBusiness LoadProductionBusinessChecker(string UserId, int CustomerId);

		LoadPolicyBusiness LoadProductionTeam(string UserId);

		DocumentTree documentTree(LoadDocumentTreeInput loadDocumentTreeInput);

		DocumentTree documentTreeTeamLeader(LoadDocumentTreeInput loadDocumentTreeInput);

		Production LoadDocument(string? DocumentNo, int? Id, int? DocumentType);

		DocumentTree FilterDocument(string? PolicyChar, DateTime? FromEffectiveDate, DateTime? FromIssueDate, DateTime? ToEffectiveDate, DateTime? ToIssueDate, int? Status, int? DocumentType, int UserId, bool? IsPaid);

		List<Subjects> LoadMemberBusiness(int PolicyId, string? Princible);

		List<MembersList> LoadMemberTree(int PolicyId, string princible, string NationalId);
		List<MembersList> LoadMemberTreeByCRno(string princible);

        (List<Subjects>, string) InsertUpdateMembers(List<Subjects> members, string connection);

		PolicyHolders InsertUpdatePolicyHolder(PolicyHolders holder);

		PolicyHolders LoadPolicyHolder(string CommercialRegisteration);

		PolicyHolders LoadPolicyHolders(int Id);

		Subjects LoadMembersubject(int Id);

		int GetPlanId(int Id);

		List<MemberValidation> memberValidations(List<Subjects> memberValidationList, string connection);

		NationalityMapping GetEskaNationality(int Nationality);

		NationalityMapping GetEskaNationalityByEska(string EskaNatCode);

		bool insertCRInfo(CRDetails cRDetails);

		List<ServicesLink> LoadAPIs();

		Discount Discount(DateTime? FromDate);

		bool AddDeclarations(MembersDeclarations declarations);

		bool RemoveDeclarations(int MemberId);

		bool RemoveMember(int MemberId, string? connection = null);

		bool RemoveDraftMember(int MemberId, string? connection = null);

		List<MembersDeclarations> LoadDecleration(LoadDecleration loadDecleration);

		MembersDeclarations LoadDeclarationByMember(int MemberId);

		CRDetails LoadCRInfo(string cRDetails);

		bool AddUpdateYakeenMembers(YakeenLogsMember yakeenMembers);

		YakeenMembers getYakeenMembers(string nationalId, string sponsor);

		Production getDocumentByKey(string key);
		List<Production> getDocumentByPolicyNo(string key);
        Production getDocumentByKey(int key);

		bool MarkasPushToEska(string key);

		bool MarkasPushToYakeen(string key);

		bool updateFinancialDate(UpdateFinancialPayment updateFinancial);

		(Production, string) CancellationMember(int MemberId, int policyid, int Cancellation, string CreatedBy);

		bool DeletePolicyBusiness(long Id);

		(bool, string) ValidatePolicyHolder(string CRNational, int UserId);

		LoadDocsBusiness LoadPolicyBusiness(int? RoleId, string? CreatedBy, string? PolicyNo, DateTime? issuedate, int? status, int? count, string? ClientName, string? SponserNo);

		bool DeleteEskaSQL(long EskaId);

		bool CheckExistMember(string National, int PolicyId);

		bool UpdateDiscountMember(int Id, decimal Percent);

		bool CheckPolicyHolder(string CR, int Product, int Id);

		string GetUserNameByCR(string CR);

		PlanHistory LoadPlanHistory(int PlanId, int NationalityType, int classType);

		void CreateCommand(string connectionString);

		PremiumOutcome GetPlanPremium(int relation, int MaritalStatus, int Gender, int classId, int age, string connection);
		Production LoadOriginalPolicy(int customerId);
		t_Yakeen_AddressInfo GetYakeen_AddressInfo(long CrNumber);
		Production getDocumentByCrnumber(string Crnumber);
    }
}
