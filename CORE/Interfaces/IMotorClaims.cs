using System;
using System.Collections.Generic;
using System.Data;
using CORE.DTOs.APIs.MotorClaim;
using CORE.DTOs.MotorClaim;
using CORE.DTOs.MotorClaim.Claims;
using CORE.DTOs.MotorClaim.Frauds;
using CORE.DTOs.MotorClaim.Integrations.APIs;
using CORE.DTOs.MotorClaim.Productions;
using CORE.DTOs.MotorClaim.Survoyer;
using CORE.DTOs.MotorClaim.WorkFlow;
using CORE.Services;

namespace CORE.Interfaces
{
	public interface IMotorClaims : ISvc
	{
		Claims InsertUpdateClaims(Claims claims);

		ClaimVehicle InsertClaimVehicle(ClaimVehicle claimVehicle);

		ReserveBalance ReserveBalance(int ClaimId, int? ClaimantId);

		ClaimHistory InsertClaimHistory(ClaimHistory claims);

		List<Claims> LoadClaims(long? Id, int? policyId, string? AcciedentReport = null);

		Claims UpdateAssign(int ClaimId, int UserId);

		List<ClaimMaster> LoadClaimsMaster(string? NationalID, int? Branch, string? chassis, string? claimno, string? mobile, string? policy, DateTime? RegisteredFrom, DateTime? RegisteredTo, int? ClaimStatus, int? Id);

		bool DeleteClaim(long Id);

		EClaims InsertUpdateEClaims(EClaims claims);

		List<EClaims> LoadEclaims(long? Id, string? NationalID);

		bool DeleteEClaims(long Id);

		Claimants InsertUpdateClaimants(Claimants claims);

		List<Claimants> LoadClaimants(long? Id, long? ClaimId);

		bool Claimants(long Id);

		ClaimTransactions InsertUpdateClaimTrans(ClaimTransactions claims);

		List<ClaimTransactions> LoadClaimTrans(int TransactionType, int ClaimantId);

		List<Reserve> LoadReserve(int? Id, int? ClaimId, int? TransactionId);

		bool DeleteClaimTrans(long Id);

		Collectors InsertUpdateCollectorss(Collectors claims);

		List<Collectors> LoadCollectors(long? Id, int? ClaimId);

		ClaimVehicle LoadClaimVehicle(long ClaimId);

		bool DeleteCollectors(long Id);

		FraudIndicators InsertUpdateFraudIndicators(FraudIndicators claims);

		List<FraudIndicators> LoadFraudIndicators(long? Id, string? Name = null, int? Status = null);

		bool DeleteFraudIndicators(long Id);

		FraudSetup InsertUpdateFraudSetup(FraudSetup claims);

		List<FraudSetup> LoadFraudSetup(int? Id, int? ScoreFrom = null, int? ScoreTo = null);

		bool DeleteFraudSetup(long Id);

		ProductionInfo InsertUpdateProductionInfo(ProductionInfo claims);

		List<ProductionInfo> LoadProductionInfo(long? Id, string? OwnerId, int? PolicyId);

		bool DeleteProductionInfo(long Id);

		VehiclesInfo InsertUpdateVehicleInfo(VehiclesInfo claims);

		List<VehiclesInfo> LoadVehicleInfo(long? Id, string? Sequence);

		bool DeleteVehicleInfo(long Id);

		VehileCovers InsertUpdateVehileCovers(VehileCovers claims);

		List<VehileCovers> LoadVehileCovers(long? Id, int? PolicyId);

		bool DeleteVehileCovers(long Id);

		WorkFlowApprovers InsertWorkFlowApprovers(WorkFlowApprovers claims);

		List<WorkFlowApprovers> LoadWorkFlowApprovers(long? Id, int? ClaimId);

		bool DeleteWorkFlowApprovers(long Id);

		WorkFlowStages InsertWorkFlowDelegation(WorkFlowStages claims);

		List<WorkFlowStages> LoadWorkFlowStages(long? Id, string? Name = null);

		bool DeleteWorkFlowStages(long Id);

		WorkFlowHistory InsertWorkFlowHistory(WorkFlowHistory claims);

		List<WorkFlowHistory> LoadWorkFlowHistory(long? Id, int? ClaimId);

		bool DeleteWorkFlowHistory(long Id);

		WorkFlowHistoryDetails InsertUpdateWorkFlowHistoryDetails(WorkFlowHistoryDetails claims);

		List<WorkFlowHistoryDetails> LoadWorkFlowHistoryDetails(long? Id, int? Status);

		bool DeleteWorkFlowHistoryDetails(long Id);

		WorkFlowReassign InsertUpdateWorkFlowReassign(WorkFlowReassign claims);

		List<WorkFlowReassign> LoadWorkFlowReassign(long? Id, string? AssignTo);

		bool DeleteWorkFlowReassign(long Id);

		WorkFlowApprovers InsertUpdateWorkflowApprover(WorkFlowApprovers claims);

		DelegationSetup InsertUpdateDelegation(DelegationSetup claims);

		List<DelegationSetup> LoadDelegation(int? Id, int? Status = null);

		List<AuthorityMatrix> LoadAuthorityMatrix(int? Id, int? ModuleId = null);

		bool DeleteDelegation(int Id);

		DocumentInfo InsertUpdateDocuments(DocumentInfo claims);

		AuthorityMatrix InsertUpdateAuthorityMatrix(AuthorityMatrix claims);

		Attachments InsertUpdateAttachments(Attachments claims);

		Survoyer InsertUpdateSurvoyerEntry(Survoyer claims);

		List<DocumentInfo> LoadDocuments(int? Id, int? ModuleId = null);

		List<Attachments> LoadAttachments(int? Id, int? ModuleId = null);

		bool DeleteDocument(int Id);

		bool DeleteAttachment(int Id);

		ClaimSearchResult claimSearch(SearchingObj obj, string connection);

		bool MigrationClaim(string connection, string? PolicyNo, DateTime? Date);

		NajmResponse LoadNajmData(string AccidentCode);

		TaqdeerResponse LoadTaqdeer(string DACaseNo);

		List<LookupTable> LoadLookUp(SearchLookUp lookUp);

		Reserve InsertReserve(Reserve claims);

		Claims UpdateAutoAssign(AutoAssignObj obj, string connection);

		DataTable ClaimsMigration(string Connection);

		ClaimSubmissionDocuments LoadClaimSubmissionDocuments(ClaimSubmissionDocuments obj, string connection);

		void UpdateClaimsMigration(int Id, string connection, int status);

		List<eClaims> LoadeClaims(eClaimsObj obj, string connection);
	}
}
