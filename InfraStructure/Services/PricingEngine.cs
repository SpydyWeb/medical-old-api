using System;
using System.Collections.Generic;
using System.Linq;
using CORE.DTOs.PricingEngine;
using CORE.Interfaces;
using CORE.Services;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraStructure.Services
{
	internal class PricingEngine : Svc, IPricingEngine, ISvc
	{
		public PricingEngine(IUnitOfWork unitOfWork, IServiceScopeFactory factory)
			: base(unitOfWork)
		{
		}

		public PricingLOB InsertUpdatePricingLOB(PricingLOB obj)
		{
			PricingLOB obj2 = obj;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (obj2.Id > 0)
					{
						((DbContext)(object)context).Set<PricingLOB>().Update(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
					else
					{
						((DbContext)(object)context).Set<PricingLOB>().Add(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
				}
				catch (Exception)
				{
				}
				return obj2;
			});
		}

		public PricingProducts InsertUpdatePricingProducts(PricingProducts obj)
		{
			PricingProducts obj2 = obj;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (obj2.Id > 0)
					{
						((DbContext)(object)context).Set<PricingProducts>().Update(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
					else
					{
						((DbContext)(object)context).Set<PricingProducts>().Add(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
				}
				catch (Exception)
				{
				}
				return obj2;
			});
		}

		public PricingChannels InsertUpdatePricingChannels(PricingChannels obj)
		{
			PricingChannels obj2 = obj;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (obj2.Id > 0)
					{
						((DbContext)(object)context).Set<PricingChannels>().Update(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
					else
					{
						((DbContext)(object)context).Set<PricingChannels>().Add(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
				}
				catch (Exception)
				{
				}
				return obj2;
			});
		}

		public Factors InsertUpdateFactors(Factors obj)
		{
			Factors obj2 = obj;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (obj2.Id > 0)
					{
						((DbContext)(object)context).Set<Factors>().Update(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
					else
					{
						((DbContext)(object)context).Set<Factors>().Add(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
				}
				catch (Exception)
				{
				}
				return obj2;
			});
		}

		public FactorElements InsertUpdateFactorElements(FactorElements obj)
		{
			FactorElements obj2 = obj;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (obj2.Id > 0)
					{
						((DbContext)(object)context).Set<FactorElements>().Update(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
					else
					{
						((DbContext)(object)context).Set<FactorElements>().Add(obj2);
						((DbContext)(object)context).SaveChanges();
						unitOfWork.SetToBeCommitted();
					}
				}
				catch (Exception)
				{
				}
				return obj2;
			});
		}

		public List<PricingLOB> LoadPricingLOB(int? Id)
		{
			List<PricingLOB> lOBs = new List<PricingLOB>();
			return Action(delegate(DataBaseContext context)
			{
				if (Id.HasValue && Id.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<PricingLOB>()
						where p.Id == ((int?)Id).Value
						select p).ToList();
				}
				else
				{
					lOBs = ((DbContext)(object)context).Set<PricingLOB>().ToList();
				}
				return lOBs;
			});
		}

		public List<PricingProducts> LoadPricingProducts(int? Id, int? LOBId)
		{
			List<PricingProducts> lOBs = new List<PricingProducts>();
			return Action(delegate(DataBaseContext context)
			{
				if (Id.HasValue && Id.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<PricingProducts>()
						where p.Id == ((int?)Id).Value
						select p).ToList();
				}
				else if (LOBId.HasValue && LOBId.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<PricingProducts>()
						where p.LOB == ((int?)LOBId).Value
						select p).ToList();
				}
				else
				{
					lOBs = ((DbContext)(object)context).Set<PricingProducts>().ToList();
				}
				return lOBs;
			});
		}

		public List<PricingChannels> LoadPricingChannels(int? Id, int? LOBId, int? ProductId)
		{
			List<PricingChannels> lOBs = new List<PricingChannels>();
			return Action(delegate(DataBaseContext context)
			{
				if (Id.HasValue && Id.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<PricingChannels>()
						where p.Id == ((int?)Id).Value
						select p).ToList();
				}
				else if (LOBId.HasValue && LOBId.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<PricingChannels>()
						where p.LOB == ((int?)LOBId).Value
						select p).ToList();
				}
				else if (ProductId.HasValue && ProductId.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<PricingChannels>()
						where p.ProductId == ((int?)ProductId).Value
						select p).ToList();
				}
				else
				{
					lOBs = ((DbContext)(object)context).Set<PricingChannels>().ToList();
				}
				return lOBs;
			});
		}

		public List<Factors> LoadFactors(int? Id, int? ChannelId)
		{
			List<Factors> lOBs = new List<Factors>();
			return Action(delegate(DataBaseContext context)
			{
				if (Id.HasValue && Id.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<Factors>()
						where p.Id == ((int?)Id).Value
						select p).ToList();
				}
				else if (ChannelId.HasValue && ChannelId.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<Factors>()
						where p.ChannelId == ((int?)ChannelId).Value
						select p).ToList();
				}
				else
				{
					lOBs = ((DbContext)(object)context).Set<Factors>().ToList();
				}
				return lOBs;
			});
		}

		public List<FactorElements> LoadFactorElements(int? Id, int? FactorId)
		{
			List<FactorElements> lOBs = new List<FactorElements>();
			return Action(delegate(DataBaseContext context)
			{
				if (Id.HasValue && Id.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<FactorElements>()
						where p.Id == ((int?)Id).Value
						select p).ToList();
				}
				else if (FactorId.HasValue && FactorId.Value > 0)
				{
					lOBs = (from p in ((DbContext)(object)context).Set<FactorElements>()
						where p.FactorId == ((int?)FactorId).Value
						select p).ToList();
				}
				else
				{
					lOBs = ((DbContext)(object)context).Set<FactorElements>().ToList();
				}
				return lOBs;
			});
		}
	}
}
