using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DYNAMIC_VALUES")]
	public class SstDynamicValues : BaseModel
	{
		[Column("QUEST_DETAIL_ID")]
		public long QuestDetailId { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public short Order { get; set; }

		[Column("VALUE")]
		public short Value { get; set; }

		[ForeignKey("QuestDetailId")]
		[InverseProperty("SstDynamicValues")]
		public virtual SstQuestDetails QuestDetail { get; set; }
	}
}
