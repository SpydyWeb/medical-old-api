using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Authentications;

namespace CORE.DTOs.APIs.Business
{
	public class TeamMembers : Results
	{
		public List<Users> Users { get; set; }

		public TeamMembers()
		{
			Users = new List<Users>();
		}
	}
}
