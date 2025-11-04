using System;

namespace CORE.DTOs.NextCare
{
	public class Directdebitinformation
	{
		public string accountHolderName { get; set; }

		public string accountNumber { get; set; }

		public int bankId { get; set; }

		public int branchId { get; set; }

		public string iban { get; set; }

		public string bic { get; set; }

		public string mandateReferenceNumber { get; set; }

		public DateTime mandateDate { get; set; }

		public int transferDirection { get; set; }

		public bool defaultPayment { get; set; }

		public int userId { get; set; }
	}
}
