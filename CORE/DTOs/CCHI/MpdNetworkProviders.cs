namespace CORE.DTOs.CCHI
{
	public class MpdNetworkProviders
	{
		public int? Id { get; set; }

		public long MntPrvNetId { get; set; }

		public int MntNetId { get; set; }

		public string MntPrvNetName { get; set; }

		public int MntPrvNetCategoryId { get; set; }

		public string MntPrvNetCategoryName { get; set; }

		public string Status { get; set; }
	}
}
