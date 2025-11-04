using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PROCESS_ROLES")]
	public class SstProcessRoles : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("USERNAME")]
		public string Username { get; set; }

		[Column("GROUP_ID")]
		public long? GroupId { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("PROCESS_STEP_ID")]
		public long ProcessStepId { get; set; }
	}
}
