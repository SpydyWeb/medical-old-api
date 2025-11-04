using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.TP_Services
{
	public class SingeYakeenResponse : Results
	{
		public string Name { get; set; }

		public string DateOfBirth { get; set; }

		public int Gender { get; set; }
	}
}
