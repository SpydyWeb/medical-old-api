using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedSetup.Domain.Models
{
	[Table("TEMP_VOUCHERS")]
	public class TempVouchers
	{
		[Column("ID")]
		public long Id { get; set; }

		[Column("CCL_INS_ID")]
		public long? CclInsId { get; set; }

		[Column("CCL_NPL_ID")]
		public long? CclNplId { get; set; }

		[Column("CCL_TRN_ID")]
		public long? CclTrnId { get; set; }

		[Column("CPD_INS_ID")]
		public long? CpdInsId { get; set; }

		[Column("CPD_RECON_ID")]
		public long? CpdReconId { get; set; }

		[Column("CPD_SERVICE_ID")]
		public long? CpdServiceId { get; set; }

		[Column("FGL_TRN_ID")]
		public long? FglTrnId { get; set; }

		[Column("INS_TRN_ID")]
		public long? InsTrnId { get; set; }

		[Column("VOUCHER_DATE")]
		public DateTime? VoucherDate { get; set; }

		[Column("SRN_LOSS_SHARE_ID")]
		public long? SrnLossShareId { get; set; }

		[Column("SRN_PORT_REIN_ID")]
		public long? SrnPortReinId { get; set; }

		[Column("SRN_REP_DIST_ID")]
		public long? SrnRepDistId { get; set; }

		[Column("SRN_PROF_COMM_SHR_ID")]
		public long? SrnProfCommShrId { get; set; }

		[Column("SRN_INS_ID")]
		public double? SrnInsId { get; set; }

		[Column("SRN_CLM_DIST_ID")]
		public long? SrnClmDistId { get; set; }

		[Column("PORTFOLIO_TYPE")]
		public byte? PortfolioType { get; set; }

		[Column("SRN_REINS_ID")]
		public long? SrnReinsId { get; set; }

		[Column("SRN_DPST_REINS_ID")]
		public long? SrnDpstReinsId { get; set; }

		[Column("SRN_XTR_ID")]
		public double? SrnXtrId { get; set; }

		[Column("SRN_ADJ_DETL_ID")]
		public long? SrnAdjDetlId { get; set; }

		[Column("DECLARATION_ID")]
		public long? DeclarationId { get; set; }

		[Column("UNEARNED_ANALYSIS_ID")]
		public long? UnearnedAnalysisId { get; set; }

		[Column("ASSIGN_SURVEYOR")]
		public long? AssignSurveyor { get; set; }

		[Column("GPD_INS_ID")]
		public long? GpdInsId { get; set; }

		[Column("GCL_TRANSACTION_ID")]
		public long? GclTransactionId { get; set; }

		[Column("GCL_INSTALLMENT_ID")]
		public long? GclInstallmentId { get; set; }

		[Column("MNT_PROVIDER_DISCOUNT")]
		public long? MntProviderDiscount { get; set; }

		[Column("MPD_INS_ID")]
		public long? MpdInsId { get; set; }

		[Column("MPD_SHARE_ID")]
		public long? MpdShareId { get; set; }

		[Column("MCL_SETTLEMENT_ID")]
		public long? MclSettlementId { get; set; }

		[Column("MCL_SETTL_DET_ID")]
		public long? MclSettlDetId { get; set; }

		[Column("GPD_LONGTERM_ID", TypeName = "NUMBER(15)")]
		public long? GpdLongtermId { get; set; }
	}
}
