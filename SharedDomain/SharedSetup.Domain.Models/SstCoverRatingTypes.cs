using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_COVER_RATING_TYPES")]
	public class SstCoverRatingTypes : BaseModel
	{
		[NotMapped]
		public string CoverTypeName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string RatingTypeName { get; set; }

		[NotMapped]
		public string RateFractionName { get; set; }

		[NotMapped]
		public string ApplyPremiumName { get; set; }

		[NotMapped]
		public long[] PolicyTypeArr { get; set; }

		[Column("COVER_TYPE")]
		public long CoverType { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[Column("RATING_TYPE")]
		public short RatingType { get; set; }

		[Column("RATE_FRACTION")]
		public short RateFraction { get; set; }

		[Column("ROUND_TO")]
		public short? RoundTo { get; set; }

		[Column("CALC_REF")]
		public short? CalcRef { get; set; }

		[Column("ENDORSEMNT_RATING")]
		public short? EndorsemntRating { get; set; }

		[Column("DEDCUTBLE_FROM")]
		public short? DedcutbleFrom { get; set; }

		[Column("APPLY_PREMIUM")]
		public bool? ApplyPremium { get; set; }

		[Column("IS_EDITABLE")]
		public bool? IsEditable { get; set; }

		[Column("IS_DISCOUNTABLE")]
		public bool? IsDiscountable { get; set; }

		[Column("IS_BASIC_PREMIUM")]
		public bool? IsBasicPremium { get; set; }

		[Column("IS_AUTO_ADD")]
		public bool? IsAutoAdd { get; set; }

		[Column("IS_ACTIVE")]
		public bool? IsActive { get; set; }

		[Column("APPLY_AGENT_COMM")]
		public bool? ApplyAgentComm { get; set; }

		[ForeignKey("CoverType")]
		[InverseProperty("SstCoverRatingTypes")]
		public virtual SstCoverTypes CoverTypeNavigation { get; set; }
	}
}
