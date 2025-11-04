using System;

namespace SharedSetup.Domain.DTO.Core
{
	public class FavoriteMenuDTO
	{
		public string uRL { get; set; }

		public int? uSER_DEFAULT_PAGE_SMU_ID { get; set; }

		public int? uSER_DEFAULT_PAGE_APP_ID { get; set; }

		public bool iS_FAVORITE { get; set; }

		public int? iD { get; set; }

		public int? cAM_APP_ID { get; set; }

		public DateTime mODIFICATION_DATE { get; set; }

		public string nAME { get; set; }

		public string uSERNAME { get; set; }

		public int? cAM_SMU_ID { get; set; }

		public string cUSTOM_NAME { get; set; }
	}
}
