using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;
using SharedSetup.Domain.Models;

namespace Domain.Extension
{
	public static class IEnumerableExtension
	{
		public static List<T> ApplyPaging<T>(this List<T> query, int pageNumber, int? pageSize)
		{
			return pageSize.HasValue ? query.Skip((pageNumber - 1) * pageSize.Value).Take(pageSize.Value).ToList() : query;
		}

		public static IQueryable<T> ApplyQueryablePaging<T>(this IQueryable<T> query, int pageNumber, int? pageSize, ref long totalRecords)
		{
			totalRecords = query.Count();
			return pageSize.HasValue ? query.Skip((pageNumber - 1) * pageSize.Value).Take(pageSize.Value) : query;
		}

		public static List<T> EmptyIfNull<T>(this List<T> list)
		{
			return (list == null) ? Enumerable.Empty<T>().ToList() : list;
		}

		public static string FindLabel<T>(this List<T> itemList, string value) where T : SelectItem
		{
			if (itemList != null && itemList.Count() > 0)
			{
				T selectItem = itemList.Find((T x) => x.value == value);
				if (selectItem != null)
				{
					return selectItem.label;
				}
				return string.Empty;
			}
			return string.Empty;
		}

		public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
		{
			foreach (T item in enumeration)
			{
				action(item);
			}
		}

		public static string GetPreferenceValue<T>(this List<T> sstPreferences, string prefCode) where T : SstPreferences
		{
			string value = string.Empty;
			if (sstPreferences != null && sstPreferences.Count() > 0)
			{
				T preference = sstPreferences.Find((T p) => p.Code == prefCode);
				if (preference != null)
				{
					value = preference.PrefValue.ToLower();
				}
			}
			return value;
		}

		public static T SetValue<T>(this T input, Action<T> action)
		{
			action(input);
			return input;
		}

		public static string stringify<T>(this List<T> List, char seperator = ',')
		{
			string value = string.Empty;
			if (List != null && List.Count() > 0)
			{
				value = string.Join(seperator, List);
			}
			return value;
		}

		public static IQueryable<TSource> WhereMany<TSource>(this IQueryable<TSource> source, IEnumerable<Expression<Func<TSource, bool>>> expressions)
		{
			foreach (Expression<Func<TSource, bool>> expression in expressions)
			{
				source = source.Where(expression);
			}
			return source;
		}
	}
}
