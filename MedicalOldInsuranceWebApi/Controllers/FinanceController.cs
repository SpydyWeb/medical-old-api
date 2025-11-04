using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.Business;
using CORE.Interfaces;
using InsuranceAPIs.Models.Configuration_Objects;
using MicroAPIs.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InsuranceAPIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FinanceController : ControllerBase
	{
		private static HttpClient client = new HttpClient();

		private readonly AppSettings _appSettings;

		public static IWebHostEnvironment? _environment;

		private readonly ITracker _tracker;

		private readonly IFinance _Finance;

		private readonly IBusiness _Business;

		public FinanceController(IOptions<AppSettings> appSettings, IWebHostEnvironment environment, ITracker tracker, IFinance finance, IBusiness business)
		{
			_environment = environment;
			_appSettings = appSettings.Value;
			_tracker = tracker;
			_Finance = finance;
			_Business = business;
		}

		[HttpPost]
		[Route("InsertUpdateCreditLimit")]
		public CreditLimitOutput InsertUpdateCreditLimit([FromBody] CreditLimits creditLimits)
		{
			CreditLimitOutput creditLimitOutput = new CreditLimitOutput();
			creditLimitOutput.creditLimits = _Finance.InsertUpdateCreditLimit(creditLimits);
			CreditLimitHistory creditLimitHistory = new CreditLimitHistory();
			creditLimitHistory.ExtendLimit = creditLimits.ExtendLimit;
			creditLimitHistory.CreditLimit = creditLimits.CreditLimit;
			creditLimitHistory.CreditLimitID = creditLimits.Id;
			creditLimitHistory.FinanceId = creditLimits.FinanceUserId;
			creditLimitHistory.EskaId = creditLimits.EskaId;
			creditLimitHistory.Balance = creditLimits.Balance;
			creditLimitHistory.LastPaymentDate = creditLimits.LastPaymentDate;
			_Finance.InsertCreditLimitHistory(creditLimitHistory);
			if (creditLimitOutput.creditLimits.Id > 0)
			{
				creditLimitOutput.ResponseDate = DateTime.Now;
				creditLimitOutput.status = true;
				creditLimitOutput.httpStatusCode = HttpStatusCode.OK;
				creditLimitOutput.message = "";
			}
			else
			{
				creditLimitOutput.ResponseDate = DateTime.Now;
				creditLimitOutput.status = false;
				creditLimitOutput.httpStatusCode = HttpStatusCode.InternalServerError;
				creditLimitOutput.message = "Error Wile insert or update Credit Limit";
			}
			return creditLimitOutput;
		}

		[HttpPost]
		[Route("LoadCreditLimit")]
		public CreditLimitOutput LoadCreditLimit([FromBody] LoadCreditLimitInput loadCreditLimitInput)
		{
			CreditLimitOutput creditLimitOutput = new CreditLimitOutput();
			creditLimitOutput.creditLimits = new CreditLimits();
			if (loadCreditLimitInput.Id.HasValue && loadCreditLimitInput.Id.Value > 0)
			{
				creditLimitOutput.creditLimits = _Finance.LoadCreditLimit(0L, loadCreditLimitInput.Id);
			}
			else if (loadCreditLimitInput.EskaId.HasValue && loadCreditLimitInput.EskaId.Value > 0)
			{
				creditLimitOutput.creditLimits = _Finance.LoadCreditLimit(loadCreditLimitInput.EskaId.Value);
			}
			else
			{
				creditLimitOutput.creditLimits = _Finance.LoadCreditLimit(0L, null, loadCreditLimitInput.UserId.Value);
			}
			if (creditLimitOutput.creditLimits != null && creditLimitOutput.creditLimits.Id > 0)
			{
				creditLimitOutput.ResponseDate = DateTime.Now;
				creditLimitOutput.status = true;
				creditLimitOutput.httpStatusCode = HttpStatusCode.OK;
				creditLimitOutput.message = "";
			}
			else
			{
				creditLimitOutput.ResponseDate = DateTime.Now;
				creditLimitOutput.status = false;
				creditLimitOutput.httpStatusCode = HttpStatusCode.InternalServerError;
				creditLimitOutput.message = "Error While Loading Credit Limit";
			}
			return creditLimitOutput;
		}

		[HttpPost]
		[Route("LoadAllCreditLimits")]
		public LoadCreditLimitOutput LoadAllCreditLimits()
		{
			LoadCreditLimitOutput creditLimitOutput = new LoadCreditLimitOutput();
			List<CreditLimits> lsCredit = new List<CreditLimits>();
			lsCredit = _Finance.LoadAllCreditLimit();
			creditLimitOutput.lcreditLimits.AddRange(lsCredit);
			creditLimitOutput.ResponseDate = DateTime.Now;
			creditLimitOutput.status = true;
			creditLimitOutput.httpStatusCode = HttpStatusCode.OK;
			creditLimitOutput.message = "";
			return creditLimitOutput;
		}

		[HttpGet]
		[Route("FilterCreditLimit")]
		public LoadCreditLimitOutput FilterCreditLimit([FromQuery] string obj)
		{
			LoadCreditLimitOutput creditLimitOutput = new LoadCreditLimitOutput();
			creditLimitOutput.lcreditLimits = new List<CreditLimits>
			{
				new CreditLimits()
			};
			LoadCreditLimitInput loadCreditLimitInput = new LoadCreditLimitInput();
			loadCreditLimitInput = JsonConvert.DeserializeObject<LoadCreditLimitInput>(Utilities.Decryption(obj, _appSettings.BCKey, _appSettings.BCIV));
			creditLimitOutput.lcreditLimits = (from x in _Finance.LoadAllCreditLimit()
				where (loadCreditLimitInput.UserId == 0) ? (x.UserId == x.UserId) : (x.UserId == loadCreditLimitInput.UserId)
				select x).ToList();
			if (creditLimitOutput.lcreditLimits != null && creditLimitOutput.lcreditLimits.Count > 0)
			{
				creditLimitOutput.ResponseDate = DateTime.Now;
				creditLimitOutput.status = true;
				creditLimitOutput.httpStatusCode = HttpStatusCode.OK;
				creditLimitOutput.message = "";
			}
			else
			{
				creditLimitOutput.ResponseDate = DateTime.Now;
				creditLimitOutput.status = false;
				creditLimitOutput.httpStatusCode = HttpStatusCode.InternalServerError;
				creditLimitOutput.message = "Error While Loading Credit Limit";
			}
			return creditLimitOutput;
		}

		[HttpGet]
		[Route("LoadCreditLimitHistory")]
		public CreditLimitHistoryOutput LoadCreditLimitHistory([FromQuery] string Obj)
		{
			CreditLimitHistoryOutput creditLimitOutput = new CreditLimitHistoryOutput();
			creditLimitOutput.creditLimitHistories = new List<CreditLimitHistory>();
			LoadCreditHistoryInput loadCreditLimitInput = new LoadCreditHistoryInput();
			loadCreditLimitInput = JsonConvert.DeserializeObject<LoadCreditHistoryInput>(Obj);
			creditLimitOutput.creditLimitHistories.AddRange(_Finance.LoadCreditLimitHistory(loadCreditLimitInput.CreditId));
			if (creditLimitOutput.creditLimitHistories.Count > 0)
			{
				creditLimitOutput.ResponseDate = DateTime.Now;
				creditLimitOutput.status = true;
				creditLimitOutput.httpStatusCode = HttpStatusCode.OK;
				creditLimitOutput.message = "";
			}
			else
			{
				creditLimitOutput.ResponseDate = DateTime.Now;
				creditLimitOutput.status = false;
				creditLimitOutput.httpStatusCode = HttpStatusCode.InternalServerError;
				creditLimitOutput.message = "Error While Loading Credit Limit";
			}
			return creditLimitOutput;
		}
	}
}
