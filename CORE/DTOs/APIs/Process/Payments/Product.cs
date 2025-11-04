namespace CORE.DTOs.APIs.Process.Payments
{
	public class Product
	{
		public string ProductCode { get; set; }

		public decimal Price { get; set; }

		public decimal Qty { get; set; }

		public string TaxCode { get; set; }
	}
}
