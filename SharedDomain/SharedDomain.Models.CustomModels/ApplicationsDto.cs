using System;

namespace SharedDomain.Models.CustomModels
{
	public class ApplicationsDto
	{
		public int iD { get; set; }

		public string nAME { get; set; }

		public string nAME2 { get; set; }

		public string sHORT_NAME { get; set; }

		public int? cAM_APP_ID { get; set; }

		public int? order { get; set; }

		public string createdBy { get; set; }

		public string modifiedBy { get; set; }

		public DateTime modificationDate { get; set; }

		public DateTime? creationDate { get; set; }

		public int com_ID { get; set; }
	}
}
