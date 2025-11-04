namespace Domain.Models.SearchCriteria
{
	public class SstSubBranchesSearchCriteria
	{
		public long CompanyId { get; set; }

		public long? SystemId { get; set; }

		public string Code { get; set; }

		public short? TypeOfBusiness { get; set; }

		public long? BranchId { get; set; }

		public long? SubBranchId { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }
	}
}
