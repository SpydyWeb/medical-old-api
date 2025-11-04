using System.Collections.Generic;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process;
using CORE.DTOs.APIs.Process.Approvals;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Business;
using CORE.Services;
using CORE.TablesObjects;

namespace CORE.Interfaces
{
	public interface IProcess : ISvc
	{
		Results SetApprovalStatus(AddToApprovals approvals);
		Results CheckUserBlackList(string input);
		Results InsertUserBlacklistMember(string input);

		bool UpdateApproval(int approvalId, bool? isEmailSent, bool? isSMSSent);

		PolicyPaymentResponse LoadPaymentInfo(PolicyPaymentInput input);

		Results SavePaymentLog(PaymentLog input);

		List<ApprovalSet> LoadApprovalsInput(LoadApprovalsInput input);

		ApprovalHistory LoadApprovalsHist(int Id);

		Production LoadByKey(string key);

		List<HealthDeclarations> LoadDeclerations();

		ApprovalHistDetails insertApprovalHistDetails(ApprovalHistDetails approvalHistDetails);

		List<approvalhistlist> LoadHistoryApproval(LoadApprovalHistDetails input);

		SadadTokens InsertToken(SadadTokens tokens);

		SadadTransactions InsertUpdateSadad(SadadTransactions sadad);

        Results InsertUpdateOnline(OnlineTransactions onlineTransactions);

        SadadTokens ValidateToken();

		SadadTransactions ValidateSadad(int? PolicyId, string? InvoiceNo = null, string? InternalCode = null);
	}
}
