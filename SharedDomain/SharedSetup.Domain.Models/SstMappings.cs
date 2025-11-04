using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_MAPPINGS")]
	public class SstMappings : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("SOURCE_TYPE")]
		public byte? SourceType { get; set; }

		[Column("DB_TYPE")]
		public byte? DbType { get; set; }

		[Column("DB_HOST")]
		public string DbHost { get; set; }

		[Column("DB_PORT")]
		public byte? DbPort { get; set; }

		[Column("DB_SERVICE")]
		public string DbService { get; set; }

		[Column("DB_USER")]
		public string DbUser { get; set; }

		[Column("DB_PASSWORD")]
		public string DbPassword { get; set; }

		[Column("API_URL")]
		public byte[] ApiUrl { get; set; }

		[Column("API_TYPE")]
		public byte? ApiType { get; set; }

		[Column("AUTH_TYPE")]
		public byte? AuthType { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("MODULE_CODE")]
		public long ModuleCode { get; set; }

		[Column("INTEGRATION_ID")]
		public long IntegrationId { get; set; }
	}
}
