using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SharedDomain.Extension
{
	public static class ObjectExtension
	{
		public static object MapAsJson(this object source, List<MapSetting> settings, bool isMultiple = false)
		{
			List<JObject> list = new List<JObject>();
			IList list2 = ((!isMultiple) ? new List<object> { source } : ((IList)source));
			int count = list2.Count;
			for (int i = 0; i < count; i++)
			{
				list.Add(_mapObject(list2[i], settings));
			}
			if (!isMultiple)
			{
				return list.First();
			}
			return list;
		}

		private static JObject _mapObject(object source, List<MapSetting> settings)
		{
			dynamic val = new JObject();
			int count = settings.Count;
			for (int i = 0; i < count; i++)
			{
				MapSetting mapSetting = settings[i];
				if (mapSetting.IsValueType)
				{
					if (!string.IsNullOrEmpty(mapSetting.VirtualizationPropertyName))
					{
						object value = source.GetType().GetProperty(mapSetting.PropertyName).GetValue(source);
						if (value != null)
						{
							val[mapSetting.VirtualizationPropertyName] = JToken.FromObject(source.GetType().GetProperty(mapSetting.PropertyName).GetValue(source));
						}
						else
						{
							val[mapSetting.VirtualizationPropertyName] = null;
						}
					}
					else
					{
						object value2 = source.GetType().GetProperty(mapSetting.PropertyName).GetValue(source);
						if (value2 != null)
						{
							val[mapSetting.PropertyName] = JToken.FromObject(value2);
						}
						else
						{
							val[mapSetting.PropertyName] = null;
						}
					}
				}
				else if (!mapSetting.IsMultiple)
				{
					if (!string.IsNullOrEmpty(mapSetting.VirtualizationPropertyName))
					{
						JObject jObject = _mapObject(source.GetType().GetProperty(mapSetting.PropertyName).GetValue(source), mapSetting.Childrens.ToList());
						if (jObject != null)
						{
							val[mapSetting.VirtualizationPropertyName] = JToken.FromObject(jObject);
						}
						else
						{
							val[mapSetting.VirtualizationPropertyName] = null;
						}
					}
					else
					{
						JObject jObject2 = _mapObject(source.GetType().GetProperty(mapSetting.PropertyName).GetValue(source), mapSetting.Childrens.ToList());
						if (jObject2 != null)
						{
							val[mapSetting.PropertyName] = JToken.FromObject(jObject2);
						}
						else
						{
							val[mapSetting.PropertyName] = null;
						}
					}
				}
				else
				{
					if (!mapSetting.IsMultiple)
					{
						continue;
					}
					IEnumerable enumerable = (IEnumerable)source.GetType().GetProperty(mapSetting.PropertyName).GetValue(source);
					List<JObject> list = new List<JObject>();
					foreach (object item in enumerable)
					{
						object source2 = item;
						list.Add(_mapObject(source2, mapSetting.Childrens.ToList()));
					}
					if (!string.IsNullOrEmpty(mapSetting.VirtualizationPropertyName))
					{
						if (list != null)
						{
							val[mapSetting.VirtualizationPropertyName] = JToken.FromObject(list);
						}
						else
						{
							val[mapSetting.VirtualizationPropertyName] = null;
						}
					}
					else if (list != null)
					{
						val[mapSetting.PropertyName] = JToken.FromObject(list);
					}
					else
					{
						val[mapSetting.PropertyName] = null;
					}
				}
			}
			return val;
		}
	}
}
