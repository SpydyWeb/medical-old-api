namespace SharedDomain.Models.SearchCriteria
{
	public class SstCommissionStructureSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public short? Category { get; set; }

		public long? CommStructureId { get; set; }

		public string Name { get; set; }

		public string Categories { get; set; }

		public short BusinessType { get; set; }

		public short? ClassId { get; set; }

		public short? PolicyType { get; set; }

		public byte? AutoAdd { get; set; }

		public int PageNo { get; set; }

		public int? PageSize { get; set; }
	}
}
