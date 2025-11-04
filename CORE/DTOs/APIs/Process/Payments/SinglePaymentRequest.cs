using System;
using System.Collections.Generic;

namespace CORE.DTOs.APIs.Process.Payments
{
	public class SinglePaymentRequest
	{
		public bool IsClientEnterpise { get; set; }

		public string? RegistrationNo { get; set; }

		public string? InternalCode { get; set; }

		public DateTime IssueDate { get; set; }

		public decimal TotalAmount { get; set; }

		public List<Product> Products { get; set; }

		public bool HasValidityPeriod { get; set; }

		public string? SubBillerRegistrationNo { get; set; }

		public DateTime DueDate { get; set; }

		public DateTime ExpiryDate { get; set; }

		public string? FromDurationTime { get; set; }

		public string? ToDurationTime { get; set; }

		public Company Company { get; set; }

		public decimal SubBillerShareAmount { get; set; }

		public decimal SubBillerSharePercentage { get; set; }

		public bool ExportToSadad { get; set; }
	}
}
