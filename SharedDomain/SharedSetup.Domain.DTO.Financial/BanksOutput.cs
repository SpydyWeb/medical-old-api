using System.Dynamic;

namespace SharedSetup.Domain.DTO.Financial
{
	public class BanksOutput
	{
		public string Name { get; set; }

		public int CompanyId { get; set; }

		public ExpandoObject Extend { get; set; }
	}
}
