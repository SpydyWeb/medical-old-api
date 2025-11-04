using System;

namespace CORE.DTOs.APIs.Process.Payments
{
	public class PaymentLog
	{
		public int Id { get; set; }

		public DateTime TransactionDate { get; set; }

		public bool Status { get; set; }

		public int PolicyId { get; set; }

		public string? CustomerEmail { get; set; }

		public int TransactionType { get; set; }

		public string? MerchantReference { get; set; }

		public string? PayfortId { get; set; }

		public string? PayfortStatus { get; set; }

		public string? CardDetails { get; set; }

		public string? CardType { get; set; }

		public string? BankAttachment { get; set; }
		public string PolicyNo { get; set; }
		public string ProductName { get; set; }
	}
}
