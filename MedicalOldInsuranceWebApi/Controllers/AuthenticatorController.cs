using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using CORE.DTOs.APIs.Authenticator;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Authentications;
using CORE.DTOs.Authentications.APIs;
using CORE.Interfaces;
using InsuranceAPIs.Models.Authentications;
using InsuranceAPIs.Models.Configuration_Objects;
using MicroAPIs.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace InsuranceAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {
        private static HttpClient client = new HttpClient();

        private readonly AppSettings _appSettings;

        public static IWebHostEnvironment _environment;

        private readonly IUserManagment _svcUsers;

        private readonly ITracker _tracker;

        public AuthenticatorController(IOptions<AppSettings> appSettings, IWebHostEnvironment environment, IUserManagment svcUsers, ITracker tracker)
        {
            _environment = environment;
            _appSettings = appSettings.Value;
            _svcUsers = svcUsers;
            _tracker = tracker;
        }

        [HttpPost]
        [Route("Login")]
        public string Login([FromBody] Login login)
        {
            StringValues language = default(StringValues);
            Request.Headers.TryGetValue("Lang", out language);
            string Language = ((!string.IsNullOrEmpty(language)) ? ((string?)language) : "En");
            string Msg = "";
            LoginObj auth = new LoginObj();
            auth.Users = new Users();
            auth.Actions = new List<Actions>();
            auth.Pages = new List<Pages>();
            auth.Roles = new Roles();
            auth.PageRoleActions = new List<PageRoleActions>();
            auth.PageActions = new List<PageActions>();
            auth.RolesPages = new List<RolesPages>();
            auth.UserRoles = new UserRoles();
            auth.Employees = new List<Users>();
            try
            {
                auth.Users = _svcUsers.GetUser(login.UserName, login.Password);
                auth.Users.IsCurrentLogedIn = true;
                if (auth.Users != null && auth.Users.Id > 0)
                {
                    auth.Employees.AddRange(_svcUsers.LoadTeamMembers(auth.Users.Id));
                    auth.UserRoles = _svcUsers.GetUserRoles(auth.Users.Id);
                    if (string.IsNullOrEmpty(auth.Users.AccessKey))
                    {
                        if (_appSettings.RolesForCheck.Contains(auth.UserRoles.RoleId.ToString()))
                        {
                            auth.IsKeyNew = true;
                            string Mask = string.Empty;
                            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
                            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                            NetworkInterface[] array = nics;
                            foreach (NetworkInterface adapter in array)
                            {
                                IPInterfaceProperties properties = adapter.GetIPProperties();
                                PhysicalAddress address = adapter.GetPhysicalAddress();
                                byte[] bytes = address.GetAddressBytes();
                                for (int i = 0; i < bytes.Length; i++)
                                {
                                    Mask += bytes[i].ToString("X2");
                                    if (i != bytes.Length - 1)
                                    {
                                        Mask += "-";
                                    }
                                }
                            }
                            auth.Users.AccessKey = Mask;
                            _svcUsers.UpdateUsers(auth.Users.Id, auth.Users.AccessKey, IsBool: true);
                        }
                        else
                        {
                            auth.IsKeyNew = false;
                        }
                    }
                    UserRoles? userRoles = auth.UserRoles;
                    if (userRoles != null && userRoles.Id == 0)
                    {
                        Msg += ((Language == "En") ? " , User is not Assigned to any role " : "");
                    }
                    else
                    {
                        auth.Roles = _svcUsers.GetRoles(auth.UserRoles.RoleId);
                        Roles? roles = auth.Roles;
                        if (roles != null && roles.Id == 0)
                        {
                            Msg += ((Language == "En") ? " , User Assigned To undefined Role " : "");
                        }
                        else
                        {
                            auth.RolesPages = _svcUsers.GetRolePages(auth.UserRoles.Id);
                            if (auth.RolesPages.Count() == 0)
                            {
                                Msg += ((Language == "En") ? " , Role is not Assigned To Any Page " : "");
                            }
                            else
                            {
                                auth.Pages = _svcUsers.GetPages(auth.RolesPages.Select((RolesPages p) => p.PageId).ToList());
                                if (auth.Pages.Count() == 0)
                                {
                                    Msg += ((Language == "En") ? " , Role is assigned to undifiend Page " : "");
                                }
                                else
                                {
                                    auth.PageActions = _svcUsers.GetPageActions(auth.RolesPages.Select((RolesPages p) => p.PageId).ToList());
                                    if (auth.PageActions.Count() == 0)
                                    {
                                        Msg += ((Language == "En") ? " , Page is not assigned to any Action " : "");
                                    }
                                    else
                                    {
                                        auth.PageRoleActions = _svcUsers.GetPagesRoleActions(auth.UserRoles.Id);
                                        if (auth.PageRoleActions.Count() == 0)
                                        {
                                            Msg += ((Language == "En") ? " , Page Role and Actions is not mapped " : "");
                                        }
                                        else
                                        {
                                            auth.Actions = _svcUsers.GetActions(auth.PageRoleActions.Select((PageRoleActions x) => x.ActionTypeId).ToList());
                                            if (auth.Actions.Count() == 0)
                                            {
                                                Msg += ((Language == "En") ? " , Page and Role Assigned to undifiend Action " : "");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Response.Headers.Add("OAuthToken", Utilities.Encrypt(JsonConvert.SerializeObject(auth), _appSettings.BCKey, _appSettings.BCIV));
                    return Msg;
                }
                Response.Headers.Add("OAuthToken", "");
                return Msg + ((Language == "En") ? " Username and Password is not correct " : "");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Route("LoadUser")]
        public UserInfoAPI LoadUser([FromBody] string Username)
        {
            UserInfoAPI userInfoAPI = new UserInfoAPI();
            userInfoAPI.Users = new Users();
            userInfoAPI.httpStatusCode = (HttpStatusCode)0;
            try
            {
                userInfoAPI.Users = _svcUsers.GetUserByUsername(Username);
                if (userInfoAPI.Users != null && userInfoAPI.Users.Id > 0)
                {
                    userInfoAPI.status = true;
                    userInfoAPI.ResponseDate = DateTime.Now;
                    userInfoAPI.httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    userInfoAPI.status = false;
                    userInfoAPI.ResponseDate = DateTime.Now;
                    userInfoAPI.message = "User not Exists";
                    userInfoAPI.httpStatusCode = HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                userInfoAPI.status = false;
                userInfoAPI.ResponseDate = DateTime.Now;
                userInfoAPI.message = "Wrong Request";
                userInfoAPI.httpStatusCode = HttpStatusCode.BadRequest;
            }
            return userInfoAPI;
        }

        [HttpPost]
        [Route("LoadUserByEmail")]
        public UserInfoAPI LoadUserByEmail([FromBody] string Email)
        {
            UserInfoAPI userInfoAPI = new UserInfoAPI();
            userInfoAPI.Users = new Users();
            userInfoAPI.httpStatusCode = (HttpStatusCode)0;
            try
            {
                userInfoAPI.Users = _svcUsers.GetUserByEmail(Email);
                if (userInfoAPI.Users != null && userInfoAPI.Users.Id > 0)
                {
                    userInfoAPI.status = true;
                    userInfoAPI.ResponseDate = DateTime.Now;
                    userInfoAPI.httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    userInfoAPI.status = false;
                    userInfoAPI.ResponseDate = DateTime.Now;
                    userInfoAPI.message = "User not Exists";
                    userInfoAPI.httpStatusCode = HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                userInfoAPI.status = false;
                userInfoAPI.ResponseDate = DateTime.Now;
                userInfoAPI.message = "Wrong Request";
                userInfoAPI.httpStatusCode = HttpStatusCode.BadRequest;
            }
            return userInfoAPI;
        }

        [HttpPost]
        [Route("LoadUserById")]
        public UserInfoAPI LoadUserById([FromBody] int Id)
        {
            UserInfoAPI userInfoAPI = new UserInfoAPI();
            userInfoAPI.Users = new Users();
            userInfoAPI.httpStatusCode = (HttpStatusCode)0;
            try
            {
                userInfoAPI.Users = _svcUsers.GetUserById(Id);
                if (userInfoAPI.Users != null && userInfoAPI.Users.Id > 0)
                {
                    userInfoAPI.status = true;
                    userInfoAPI.ResponseDate = DateTime.Now;
                    userInfoAPI.httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    userInfoAPI.status = false;
                    userInfoAPI.ResponseDate = DateTime.Now;
                    userInfoAPI.message = "User not Exists";
                    userInfoAPI.httpStatusCode = HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                userInfoAPI.status = false;
                userInfoAPI.ResponseDate = DateTime.Now;
                userInfoAPI.message = "Wrong Request";
                userInfoAPI.httpStatusCode = HttpStatusCode.BadRequest;
            }
            return userInfoAPI;
        }

        [HttpPost]
        [Route("UpdatePassword")]
        public UserInfoAPI UpdatePassword([FromBody] UpdatePassword obj)
        {
            UserInfoAPI userInfoAPI = new UserInfoAPI();
            userInfoAPI.Users = new Users();
            userInfoAPI.httpStatusCode = (HttpStatusCode)0;
            try
            {
                if (_svcUsers.UpdateUserPassword(obj.Username, obj.Password))
                {
                    userInfoAPI.Users = _svcUsers.GetUserByUsername(obj.Username);
                    userInfoAPI.status = true;
                    userInfoAPI.ResponseDate = DateTime.Now;
                    userInfoAPI.httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    userInfoAPI.status = false;
                    userInfoAPI.ResponseDate = DateTime.Now;
                    userInfoAPI.message = "User not Exists";
                    userInfoAPI.httpStatusCode = HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                userInfoAPI.status = false;
                userInfoAPI.ResponseDate = DateTime.Now;
                userInfoAPI.message = "Wrong Request";
                userInfoAPI.httpStatusCode = HttpStatusCode.BadRequest;
            }
            return userInfoAPI;
        }

        [HttpPost]
        [Route("Tokenization")]
        public string Tokenization([FromBody] Tokenization obj)
        {
            if (obj == null && obj.Key == _appSettings.TokenKey)
            {
                string OAuth3 = Utilities.Encrypt(obj.ApplicationName + DateTime.Now.Year * obj.ApplicationId, _appSettings.BCKey, _appSettings.BCIV);
                Applications application = _svcUsers.ApplicationToken(obj.ApplicationId, obj.ApplicationName);
                if (application != null && application.Id > 0)
                {
                    string ApplicationTrustedToken = Utilities.Encrypt(application.Name + application.Year * application.AppId, _appSettings.BCKey, _appSettings.BCIV);
                    if (ApplicationTrustedToken.Equals(OAuth3))
                    {
                        return ApplicationTrustedToken;
                    }
                    return "..!..";
                }
                return "..!..";
            }
            return "Application Name and ID is not provided";
        }

        [HttpGet]
        [Route("AllUsers")]
        public List<Users> AllUsers()
        {
            StringValues Token = "";
            List<Users> lstUsers = new List<Users>();
            try
            {
                return _svcUsers.GetAllUsers(null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("AllLeadsUsers")]
        public List<Users> AllLeadsUsers()
        {
            try
            {
                return _svcUsers.AllLeads();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("AddUsers")]
        public CORE.DTOs.APIs.Unified_Response.Results AddUsers([FromBody] InsertUser Obj)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            bool Status = _svcUsers.AddMembers(Obj, _appSettings.BCKey, _appSettings.BCIV);
            results.ResponseDate = DateTime.Now;
            results.status = Status;
            results.httpStatusCode = (Status ? HttpStatusCode.OK : HttpStatusCode.InsufficientStorage);
            return results;
        }

        [HttpPost]
        [Route("UpdateUser")]
        public CORE.DTOs.APIs.Unified_Response.Results UpdateUSer([FromBody] InsertUser Obj)
        {
            CORE.DTOs.APIs.Unified_Response.Results results = new CORE.DTOs.APIs.Unified_Response.Results();
            bool Status = _svcUsers.Update(Obj);
            results.ResponseDate = DateTime.Now;
            results.status = Status;
            results.httpStatusCode = (Status ? HttpStatusCode.OK : HttpStatusCode.InsufficientStorage);
            return results;
        }

        [HttpPost]
        [Route("UpdateFreez")]
        public Users UpdateFreez([FromBody] Users Obj)
        {
            Obj = _svcUsers.InsertUpdateUser(Obj);
            return Obj;
        }
    }
}
