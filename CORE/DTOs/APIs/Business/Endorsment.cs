using System.Collections.Generic;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class Endorsment
	{
		public Production Production { get; set; }

		public List<Subjects> Members { get; set; }

		public Endorsment()
		{
			Production = new Production();
			Members = new List<Subjects>();
		}
	}
}
