using System.Collections.Generic;

namespace SharedDomain.Extension
{
	public class MapSetting
	{
		public string PropertyName { get; set; }

		public string VirtualizationPropertyName { get; set; }

		public bool IsMultiple { get; set; }

		public bool IsValueType { get; set; }

		public IEnumerable<MapSetting> Childrens { get; set; }

		public MapSetting(string propertyName, bool isValueType, bool isMultiple, string VirtualizationPropertyName)
		{
			PropertyName = propertyName;
			IsValueType = isValueType;
			IsMultiple = isMultiple;
			this.VirtualizationPropertyName = VirtualizationPropertyName;
		}

		public MapSetting(string propertyName, bool isValueType, bool isMultiple)
		{
			PropertyName = propertyName;
			IsValueType = isValueType;
			IsMultiple = isMultiple;
		}

		public MapSetting(string propertyName, bool isValueType, bool isMultiple, IEnumerable<MapSetting> childrens)
		{
			PropertyName = propertyName;
			IsValueType = isValueType;
			IsMultiple = isMultiple;
			Childrens = childrens;
		}

		public MapSetting(string propertyName, bool isValueType, bool isMultiple, IEnumerable<MapSetting> childrens, string VirtualizationPropertyName)
		{
			PropertyName = propertyName;
			IsValueType = isValueType;
			IsMultiple = isMultiple;
			Childrens = childrens;
			this.VirtualizationPropertyName = VirtualizationPropertyName;
		}
	}
}
