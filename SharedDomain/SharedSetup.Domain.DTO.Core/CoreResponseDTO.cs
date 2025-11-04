using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Core
{
	public class CoreResponseDTO<T> where T : class
	{
		public T data { get; set; }

		[JsonProperty("content")]
		private T content
		{
			set
			{
				data = value;
			}
		}

		public bool isError { get; set; }

		public object errorCode { get; set; }

		public object aPIVersion { get; set; }

		public string error { get; set; }

		[JsonProperty("code")]
		private object code
		{
			set
			{
				errorCode = value;
			}
		}

		[JsonProperty("message")]
		private string message
		{
			set
			{
				error = value;
				isError = !string.IsNullOrEmpty(value.ToString());
			}
		}
	}
}
