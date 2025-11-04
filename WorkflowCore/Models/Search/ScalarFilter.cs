using System;
using System.Linq.Expressions;

namespace WorkflowCore.Models.Search
{
	public class ScalarFilter : SearchFilter
	{
		public object Value { get; set; }

		public static SearchFilter Equals(Expression<Func<WorkflowSearchResult, object>> property, object value)
		{
			return new ScalarFilter
			{
				Property = property,
				Value = value
			};
		}

		public static SearchFilter Equals<T>(Expression<Func<T, object>> property, object value)
		{
			return new ScalarFilter
			{
				IsData = true,
				DataType = typeof(T),
				Property = property,
				Value = value
			};
		}
	}
}
