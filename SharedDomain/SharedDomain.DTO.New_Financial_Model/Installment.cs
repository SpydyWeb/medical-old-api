using System;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class Installment
	{
		public long ID { get; set; }

		public string INSTALLMENT_SERIAL { get; set; }

		public decimal AMOUNT { get; set; }

		public DateTime DUE_DATE { get; set; }

		public string Notes { get; set; }
	}
}
