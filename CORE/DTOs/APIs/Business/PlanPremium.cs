namespace CORE.DTOs.APIs.Business
{
	public class PlanPremium
	{
		public int Id { get; set; }

		public int AgeFrom { get; set; }

		public int AgeTo { get; set; }

		public int? MaritalStatus { get; set; }

		public int? Gender { get; set; }

		public int? Relation { get; set; }

		public decimal Gross { get; set; }

		public decimal Net { get; set; }

		public decimal Loading { get; set; }

		public int ClassId { get; set; }
	}
}
