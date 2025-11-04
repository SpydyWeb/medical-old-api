using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Core
{
	public class ReportOutputDTO
	{
		public bool canPrintPdf { get; set; }

		public bool canPrintWord { get; set; }

		public bool canPrintRtf { get; set; }

		public bool canPrintExcel { get; set; }

		public bool canPrintExcelRecords { get; set; }

		public bool canViewReport { get; set; }

		public bool canDownloadReport { get; set; }

		public bool canPrintReport { get; set; }

		public string CAM_RPT_CODE { get; set; }

		public string ERROR_CODE { get; set; }

		public string USERNAME { get; set; }

		public int STATUS { get; set; }

		[JsonProperty("PRINT_PDF")]
		private int PRINT_PDF
		{
			set
			{
				canPrintPdf = value > 0;
			}
		}

		[JsonProperty("PRINT_WORD")]
		private int PRINT_WORD
		{
			set
			{
				canPrintWord = value > 0;
			}
		}

		[JsonProperty("PRINT_RTF")]
		private int PRINT_RTF
		{
			set
			{
				canPrintRtf = value > 0;
			}
		}

		[JsonProperty("PRINT_EXCEL")]
		private int PRINT_EXCEL
		{
			set
			{
				canPrintExcel = value > 0;
			}
		}

		[JsonProperty("PRINT_EXCEL_RECORD")]
		private int PRINT_EXCEL_RECORD
		{
			set
			{
				canPrintExcelRecords = value > 0;
			}
		}

		[JsonProperty("VIEW_REPORT")]
		private int VIEW_REPORT
		{
			set
			{
				canViewReport = value > 0;
			}
		}

		[JsonProperty("DOWNLOAD_REPORT")]
		private int DOWNLOAD_REPORT
		{
			set
			{
				canDownloadReport = value > 0;
			}
		}

		[JsonProperty("PRINT_REPORT")]
		private int PRINT_REPORT
		{
			set
			{
				canPrintReport = value > 0;
			}
		}
	}
}
