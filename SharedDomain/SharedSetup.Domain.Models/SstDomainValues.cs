using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DOMAIN_VALUES")]
	public class SstDomainValues : BaseModel
	{
		[Column("VALUE")]
		public long Value { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public int Order { get; set; }

		[Column("DOMAIN_CODE")]
		public long DomainCode { get; set; }

		[Column("DOMAIN_ID")]
		public long DomainId { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("SHORT_NAME")]
		public string ShortName { get; set; }

		[ForeignKey("DomainId")]
		[InverseProperty("SstDomainValues")]
		public virtual SstDomains Domain { get; set; }
	}
}
