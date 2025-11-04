using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PROCESS_PARENT_STEPS")]
	public class SstProcessParentSteps : BaseModel
	{
		[Column("SHAPE_ID")]
		public long? ShapeId { get; set; }

		[Column("EDGE_DESCRIPTION")]
		public string EdgeDescription { get; set; }

		[Column("PARENT_SHAPE_ID")]
		public long? ParentShapeId { get; set; }

		[Column("PROCESS_STEP_ID")]
		public long? ProcessStepId { get; set; }

		[Column("EDGE_TYPE")]
		public int EdgeType { get; set; }

		[Column("PROCESS_ID")]
		public long ProcessId { get; set; }

		[ForeignKey("ProcessStepId")]
		[InverseProperty("SstProcessParentSteps")]
		public virtual SstProcessSteps ProcessStep { get; set; }
	}
}
