using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_INTEGRATIONS_SETTINGS")]
	public class SstIntegrationsSettings : BaseModel
	{
		[Column("DB_TYPE")]
		public int? DbType { get; set; }

		[Column("DB_SCHEMA")]
		public string DbSchema { get; set; }

		[Column("DB_HOST")]
		public string DbHost { get; set; }

		[Column("DB_PORT")]
		public int? DbPort { get; set; }

		[Column("DB_SERVICE")]
		public string DbService { get; set; }

		[Column("DB_USER")]
		public string DbUser { get; set; }

		[Column("DB_PASSWORD")]
		public string DbPassword { get; set; }

		[Column("API_URL")]
		public string ApiUrl { get; set; }

		[Column("API_TYPE")]
		public byte? ApiType { get; set; }

		[Column("API_SOURCE_TYPE")]
		public byte? ApiSourceType { get; set; }

		[Column("URL_TYPE")]
		public byte? UrlType { get; set; }

		[Column("SERVICE_METHOD")]
		public string ServiceMethod { get; set; }

		[Column("AUTH_TYPE")]
		public byte? AuthType { get; set; }

		[Column("API_NAME")]
		public string ApiName { get; set; }

		[Column("HTTP_TYPE")]
		public byte? HttpType { get; set; }

		[Column("XML_STRUCTURE")]
		public byte[] XmlStructure { get; set; }

		[Column("INTEGRATION_ID")]
		public long? IntegrationId { get; set; }

		[Column("PRODUCT_ID")]
		public long? ProductId { get; set; }

		[Column("MODULE_CODE")]
		public long? ModuleCode { get; set; }

		[ForeignKey("IntegrationId")]
		[InverseProperty("SstIntegrationsSettings")]
		public virtual SstIntegrations Integration { get; set; }

		[ForeignKey("ProductId")]
		[InverseProperty("SstIntegrationsSettings")]
		public virtual SpdProducts Product { get; set; }
	}
}
