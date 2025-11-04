using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PAGES")]
	public class SstPages : BaseModel
	{
		[Column("KEY")]
		public string Key { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public int Order { get; set; }

		[Column("PAGE_URL")]
		public string PageUrl { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("PAGE_ID")]
		public long? PageId { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("ModuleCode")]
		[InverseProperty("SstPages")]
		public virtual SstModules ModuleCodeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstPages")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Page")]
		public virtual ICollection<SstPagesControls> SstPagesControls { get; set; }

		[InverseProperty("Page")]
		public virtual ICollection<SstProcessStepsPages> SstProcessStepsPages { get; set; }

		public SstPages()
		{
			SstPagesControls = new HashSet<SstPagesControls>();
			SstProcessStepsPages = new HashSet<SstProcessStepsPages>();
		}
	}
}
