using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_NOTIFICATIONS_CONTACTS")]
	public class SstNotificationsContacts : BaseModel
	{
		[Column("TYPE")]
		public byte Type { get; set; }

		[Column("USERNAME")]
		public string Username { get; set; }

		[Column("GROUP_ID")]
		public long? GroupId { get; set; }

		[Column("TEMPLATE_ID")]
		public long TemplateId { get; set; }
	}
}
