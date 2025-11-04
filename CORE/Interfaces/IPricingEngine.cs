using System.Collections.Generic;
using CORE.DTOs.PricingEngine;
using CORE.Services;

namespace CORE.Interfaces
{
	public interface IPricingEngine : ISvc
	{
		PricingLOB InsertUpdatePricingLOB(PricingLOB obj);

		PricingProducts InsertUpdatePricingProducts(PricingProducts obj);

		PricingChannels InsertUpdatePricingChannels(PricingChannels obj);

		Factors InsertUpdateFactors(Factors obj);

		FactorElements InsertUpdateFactorElements(FactorElements obj);

		List<PricingLOB> LoadPricingLOB(int? Id);

		List<PricingProducts> LoadPricingProducts(int? Id, int? LOBId);

		List<PricingChannels> LoadPricingChannels(int? Id, int? LOBId, int? ProductId);

		List<Factors> LoadFactors(int? Id, int? ChannelId);

		List<FactorElements> LoadFactorElements(int? Id, int? FactorId);
	}
}
