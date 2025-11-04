using System;

namespace SharedSetup.Domain.DTO.Core
{
	public class ResourcesDTO
	{
		public string RESOURCE_OBJECT { get; set; }

		public string RESOURCE_NAME { get; set; }

		public string RESOURCE_VALUE { get; set; }

		public string CULTURE_NAME { get; set; }

		public long? CRG_GRP_ID { get; set; }

		public long? CONTROLID { get; set; }

		public long? CAM_DOM_ID { get; set; }

		public long? OVERRIDE_BUSINESS_VISIBILITY { get; set; }

		public long? VALUE { get; set; }

		public long CRG_COM_ID { get; set; }

		public long CAM_APP_ID { get; set; }

		public DateTime MODIFICATION_DATE { get; set; }
	}
}
