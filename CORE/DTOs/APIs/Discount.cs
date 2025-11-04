using System;

namespace CORE.DTOs.APIs
{
	public class Discount
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int ApplyOn { get; set; }

		public decimal DiscountPercent { get; set; }

		public decimal DiscountPercentC { get; set; }

		public decimal DiscountPercentCPlus { get; set; }

		public decimal DiscountPercentCBasic { get; set; }

		public DateTime ExpiryDate { get; set; }

		public decimal EndorsementDiscount { get; set; }

		public DateTime EndExpiryDate { get; set; }
	}
}
