namespace SharedDomain.DTO.New_Financial_Model
{
	public class CostCenterOutput
	{
		public long ID { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public int CompanyId { get; set; }

		public int IsActive { get; set; }

		public int? BranchId { get; set; }

		public CostCenterOutputExtend Extend { get; set; }
	}
}
