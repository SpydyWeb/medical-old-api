using CORE.DTOs.MotorClaim.Claims;

namespace CORE.DTOs.MotorClaim.Integrations.APIs
{
	public class SearchLookUp
	{
		public int? Id { get; set; }

		public string? Name { get; set; }

		public SystemEnums? MajorCode { get; set; }

		public int? ParentId { get; set; }

		public DomainForCalim? domainForCalim { get; set; }
	}
}
