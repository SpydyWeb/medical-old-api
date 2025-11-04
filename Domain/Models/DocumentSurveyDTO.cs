using System;

namespace Domain.Models
{
	public class DocumentSurveyDTO
	{
		public long DocumentId { get; set; }

		public long SurveyId { get; set; }

		public long DocumentNo { get; set; }

		public string DocumentTypeName { get; set; }

		public string ClassName { get; set; }

		public string PolicyTypeName { get; set; }

		public string ProductName { get; set; }

		public DateTime? AssignDateTime { get; set; }

		public string SurveyorNameId { get; set; }

		public string SurveyorName { get; set; }

		public string SurveyStatusName { get; set; }

		public string SurveyLevelName { get; set; }

		public short? SurveyorType { get; set; }

		public string SegmentCode { get; set; }
	}
}
