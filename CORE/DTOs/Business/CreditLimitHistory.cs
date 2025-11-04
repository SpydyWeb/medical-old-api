using System;

namespace CORE.DTOs.Business
{
	public class CreditLimitHistory
	{
		public long Id { get; set; }

		public long EskaId { get; set; }

		public decimal CreditLimit { get; set; }

		public decimal Balance { get; set; }

		public DateTime? LastPaymentDate { get; set; }

		public decimal ExtendLimit { get; set; }

		public int FinanceId { get; set; }

		public int CreditLimitID { get; set; }
	}
}
