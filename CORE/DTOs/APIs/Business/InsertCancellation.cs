namespace CORE.DTOs.APIs.Business
{
	public class InsertCancellation
	{
		public int PolicyId { get; set; }

		public int MemberId { get; set; }

		public int Cancellation { get; set; }

		public string CreatedBy { get; set; }

		public string Attachments { get; set; }
	}
}
