using SharedSetup.Domain.Enums;

namespace Domain.Models.SearchCriteria
{
	public class IndustrySectorsSearch
	{
		public long? industry { get; set; }

		public long? Id { get; set; }

		public long? sectorId { get; set; }

		public long companyId { get; set; }

		public LoadType loadType { get; set; }
	}
}
