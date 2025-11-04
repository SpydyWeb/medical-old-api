using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_QUEST_SYSTEMS")]
	public class SstQuestSystems : BaseModel
	{
		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("QUIESTIONNAIRE_ID")]
		public long QuiestionnaireId { get; set; }

		[ForeignKey("QuiestionnaireId")]
		[InverseProperty("SstQuestSystems")]
		public virtual SstQuestionnaires Quiestionnaire { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstQuestSystems")]
		public virtual SstSystems System { get; set; }
	}
}
