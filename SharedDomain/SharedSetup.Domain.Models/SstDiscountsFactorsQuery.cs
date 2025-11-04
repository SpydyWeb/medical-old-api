using System.ComponentModel.DataAnnotations.Schema;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DISCOUNTS_FACTORS_QUERY")]
	public class SstDiscountsFactorsQuery
	{
		[Column("ID")]
		public long Id { get; set; }

		[Column("DISCOUNT_ID")]
		public long? DiscountId { get; set; }

		[Column("POLICY_DISC_ID")]
		public long? PolicyDiscId { get; set; }

		[Column("SQL_STATMENT")]
		public string SqlStatment { get; set; }

		[ForeignKey("DiscountId")]
		[InverseProperty("SstDiscountsFactorsQuery")]
		public virtual SstDiscounts Discount { get; set; }

		[ForeignKey("PolicyDiscId")]
		[InverseProperty("SstDiscountsFactorsQuery")]
		public virtual SstPolicyDiscounts PolicyDisc { get; set; }
	}
}
