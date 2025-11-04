namespace CORE.DTOs.Business
{
	public class MangementUsers
	{
		public long Id { get; set; }

		public int UserManagerId { get; set; }

		public int EskaUserId { get; set; }

		public int CreationDate { get; set; }

		public int CreatedBy { get; set; }

		public int? ModifiedDate { get; set; }

		public int? ModifiedBy { get; set; }
	}
}
