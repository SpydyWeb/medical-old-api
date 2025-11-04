using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_LOGS_DETAILS")]
	public class SstLogsDetails : BaseModel
	{
		[Column("TYPE")]
		public byte? Type { get; set; }

		[Column("CONTENT")]
		public string Content { get; set; }

		[Column("PROCESS_DATE")]
		public DateTime? ProcessDate { get; set; }

		[Column("LOG_ID")]
		public long? LogId { get; set; }

		[ForeignKey("LogId")]
		[InverseProperty("SstLogsDetails")]
		public virtual SstLogs Log { get; set; }
	}
}
