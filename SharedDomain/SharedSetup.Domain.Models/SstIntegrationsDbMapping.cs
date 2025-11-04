using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_INTEGRATIONS_DB_MAPPING")]
	public class SstIntegrationsDbMapping : BaseModel
	{
		[Column("TABLE_NAME")]
		public string TableName { get; set; }

		[Column("COLUMN_NAME")]
		public string ColumnName { get; set; }

		[Column("COLUMN_TYPE")]
		public string ColumnType { get; set; }

		[Column("ELEMENT_TYPE")]
		public int? ElementType { get; set; }

		[Column("ELEMENT_ID")]
		public long? ElementId { get; set; }

		[Column("ELEMENT_KEY")]
		public string ElementKey { get; set; }

		[Column("DEFAULT_VALUE")]
		public string DefaultValue { get; set; }

		[Column("SETTING_ID")]
		public long? SettingId { get; set; }

		[Column("ELEMENET_PARENT")]
		public long? ElemenetParent { get; set; }
	}
}
