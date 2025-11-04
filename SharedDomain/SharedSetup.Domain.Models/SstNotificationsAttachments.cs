using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_NOTIFICATIONS_ATTACHMENTS")]
	public class SstNotificationsAttachments : BaseModel
	{
		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("TYPE")]
		public byte Type { get; set; }

		[Column("ATTACH_PATH")]
		public string AttachPath { get; set; }

		[Column("REPORT_CODE")]
		public string ReportCode { get; set; }

		[Column("STATUS")]
		public byte? Status { get; set; }

		[Column("NOTIFICATION_ID")]
		public long NotificationId { get; set; }
	}
}
