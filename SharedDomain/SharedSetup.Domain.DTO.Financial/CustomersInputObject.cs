using System.Collections.Generic;

namespace SharedSetup.Domain.DTO.Financial
{
	public class CustomersInputObject
	{
		public CustomersInput CustomersInput { get; set; }

		public List<string> CustomerTypesDataObj { get; set; }

		public int ChartOfAccountsDataObj { get; set; }

		public List<int> AgentsDataObj { get; set; }

		public List<int> RolesDataObj { get; set; }
	}
}
