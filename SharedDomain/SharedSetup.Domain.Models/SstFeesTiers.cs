using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FEES_TIERS")]
	public class SstFeesTiers : BaseModel
	{
		[NotMapped]
		public string FeeName { get; set; }

		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypesName { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("AMOUNT_FROM")]
		public decimal? AmountFrom { get; set; }

		[Column("AMOUNT_TO")]
		public decimal? AmountTo { get; set; }

		[Column("TIER_TYPE")]
		public byte TierType { get; set; }

		[Column("FEE_PERCENT")]
		public decimal FeePercent { get; set; }

		[Column("FEE_AMOUNT")]
		public decimal? FeeAmount { get; set; }

		[Column("MIN_AMOUNT")]
		public decimal? MinAmount { get; set; }

		[Column("MAX_AMOUNT")]
		public decimal? MaxAmount { get; set; }

		[Column("CURRENCY")]
		public string Currency { get; set; }

		[Column("VOUCHER_SIDE")]
		public byte VoucherSide { get; set; }

		[Column("ROUND_TO")]
		public byte? RoundTo { get; set; }

		[Column("LOCATION")]
		public int? Location { get; set; }

		[Column("TAX_CODE")]
		public string TaxCode { get; set; }

		[Column("MULTIPLE_OF")]
		public long? MultipleOf { get; set; }

		[Column("TERM_FROM")]
		public short? TermFrom { get; set; }

		[Column("TERM_TO")]
		public short? TermTo { get; set; }

		[Column("YEAR_FROM")]
		public short? YearFrom { get; set; }

		[Column("YEAR_TO")]
		public short? YearTo { get; set; }

		[Column("AUTO_ADD")]
		public byte? AutoAdd { get; set; }

		[Column("FEE_ID")]
		public long FeeId { get; set; }

		[Column("CALCULATION_METHOD")]
		public byte? CalculationMethod { get; set; }

		[Column("ORIGIN")]
		public short? Origin { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstFeesTiers")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("FeeId")]
		[InverseProperty("SstFeesTiers")]
		public virtual SstFees Fee { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstFeesTiers")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstFeesTiers")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("FeeTier")]
		public virtual ICollection<SstFeesTiersDetails> SstFeesTiersDetails { get; set; }

		public SstFeesTiers()
		{
			SstFeesTiersDetails = new HashSet<SstFeesTiersDetails>();
		}
	}
}
