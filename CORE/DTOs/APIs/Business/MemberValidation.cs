using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class MemberValidation
	{
		public Subjects members { get; set; }

		public string? Error { get; set; }
	}
}
