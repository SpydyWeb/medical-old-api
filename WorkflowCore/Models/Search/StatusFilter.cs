using System;
using System.Linq.Expressions;

namespace WorkflowCore.Models.Search
{
	public class StatusFilter : ScalarFilter
	{
		protected StatusFilter()
		{
			Expression<Func<WorkflowSearchResult, object>> property = (WorkflowSearchResult x) => x.Status;
			Property = property;
		}

		public static StatusFilter Equals(WorkflowStatus value)
		{
			return new StatusFilter
			{
				Value = value.ToString()
			};
		}
	}
}
