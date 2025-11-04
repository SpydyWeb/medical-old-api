using System;

namespace SharedSetup.Domain.DTO.Core
{
	public class SystemDTO
	{
		public string cODE { get; set; }

		public string nAME { get; set; }

		public string nAME2 { get; set; }

		public string sHORT_NAME { get; set; }

		public string dESTINATION { get; set; }

		public object cAM_APP_ID { get; set; }

		public object order { get; set; }

		public object createdBy { get; set; }

		public object modifiedBy { get; set; }

		public DateTime modificationDate { get; set; }

		public DateTime creationDate { get; set; }
	}
}
