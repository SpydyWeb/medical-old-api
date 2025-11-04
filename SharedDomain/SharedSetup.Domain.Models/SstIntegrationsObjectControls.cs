using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	public class SstIntegrationsObjectControls : BaseModel
	{
		public string ParamType { get; set; }

		public string ParamName { get; set; }

		public int? ElementType { get; set; }

		public long? ElementParent { get; set; }

		public long? ElementId { get; set; }

		public string ElementKey { get; set; }

		public string DefaultValue { get; set; }

		public int? Order { get; set; }

		public long? ObjectId { get; set; }

		public long? StepId { get; set; }

		public virtual SstIntegrationsApiObject Object { get; set; }

		public virtual SpdProductsSteps Step { get; set; }
	}
}
