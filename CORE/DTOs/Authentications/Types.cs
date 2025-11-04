namespace CORE.DTOs.Authentications
{
	public class Types
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int MedicalId { get; set; }

		public int GeneralId { get; set; }

		public int TravelId { get; set; }

		public decimal? Commission { get; set; }

		public int? ChartOfAccount { get; set; }

		public int? BusinessType { get; set; }
        public int? UserBusinessType { get; set; }
    }
}
