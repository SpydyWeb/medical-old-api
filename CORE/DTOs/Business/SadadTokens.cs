using System;

namespace CORE.DTOs.Business
{
	public class SadadTokens
	{
		public int Id { get; set; }

		public string? Token { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? ExpiryDate { get; set; }

		public string? Error { get; set; }

		public int? ValidationPeriod { get; set; }
	}
}
