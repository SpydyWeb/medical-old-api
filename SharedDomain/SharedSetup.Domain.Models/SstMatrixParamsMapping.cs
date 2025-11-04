using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_MATRIX_PARAMS_MAPPING")]
	public class SstMatrixParamsMapping : BaseModel
	{
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

		[Column("FORMULA_COLUMN")]
		public string FormulaColumn { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstMatrixParamsMapping")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("ParamMap")]
		public virtual ICollection<SstRatingMatrixParams> SstRatingMatrixParams { get; set; }

		public SstMatrixParamsMapping()
		{
			SstRatingMatrixParams = new HashSet<SstRatingMatrixParams>();
		}
	}
}
