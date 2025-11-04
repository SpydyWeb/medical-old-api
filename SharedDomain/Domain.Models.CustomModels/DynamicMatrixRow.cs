using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Domain.Models.CustomModels
{
	public class DynamicMatrixRow : DynamicObject
	{
		public Dictionary<string, object> properties = new Dictionary<string, object>();

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			string key = binder.Name.ToLower();
			return properties.TryGetValue(key, out result);
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			properties[binder.Name.ToLower()] = value;
			return true;
		}

		public JObject formattedAsJson()
		{
			string json = JsonConvert.SerializeObject(properties);
			return JObject.Parse(json);
		}
	}
}
