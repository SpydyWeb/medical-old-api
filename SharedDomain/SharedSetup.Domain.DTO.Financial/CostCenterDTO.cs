namespace SharedSetup.Domain.DTO.Financial
{
	public class CostCenterDTO
	{
		public int ID { get; set; }

		public string NAME { get; set; }

		public string NAME2 { get; set; }

		public int COMPANYID { get; set; }

		public int ISACTIVE { get; set; }

		public Extend EXTEND { get; set; }
	}
}
