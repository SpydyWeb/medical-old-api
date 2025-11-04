namespace Domain.Models.SearchCriteria
{
	public class RuleSearchCriteria
	{
		public long ComponentId { get; set; }

		public int? Count { get; set; }

		public string Query { get; set; }

		public long[] rulesIds { get; set; }

		public int companyId { get; set; }

		public long[] ruleType { get; set; }
	}
}
