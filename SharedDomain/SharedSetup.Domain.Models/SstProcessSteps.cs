using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PROCESS_STEPS")]
	public class SstProcessSteps : BaseModel
	{
		[Column("NAME")]
		public string Name { get; set; }

		[Column("STEP_ID")]
		public long? StepId { get; set; }

		[Column("SHAPE_TYPE")]
		public long? ShapeType { get; set; }

		[Column("X_POSITION")]
		public long? XPosition { get; set; }

		[Column("Y_POSITION")]
		public long? YPosition { get; set; }

		[Column("WIDTH")]
		public long? Width { get; set; }

		[Column("HEIGHT")]
		public long? Height { get; set; }

		[Column("PROCESS_ID")]
		public long? ProcessId { get; set; }

		[Column("PROCESS_STEP_ID")]
		public long? ProcessStepId { get; set; }

		[Column("FONT_COLOR")]
		public string FontColor { get; set; }

		[Column("BACK_COLOR")]
		public string BackColor { get; set; }

		[Column("FONT_SIZE")]
		public int? FontSize { get; set; }

		[InverseProperty("ProcessStep")]
		public virtual ICollection<SstProcessParentSteps> SstProcessParentSteps { get; set; }

		[InverseProperty("Step")]
		public virtual ICollection<SstProcessStepsPages> SstProcessStepsPages { get; set; }

		public SstProcessSteps()
		{
			SstProcessParentSteps = new HashSet<SstProcessParentSteps>();
			SstProcessStepsPages = new HashSet<SstProcessStepsPages>();
		}
	}
}
