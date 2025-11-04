using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FEES_TIERS_DETAILS")]
	public class SstFeesTiersDetails : BaseModel
	{
		[Column("BRANCH")]
		public long? Branch { get; set; }

		[Column("FEE_TIER_ID")]
		public long FeeTierId { get; set; }

		[Column("BUSINESS_TYPE")]
		public byte? BusinessType { get; set; }

		[Column("INCLUSION")]
		public byte? Inclusion { get; set; }

		[Column("COVER_ID")]
		public long? CoverId { get; set; }

		[Column("TPA")]
		public long? Tpa { get; set; }

		[ForeignKey("CoverId")]
		[InverseProperty("SstFeesTiersDetails")]
		public virtual SstCoverTypes Cover { get; set; }

		[ForeignKey("FeeTierId")]
		[InverseProperty("SstFeesTiersDetails")]
		public virtual SstFeesTiers FeeTier { get; set; }
	}
}
