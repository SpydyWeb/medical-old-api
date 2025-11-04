namespace CORE.DTOs.APIs.Business
{
		public class MembersDeclarations
		{
			public int Id { get; set; }

			public int MemberId { get; set; }

			public bool QuestionOne { get; set; }

			public bool QuestionTwo { get; set; }

			public bool QuestionThree { get; set; }

			public bool QuestionFour { get; set; }

			public bool QuestionFive { get; set; }

			public bool QuestionSix { get; set; }

			public bool? QuestionSeven { get; set; }

			public bool? QuestionEight { get; set; }

			public bool? QuestionNine { get; set; }

			public int? PolicyId { get; set; }

			public decimal? AdditionalPremium { get; set; }

			public string? MedicalReportPath { get; set; }

			public string? Height { get; set; }

			public string? Weight { get; set; }
		}
}
