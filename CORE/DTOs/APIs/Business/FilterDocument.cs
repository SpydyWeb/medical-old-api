namespace CORE.DTOs.APIs.Business
{
	public class FilterDocument
	{
		public string? DocumentNo { get; set; }

		public int? Id { get; set; }

		public int? DocumentType { get; set; }

        public int? CustomerId { get; set; }
    }
}
