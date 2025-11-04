using System.Dynamic;

namespace SharedSetup.Domain.DTO.Financial
{
	public class CustomersTypeOutput
	{
		public int ID { get; set; }

		public int? CompanyId { get; set; }

		public string Code { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public ExpandoObject Extend { get; set; }
	}
}
