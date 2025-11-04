using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PROCESS_ACTIONS")]
	public class SstProcessActions : BaseModel
	{
		[Column("ACTION_TYPE")]
		public byte ActionType { get; set; }

		[Column("TARGET_TYPE")]
		public byte TargetType { get; set; }

		[Column("TARGET_PARENT")]
		public long? TargetParent { get; set; }

		[Column("TARGET_ID")]
		public long? TargetId { get; set; }

		[Column("TARGET_ACTION")]
		public string TargetAction { get; set; }

		[Column("RULE_ID")]
		public long RuleId { get; set; }

		[Column("TARGET_KEY")]
		public long? TargetKey { get; set; }
	}
}
