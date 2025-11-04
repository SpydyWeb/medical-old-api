namespace SharedSetup.Domain.DTO.Core
{
	public class ReportParameterDTO
	{
		public int ParamID { get; set; }

		public string ColumnType { get; set; }

		public int ParamOrder { get; set; }

		public string ParamFrom { get; set; }

		public string ParamTo { get; set; }

		public string ParamFromDescription { get; set; }

		public string ParamToDescription { get; set; }

		public string FromValue { get; set; }

		public string ToValue { get; set; }

		public bool ParamFromRequired { get; set; }

		public bool ParamToRequired { get; set; }

		public string ReportCode { get; set; }
	}
}
