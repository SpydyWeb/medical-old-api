using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CODES")]
	public class SstCodes : BaseModel
	{
		[Column("MAJOR_CODE")]
		public long MajorCode { get; set; }

		[Column("MINOR_CODE")]
		public long MinorCode { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[Column("CODE_ID")]
		public long? CodeId { get; set; }

		[Column("DOMAIN_ID")]
		public long? DomainId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[ForeignKey("CodeId")]
		[InverseProperty("InverseCode")]
		public virtual SstCodes Code { get; set; }

		[ForeignKey("ModuleCode")]
		[InverseProperty("SstCodes")]
		public virtual SstModules ModuleCodeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstCodes")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Code")]
		public virtual ICollection<SstCodes> InverseCode { get; set; }

		public SstCodes()
		{
			InverseCode = new HashSet<SstCodes>();
		}
	}
}
