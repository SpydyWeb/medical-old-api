using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_ACCOUNTS")]
	public class SstAccounts : BaseModel
	{
		[NotMapped]
		public string ElementName { get; set; }

		[NotMapped]
		public string BusinessTypeName { get; set; }

		[NotMapped]
		public string BranchName { get; set; }

		[NotMapped]
		public string TransactionTypeName { get; set; }

		[NotMapped]
		public string CurrencyName { get; set; }

		[NotMapped]
		public string GlAccountName { get; set; }

		[NotMapped]
		public string CostCenterName { get; set; }

		[NotMapped]
		public string RefundGlAccountName { get; set; }

		[NotMapped]
		public string CounterAccountName { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("COVER_ID")]
		public long? CoverId { get; set; }

		[Column("FEE_ID")]
		public long? FeeId { get; set; }

		[Column("DISCOUNT_ID")]
		public long? DiscountId { get; set; }

		[Column("BUSINESS_TYPE")]
		public byte? BusinessType { get; set; }

		[Column("BRANCH")]
		public long? Branch { get; set; }

		[Column("TRANSACTION_TYPE")]
		public long TransactionType { get; set; }

		[Column("CURRENCY")]
		public string Currency { get; set; }

		[Column("GL_ACCOUNT")]
		public long? GlAccount { get; set; }

		[Column("GL_REFUND_ACCOUNT")]
		public long? GlRefundAccount { get; set; }

		[Column("COST_CENTER")]
		public long? CostCenter { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("COUNTER_ACCOUNT")]
		public long? CounterAccount { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstAccounts")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("CoverId")]
		[InverseProperty("SstAccounts")]
		public virtual SstCoverTypes Cover { get; set; }

		[ForeignKey("DiscountId")]
		[InverseProperty("SstAccounts")]
		public virtual SstPolicyDiscounts Discount { get; set; }

		[ForeignKey("FeeId")]
		[InverseProperty("SstAccounts")]
		public virtual SstFees Fee { get; set; }

		[ForeignKey("ModuleCode")]
		[InverseProperty("SstAccounts")]
		public virtual SstModules ModuleCodeNavigation { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstAccounts")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstAccounts")]
		public virtual SstSystems System { get; set; }
	}
}
