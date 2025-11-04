using System.Collections.Generic;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class TRANSDETAIL
	{
		public long? DR_CR { get; set; }

		public string Notes { get; set; }

		public decimal Amount { get; set; }

		public decimal AmountLC { get; set; }

		public int TAX_PERCENTAGE { get; set; }

		public object CustomerId { get; set; }

		public long? Account_ID { get; set; }

		public object COST_CENTER_ID { get; set; }

		public int? PAYMENT_METHOD { get; set; }

		public List<Installment> Installments { get; set; }

		public List<INSAGENT> INS_AGENTS { get; set; }
	}
}
