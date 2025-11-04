using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PROCESS_STEPS_PAGES")]
	public class SstProcessStepsPages : BaseModel
	{
		[Column("PAGE_ID")]
		public long PageId { get; set; }

		[Required]
		[Column("CONTROL_KEY")]
		public string ControlKey { get; set; }

		[Column("RULE_ID")]
		public long? RuleId { get; set; }

		[Column("STEP_ID")]
		public long? StepId { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[ForeignKey("PageId")]
		[InverseProperty("SstProcessStepsPages")]
		public virtual SstPages Page { get; set; }

		[ForeignKey("RuleId")]
		[InverseProperty("SstProcessStepsPages")]
		public virtual SstRules Rule { get; set; }

		[ForeignKey("StepId")]
		[InverseProperty("SstProcessStepsPages")]
		public virtual SstProcessSteps Step { get; set; }
	}
}
