using System;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class ExchangeRateOutput
	{
		public long ID { get; set; }

		public decimal Exrate { get; set; }

		public DateTime? EfectiveDate { get; set; }

		public string CurrencyCode { get; set; }

		public int CompanyId { get; set; }

		public string CreatedBy { get; set; }

		public DateTime? CreatedDate { get; set; }

		public long? BranchId { get; set; }

		public string ModifiedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }

		public DateTime? EffectiveDate { get; set; }

		public string Name { get; set; }

		public string CompanyName { get; set; }

		public ExchangeRateOutputExtend Extend { get; set; }
	}
}
