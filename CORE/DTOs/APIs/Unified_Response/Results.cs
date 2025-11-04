using System;
using System.Net;

namespace CORE.DTOs.APIs.Unified_Response
{
	public class Results
	{
		public bool status { get; set; }

		public string message { get; set; }

		public DateTime ResponseDate { get; set; }

		public HttpStatusCode httpStatusCode { get; set; }
	}
}
