namespace SharedSetup.Domain.DTO.Financial
{
	public class ExchangeRateDTO
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public decimal Exrate { get; set; }

		public int EntityId { get; set; }

		public string CurrencyCode { get; set; }

		public string EffectiveDate { get; set; }

		public string entity_name { get; set; }
	}
}
