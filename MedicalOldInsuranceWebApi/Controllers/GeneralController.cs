using System.Collections.Generic;
using System.Net.Http;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Setups.MMP;
using CORE.DTOs.Business;
using CORE.Interfaces;
using DataAccessLayer.Oracle.Eskadenia.Motor_Claim_Migration;
using DataAccessLayer.Oracle.Eskadenia.Setups;
using InsuranceAPIs.Models.Configuration_Objects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InsuranceAPIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GeneralController
	{
		private static HttpClient client = new HttpClient();

		private readonly AppSettings _appSettings;

		public static IWebHostEnvironment? _environment;

		private readonly IBusiness _svcBusiness;

		private readonly ITracker _tracker;

		private readonly IMotorClaims _mc;

		public GeneralController(IOptions<AppSettings> appSettings, IBusiness svcBusiness, ITracker tracker, IMotorClaims mc)
		{
			_appSettings = appSettings.Value;
			_svcBusiness = svcBusiness;
			_tracker = tracker;
			_mc = mc;
		}

		[HttpPost]
		[Route("MMPSetup")]
		public MMPSetups LoadMMPSetup([FromBody] string obj)
		{
			MMPSetups mMPSetups = new MMPSetups();
			mMPSetups.ddlLiability = new List<DDL>();
			mMPSetups.ddlLiability = Setup.LoadLoability(_appSettings.EskaConnection, 7006.ToString());
			return mMPSetups;
		}

		[HttpPost]
		[Route("MMPCalculate")]
		public List<CalculateMMPResponse> MMPCalculate([FromBody] List<CalculateMMP> obj)
		{
			List<CalculateMMPResponse> responses = new List<CalculateMMPResponse>();
			obj.ForEach(delegate(CalculateMMP item)
			{
				CalculateMMPResponse calculateMMPResponse = new CalculateMMPResponse();
				calculateMMPResponse.GrossPremium = PricingClass.CalculateMMP(_appSettings.EskaConnection, item.LiabilityId, item.ProffessionId, 7006.ToString(), 6);
				calculateMMPResponse.NationalId = item.NationalId;
				calculateMMPResponse.PolicyPeriod = item.PolicyPeriod;
				calculateMMPResponse.ProffessionId = item.ProffessionId;
				calculateMMPResponse.LiabilityId = item.LiabilityId;
				calculateMMPResponse.CategoryId = item.CategoryId;
				calculateMMPResponse.GrossPremium *= (decimal?)item.PolicyPeriod;
				responses.Add(calculateMMPResponse);
			});
			return responses;
		}

		[HttpPost]
		[Route("GetMMPPrice")]
		public decimal? GetMMPPrice([FromBody] MMPPricing obj)
		{
			return _svcBusiness.GetMMPPrice(obj);
		}
	}
}
