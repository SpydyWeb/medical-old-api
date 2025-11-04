using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DISCOUNTS_BUSINESS_FACTORS")]
	public class SstDiscountsBusinessFactors : BaseModel
	{
		[Column("POLICY_DISCOUNT_ID")]
		public long PolicyDiscountId { get; set; }

		[Column("DISCOUNT_FACTOR_ID")]
		public long DiscountFactorId { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("VALUE_FROM")]
		public long ValueFrom { get; set; }

		[Column("VALUE_TO")]
		public long? ValueTo { get; set; }

		[Column("FACTOR_TYPE")]
		public short FactorType { get; set; }

		[Column("REFERENCE_ID")]
		public short? ReferenceId { get; set; }

		[ForeignKey("DiscountFactorId")]
		[InverseProperty("SstDiscountsBusinessFactors")]
		public virtual SstDiscountsFactors DiscountFactor { get; set; }

		[ForeignKey("PolicyDiscountId")]
		[InverseProperty("SstDiscountsBusinessFactors")]
		public virtual SstPolicyDiscounts PolicyDiscount { get; set; }
	}
}
