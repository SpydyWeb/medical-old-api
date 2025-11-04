namespace Domain.Models.CustomModels
{
	public class EmailConfiguration
	{
		public string From { get; set; }

		public string Password { get; set; }

		public string UserName { get; set; }

		public string SmtpServer { get; set; }

		public int Port { get; set; }

		public string ExchangeServer { get; set; }

		public bool UseSSL { get; set; }

		public bool UseStartTls { get; set; }

		public string DisplayName { get; set; }

		public string Subject { get; set; }
	}
}
