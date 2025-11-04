using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_RATING_MATRIX_PARAMS")]
	public class SstRatingMatrixParams : BaseModel
	{
		[NotMapped]
		public string SourceName { get; set; }

		[Column("RATING_MATRIX_ID")]
		public long RatingMatrixId { get; set; }

		[Column("PARAM_MAP_ID")]
		public long ParamMapId { get; set; }

		[Column("SERIAL")]
		public long? Serial { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("SOURCE")]
		public byte? Source { get; set; }

		[Column("LOB")]
		public short? Lob { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("VALUE_FROM")]
		public string ValueFrom { get; set; }

		[Column("VALUE_TO")]
		public string ValueTo { get; set; }

		[Column("DATA_TYPE")]
		public short DataType { get; set; }

		[Column("PARAM_TYPE")]
		public short ParamType { get; set; }

		[Column("REFERENCE_ID")]
		public long? ReferenceId { get; set; }

		[Required]
		[Column("TABLE_NAME")]
		public string TableName { get; set; }

		[Required]
		[Column("COLUMN_NAME")]
		public string ColumnName { get; set; }

		[ForeignKey("ParamMapId")]
		[InverseProperty("SstRatingMatrixParams")]
		public virtual SstMatrixParamsMapping ParamMap { get; set; }

		[ForeignKey("RatingMatrixId")]
		[InverseProperty("SstRatingMatrixParams")]
		public virtual SstRatingMatrix RatingMatrix { get; set; }
	}
}
