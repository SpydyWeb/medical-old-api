using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_NOTIFICATIONS_LOGS")]
	public class SstNotificationsLogs : BaseModel
	{
		[Column("STATUS")]
		public byte? Status { get; set; }

		[Column("REQUEST")]
		public string Request { get; set; }

		[Column("REQUEST_DATE")]
		public DateTime? RequestDate { get; set; }

		[Column("RESPONSE")]
		public string Response { get; set; }

		[Column("RESPONSE_DATE")]
		public DateTime? ResponseDate { get; set; }

		[Column("KEY_TYPE")]
		public byte? KeyType { get; set; }

		[Column("KEY_VALUE")]
		public string KeyValue { get; set; }

		[Column("NOTIFICATION_ID")]
		public long? NotificationId { get; set; }
	}
}
