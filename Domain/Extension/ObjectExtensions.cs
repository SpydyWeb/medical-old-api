using Newtonsoft.Json;

namespace Domain.Extension
{
	public static class ObjectExtensions
	{
		public static string EmptyIfNull(this object value)
		{
			return value?.ToString() ?? string.Empty;
		}

		public static T CloneJson<T>(this T model)
		{
			if (model == null)
			{
				return default(T);
			}
			string serializedModel = JsonConvert.SerializeObject(model);
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				ObjectCreationHandling = ObjectCreationHandling.Replace
			};
			return JsonConvert.DeserializeObject<T>(serializedModel, jsonSerializerSettings);
		}
	}
}
