using System;
using System.Collections.Generic;
using System.Linq;
using CORE.DTOs.Business;
using CORE.Interfaces;
using CORE.Services;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraStructure.Services
{
	public class Finance : Svc, IFinance, ISvc
	{
		public Finance(IUnitOfWork unitOfWork, IServiceScopeFactory factory)
			: base(unitOfWork)
		{
		}

		public CreditLimits InsertUpdateCreditLimit(CreditLimits creditLimit)
		{
			CreditLimits creditLimit2 = creditLimit;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (creditLimit2.Id > 0)
					{
						((DbContext)(object)context).Set<CreditLimits>().Update(creditLimit2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<CreditLimits>().Add(creditLimit2);
						((DbContext)(object)context).SaveChanges();
					}
					return creditLimit2;
				}
				catch (Exception)
				{
					return (CreditLimits)null;
				}
			});
		}

		public CreditLimits LoadCreditLimit(long EskaUserId, int? Id = null, int? UserId = null)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					return (Id.HasValue && Id.Value > 0) ? (from p in ((DbContext)(object)context).Set<CreditLimits>()
						where p.Id == ((int?)Id).Value
						select p).FirstOrDefault() : ((UserId.HasValue && UserId.Value > 0) ? (from p in ((DbContext)(object)context).Set<CreditLimits>()
						where p.UserId == ((int?)UserId).Value
						select p).FirstOrDefault() : (from p in ((DbContext)(object)context).Set<CreditLimits>()
						where p.EskaId == EskaUserId
						select p).FirstOrDefault());
				}
				catch (Exception)
				{
					return (CreditLimits)null;
				}
			});
		}

		public List<CreditLimits> LoadAllCreditLimit()
		{
			return Action(delegate(DataBaseContext context)
			{
				List<CreditLimits> list = new List<CreditLimits>();
				try
				{
					return ((DbContext)(object)context).Set<CreditLimits>().ToList();
				}
				catch (Exception)
				{
					return (List<CreditLimits>)null;
				}
			});
		}

		public List<CreditLimitHistory> LoadCreditLimitHistory(int CreditLimitId)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					return (from p in ((DbContext)(object)context).Set<CreditLimitHistory>()
						where p.CreditLimitID == CreditLimitId
						orderby p.Id descending
						select p).ToList();
				}
				catch (Exception)
				{
					return (List<CreditLimitHistory>)null;
				}
			});
		}

		public CreditLimitHistory InsertCreditLimitHistory(CreditLimitHistory creditLimitHistory)
		{
			CreditLimitHistory creditLimitHistory2 = creditLimitHistory;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (creditLimitHistory2.Id > 0)
					{
						((DbContext)(object)context).Set<CreditLimitHistory>().Update(creditLimitHistory2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<CreditLimitHistory>().Add(creditLimitHistory2);
						((DbContext)(object)context).SaveChanges();
					}
					return creditLimitHistory2;
				}
				catch (Exception)
				{
					return (CreditLimitHistory)null;
				}
			});
		}
	}
}
