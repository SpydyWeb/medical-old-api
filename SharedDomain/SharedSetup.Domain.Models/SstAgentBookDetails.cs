using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_AGENT_BOOK_DETAILS")]
	public class SstAgentBookDetails : BaseModel
	{
		[NotMapped]
		public string AgentName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string StatusName { get; set; }

		[NotMapped]
		public string RiskName { get; set; }

		[NotMapped]
		public string SerailName { get; set; }

		[NotMapped]
		public string RiskStatus { get; set; }

		[NotMapped]
		public string PolicyNoName { get; set; }

		[Column("PARENT_BOOK_ID")]
		public long ParentBookId { get; set; }

		[Column("PAGE_NO")]
		public int PageNo { get; set; }

		[Column("PAGE_DATE")]
		public DateTime PageDate { get; set; }

		[Column("AGENT_ID")]
		public long? AgentId { get; set; }

		[Column("PAGE_STATUS")]
		public byte PageStatus { get; set; }

		[Column("RETURNED_DATE")]
		public DateTime? ReturnedDate { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[ForeignKey("ParentBookId")]
		[InverseProperty("SstAgentBookDetails")]
		public virtual SstAgentBooks ParentBook { get; set; }
	}
}
