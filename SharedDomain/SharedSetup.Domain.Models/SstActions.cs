using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_ACTIONS")]
	public class SstActions : BaseModel
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
		public short? TargetAction { get; set; }

		[Column("RULE_ID")]
		public long RuleId { get; set; }

		[Column("TARGET_KEY")]
		public string TargetKey { get; set; }

		[Column("STEP_ID")]
		public long? StepId { get; set; }

		[Column("APPLIED_ON")]
		public short? AppliedOn { get; set; }

		[Column("ACTION_VALUE")]
		public string ActionValue { get; set; }

		[Column("REF_COM_ID")]
		public long? RefComId { get; set; }

		[Column("ORDER")]
		public short? Order { get; set; }

		[Column("NOTIFICATION_ID")]
		public long? NotificationId { get; set; }

		[ForeignKey("RuleId")]
		[InverseProperty("SstActions")]
		public virtual SstRules Rule { get; set; }
	}
}
