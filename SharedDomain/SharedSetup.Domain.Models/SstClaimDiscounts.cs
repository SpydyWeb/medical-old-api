using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CLAIM_DISCOUNTS")]
	public class SstClaimDiscounts : BaseModel
	{
		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("AMOUNT")]
		public decimal Amount { get; set; }

		[Column("PERCENT")]
		public decimal Percent { get; set; }

		[Column("AFTER_CLAIM_PERCENT")]
		public decimal AfterClaimPercent { get; set; }

		[Column("CLAIM_YEARS_FROM")]
		public short ClaimYearsFrom { get; set; }

		[Column("CLAIM_YEARS_TO")]
		public short ClaimYearsTo { get; set; }

		[Column("DISCOUNT_ID")]
		public long DiscountId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstClaimDiscounts")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("DiscountId")]
		[InverseProperty("SstClaimDiscounts")]
		public virtual SstDiscounts Discount { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstClaimDiscounts")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
