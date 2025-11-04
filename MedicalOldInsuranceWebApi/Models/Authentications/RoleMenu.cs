using System.Collections.Generic;

namespace InsuranceAPIs.Models.Authentications
{
	public class RoleMenu
	{
		public int Id { get; set; }

		public List<MasterMenu> MasterMenus { get; set; }

		public int RoleId { get; set; }
	}
}
