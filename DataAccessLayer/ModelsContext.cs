using CORE.DTOs.APIs;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.APIs.TP_Services;
using CORE.DTOs.Authentications;
using CORE.DTOs.Business;
using CORE.DTOs.MotorClaim;
using CORE.DTOs.MotorClaim.Claims;
using CORE.DTOs.MotorClaim.Frauds;
using CORE.DTOs.MotorClaim.Integrations.Tables;
using CORE.DTOs.MotorClaim.Productions;
using CORE.DTOs.MotorClaim.Survoyer;
using CORE.DTOs.MotorClaim.WorkFlow;
using CORE.DTOs.PricingEngine;
using CORE.TablesObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
	public static class ModelsContext
	{
		public static void UserModelBuilder(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Users>().ToTable("Users").HasKey((Users p) => p.Id);
			modelBuilder.Entity<UserRoles>().ToTable("UserRoles").HasKey((UserRoles p) => p.Id);
			modelBuilder.Entity<Roles>().ToTable("Roles").HasKey((Roles p) => p.Id);
			modelBuilder.Entity<RolesPages>().ToTable("RolesPages").HasKey((RolesPages p) => p.Id);
			modelBuilder.Entity<PageActions>().ToTable("PageActions").HasKey((PageActions p) => p.Id);
			modelBuilder.Entity<Pages>().ToTable("Pages").HasKey((Pages P) => P.Id);
			modelBuilder.Entity<PageRoleActions>().ToTable("PagesRolesActions").HasKey((PageRoleActions p) => p.Id);
			modelBuilder.Entity<Actions>().ToTable("ActionsType").HasKey((Actions p) => p.Id);
			modelBuilder.Entity<AuditTrail>().ToTable("AuditTrails").HasKey((AuditTrail p) => p.Id);
			modelBuilder.Entity<LoginHistory>().ToTable("LogingHistory").HasKey((LoginHistory p) => p.Id);
			modelBuilder.Entity<Production>().ToTable("Productions").HasKey((Production p) => p.Id);
			modelBuilder.Entity<UserBlockID>().ToTable("UserBlockID").HasKey((UserBlockID p) => p.Id);
			modelBuilder.Entity<Subjects>().ToTable("Subjects").HasKey((Subjects p) => p.Id);
			modelBuilder.Entity<ServicesLink>().ToTable("ServicesLink").HasKey((ServicesLink p) => p.Id);
			modelBuilder.Entity<PolicyHolders>().ToTable("PolicyHolder").HasKey((PolicyHolders p) => p.Id);
			modelBuilder.Entity<NationalityMapping>().ToTable("NationalityMapping").HasKey((NationalityMapping p) => p.Id);
			modelBuilder.Entity<CRDetails>().ToTable("CRDETAILS_LOG").HasKey((CRDetails p) => p.ID);
			modelBuilder.Entity<Discount>().ToTable("DiscountSetup").HasKey((Discount p) => p.Id);
			modelBuilder.Entity<MembersDeclarations>().ToTable("MembersDeclarations").HasKey((MembersDeclarations p) => p.Id);
			modelBuilder.Entity<ApprovalHistory>().ToTable("ApprovalHistory").HasKey((ApprovalHistory p) => p.Id);
			modelBuilder.Entity<YakeenLogsMember>().ToTable("YakeenMembers").HasKey((YakeenLogsMember p) => p.Id);
			modelBuilder.Entity<PaymentLog>().ToTable("PaymentInfo").HasKey((PaymentLog p) => p.Id);
			modelBuilder.Entity<Types>().ToTable("Type").HasKey((Types p) => p.Id);
			modelBuilder.Entity<UserTypes>().ToTable("UserType").HasKey((UserTypes p) => p.Id);
			modelBuilder.Entity<HealthDeclarations>().ToTable("HealthDeclarationQuestions").HasKey((HealthDeclarations p) => p.Id);
			modelBuilder.Entity<CreditLimits>().ToTable("CreditLimits").HasKey((CreditLimits p) => p.Id);
			modelBuilder.Entity<CreditLimitHistory>().ToTable("CreditHistory").HasKey((CreditLimitHistory p) => p.Id);
			modelBuilder.Entity<ApprovalHistDetails>().ToTable("ApprovalHistoryDetails").HasKey((ApprovalHistDetails p) => p.Id);
			modelBuilder.Entity<SadadTokens>().ToTable("SadadTokens").HasKey((SadadTokens p) => p.Id);
			modelBuilder.Entity<SadadTransactions>().ToTable("SadadTransactions").HasKey((SadadTransactions p) => p.Id);
			modelBuilder.Entity<MangementUsers>().ToTable("MangementUsers").HasKey((MangementUsers p) => p.Id);
			modelBuilder.Entity<DocumentInfo>().ToTable("DocumentsSetup").HasKey((DocumentInfo p) => p.Id);
			modelBuilder.Entity<DelegationSetup>().ToTable("DelegationSetup").HasKey((DelegationSetup p) => p.Id);
			modelBuilder.Entity<MMPPricing>().ToTable("MMPPricing").HasKey((MMPPricing p) => p.Id);
			modelBuilder.Entity<PlanPremium>().ToTable("PlanPremium").HasKey((PlanPremium p) => p.Id);
			modelBuilder.Entity<PlanHistory>().ToTable("PlanHistory").HasKey((PlanHistory p) => p.Id);
			modelBuilder.Entity<CORE.DTOs.APIs.Business.Product>().ToTable("Products").HasKey((CORE.DTOs.APIs.Business.Product p) => p.Id);
			modelBuilder.Entity<Claims>().ToTable("Claims").HasKey((Claims p) => p.Id);
			modelBuilder.Entity<EClaims>().ToTable("EClaims").HasKey((EClaims p) => p.Id);
			modelBuilder.Entity<Attachments>().ToTable("Attachments").HasKey((Attachments p) => p.Id);
			modelBuilder.Entity<Claimants>().ToTable("Claimants").HasKey((Claimants p) => p.Id);
			modelBuilder.Entity<ClaimTransactions>().ToTable("ClaimTransactions").HasKey((ClaimTransactions p) => p.Id);
			modelBuilder.Entity<Collectors>().ToTable("Collectors").HasKey((Collectors p) => p.Id);
			modelBuilder.Entity<FraudIndicators>().ToTable("FraudIndicators").HasKey((FraudIndicators p) => p.Id);
			modelBuilder.Entity<FraudSetup>().ToTable("FraudSetup").HasKey((FraudSetup p) => p.Id);
			modelBuilder.Entity<ProductionInfo>().ToTable("PolicyInfo").HasKey((ProductionInfo p) => p.Id);
			modelBuilder.Entity<VehiclesInfo>().ToTable("VehiclesInfo").HasKey((VehiclesInfo p) => p.Id);
			modelBuilder.Entity<ClaimSubmissionDocuments>().ToTable("ClaimSubmissionDocuments").HasKey((ClaimSubmissionDocuments p) => p.Id);
			modelBuilder.Entity<VehileCovers>().ToTable("VehileCovers").HasKey((VehileCovers p) => p.Id);
			modelBuilder.Entity<WorkFlowApprovers>().ToTable("WorkFlowApprovers").HasKey((WorkFlowApprovers p) => p.Id);
			modelBuilder.Entity<WorkFlowHistory>().ToTable("WorkFlowHistory").HasKey((WorkFlowHistory p) => p.Id);
			modelBuilder.Entity<WorkFlowHistoryDetails>().ToTable("WorkFlowHistoryDetails").HasKey((WorkFlowHistoryDetails p) => p.Id);
			modelBuilder.Entity<WorkFlowReassign>().ToTable("WorkFlowReassign").HasKey((WorkFlowReassign p) => p.Id);
			modelBuilder.Entity<WorkFlowStages>().ToTable("WorkFlowStages").HasKey((WorkFlowStages p) => p.Id);
			modelBuilder.Entity<Drivers>().ToTable("VehicleDriver").HasKey((Drivers p) => p.Id);
			modelBuilder.Entity<ClaimVehicle>().ToTable("ClaimVehicles").HasKey((ClaimVehicle p) => p.Id);
			modelBuilder.Entity<ClaimHistory>().ToTable("ClaimHistory").HasKey((ClaimHistory p) => p.Id);
			modelBuilder.Entity<Survoyer>().ToTable("surveyor").HasKey((Survoyer p) => p.Id);
			modelBuilder.Entity<LookupTable>().ToTable("LookupTable").HasKey((LookupTable p) => p.Id);
			modelBuilder.Entity<AuthorityMatrix>().ToTable("AuthorityMatrix").HasKey((AuthorityMatrix p) => p.Id);
			modelBuilder.Entity<Reserve>().ToTable("Reserve").HasKey((Reserve p) => p.Id);
			modelBuilder.Entity<ClaimStatusMapping>().ToTable("ClaimStatusMapping").HasKey((ClaimStatusMapping p) => p.Id);
			modelBuilder.Entity<NajmAccidentinfo>().ToTable("NajmAccidentinfo").HasKey((NajmAccidentinfo p) => p.Id);
			modelBuilder.Entity<NajmPartiesInfo>().ToTable("NajmPartiesInfo").HasKey((NajmPartiesInfo p) => p.ID);
			modelBuilder.Entity<NajmDamageInfo>().ToTable("NajmDamageInfo").HasKey((NajmDamageInfo p) => p.Id);
			modelBuilder.Entity<NajmActs>().ToTable("NajmActs").HasKey((NajmActs p) => p.Id);
			modelBuilder.Entity<NajmImageInfo>().ToTable("NajmImageInfo").HasKey((NajmImageInfo p) => p.Id);
			modelBuilder.Entity<PartyInsuranceInfo>().ToTable("PartyInsuranceInfo").HasKey((PartyInsuranceInfo p) => p.Id);
			modelBuilder.Entity<ClaimsMigration>().ToTable("eClaims").HasKey((ClaimsMigration p) => p.Id);
			modelBuilder.Entity<TaqdeerCase>().ToTable("TaqdeerCases").HasKey((TaqdeerCase p) => p.DACaseNumber);
			modelBuilder.Entity<TaqdeerFeesDetail>().ToTable("TaqdeerFeesDetail").HasKey((TaqdeerFeesDetail p) => p.Id);
			modelBuilder.Entity<TaqdeerImageDetaila>().ToTable("TaqdeerImageDetaila").HasKey((TaqdeerImageDetaila p) => p.Id);
			modelBuilder.Entity<TaqdeerSparePartDetail>().ToTable("TaqdeerSparePartDetail").HasKey((TaqdeerSparePartDetail p) => p.Id);
			modelBuilder.Entity<TaqdeerSparePartsInfo>().ToTable("TaqdeerSparePartsInfo").HasKey((TaqdeerSparePartsInfo p) => p.Id);
			modelBuilder.Entity<PricingLOB>().ToTable("lineOfBusiness").HasKey((PricingLOB p) => p.Id);
			modelBuilder.Entity<Factors>().ToTable("Factors").HasKey((Factors p) => p.Id);
			modelBuilder.Entity<FactorElements>().ToTable("FactorElements").HasKey((FactorElements p) => p.Id);
			modelBuilder.Entity<PricingProducts>().ToTable("PricingProducts").HasKey((PricingProducts p) => p.Id);
			modelBuilder.Entity<PricingChannels>().ToTable("PricingChannels").HasKey((PricingChannels p) => p.Id);
            modelBuilder.Entity<OnlineTransactions>().ToTable("OnlineTransactions").HasKey((OnlineTransactions p) => p.Id);
            modelBuilder.Entity<t_Yakeen_AddressInfo>().ToTable("t_Yakeen_AddressInfo").HasKey((t_Yakeen_AddressInfo p) => p.ID);
        }
	}
}
