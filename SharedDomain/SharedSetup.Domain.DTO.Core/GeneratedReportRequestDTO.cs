using System.Collections.Generic;

namespace SharedSetup.Domain.DTO.Core
{
	public class GeneratedReportRequestDTO
	{
		public string ReportCode { get; set; }

		public List<ReportParameterDTO> oReportParameters { get; set; }

		public string UserName { get; set; }

		public string Path { get; set; }

		public string FileName { get; set; }

		public string OutputType { get; set; }

		public string Language { get; set; }

		public string ApplicationID { get; set; }

		public string Langauage { get; set; }
	}
}
