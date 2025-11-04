using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PREFERENCES")]
	public class SstPreferences : BaseModel
	{
		[NotMapped]
		public string DataTypeName { get; set; }

		[Required]
		[Column("CODE")]
		public string Code { get; set; }

		[Required]
		[Column("PREF_NAME")]
		public string PrefName { get; set; }

		[Column("PREF_TYPE")]
		public short PrefType { get; set; }

		[Required]
		[Column("PREF_VALUE")]
		public string PrefValue { get; set; }

		[Required]
		[Column("PREF_PAGE")]
		public string PrefPage { get; set; }

		[Required]
		[Column("PREF_DESCRIPTION")]
		public string PrefDescription { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }
	}
}
