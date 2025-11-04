using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_MODULES")]
	public class SstModules : BaseModel2
	{
		[Key]
		[Column("CODE")]
		public string Code { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstModules")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("ModuleCodeNavigation")]
		public virtual ICollection<SstAccounts> SstAccounts { get; set; }

		[InverseProperty("ModuleCodeNavigation")]
		public virtual ICollection<SstCodes> SstCodes { get; set; }

		[InverseProperty("ModuleCodeNavigation")]
		public virtual ICollection<SstPages> SstPages { get; set; }

		[InverseProperty("ModuleCodeNavigation")]
		public virtual ICollection<SstProcessSystems> SstProcessSystems { get; set; }

		public SstModules()
		{
			SstAccounts = new HashSet<SstAccounts>();
			SstCodes = new HashSet<SstCodes>();
			SstPages = new HashSet<SstPages>();
			SstProcessSystems = new HashSet<SstProcessSystems>();
		}
	}
}
