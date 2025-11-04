using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_RATING_MATRIX_VALUES")]
	public class SstRatingMatrixValues : BaseModel
	{
		[Column("RATING_MATRIX_ID")]
		public long RatingMatrixId { get; set; }

		[Column("SERIAL")]
		public long Serial { get; set; }

		[Column("VALUE_AS_JSON")]
		public string ValueAsJson { get; set; }

		[Column("QUERY")]
		public string Query { get; set; }

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

		[ForeignKey("RatingMatrixId")]
		[InverseProperty("SstRatingMatrixValues")]
		public virtual SstRatingMatrix RatingMatrix { get; set; }
	}
}
