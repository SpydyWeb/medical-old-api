using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PROCESS_CONDITIONS")]
	public class SstProcessConditions : BaseModel
	{
		[Column("CONDITION_TYPE")]
		public byte ConditionType { get; set; }

		[Column("REFERENCE_TYPE")]
		public byte? ReferenceType { get; set; }

		[Column("REFERENCE_PARENT")]
		public long? ReferenceParent { get; set; }

		[Column("REFERENCE_ID")]
		public long? ReferenceId { get; set; }

		[Column("REFERENCE_KEY")]
		public long? ReferenceKey { get; set; }

		[Column("VALIDATOR")]
		public byte? Validator { get; set; }

		[Column("VALIDATOR_VALUE")]
		public string ValidatorValue { get; set; }

		[Column("VALIDATOR_VALUE2")]
		public string ValidatorValue2 { get; set; }

		[Column("OPERATOR")]
		public byte? Operator { get; set; }

		[Column("ORDER")]
		public byte Order { get; set; }

		[Column("FORMULA")]
		public string Formula { get; set; }

		[Column("RULE_ID")]
		public long RuleId { get; set; }
	}
}
