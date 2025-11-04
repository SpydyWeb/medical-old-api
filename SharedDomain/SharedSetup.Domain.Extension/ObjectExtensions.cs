using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SharedSetup.Domain.Extension
{
	public static class ObjectExtensions
	{
		public static string EmptyIfNull(this object value)
		{
			return value?.ToString() ?? string.Empty;
		}

		public static string ToQueryString(this object requestObject, string separator = ",")
		{
			if (requestObject == null)
			{
				throw new ArgumentNullException("request");
			}
			Dictionary<string, object> dictionary = (from x in requestObject.GetType().GetProperties()
				where x.CanRead
				where x.GetValue(requestObject, null) != null
				select x).ToDictionary((PropertyInfo x) => x.Name, (PropertyInfo x) => x.GetValue(requestObject, null));
			List<string> list = (from x in dictionary
				where !(x.Value is string) && x.Value is IEnumerable
				select x.Key).ToList();
			foreach (string item in list)
			{
				Type type = dictionary[item].GetType();
				Type type2 = (type.IsGenericType ? type.GetGenericArguments()[0] : type.GetElementType());
				if (type2.IsPrimitive || type2 == typeof(string))
				{
					IEnumerable source = dictionary[item] as IEnumerable;
					dictionary[item] = string.Join(separator, source.Cast<object>());
				}
			}
			return string.Join("&", dictionary.Select((KeyValuePair<string, object> x) => Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value.ToString())));
		}

		public static string ToSnakeCase(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}
			return Regex.Match(input, "^_+")?.ToString() + Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToUpper();
		}

		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> seenKeys = new HashSet<TKey>();
			return source.Where((TSource element) => seenKeys.Add(keySelector(element)));
		}

		public static IQueryable<TSource> DistinctBy<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> seenKeys = new HashSet<TKey>();
			return source.Where((TSource element) => seenKeys.Add(keySelector(element)));
		}

		public static IQueryable<T> ApplyQueryablePaging<T>(this IQueryable<T> query, int pageNumber, int? pageSize, ref long totalRecords)
		{
			totalRecords = query.Count();
			return pageSize.HasValue ? query.Skip((pageNumber - 1) * pageSize.Value).Take(pageSize.Value) : query;
		}
	}
}
