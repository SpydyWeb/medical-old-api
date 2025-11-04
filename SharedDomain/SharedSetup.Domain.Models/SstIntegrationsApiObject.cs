using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_INTEGRATIONS_API_OBJECT")]
	public class SstIntegrationsApiObject : BaseModel
	{
		[Column("PARAM_TYPE")]
		public string ParamType { get; set; }

		[Column("PARAM_NAME")]
		public string ParamName { get; set; }

		[Column("ELEMENT_TYPE")]
		public int? ElementType { get; set; }

		[Column("ELEMENT_PARENT")]
		public long? ElementParent { get; set; }

		[Column("ELEMENT_ID")]
		public long? ElementId { get; set; }

		[Column("ELEMENT_KEY")]
		public string ElementKey { get; set; }

		[Column("DEFAULT_VALUE")]
		public string DefaultValue { get; set; }

		[Column("ORDER")]
		public int? Order { get; set; }

		[Column("MAPPING_ID")]
		public long? MappingId { get; set; }

		[Column("STEP_ID")]
		public long? StepId { get; set; }
	}
}
