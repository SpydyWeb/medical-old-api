namespace CORE.DTOs.NextCare
{
	public class Endorsement
	{
		public int endoType { get; set; }

		public string reference { get; set; }

		public Principal[] principals { get; set; }
	}
}
