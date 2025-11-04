using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_POLICY_DISCOUNTS")]
	public class SstPolicyDiscounts : BaseModel
	{
		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string BusinessTypeName { get; set; }

		[Column("DISCOUNT_PER")]
		public decimal? DiscountPer { get; set; }

		[Column("DISCOUNT_AMT")]
		public decimal? DiscountAmt { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime? ExpiryDate { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("ROUND_TO")]
		public byte? RoundTo { get; set; }

		[Column("RENEWAL_FROM")]
		public DateTime? RenewalFrom { get; set; }

		[Column("RENEWAL_TO")]
		public DateTime? RenewalTo { get; set; }

		[Column("AUTO_ADD")]
		public byte AutoAdd { get; set; }

		[Column("SEPARATE_VOUCHER")]
		public byte SeparateVoucher { get; set; }

		[Column("BUSINESS_TYPE")]
		public long? BusinessType { get; set; }

		[Column("COVER_TYPE")]
		public long? CoverType { get; set; }

		[Column("RISK_TYPE")]
		public long? RiskType { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("DISCOUNT_ID")]
		public long DiscountId { get; set; }

		[Column("LOADING_AMT")]
		public decimal? LoadingAmt { get; set; }

		[Column("LOADING_PER")]
		public decimal? LoadingPer { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstPolicyDiscounts")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("DiscountId")]
		[InverseProperty("SstPolicyDiscounts")]
		public virtual SstDiscounts Discount { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstPolicyDiscounts")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[InverseProperty("Discount")]
		public virtual ICollection<SstAccounts> SstAccounts { get; set; }

		[InverseProperty("PolicyDiscount")]
		public virtual ICollection<SstDiscountsBusinessFactors> SstDiscountsBusinessFactors { get; set; }

		[InverseProperty("PolicyDisc")]
		public virtual ICollection<SstDiscountsFactorsQuery> SstDiscountsFactorsQuery { get; set; }

		public SstPolicyDiscounts()
		{
			SstAccounts = new HashSet<SstAccounts>();
			SstDiscountsBusinessFactors = new HashSet<SstDiscountsBusinessFactors>();
			SstDiscountsFactorsQuery = new HashSet<SstDiscountsFactorsQuery>();
		}
	}
}
