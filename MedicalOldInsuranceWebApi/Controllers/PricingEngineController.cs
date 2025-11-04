using System.Net.Http;
using CORE.Interfaces;
using InsuranceAPIs.Models.Configuration_Objects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InsuranceAPIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PricingEngineController : ControllerBase
	{
		private static HttpClient client = new HttpClient();

		private readonly AppSettings _appSettings;

		public static IWebHostEnvironment? _environment;

		private readonly IBusiness _svcBusiness;

		private readonly ITracker _tracker;

		private readonly IProcess _process;

		public PricingEngineController(IOptions<AppSettings> appSettings, IWebHostEnvironment environment, IBusiness svcBus, ITracker tracker, IProcess process)
		{
			_environment = environment;
			_appSettings = appSettings.Value;
			_svcBusiness = svcBus;
			_tracker = tracker;
			_process = process;
		}
	}
}
