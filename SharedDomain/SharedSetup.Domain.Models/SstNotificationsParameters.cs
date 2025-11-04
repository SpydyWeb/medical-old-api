using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_NOTIFICATIONS_PARAMETERS")]
	public class SstNotificationsParameters : BaseModel
	{
		[Column("PARAMETER_TYPE")]
		public byte? ParameterType { get; set; }

		[Column("PARAMETER_REF")]
		public long? ParameterRef { get; set; }

		[Column("NOTIFICATION_ID")]
		public long NotificationId { get; set; }
	}
}
