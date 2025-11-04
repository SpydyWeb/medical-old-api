using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SHORT_PERIODS_DETAILS")]
	public class SstShortPeriodsDetails : BaseModel
	{
		[Column("ENDORSEMENT_TYPE")]
		public long? EndorsementType { get; set; }

		[Column("SHORT_PERIOD_ID")]
		public long ShortPeriodId { get; set; }

		[ForeignKey("ShortPeriodId")]
		[InverseProperty("SstShortPeriodsDetails")]
		public virtual SstShortPeriods ShortPeriod { get; set; }
	}
}
