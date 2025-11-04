using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_USER_ALERTS")]
	public class SstUserAlerts : BaseModel
	{
		[Column("ALERT_ID")]
		public long AlertId { get; set; }

		[Column("USER_ID")]
		public long UserId { get; set; }

		[Column("READ_FLAG")]
		public byte? ReadFlag { get; set; }

		[Column("READ_DATE")]
		public DateTime? ReadDate { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[ForeignKey("AlertId")]
		[InverseProperty("SstUserAlerts")]
		public virtual SstAlerts Alert { get; set; }

		[ForeignKey("UserId")]
		[InverseProperty("SstUserAlerts")]
		public virtual SstUsers User { get; set; }
	}
}
