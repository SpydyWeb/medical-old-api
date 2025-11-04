using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_RESOURCES_BKP")]
	public class SstResourcesBkp : BaseModel
	{
		[Column("OBJECT")]
		public string Object { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

		[Column("VALUE")]
		public string Value { get; set; }

		[Column("LANGUAGE")]
		public string Language { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }
	}
}
