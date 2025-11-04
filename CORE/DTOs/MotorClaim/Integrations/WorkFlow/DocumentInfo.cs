namespace CORE.DTOs.MotorClaim.WorkFlow
{
	public class DocumentInfo
	{
		public int Id { get; set; }

		public int ModuleId { get; set; }

		public string Name { get; set; }

		public bool IsRequired { get; set; }

		public string? CreatedBy { get; set; }

		public string? ModifiedBy { get; set; }
	}
}
