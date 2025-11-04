using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DISCOUNTS_FACTORS")]
	public class SstDiscountsFactors : BaseModel
	{
		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("LOB")]
		public long Lob { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("VALUE_FROM")]
		public long ValueFrom { get; set; }

		[Column("VALUE_TO")]
		public long? ValueTo { get; set; }

		[Column("FACTOR_TYPE")]
		public short FactorType { get; set; }

		[Column("REFERENCE_ID")]
		public short? ReferenceId { get; set; }

		[Column("COLUMN_NAME")]
		public string ColumnName { get; set; }

		[Column("TABLE_NAME")]
		public string TableName { get; set; }

		[Column("COL_TYPE")]
		public short? ColType { get; set; }

		[Column("IS_FORMULA")]
		public short? IsFormula { get; set; }

		[Column("COL_FORMULA")]
		public string ColFormula { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstDiscountsFactors")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("DiscountFactor")]
		public virtual ICollection<SstDiscountsBusinessFactors> SstDiscountsBusinessFactors { get; set; }

		public SstDiscountsFactors()
		{
			SstDiscountsBusinessFactors = new HashSet<SstDiscountsBusinessFactors>();
		}
	}
}
