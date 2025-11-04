using System.Collections.Generic;

namespace SharedDomain.Models.SearchCriteria
{
	public class PageControlSearch
	{
		public long id { get; set; }

		public string key { get; set; }

		public long systemId { get; set; }

		public string moduleCode { get; set; }

		public IEnumerable<PageControl> controls { get; set; }
	}
}
