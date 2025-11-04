using System.Collections.Generic;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.Authentications;
using CORE.Services;

namespace CORE.Interfaces
{
	public interface IUserManagment : ISvc
	{
		Users? GetUser(string Username, string Password);

		Users? GetUser(int Id);

		List<Users?> GetAllUsers(bool? isActive);

		List<Users?> AllLeads();

		Users? GetUserByUsername(string Username);

		Users? GetUserByEmail(string Email);

		Users? GetUserById(int Id);

		Types getTypeUser(int UserId);

		bool UpdateUserPassword(string Username, string Password);

		bool UpdateUsers(int Id, string AccessKey, bool IsBool);

		UserRoles? GetUserRoles(int UserId);

		Roles? GetRoles(int Id);

		List<RolesPages?> GetRolePages(int RoleId);

		List<Pages?> GetPages(List<int> Ids);

		List<PageRoleActions?> GetPagesRoleActions(int RoleId);

		List<Actions?> GetActions(List<int> Ids);

		List<PageActions> GetPageActions(List<int> PagesIds);

		Applications ApplicationToken(int ApplicationId, string AppName);

		List<Users> LoadTeamMembers(int Manager);

		TeamMembers LoadTeamMembersV2(int Manager);

		bool AddMembers(InsertUser obj, string bcKey, string bcIV);

		bool Update(InsertUser obj);

		Users InsertUpdateUser(Users obj);
	}
}
