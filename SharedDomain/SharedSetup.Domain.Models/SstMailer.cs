using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_MAILER")]
	public class SstMailer : BaseModel
	{
		[Column("TYPE")]
		public byte? Type { get; set; }

		[Column("USERNAME")]
		public string Username { get; set; }

		[Column("PASSWORD")]
		public string Password { get; set; }

		[Column("HOST")]
		public string Host { get; set; }

		[Column("PORT")]
		public long? Port { get; set; }

		[Column("SECURITY")]
		public byte? Security { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstMailer")]
		public virtual SstSystems System { get; set; }
	}
}
