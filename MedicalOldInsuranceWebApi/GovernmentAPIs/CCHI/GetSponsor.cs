using System.Net;
using CORE.DTOs.APIs.Business;
using ServiceReference1;

namespace InsuranceAPIs.GovernmentAPIs.CCHI
{
	public static class GetSponsor
	{
		public static async Task<SponsorV3> GetSponsorV3(string CR, string CCHIKey)
		{
			SponsorV3 sponsorV3 = new SponsorV3();
			MOCServiceClient serviceClient1 = new MOCServiceClient(MOCServiceClient.EndpointConfiguration.BasicHttpBinding_IMOCService1);
			HRSDResponse sponsorDetails1 = new HRSDResponse();	
			GetSponsorsDetailsV3Request getSponsorsDetailsV3Request = new GetSponsorsDetailsV3Request();
			GetSponsorsDetailsV3Response getSponsorsDetailsV3Response = new GetSponsorsDetailsV3Response();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            getSponsorsDetailsV3Request.SponsorNumber = CR;
			getSponsorsDetailsV3Request.CompanyNumber = "131";
			getSponsorsDetailsV3Request.AccessKey = CCHIKey;
            getSponsorsDetailsV3Response = await serviceClient1.GetSponsorsDetailsV3Async(getSponsorsDetailsV3Request);
			sponsorDetails1 = getSponsorsDetailsV3Response.GetSponsorsDetailsV3Result;
            if (sponsorDetails1 != null)
			{
				sponsorV3.RemainingDependent = sponsorDetails1.Remaining_Dependents;
				sponsorV3.RemainingMain = sponsorDetails1.Remaining_Main;
				sponsorV3.RequiredMain = sponsorDetails1.Required_Main;
				sponsorV3.RequiredDependent = sponsorDetails1.Required_Dependents;
				return sponsorV3;
			}
			return null;
		}
	}
}
