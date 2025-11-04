namespace SharedSetup.Domain.DTO.Core
{
	public class CurrenciesDTO
	{
		public string cODE { get; set; }

		public string nAME { get; set; }

		public string nAME2 { get; set; }

		public string sIGN { get; set; }

		public string fRACTION_NAME { get; set; }

		public string fRACTION_NAME2 { get; set; }

		public string fRACTION_SIGN { get; set; }

		public decimal? fRACTION_RATE { get; set; }

		public long? dECIMAL_PLACES { get; set; }

		public string fORMAT_MASK { get; set; }

		public string fORMAT_MASK_NG { get; set; }

		public object iD { get; set; }
	}
}
