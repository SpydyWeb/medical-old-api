using System;
using CORE.DTOs.Authentications;
using CORE.Interfaces;
using CORE.Services;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraStructure.Services
{
	public class Tracker : Svc, ITracker, ISvc
	{
		public Tracker(IUnitOfWork unitOfWork, IServiceScopeFactory factory)
			: base(unitOfWork)
		{
		}

		public UserAction InsertTracker(UserAction action)
		{
			UserAction action2 = action;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					((DbContext)(object)context).Set<UserAction>().Add(action2);
					((DbContext)(object)context).SaveChanges();
					unitOfWork.SetToBeCommitted();
					return action2;
				}
				catch (Exception)
				{
					return action2;
				}
			});
		}
	}
}
