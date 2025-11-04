using System.Collections.Generic;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class Policy
	{
		public Production production { get; set; }

		public List<Subjects> Members { get; set; }

		public List<Endorsment> Endors { get; set; }

		public Policy()
		{
			production = new Production();
			Members = new List<Subjects>();
			Endors = new List<Endorsment>();
		}
	}
}
