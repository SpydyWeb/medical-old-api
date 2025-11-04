using System.Collections.Generic;

namespace InsuranceAPIs.Models
{
	public class MasterMenu
	{
		public string Name { get; set; }

		public int Id { get; set; }

		public List<SubMenu> subMenus { get; set; }
	}
}
