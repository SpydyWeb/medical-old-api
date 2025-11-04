using System.Collections.Generic;
using SharedSetup.Domain.Common;

namespace Domain.Models.CustomModels
{
	public class DynamicMatrixColumn
	{
		public string ColumnName { get; set; }

		public string ParamName { get; set; }

		public string ValueFrom { get; set; }

		public string ValueTo { get; set; }

		public long SystemId { get; set; }

		public int ParamType { get; set; }

		public int DataType { get; set; }

		public long? ReferenceId { get; set; }

		public List<SelectItem> ReferenceList { get; set; }
	}
}
