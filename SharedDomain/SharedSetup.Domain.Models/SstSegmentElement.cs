using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SEGMENT_ELEMENT")]
	public class SstSegmentElement : BaseModel
	{
		[Column("NAME")]
		public string Name { get; set; }

		[Column("ELEMENT_TYPE")]
		public byte? ElementType { get; set; }

		[Column("CAM_APP_ID")]
		public long? CamAppId { get; set; }

		[Column("COLUMN_NAME")]
		public string ColumnName { get; set; }

		[Column("TABLE_NAME")]
		public string TableName { get; set; }

		[Column("WHERE_CONDITION")]
		public string WhereCondition { get; set; }

		[Column("SEGMENT_TYPE")]
		public byte? SegmentType { get; set; }
	}
}
