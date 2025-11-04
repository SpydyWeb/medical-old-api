using System.Collections.Generic;
using CORE.DTOs.Authentications;

namespace CORE.DTOs.APIs.Authenticator
{
	public class LoginObj
	{
		public bool IsKeyNew { get; set; } = false;


		public Users? Users { get; set; }

		public Roles? Roles { get; set; }

		public UserRoles? UserRoles { get; set; }

		public List<RolesPages?> RolesPages { get; set; }

		public List<PageRoleActions?> PageRoleActions { get; set; }

		public List<Actions?> Actions { get; set; }

		public List<Pages?> Pages { get; set; }

		public List<PageActions?> PageActions { get; set; }

		public List<Users> Employees { get; set; }
	}
}
