namespace CORE.DTOs.MotorClaim.Claims
{
	public class AuthorityMatrix
	{
		public int Id { get; set; }

		public int ModuleId { get; set; }

		public int MinLimit { get; set; }

		public int MaxLimit { get; set; }

		public int? RoleId { get; set; }

		public int? UserId { get; set; }
	}
}
