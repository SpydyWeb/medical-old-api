using System;
using System.Linq.Expressions;

namespace WorkflowCore.Models.Search
{
	public class DateRangeFilter : SearchFilter
	{
		public DateTime? BeforeValue { get; set; }

		public DateTime? AfterValue { get; set; }

		public static DateRangeFilter Before(Expression<Func<WorkflowSearchResult, object>> property, DateTime value)
		{
			return new DateRangeFilter
			{
				Property = property,
				BeforeValue = value
			};
		}

		public static DateRangeFilter After(Expression<Func<WorkflowSearchResult, object>> property, DateTime value)
		{
			return new DateRangeFilter
			{
				Property = property,
				AfterValue = value
			};
		}

		public static DateRangeFilter Between(Expression<Func<WorkflowSearchResult, object>> property, DateTime start, DateTime end)
		{
			return new DateRangeFilter
			{
				Property = property,
				BeforeValue = end,
				AfterValue = start
			};
		}

		public static DateRangeFilter Before<T>(Expression<Func<T, object>> property, DateTime value)
		{
			return new DateRangeFilter
			{
				IsData = true,
				DataType = typeof(T),
				Property = property,
				BeforeValue = value
			};
		}

		public static DateRangeFilter After<T>(Expression<Func<T, object>> property, DateTime value)
		{
			return new DateRangeFilter
			{
				IsData = true,
				DataType = typeof(T),
				Property = property,
				AfterValue = value
			};
		}

		public static DateRangeFilter Between<T>(Expression<Func<T, object>> property, DateTime start, DateTime end)
		{
			return new DateRangeFilter
			{
				IsData = true,
				DataType = typeof(T),
				Property = property,
				BeforeValue = end,
				AfterValue = start
			};
		}
	}
}
