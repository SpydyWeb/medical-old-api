using System;
using System.Linq.Expressions;

namespace WorkflowCore.Models.Search
{
	public class NumericRangeFilter : SearchFilter
	{
		public double? LessValue { get; set; }

		public double? GreaterValue { get; set; }

		public static NumericRangeFilter LessThan(Expression<Func<WorkflowSearchResult, object>> property, double value)
		{
			return new NumericRangeFilter
			{
				Property = property,
				LessValue = value
			};
		}

		public static NumericRangeFilter GreaterThan(Expression<Func<WorkflowSearchResult, object>> property, double value)
		{
			return new NumericRangeFilter
			{
				Property = property,
				GreaterValue = value
			};
		}

		public static NumericRangeFilter Between(Expression<Func<WorkflowSearchResult, object>> property, double start, double end)
		{
			return new NumericRangeFilter
			{
				Property = property,
				LessValue = end,
				GreaterValue = start
			};
		}

		public static NumericRangeFilter LessThan<T>(Expression<Func<T, object>> property, double value)
		{
			return new NumericRangeFilter
			{
				IsData = true,
				DataType = typeof(T),
				Property = property,
				LessValue = value
			};
		}

		public static NumericRangeFilter GreaterThan<T>(Expression<Func<T, object>> property, double value)
		{
			return new NumericRangeFilter
			{
				IsData = true,
				DataType = typeof(T),
				Property = property,
				GreaterValue = value
			};
		}

		public static NumericRangeFilter Between<T>(Expression<Func<T, object>> property, double start, double end)
		{
			return new NumericRangeFilter
			{
				IsData = true,
				DataType = typeof(T),
				Property = property,
				LessValue = end,
				GreaterValue = start
			};
		}
	}
}
