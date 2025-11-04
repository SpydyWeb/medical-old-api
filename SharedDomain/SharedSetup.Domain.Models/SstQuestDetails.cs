using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_QUEST_DETAILS")]
	public class SstQuestDetails : BaseModel
	{
		[NotMapped]
		public string DataTypeName { get; set; }

		[NotMapped]
		public string SourceName { get; set; }

		[NotMapped]
		public string VisibleName { get; set; }

		[NotMapped]
		public string MandatoryName { get; set; }

		[NotMapped]
		public IEnumerable<SelectItem> DefaultValueItems { get; set; }

		[NotMapped]
		public IEnumerable<SelectItem> SourceItems { get; set; }

		[Column("QUESTIONNAIRE_ID")]
		public long QuestionnaireId { get; set; }

		[Column("POLICY_TYPE_ID")]
		public long? PolicyTypeId { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public short Order { get; set; }

		[Column("VISIBLE")]
		public bool Visible { get; set; }

		[Column("MANDATORY")]
		public bool Mandatory { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("DESCRIPTION")]
		public string Description { get; set; }

		[Column("REPAIR_CONDITION")]
		public long? RepairCondition { get; set; }

		[Column("FROM_AGE")]
		public short? FromAge { get; set; }

		[Column("TO_AGE")]
		public short? ToAge { get; set; }

		[Column("GROUP")]
		public short? Group { get; set; }

		[Column("DATA_TYPE")]
		public short DataType { get; set; }

		[Column("SOURCE_TYPE")]
		public short SourceType { get; set; }

		[Column("SOURCE")]
		public long Source { get; set; }

		[Column("DEFAULT_VALUE")]
		public short? DefaultValue { get; set; }

		[Column("ABBREVIATION")]
		public string Abbreviation { get; set; }

		[ForeignKey("PolicyTypeId")]
		[InverseProperty("SstQuestDetails")]
		public virtual SstPolicyTypes PolicyType { get; set; }

		[ForeignKey("QuestionnaireId")]
		[InverseProperty("SstQuestDetails")]
		public virtual SstCoreQuestionnaires Questionnaire { get; set; }

		[InverseProperty("QuestDetail")]
		public virtual ICollection<SstAnswers> SstAnswers { get; set; }

		[InverseProperty("QuestDetail")]
		public virtual ICollection<SstDynamicValues> SstDynamicValues { get; set; }

		public SstQuestDetails()
		{
			SstAnswers = new HashSet<SstAnswers>();
			SstDynamicValues = new HashSet<SstDynamicValues>();
		}
	}
}
