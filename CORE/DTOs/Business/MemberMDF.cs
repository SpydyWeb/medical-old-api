namespace CORE.DTOs.Business
{
	public class MemberMDF
	{
		public long Id { get; set; }

		public long MemberID { get; set; }

		public long PolicyId { get; set; }

		public string Question1 { get; set; }

		public string Question2 { get; set; }

		public string Question3 { get; set; }

		public string Question4 { get; set; }

		public string Question5 { get; set; }

		public string Question6 { get; set; }

		public string? Question7 { get; set; }

		public string? Question8 { get; set; }

		public string? Question9 { get; set; }

		public int Height { get; set; }

		public int Weight { get; set; }

		public decimal BMI { get; set; }
	}
}
