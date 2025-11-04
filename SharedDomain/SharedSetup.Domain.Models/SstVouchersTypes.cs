using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_VOUCHERS_TYPES")]
	public class SstVouchersTypes : BaseModel
	{
		[Key]
		[Column("SERIAL")]
		public byte Serial { get; set; }

		[Required]
		[Column("VOUCHER_NAME")]
		public string VoucherName { get; set; }

		[Required]
		[Column("TABLE_NAME")]
		public string TableName { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Required]
		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[Required]
		[Column("FCR_TRT_CODE")]
		public string FcrTrtCode { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[InverseProperty("VoucherSerialNavigation")]
		public virtual ICollection<SstVouchersEntries> SstVouchersEntriesVoucherSerialNavigation { get; set; }

		[InverseProperty("VoucherTypeNavigation")]
		public virtual ICollection<SstVouchersEntries> SstVouchersEntriesVoucherTypeNavigation { get; set; }

		public SstVouchersTypes()
		{
			SstVouchersEntriesVoucherSerialNavigation = new HashSet<SstVouchersEntries>();
			SstVouchersEntriesVoucherTypeNavigation = new HashSet<SstVouchersEntries>();
		}
	}
}
