using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PROCESS_SYSTEMS")]
	public class SstProcessSystems : BaseModel
	{
		[Column("PROCESS_ID")]
		public long ProcessId { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[ForeignKey("ModuleCode")]
		[InverseProperty("SstProcessSystems")]
		public virtual SstModules ModuleCodeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstProcessSystems")]
		public virtual SstSystems System { get; set; }
	}
}
