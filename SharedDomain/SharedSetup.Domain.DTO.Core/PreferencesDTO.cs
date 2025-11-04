namespace SharedSetup.Domain.DTO.Core
{
	public class PreferencesDTO
	{
		public long DO_CONTROLS_SCAN { get; set; }

		public string LOGOUT_URL { get; set; }

		public string HOME_PAGE_URL { get; set; }

		public int IS_DEFAULT_ORDER { get; set; }

		public string LOGIN_IMAGE_URL { get; set; }

		public string IS_PASSWORD_ENCRYPT_ON_CLIENT { get; set; }
	}
}
