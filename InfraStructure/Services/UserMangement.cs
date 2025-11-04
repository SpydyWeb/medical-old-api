using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.Authentications;
using CORE.DTOs.Business;
using CORE.Interfaces;
using CORE.Services;
using DataAccessLayer;
using InsuranceAPIs.Logger;
using MicroAPIs.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;

namespace InfraStructure.Services
{
	public class UserMangement : Svc, IUserManagment, ISvc
	{
		public UserMangement(IUnitOfWork unitOfWork, IServiceScopeFactory factory)
			: base(unitOfWork)
		{
		}

		public UserTypes? GetUserTypes(int Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				UserTypes result = new UserTypes();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<UserTypes>().AsQueryable()
						where p.Id == Id
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public List<RolesPages?> GetRoleMenu(int RoleId)
		{
			return Action(delegate(DataBaseContext context)
			{
				List<RolesPages> result = new List<RolesPages>();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<RolesPages>().AsQueryable()
						where p.RoleId == RoleId
						select p).ToList();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public Pages? GetMasterMenu(int Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				Pages result = new Pages();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Pages>().AsQueryable()
						where p.Id == Id
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public List<SubMenu?> GetSubMenu(int MasterId)
		{
			return Action(delegate(DataBaseContext context)
			{
				List<SubMenu> result = new List<SubMenu>();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<SubMenu>().AsQueryable()
						where p.MasterId == MasterId
						select p).ToList();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public Users? GetUser(string Username, string Password)
		{
			string Username2 = Username;
			string Password2 = Password;
			return Action(delegate(DataBaseContext context)
			{
				Users result = new Users();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where p.UserName.Trim().ToUpper() == Username2.Trim().ToUpper() && p.Password.Trim() == Password2
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public bool AddMembers(InsertUser obj, string bcKey, string bcIV)
		{
			InsertUser obj2 = obj;
			return Action(delegate(DataBaseContext context)
			{
				Users users = new Users();
				users.CreationDate = DateTime.Now;
				users.Email = obj2.Email;
				users.EskaId = obj2.EskaId;
				users.IsActive = true;
				users.LastPasswordChange = DateTime.Now;
				users.IsOneTimePassword = true;
				users.LastPasswordChange = DateTime.Now;
				users.Password = Utilities.Encrypt(obj2.Password, bcKey, bcIV);
				users.UserName = obj2.Username;
				users.Mobile = obj2.Mobile.ToString();
				users.AllowCredit = obj2.IsAllow;
				users.ManagerId = obj2.TeamLeader;
				try
				{
					((DbContext)(object)context).Set<Users>().Add(users);
					((DbContext)(object)context).SaveChanges();
					unitOfWork.SetToBeCommitted();
					UserRoles entity = new UserRoles
					{
						RoleId = obj2.RoleId,
						UserId = users.Id
					};
					((DbContext)(object)context).Set<UserRoles>().Add(entity);
					UserTypes entity2 = new UserTypes
					{
						UserId = users.Id,
						TypeId = obj2.Type
					};
					((DbContext)(object)context).Set<UserTypes>().Add(entity2);
					((DbContext)(object)context).SaveChanges();
					unitOfWork.SetToBeCommitted();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public bool Update(Users obj)
		{
			Users obj2 = obj;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					((DbContext)(object)context).Set<Users>().Update(obj2);
					((DbContext)(object)context).SaveChanges();
					unitOfWork.SetToBeCommitted();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public List<Users> LoadTeamMembers(int Manager)
		{
			List<Users> team = new List<Users>();
			List<Users> team2 = new List<Users>();
			return Action(delegate(DataBaseContext context)
			{
				DataBaseContext context2 = context;
				try
				{
					List<Users> list = (from p in ((DbContext)(object)context2).Set<Users>()
						where p.ManagerId == (int?)Manager
						orderby p.Id descending
						select p).ToList();
					if (list != null && list.Count > 0)
					{
						team.AddRange(list);
					}
					list.ForEach(delegate(Users supervisor)
					{
						List<Users> list2 = (from p in ((DbContext)(object)context2).Set<Users>()
							where p.ManagerId == (int?)supervisor.Id
							orderby p.Id descending
							select p).ToList();
						if (list2 != null && list2.Count > 0)
						{
							team.AddRange(list2);
						}
						list2.ForEach(delegate(Users secondLevel)
						{
							List<Users> list3 = (from p in ((DbContext)(object)context2).Set<Users>()
								where p.ManagerId == (int?)secondLevel.Id
								orderby p.Id descending
								select p).ToList();
							if (list3 != null && list3.Count > 0)
							{
								team.AddRange(list3);
							}
							list3.ForEach(delegate(Users thiredLevel)
							{
								List<Users> list4 = (from p in ((DbContext)(object)context2).Set<Users>()
									where p.ManagerId == (int?)thiredLevel.Id
									orderby p.Id descending
									select p).ToList();
								if (list4 != null && list4.Count > 0)
								{
									team.AddRange(list4);
								}
								list4.ForEach(delegate(Users fourthLvl)
								{
									List<Users> list5 = (from p in ((DbContext)(object)context2).Set<Users>()
										where p.ManagerId == (int?)fourthLvl.Id
										orderby p.Id descending
										select p).ToList();
									if (list5 != null && list5.Count > 0)
									{
										team.AddRange(list5);
									}
									list5.ForEach(delegate(Users fifthLvl)
									{
										List<Users> list6 = (from p in ((DbContext)(object)context2).Set<Users>()
											where p.ManagerId == (int?)fifthLvl.Id
											orderby p.Id descending
											select p).ToList();
										if (list6 != null && list6.Count > 0)
										{
											team.AddRange(list6);
										}
										list6.ForEach(delegate(Users sixthLvl)
										{
											List<Users> list7 = (from p in ((DbContext)(object)context2).Set<Users>()
												where p.ManagerId == (int?)sixthLvl.Id
												orderby p.Id descending
												select p).ToList();
											if (list7 != null && list7.Count > 0)
											{
												team.AddRange(list7);
											}
										});
									});
								});
							});
						});
					});
					return (team.Count > 0) ? team.OrderBy((Users p) => p.UserName).ToList() : team;
				}
				catch (Exception)
				{
					return (List<Users>)null;
				}
			});
		}

		private List<Users> GetTeamMembers(int Manager)
		{
			List<Users> team = new List<Users>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					List<Users> list = (from p in ((DbContext)(object)context).Set<Users>()
						where p.ManagerId == (int?)Manager
						orderby p.Id descending
						select p).ToList();
					if (list != null && list.Count > 0)
					{
						team.AddRange(list);
					}
					return team;
				}
				catch (Exception)
				{
					return (List<Users>)null;
				}
			});
		}

		public TeamMembers LoadTeamMembersV2(int Manager)
		{
			TeamMembers teamMembers = new TeamMembers();
			teamMembers.Users = new List<Users>();
			return Action(delegate(DataBaseContext context)
			{
				DataBaseContext context2 = context;
				try
				{
					List<MangementUsers> list = (from p in ((DbContext)(object)context2).Set<MangementUsers>()
						where p.UserManagerId == Manager
						select p).ToList();
					list.ForEach(delegate(MangementUsers EskaId)
					{
						List<Users> collection = (from p in ((DbContext)(object)context2).Set<Users>()
							where p.EskaId == (long?)(long)EskaId.EskaUserId
							select p).ToList();
						teamMembers.Users.AddRange(collection);
					});
					if (teamMembers.Users != null && teamMembers.Users.Count > 0)
					{
						teamMembers.httpStatusCode = HttpStatusCode.OK;
						teamMembers.status = true;
						teamMembers.ResponseDate = DateTime.Now;
						teamMembers.message = "";
					}
					else
					{
						teamMembers.httpStatusCode = HttpStatusCode.NoContent;
						teamMembers.status = false;
						teamMembers.ResponseDate = DateTime.Now;
						teamMembers.message = "No Content Available";
					}
					return teamMembers;
				}
				catch (Exception)
				{
					return (TeamMembers)null;
				}
			});
		}

		public Users? GetUser(int Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				Users result = new Users();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where p.Id == Id
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public List<Users?> AllLeads()
		{
			return Action(delegate(DataBaseContext context)
			{
				List<Users> result = new List<Users>();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where p.AllowCredit == (bool?)true
						select p).ToList();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public Types getTypeUser(int UserId)
		{
			return Action(delegate(DataBaseContext context)
			{
				Types types = new Types();
				try
				{
					UserTypes UserType = (from p in ((DbContext)(object)context).Set<UserTypes>()
						where p.UserId == UserId
						select p).FirstOrDefault();
					return (from p in ((DbContext)(object)context).Set<Types>().AsQueryable()
						where p.Id == UserType.TypeId
						select p).FirstOrDefault();
				}
				catch (Exception)
				{
					return (Types)null;
				}
			});
		}

		public List<Users?> GetAllUsers(bool? isActive)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					return (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where ((bool?)isActive).HasValue ? ((bool?)p.IsActive == isActive) : (p.IsActive == p.IsActive)
					select p).ToList();
				}
				catch (Exception ex)
				{
                    ErrorHandler.APIWriteError(ex, "GetAllUsers", "", "");
                    return (List<Users>)null;
				}
			});
		}

		public Users? GetUserByUsername(string Username)
		{
			string Username2 = Username;
			return Action(delegate(DataBaseContext context)
			{
				Users result = new Users();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where p.UserName.Trim().ToUpper() == Username2.Trim().ToUpper()
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public Users? GetUserByEmail(string Email)
		{
			string Email2 = Email;
			return Action(delegate(DataBaseContext context)
			{
				Users result = new Users();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where p.Email.Trim().ToUpper() == Email2.Trim().ToUpper()
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public Users? GetUserById(int Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				Users result = new Users();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where p.Id == Id
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public bool UpdateUserPassword(string Username, string Password)
		{
			string Username2 = Username;
			string Password2 = Password;
			return Action(delegate(DataBaseContext context)
			{
				Users users = new Users();
				try
				{
					users = (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where p.UserName.Trim().ToUpper() == Username2.Trim().ToUpper()
						select p).FirstOrDefault();
					users.Password = Password2;
					users.LastPasswordChange = DateTime.Now;
					users.IsOneTimePassword = false;
					((DbContext)(object)context).Set<Users>().Update(users);
					((DbContext)(object)context).SaveChanges();
					unitOfWork.Commit();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public bool UpdateUsers(int Id, string AccessKey, bool IsBool)
		{
			string AccessKey2 = AccessKey;
			return Action(delegate(DataBaseContext context)
			{
				Users users = new Users();
				try
				{
					users = (from p in ((DbContext)(object)context).Set<Users>().AsQueryable()
						where p.Id == Id
						select p).FirstOrDefault();
					users.IsCurrentLogedIn = IsBool;
					if (!string.IsNullOrEmpty(users.AccessKey))
					{
						users.AccessKey = AccessKey2;
					}
					((DbContext)(object)context).Set<Users>().Update(users);
					((DbContext)(object)context).SaveChanges();
					unitOfWork.Commit();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public UserRoles? GetUserRoles(int UserId)
		{
			return Action(delegate(DataBaseContext context)
			{
				UserRoles result = new UserRoles();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<UserRoles>().AsQueryable()
						where p.UserId == UserId
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public Roles? GetRoles(int Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				Roles result = new Roles();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Roles>().AsQueryable()
						where p.Id == Id
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public List<RolesPages?> GetRolePages(int RoleId)
		{
			return Action(delegate(DataBaseContext context)
			{
				List<RolesPages> result = new List<RolesPages>();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<RolesPages>().AsQueryable()
						where p.RoleId == RoleId
						select p).ToList();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public List<Pages?> GetPages(List<int> Ids)
		{
			List<int> Ids2 = Ids;
			return Action(delegate(DataBaseContext context)
			{
				DataBaseContext context2 = context;
				List<Pages?> lstPages = new List<Pages>();
				try
				{
					Ids2.ForEach(delegate(int id)
					{
						Pages pages = new Pages();
						pages = (from p in ((DbContext)(object)context2).Set<Pages>().AsQueryable()
							where p.Id == id
							select p).FirstOrDefault();
						lstPages.Add(pages);
					});
					return lstPages;
				}
				catch (Exception)
				{
					return lstPages;
				}
			});
		}

		public List<PageRoleActions?> GetPagesRoleActions(int RoleId)
		{
			return Action(delegate(DataBaseContext context)
			{
				List<PageRoleActions> result = new List<PageRoleActions>();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<PageRoleActions>().AsQueryable()
						where p.RoleId == RoleId
						select p).ToList();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public List<Actions?> GetActions(List<int> Ids)
		{
			List<int> Ids2 = Ids;
			return Action(delegate(DataBaseContext context)
			{
				DataBaseContext context2 = context;
				List<Actions?> lsActions = new List<Actions>();
				try
				{
					Ids2.ForEach(delegate(int id)
					{
						Actions actions = new Actions();
						actions = (from p in ((DbContext)(object)context2).Set<Actions>().AsQueryable()
							where p.Id == id
							select p).FirstOrDefault();
						lsActions.Add(actions);
					});
					return lsActions;
				}
				catch (Exception)
				{
					return lsActions;
				}
			});
		}

		public List<PageActions> GetPageActions(List<int> PagesIds)
		{
			List<int> PagesIds2 = PagesIds;
			return Action(delegate(DataBaseContext context)
			{
				DataBaseContext context2 = context;
				List<PageActions> lsActionPages = new List<PageActions>();
				try
				{
					PagesIds2.ForEach(delegate(int id)
					{
						PageActions pageActions = new PageActions();
						pageActions = (from p in ((DbContext)(object)context2).Set<PageActions>().AsQueryable()
							where p.PageId == id
							select p).FirstOrDefault();
						lsActionPages.Add(pageActions);
					});
					return lsActionPages;
				}
				catch (Exception)
				{
					return lsActionPages;
				}
			});
		}

		public Applications ApplicationToken(int ApplicationId, string AppName)
		{
			string AppName2 = AppName;
			return Action(delegate(DataBaseContext context)
			{
				Applications result = new Applications();
				try
				{
					result = (from p in ((DbContext)(object)context).Set<Applications>().AsQueryable()
						where p.AppId == ApplicationId && p.Name == AppName2
						select p).FirstOrDefault();
					return result;
				}
				catch (Exception)
				{
					return result;
				}
			});
		}

		public bool Update(InsertUser obj)
		{
			InsertUser obj2 = obj;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					bool flag = false;
					Users policy = (from x in ((DbContext)(object)context).Set<Users>()
						where x.UserName == obj2.Username
						select x).FirstOrDefault();
					((DbContext)(object)context).SaveChanges();
					policy.Email = obj2.Email;
					policy.Mobile = obj2.Mobile.ToString();
					policy.IsActive = (obj2.status.HasValue ? obj2.status.Value : policy.IsActive);
					policy.AllowCredit = (obj2.IsAllow.HasValue ? new bool?(obj2.IsAllow.Value) : policy.AllowCredit);
					policy.FailedAttempt = (obj2.FailledAttemp.HasValue ? obj2.FailledAttemp : new int?(0));
					policy.ManagerId = (obj2.TeamLeader.HasValue ? obj2.TeamLeader : policy.ManagerId);
					if (!string.IsNullOrEmpty(obj2.Password) && obj2.Password != "0")
					{
						policy.Password = obj2.Password;
					}
					((DbContext)(object)context).Set<Users>().Update(policy);
					((DbContext)(object)context).SaveChanges();
					UserTypes userTypes = (from x in ((DbContext)(object)context).Set<UserTypes>()
						where x.UserId == policy.Id
						select x).FirstOrDefault();
					((DbContext)(object)context).SaveChanges();
					if (userTypes != null && userTypes.TypeId != obj2.Type && obj2.Type != 0)
					{
						userTypes.TypeId = obj2.Type;
						((DbContext)(object)context).Set<UserTypes>().Update(userTypes);
						((DbContext)(object)context).SaveChanges();
					}
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public Users InsertUpdateUser(Users obj)
		{
			Users obj2 = obj;
			Action(delegate(DataBaseContext context)
			{
				if (obj2.Id > 0)
				{
					((DbContext)(object)context).Set<Users>().Update(obj2);
					((DbContext)(object)context).SaveChanges();
				}
				else
				{
					((DbContext)(object)context).Set<Users>().Add(obj2);
					((DbContext)(object)context).SaveChanges();
				}
			});
			return obj2;
		}
	}
}
