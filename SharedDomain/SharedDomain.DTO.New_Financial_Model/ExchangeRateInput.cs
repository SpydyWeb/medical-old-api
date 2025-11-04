using System;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class ExchangeRateInput
	{
		public long? ID { get; set; }

		public int CompanyId { get; set; }

		public string CurrencyCode { get; set; }

		public DateTime? FromDate { get; set; }

		public DateTime? ToDate { get; set; }
	}
}
