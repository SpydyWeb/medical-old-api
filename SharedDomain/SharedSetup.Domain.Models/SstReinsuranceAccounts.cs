using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_REINSURANCE_ACCOUNTS")]
	public class SstReinsuranceAccounts : BaseModel
	{
		[Column("ACCOUNT_CATEGORY")]
		public short AccountCategory { get; set; }

		[Column("BRANCH_ID")]
		public long? BranchId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("BUSINESS_TYPE")]
		public short? BusinessType { get; set; }

		[Column("TRANSACTION_TYPE")]
		public short TransactionType { get; set; }

		[Column("GL_ACCOUNT")]
		public long? GlAccount { get; set; }

		[Column("COST_CENTER")]
		public long? CostCenter { get; set; }

		[Column("OTHER_SIDE_ACCOUNT")]
		public long? OtherSideAccount { get; set; }

		[Column("OTHER_SIDE_COST_CENTER")]
		public long? OtherSideCostCenter { get; set; }

		[Column("FEE_TYPE")]
		public long? FeeType { get; set; }

		[Column("CESSION_TYPE")]
		public short? CessionType { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Required]
		[Column("CREATION_USER")]
		[ForeignKey("ClassId")]
		[InverseProperty("SstReinsuranceAccounts")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("FeeType")]
		[InverseProperty("SstReinsuranceAccounts")]
		public virtual SstFees FeeTypeNavigation { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstReinsuranceAccounts")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstReinsuranceAccounts")]
		public virtual SstSystems System { get; set; }
	}
}
