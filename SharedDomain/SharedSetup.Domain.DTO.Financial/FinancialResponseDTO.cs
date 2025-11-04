namespace SharedSetup.Domain.DTO.Financial
{
	public class FinancialResponseDTO<T> where T : class
	{
		public T Data { get; set; }

		public string ErrorMessage { get; set; }

		public string TotalRecords { get; set; }

		public string ErrorCode { get; set; }

		public string StackTrace { get; set; }

		public bool IsError { get; set; }
	}
}
