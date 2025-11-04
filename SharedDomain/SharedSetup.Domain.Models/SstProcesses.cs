using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PROCESSES")]
	public class SstProcesses : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ACTIVE")]
		public byte? Active { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }
	}
}
