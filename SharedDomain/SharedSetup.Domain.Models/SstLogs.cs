using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_LOGS")]
	public class SstLogs : BaseModel
	{
		[Column("DATE_")]
		public DateTime? Date { get; set; }

		[Column("STATUS")]
		public byte? Status { get; set; }

		[Column("STATUS_CODE")]
		public string StatusCode { get; set; }

		[Column("URL")]
		public string Url { get; set; }

		[Column("TRANSACTION_TYPE")]
		public byte? TransactionType { get; set; }

		[Column("IO_TYPE")]
		public byte? IoType { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[InverseProperty("Log")]
		public virtual ICollection<SstLogsDetails> SstLogsDetails { get; set; }

		public SstLogs()
		{
			SstLogsDetails = new HashSet<SstLogsDetails>();
		}
	}
}
