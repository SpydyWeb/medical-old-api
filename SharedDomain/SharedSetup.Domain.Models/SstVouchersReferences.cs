using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_VOUCHERS_REFERENCES")]
	public class SstVouchersReferences : BaseModel
	{
		[Column("SERIAL")]
		public long Serial { get; set; }

		[Required]
		[Column("REFERENCE_NAME")]
		public string ReferenceName { get; set; }

		[Column("REFERENCE_TYPE")]
		public byte ReferenceType { get; set; }

		[Required]
		[Column("TABLE_NAME")]
		public string TableName { get; set; }

		[Required]
		[Column("COLUMN_NAME")]
		public string ColumnName { get; set; }

		[Column("VOUCHER_TYPE")]
		public long VoucherType { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Required]
		[Column("FCR_TRT_CODE")]
		public string FcrTrtCode { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[Required]
		[Column("WHERE_CLAUSE")]
		public string WhereClause { get; set; }
	}
}
