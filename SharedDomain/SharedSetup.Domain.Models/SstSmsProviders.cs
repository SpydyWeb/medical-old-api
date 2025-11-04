using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SMS_PROVIDERS")]
	public class SstSmsProviders : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("STATUS")]
		public byte? Status { get; set; }

		[Column("API")]
		public string Api { get; set; }

		[Column("USERNAME")]
		public string Username { get; set; }

		[Column("PASSWORD")]
		public string Password { get; set; }

		[Column("UNICODE")]
		public byte? Unicode { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstSmsProviders")]
		public virtual SstSystems System { get; set; }
	}
}
