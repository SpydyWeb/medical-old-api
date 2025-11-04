using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_NOTIFICATIONS_TEMPLATES")]
	public class SstNotificationsTemplates : BaseModel
	{
		[Column("TYPE")]
		public byte Type { get; set; }

		[Column("FROM_")]
		public string From { get; set; }

		[Column("SUBJECT")]
		public string Subject { get; set; }

		[Column("SUBJECT2")]
		public string Subject2 { get; set; }

		[Column("BODY")]
		public byte[] Body { get; set; }

		[Column("BODY2")]
		public byte[] Body2 { get; set; }

		[Column("NOTIFICATION_ID")]
		public long NotificationId { get; set; }
	}
}
