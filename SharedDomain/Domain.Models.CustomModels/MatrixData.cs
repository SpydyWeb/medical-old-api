using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Domain.Models.CustomModels
{
	public class MatrixData
	{
		public long MatrixId { get; set; }

		public List<JObject> MatrixRows { get; set; }

		public List<DynamicMatrixColumn> MatrixCols { get; set; }

		public string serializedMatrixRows
		{
			get
			{
				string result = string.Empty;
				if (MatrixRows != null && MatrixRows.Count > 0)
				{
					dynamic val = new ExpandoObject();
					val.matrixRows = MatrixRows;
					result = JsonConvert.SerializeObject(val);
				}
				return result;
			}
		}
	}
}
