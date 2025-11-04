using System;
using System.Linq.Expressions;

namespace WorkflowCore.Models.Search
{
	public abstract class SearchFilter
	{
		public bool IsData { get; set; }

		public Type DataType { get; set; }

		public Expression Property { get; set; }

		private static Func<T, V> Lambda<T, V>(Func<T, V> del)
		{
			return del;
		}
	}
}
