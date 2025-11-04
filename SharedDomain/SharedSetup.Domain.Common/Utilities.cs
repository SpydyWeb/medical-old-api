using System.ComponentModel;

namespace SharedSetup.Domain.Common
{
	public class Utilities
	{
		public static bool TryParse<T>(string value, out T result)
		{
			try
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
				if (converter != null && converter.IsValid(value))
				{
					result = (T)converter.ConvertFromString(value);
					return true;
				}
				result = default(T);
				return false;
			}
			catch
			{
				result = default(T);
				return false;
			}
		}
	}
}
