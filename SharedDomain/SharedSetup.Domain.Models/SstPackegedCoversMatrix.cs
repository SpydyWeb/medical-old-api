using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PACKEGED_COVERS_MATRIX")]
	public class SstPackegedCoversMatrix : BaseModel
	{
		[Column("PACKAGED_COVER_ID")]
		public long PackagedCoverId { get; set; }

		[Column("SERIAL")]
		public long Serial { get; set; }

		[Column("PREMIUM_RATE")]
		public decimal? PremiumRate { get; set; }

		[Column("PREMIUM_AMOUNT")]
		public decimal? PremiumAmount { get; set; }

		[Column("MIN_PREMIUM")]
		public decimal? MinPremium { get; set; }

		[Column("DED_PERCENT")]
		public decimal? DedPercent { get; set; }

		[Column("DED_AMOUNT")]
		public decimal? DedAmount { get; set; }

		[Column("APPLY_PREMIUM")]
		public byte? ApplyPremium { get; set; }

		[Column("IS_EDITABLE")]
		public byte? IsEditable { get; set; }

		[Column("IS_DISCOUNTABLE")]
		public byte? IsDiscountable { get; set; }

		[Column("IS_BASIC_PREMIUM")]
		public byte? IsBasicPremium { get; set; }

		[Column("IS_AUTO_ADD")]
		public byte? IsAutoAdd { get; set; }

		[Column("IS_ACTIVE")]
		public byte? IsActive { get; set; }

		[Column("APPLY_AGENT_COMM")]
		public byte? ApplyAgentComm { get; set; }

		[ForeignKey("PackagedCoverId")]
		[InverseProperty("SstPackegedCoversMatrix")]
		public virtual SstPackegedCovers PackagedCover { get; set; }
	}
}
