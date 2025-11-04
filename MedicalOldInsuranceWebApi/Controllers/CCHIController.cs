using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using CORE.DTOs.CCHI;
using CORE.Interfaces;
using DataAccessLayer.Oracle.Eskadenia.CCHI;
using InsuranceAPIs.Models.Configuration_Objects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;

namespace InsuranceAPIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CCHIController : ControllerBase
	{
		private static HttpClient client = new HttpClient();

		private readonly AppSettings _appSettings;

		public static IWebHostEnvironment? _environment;

		private readonly IBusiness _svcBusiness;

		private readonly ITracker _tracker;

		private readonly IProcess _process;

		public CCHIController(IOptions<AppSettings> appSettings, IWebHostEnvironment environment, IBusiness svcBus, ITracker tracker, IProcess process)
		{
			_environment = environment;
			_appSettings = appSettings.Value;
			_svcBusiness = svcBus;
			_tracker = tracker;
			_process = process;
		}

		[HttpPost]
		[Route("LoadProvidersByNetworkId")]
		public List<MpdNetworkProviders> LoadProvidersByNetworkId([FromBody] NetworkSearch networkSearch)
		{
			List<MpdNetworkProviders> networkProviders = new List<MpdNetworkProviders>();
			try
			{
				networkProviders = CCHIPortal.LoadProvidersByNetworkId(networkSearch.NetworkID, _appSettings.EskaConnection);
			}
			catch (Exception)
			{
			}
			return networkProviders;
		}

		[HttpPost]
		[Route("GetPolicies")]
		public List<Searchable> GetPolicies(Searchable Name)
		{
			List<Searchable> networks = new List<Searchable>();
			using OracleConnection objConn = new OracleConnection(_appSettings.EskaConnection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IMEDICAL.DBPKG_CCHI_ESKA_QUERY.DBP_GET_Policies";
				objCmd.Parameters.Add("P_SEGMENT", OracleDbType.Varchar2).Value = Name.Name.ToUpper();
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						networks.Add(new Searchable
						{
							ID = reader["ID"].ToString(),
							Name = reader["SEGMENT_CODE"].ToString()
						});
					}
				}
				objConn.Close();
				return networks;
			}
			catch (Exception)
			{
				return networks;
			}
		}

		[HttpPost]
		[Route("GetCustomers")]
		public List<Searchable> GetCustomers(Searchable Name)
		{
			List<Searchable> networks = new List<Searchable>();
			using OracleConnection objConn = new OracleConnection(_appSettings.EskaConnection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IMEDICAL.DBPKG_CCHI_ESKA_QUERY.DBP_GET_CUSTOMERS";
				objCmd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = Name.Name.ToUpper();
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						networks.Add(new Searchable
						{
							ID = reader["ID"].ToString(),
							SegmentCode = reader["SEGMENT_CODE"].ToString(),
							Name = reader["NAME"].ToString()
						});
					}
				}
				objConn.Close();
				return networks;
			}
			catch (Exception)
			{
				return networks;
			}
		}

		[HttpPost]
		[Route("GetMembers")]
		public List<Searchable> GetMembers(Searchable Name)
		{
			List<Searchable> networks = new List<Searchable>();
			using OracleConnection objConn = new OracleConnection(_appSettings.EskaConnection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IMEDICAL.DBPKG_CCHI_ESKA_QUERY.DBP_GET_MEMBERS";
				objCmd.Parameters.Add("P_MEMBER_NO", OracleDbType.Varchar2).Value = Name.Name.ToUpper();
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						networks.Add(new Searchable
						{
							ID = reader["ID"].ToString(),
							SegmentCode = reader["MEMBER_NO"].ToString(),
							Name = reader["NAME"].ToString()
						});
					}
				}
				objConn.Close();
				return networks;
			}
			catch (Exception)
			{
				return networks;
			}
		}

		[HttpPost]
		[Route("GetPlans")]
		public List<Searchable> GetPlans(Searchable Name)
		{
			List<Searchable> networks = new List<Searchable>();
			using OracleConnection objConn = new OracleConnection(_appSettings.EskaConnection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IMEDICAL.DBPKG_CCHI_ESKA_QUERY.DBP_GET_PLANS";
				objCmd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = Name.Name.ToUpper();
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						networks.Add(new Searchable
						{
							ID = reader["ID"].ToString(),
							Name = reader["NAME"].ToString()
						});
					}
				}
				objConn.Close();
				return networks;
			}
			catch (Exception)
			{
				return networks;
			}
		}

		[HttpPost]
		[Route("LoadSpecialists")]
		public List<Searchable> LoadSpecialists()
		{
			List<Searchable> networks = new List<Searchable>();
			using OracleConnection objConn = new OracleConnection(_appSettings.EskaConnection);
			try
			{
				string Name = string.Empty;
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IMEDICAL.DBPKG_SETUP_SUG.DBP_LOAD_ALL_SPECIALISTS";
				objCmd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = Name;
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						networks.Add(new Searchable
						{
							ID = reader["ID"].ToString(),
							Name = reader["Name"].ToString()
						});
					}
				}
				objConn.Close();
				return networks;
			}
			catch (Exception)
			{
				return networks;
			}
		}

		[HttpPost]
		[Route("UpdateCCHIEndorsment")]
		public bool UpdateCCHIEndorsment(Searchable Name)
		{
			using OracleConnection objConn = new OracleConnection(_appSettings.EskaConnection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IMEDICAL.DBPKG_CCHI_ESKA_QUERY.UpdateCCHIEndorsment";
				objCmd.Parameters.Add("P_ID", OracleDbType.Varchar2).Value = Name.ID;
				objCmd.Parameters.Add("P_Occupation", OracleDbType.Varchar2).Value = ((!string.IsNullOrEmpty(Name.Occupation)) ? ((IConvertible)Name.Occupation) : ((IConvertible)DBNull.Value));
				objCmd.Parameters.Add("P_Nationality", OracleDbType.Varchar2).Value = ((!string.IsNullOrEmpty(Name.Nationality)) ? ((IConvertible)Name.Nationality) : ((IConvertible)DBNull.Value));
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				objCmd.ExecuteNonQuery();
				objConn.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[HttpPost]
		[Route("GetNationalities")]
		public List<Searchable> GetNationalities(Searchable Name)
		{
			List<Searchable> networks = new List<Searchable>();
			using OracleConnection objConn = new OracleConnection(_appSettings.EskaConnection);
			try
			{
				OracleCommand objCmd = new OracleCommand();
				objCmd.Connection = objConn;
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "IMEDICAL.DBPKG_CCHI_ESKA_QUERY.GET_Nationalities";
				objCmd.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				objConn.Open();
				OracleDataReader reader = objCmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						networks.Add(new Searchable
						{
							ID = reader["ID"].ToString(),
							Name = reader["NAME"].ToString(),
							SegmentCode = reader["CODE"].ToString()
						});
					}
				}
				objConn.Close();
				return networks;
			}
			catch (Exception)
			{
				return networks;
			}
		}
	}
}
