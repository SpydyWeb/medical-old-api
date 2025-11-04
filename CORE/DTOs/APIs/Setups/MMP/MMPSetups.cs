using System.Collections.Generic;

namespace CORE.DTOs.APIs.Setups.MMP
{
	public class MMPSetups
	{
		public List<DDL> ddlLiability { get; set; }

		public List<DDL> ddlProffession { get; set; }

		public MMPSetups()
		{
			ddlLiability = new List<DDL>();
			ddlProffession = new List<DDL>();
		}
	}
}
