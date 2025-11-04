namespace CORE.DTOs.APIs.Process.Payments
{
	public class GenerateSadadToken
	{
		public string grant_type { get; set; }

		public string username { get; set; }

		public string password { get; set; }
	}
}
