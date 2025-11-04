using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	public class SstRuleType : BaseModel
	{
		public long SystemId { get; set; }

		public long CompanyId { get; set; }

		public string ModuleCode { get; set; }

		public long[] RuleType { get; set; }
	}
}
