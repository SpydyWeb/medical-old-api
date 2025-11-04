using System;

namespace SharedSetup.Domain.DTO.Financial
{
	public class StatementOfAccountDTO
	{
		public long CUSTOMER_ID { get; set; }

		public string CUSTOMER_SEGMENT_CODE { get; set; }

		public string CUSTOMER_NAME { get; set; }

		public string TRANSACTION_TYPE { get; set; }

		public DateTime JOURNAL_DATE { get; set; }

		public string JOURNAL_NO { get; set; }

		public long TRANSACTION_ID { get; set; }

		public string TRANSACTION_SOURCE { get; set; }

		public decimal DR_AMOUNT { get; set; }

		public decimal CR_AMOUNT { get; set; }

		public decimal DUE_AMOUNT { get; set; }

		public decimal DUE_AMOUNT_FC { get; set; }

		public decimal BALANCE { get; set; }

		public decimal CLOSE_BALANCE { get; set; }

		public decimal? DR_CR { get; set; }

		public string NOTES { get; set; }

		public decimal AMOUNT { get; set; }

		public decimal OPEN_BALANCE { get; set; }

		public long IS_INVOICE_TRANSACTION { get; set; }
	}
}
